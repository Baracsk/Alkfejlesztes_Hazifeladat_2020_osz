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

        private double steeringWheelAngle;
        private bool isReverse;

        private RobotCommumicationInterfaceModel communicationInterface;

        public RobotModel(double speedPercentage = 0, double X = 0, double Y = 0, int steeringWheelAngle = 0)
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
            this.steeringWheelAngle = steeringWheelAngle;

            this.isReverse = false;

            communicationInterface = new RobotCommumicationInterfaceModel();
        }

        //resetting all the values
        public void Reset()
        {
            SpeedPercentage = 0;
            Coord[indexX] = 0;
            Coord[indexY] = 0;
            steeringWheelAngle = 0;
            isReverse = false;
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
            steeringWheelAngle = Angle;
        }

        //Changing the gearshift to reverse mode
        public void IsReverse(bool reverse)
        {
            this.isReverse = reverse;
        }
    }
}
