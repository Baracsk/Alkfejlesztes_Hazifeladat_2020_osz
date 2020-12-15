using RobotInterfaceApp.Classes.ViewModel;
using RobotDiagnosticApp.Classes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagnosticApp.Classes
{
    public class RobotModel : IRobotModel
    {
        //variables for the parameter text on the screen
        public double Speed 
        { 
            get => textVM.Speed; 
            set { textVM.Speed = value; } 
        } 
        public double[] Coord 
        {
            get => textVM.Coord; 
            set 
            { 
                textVM.Coord = value;
                mapVM.Coord = value;
            } 
        }

        //variables for the steeringwheel and the gearshift
        public double SteeringWheelAngle
        {
            get { return interfaceVM.SteeringWheelAngle; }
            set 
            {
                interfaceVM.SteeringWheelAngle = value;
            }
        }
        public bool GearShiftInReverse 
        {
            get { return interfaceVM.GearShiftInReverse; }
            set
            {
                interfaceVM.GearShiftInReverse = value;
            }
        }
        
        //variables for the minimap
        public double Orientation 
        {
            get { return Orientation; }
            set
            {
                mapVM.Orientation = (int)value;
            }
        }

        private RobotCommumicationInterfaceModel communicationInterface;

        public ParameterTextVM textVM;
        public DrivingInterfaceVM interfaceVM;
        public MiniMapVM mapVM;

        public RobotModel(double speedPercentage = 0, double X = 0, double Y = 0, int steeringWheelAngle = 0, int orientation = 0)
        {
            textVM = new ParameterTextVM();
            interfaceVM = new DrivingInterfaceVM();
            mapVM = new MiniMapVM();
            communicationInterface = new RobotCommumicationInterfaceModel();

            //checking if speed value is between the limits
            if (speedPercentage >= 0 && speedPercentage <= 100)
            {
                textVM.Speed = speedPercentage;
            }
            else
            {
                throw new ArgumentException("speeding value should be between 0 and 100");
            }

            Coord = new double[] { X, Y };
            this.Orientation = orientation;
        }

        //resetting all the values
        public void Reset()
        {
            Speed = 0;
            Coord[0] = 0;
            Coord[1] = 0;
            SteeringWheelAngle = 0;
            Orientation = 0;
            GearShiftInReverse = false;
        }

        //increasing the speed
        public void Accelerate()
        {
            if ((Speed += Constants.SPEED_CHANGE_SCALE) < 100) { }
            else Speed = 100;
        }

        //decreasing the speed
        public void Brake()
        {
            if ((Speed -= Constants.SPEED_CHANGE_SCALE) > 0) { }
            else Speed = 0;
        }

        //Immediate stopping of the robot
        public void E_Stop()
        {
            Speed = 0;
        }

        //Turning the steering wheel
        public void changeSteeringWheelAngle(double Angle)
        {
            SteeringWheelAngle = Angle;
        }

        //Changing the gearshift to reverse mode
        public void IsReverse(bool reverse)
        {
            this.GearShiftInReverse = reverse;
        }
    }
}
