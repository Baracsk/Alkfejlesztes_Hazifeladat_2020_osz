using RobotDiagnosticApp.Classes.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Core;
using Windows.ApplicationModel.Core;
using System.Diagnostics;
using BindingPractice_1209;
using System.Threading;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace RobotDiagnosticApp.Classes 
{
    //A communication Interface that has all the communication variables and is connected to the View
    public class CommunicationInterface
    {
        //The classes that have 
        public DrivingInterfaceVM DrivingInterface;
        public MiniMapVM MiniMap;
        public SteeringWheelVM SteeringWheel;
        // TODO: make a communication interface class

        //Variables for the communication
        private System.Timers.Timer timer;

        //recieved (POST)
        private double recvX;
        private double recvY;
        private int recvOrientation;
 
        //sent (GET)
        private int sentSpeed;
        private int sentSteeringWheelAngle;
        private bool sentisReverse;
        private bool sentIsReset = false;
        private bool sentIsSelfTest = false;

        //Server-side communication parameters
        private RecvData recvData;
        private SendData sendData;

        private const string URI = "http://localhost:8000/data";
        private Thread lThread;
        private static HttpListener listener;


        public ICommand TestButtonClicked
        {
            get
            {
                return new DelegateCommand(Test);
            }
        }
        public ICommand ResetButtonClicked
        {
            get
            {
                return new DelegateCommand(Reset);
            }
        }
        public ICommand ConnectButtonClicked
        {
            get
            {
                return new DelegateCommand(Connect);
            }
        }


        //TODO assign the communication class here
        public CommunicationInterface()
        {
            DrivingInterface = new DrivingInterfaceVM();
            MiniMap = new MiniMapVM();
            SteeringWheel = new SteeringWheelVM();

            recvX = 0;
            recvY = 0;
            recvOrientation = 0;

            timer = new System.Timers.Timer(Constants.SYSTEM_TICK_MS);
            timer.Elapsed += Timer_Elapsed;

            //Comm. parameters
            recvData = new RecvData(); //Data to Get (answer to POST)
            sendData = new SendData(); //Data to Send (answer to GET) 

            listener = new HttpListener();
            listener.Prefixes.Add(URI);
            listener.Start();

            lThread = new Thread(new ThreadStart(listenThread));
            lThread.Start();
        }

        //starts the timer
        //TODO: if you want any actions when the timer starts write here (e.g. starting the connection)
        public void Connect()
        {
            timer.Start();
        }

        //updates the interface
        //TODO: if you want anything to run continuously, call its function here
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            UpdateCommunicatinData();
            //***********************MOVE IS FOR TEST ONLY**********************
            Move();
            
        }

        //resets everything to default and stops the timer (connection breaks!
        public void Reset()
        {
            DrivingInterface.Reset();
            MiniMap.Reset();

            SteeringWheel.Reset();
            sentIsReset = true;

            timer.Stop();

            recvX = 0;
            recvY = 0;
            recvOrientation = 0;
        }

        //if car did not move yet, it makes a test
        public void Test()
        {
            if (recvX == 0 && recvY ==0 && sentSpeed ==0 && recvOrientation ==0)
            {
                sentIsSelfTest = true;
            }
        }

        //functions for updating the communication data
        //gives back the current angle from the steering wheel in interval [-90, 90]
        private int getSteewingWheelAngle()
        {
            return SteeringWheel.Angle;
        }
        //TRUE = have to go reverse
        private bool isGearBoxInReverse()
        {
            return DrivingInterface.GearShiftInReverse;
        }
        //get the value of current desired speed in interval [0..100]
        private int getSpeed()
        {
            return DrivingInterface.Speed;
        }

        //TO RECIEVE
        //Sets the displayed parameters to the recieved values
        private void setNewParameters(double X, double Y, int orientation)
        {
            MiniMap.UpdatePositionParameters(recvX, Y, orientation);
        }

        //gets all the sendable data from the interface and updates interface with the arriving data when the timer elapses
        private async Task UpdateCommunicatinData()
        {
            //writing the senable parameters of the class
            sentSpeed = getSpeed();
            sentSteeringWheelAngle = getSteewingWheelAngle();
            sentisReverse = isGearBoxInReverse();

            //write back the recieved parameters on UI thread
            var dispatcher = CoreApplication.MainView.CoreWindow.Dispatcher;
            await dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => 
            { 
                setNewParameters(recvX, recvY, recvOrientation); 
            });
        }

        //**************TODO*********************
        //write functions for the communication class
        public async void listenThread()
        {
            while (listener.IsListening)
            {
                var context = await listener.GetContextAsync();
                try
                {
                    await HandlerMethodAsync(context);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }

            }

            listener.Close();
        }

        private async Task HandlerMethodAsync(HttpListenerContext ctx)
        {
            HttpListenerRequest req = ctx.Request;
            HttpListenerResponse resp = ctx.Response;

            //Console.WriteLine($"URL: {req.Url} \t{req.HttpMethod}");

            if (req.Url.ToString().Equals(""))
            {
                if (req.HttpMethod.Equals("POST"))
                    await HandleDataPostAsync(req, resp);
                else if (req.HttpMethod.Equals("GET"))
                    await HandleDataGet(req, resp);
            }

        }
        private async Task<string> GetStringContentAsync(HttpListenerRequest req)
        {
            string result = "";
            using (var bodyStream = req.InputStream)
            {
                var encoding = req.ContentEncoding;
                using (var streamReader = new StreamReader(bodyStream, encoding))
                {
                    result = await streamReader.ReadToEndAsync();
                }
            }
            return result;
        }

        private async Task BuildResponse(HttpListenerResponse resp, Encoding encoding, string content)
        {
            resp.StatusCode = 200;
            byte[] buffer = encoding.GetBytes(content);
            resp.ContentLength64 = buffer.Length;

            await resp.OutputStream.WriteAsync(buffer, 0, buffer.Length);
            resp.OutputStream.Close();
        }


        private async Task HandleDataPostAsync(HttpListenerRequest req, HttpListenerResponse resp)
        {
            string reqcontent = await GetStringContentAsync(req);

            JObject json = JObject.Parse(reqcontent);
            recvData = json.ToObject<RecvData>();

            recvX = recvData.recvX;
            recvY = recvData.recvY;
            recvOrientation = (int)recvData.recvOrientation;

            await BuildResponse(resp, req.ContentEncoding, json.ToString());
        }

        private async Task HandleDataGet(HttpListenerRequest req, HttpListenerResponse resp)
        {
            sendData.sentSpeed = sentSpeed;
            sendData.sentSteeringWheelAngle = sentSteeringWheelAngle;
            sendData.sentisReverse = sentisReverse;
            sendData.sentisReverse = sentisReverse;
            sendData.sentIsSelfTest = sentIsSelfTest;

            string jsonString = JsonConvert.SerializeObject(sendData);

            await BuildResponse(resp, req.ContentEncoding, jsonString);
        }

        //**********************FOR TEST ONLY*************************************** 
        private async Task Move()
        {
            if (sentIsSelfTest)
            {
                sentSpeed = 50;
                sentSteeringWheelAngle = 90;
            }
            if( sentIsSelfTest && Math.Abs(recvOrientation - 360) < 5 )
            {
                sentIsSelfTest = false;
                Debug.WriteLine("Test Ok");

                var dispatcher = CoreApplication.MainView.CoreWindow.Dispatcher;
                await dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    Reset();
                });
            }

            //This code should be on the robot program
            int sign = (sentisReverse) ? -1 : 1;
            recvOrientation += sentSteeringWheelAngle * sentSpeed / 1000;

            recvX += sign * (sentSpeed * Math.Sin(recvOrientation * Math.PI / 180)) * 0.02;
            recvY += sign * (sentSpeed * Math.Cos(recvOrientation * Math.PI / 180)) * 0.02;
            
        }
    }
}
