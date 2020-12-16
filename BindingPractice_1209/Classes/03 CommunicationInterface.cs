using RobotDiagnosticApp.Classes.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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


        public CommunicationInterface()
        {
            DrivingInterface = new DrivingInterfaceVM();
            MiniMap = new MiniMapVM();
            SteeringWheel = new SteeringWheelVM();
            
        }

        public void Reset()
        {
            DrivingInterface.Reset();
            SteeringWheel.Reset();
        }
        public void Test()
        {
            setNewParameters(0.10, 0.0, 20);
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
