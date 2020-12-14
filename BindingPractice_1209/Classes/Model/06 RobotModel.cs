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
        //indeces for the position array
        private const int indexX = 0;
        private const int indexY = 0;

        public double SpeedPercentage { get; set; } 
        public double[] Coord { get; set; }

        public double SteeringWheelAngle { get; set; }
        public int Orientation { get; set; }
        public bool Reverse { get; set; }

        private RobotCommumicationInterfaceModel communicationInterface;

        public RobotModel(double speedPercentage = 0, double X = 0, double Y = 0, int steeringWheelAngle = 0, int orientation = 0)
        {
            if (speedPercentage >= 0 && speedPercentage <= 100)
            {
                this.SpeedPercentage = speedPercentage;
            }
            else
            {
                throw new ArgumentException("speeding value should be between 0 and 100");
            }

            Coord = new double[] { X, Y };
            this.SteeringWheelAngle = steeringWheelAngle;

            this.Reverse = false;
            this.Orientation = orientation;

            communicationInterface = new RobotCommumicationInterfaceModel();
        }

        //resetting all the values
        public void Reset()
        {
            SpeedPercentage = 0;
            Coord[indexX] = 0;
            Coord[indexY] = 0;
            SteeringWheelAngle = 0;
            Reverse = false;
        }

        //increasing the speed
        public void Accelerate()
        {
            if ((SpeedPercentage += Constants.SPEED_CHANGE_SCALE) < 100) { }
            else SpeedPercentage = 100;
        }

        //decreasing the speed
        public void Brake()
        {
            if ((SpeedPercentage -= Constants.SPEED_CHANGE_SCALE) > 0) { }
            else SpeedPercentage = 0;
        }

        //Immediate stopping of the robot
        public void E_Stop()
        {
            SpeedPercentage = 0;
        }

        //Turning the steering wheel
        public void changeSteeringWheelAngle(double Angle)
        {
            SteeringWheelAngle = Angle;
        }

        //Changing the gearshift to reverse mode
        public void IsReverse(bool reverse)
        {
            this.Reverse = reverse;
        }
    }
}
