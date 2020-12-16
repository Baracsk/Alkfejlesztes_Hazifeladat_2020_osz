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

namespace RobotDiagnosticApp.Classes 
{
    //A communication Interface that has all the communication variables and is connected to the View
    public class CommunicationInterface
    {
        //The classes that have 
        public DrivingInterfaceVM DrivingInterface;
        public MiniMapVM MiniMap;
        public SteeringWheelVM SteeringWheel;

        //Variables for the communication
        private Timer timer;

        //recieved
        private double recvX;
        private double recvY;
        private int recvOrientation;

        //sent
        private int sentSpeed;
        private int sentSteeringWheelAngle;
        private bool sentisReverse;
        private bool sentIsReset = false;
        private bool sentIsSelfTest = false;

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


        public ICommand StartButtonClicked
        {
            get
            {
                return new DelegateCommand(Start);
            }
        }

        public CommunicationInterface()
        {
            DrivingInterface = new DrivingInterfaceVM();
            MiniMap = new MiniMapVM();
            SteeringWheel = new SteeringWheelVM();

            recvX = 0;
            recvY = 0;
            recvOrientation = 0;

            timer = new Timer(Constants.SYSTEM_TICK_MS);
            timer.Elapsed += Timer_Elapsed;

        }

        public void Start()
        {
            timer.Start();
        }

        
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Move();
            UpdateCommunicatinData();
        }

        public void Reset()
        {
            DrivingInterface.Reset();
            SteeringWheel.Reset();
            MiniMap.Reset();
            sentIsReset = true;

            timer.Stop();

            recvX = 0;
            recvY = 0;
            recvOrientation = 0;
        }
        public void Test()
        {
            setNewParameters(0.10, 0.0, 20);
            sentIsSelfTest = true;
        }
        private async Task UpdateCommunicatinData()
        {
            //writing the senable parameters of the class
            sentSpeed = getSpeed();
            sentSteeringWheelAngle = getSteewingWheelAngle();
            sentisReverse = isGearBoxInReverse();

            //TODO COMMUNICATE

            //write back the recieved parameters
            var dispatcher = CoreApplication.MainView.CoreWindow.Dispatcher;
            await dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => 
            { 
                setNewParameters(recvX, recvY, recvOrientation); 
            });
            
        }

        //*************FOR COMMUNICATION*******************

        //TO SEND
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

        private void Move()
        {
            recvOrientation += sentSteeringWheelAngle / 15;
            recvX += (sentSpeed * Math.Sin(recvOrientation * Math.PI / 180))*0.1;
            recvY += (sentSpeed * Math.Cos(recvOrientation * Math.PI / 180))*0.1;
        }
    }
}
