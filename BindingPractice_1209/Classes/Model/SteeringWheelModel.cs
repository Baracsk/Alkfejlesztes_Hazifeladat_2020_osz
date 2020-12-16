using RobotDiagnosticApp.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotDiagnosticApp.Classes.Model
{
    public class SteeringWheelModel : ObservableObject
    {
        private int _angle;
        public int Angle
        {
            get => _angle;
            set
            {
                _angle = value;
                Notify();
            }
        }

        public SteeringWheelModel(int SteeringWheelAngle = 0)
        {
            this.Angle = SteeringWheelAngle;
        }

        public void SteerRight()
        {
            if ((Angle += Constants.STEER_CHANGE_SCALE) <= 90) { }
            else Angle = 90;
        }
        public void SteerLeft()
        {
            if ((Angle -= Constants.STEER_CHANGE_SCALE) >= -90) { }
            else Angle = -90;
        }
    }
}
