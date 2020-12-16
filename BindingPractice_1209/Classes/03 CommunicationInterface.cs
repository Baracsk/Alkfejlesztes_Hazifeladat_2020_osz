using RobotDiagnosticApp.Classes.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using System.Windows.Input;

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
            //timer.Elapsed += Timer_Elapsed;

        }

        public void Start()
        {
            timer.Start();
        }

        /*
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Invoke(new Action(() => { UpdateCommunicatinData(); }));
            recvX += 10;
            UpdateCommunicatinData();
        }*/

        public void Reset()
        {
            DrivingInterface.Reset();
            SteeringWheel.Reset();
            MiniMap.Reset();
            sentIsReset = true;
        }
        public void Test()
        {
            setNewParameters(0.10, 0.0, 20);
            sentIsSelfTest = true;
        }
        private void UpdateCommunicatinData()
        {
            //writing the senable parameters of the class
            sentSpeed = getSpeed();
            sentSteeringWheelAngle = getSteewingWheelAngle();
            sentisReverse = isGearBoxInReverse();

            //TODO COMMUNICATE

            //write back the recieved parameters
            
            setNewParameters(recvX, recvY, recvOrientation);
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
            MiniMap.UpdatePositionParameters(X, Y, orientation);
        }
    }
}
