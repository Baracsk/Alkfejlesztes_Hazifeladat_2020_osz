using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagnosticApp.Classes
{
    public class RobotModel : IRobotModel
    {
        private const int indexX = 0;
        private const int indexY = 0;

        public double SpeedPercentage { get; set; }
        public double[] Coord { get; }
        private double steeringWheelAngle;

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
        }

        public void Reset()
        {
            SpeedPercentage = 0;
            Coord[indexX] = 0;
            Coord[indexY] = 0;
            steeringWheelAngle = 0;
        }

        public void Accelerate()
        {
            if ((SpeedPercentage += Constants.SPEED_CHANGE_SCALE) < 100) { }
        }

        public void Brake()
        {
            if ((SpeedPercentage -= Constants.SPEED_CHANGE_SCALE) > 0) { }
        }

        public void changeSteeringWheelAngle(double Angle)
        {
            steeringWheelAngle = Angle;
        }


    }
}
