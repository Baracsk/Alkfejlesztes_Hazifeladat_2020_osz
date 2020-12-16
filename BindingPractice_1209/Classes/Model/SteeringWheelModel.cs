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
        public int SteeringWheelAngle
        {
            get { return SteeringWheelAngle; }
            set { SteeringWheelAngle = value; }
        }

        public SteeringWheelModel(int SteeringWheelAngle = 0)
        {
            this.SteeringWheelAngle = SteeringWheelAngle;
        }

        public void SteerLeft()
        {
            if ((SteeringWheelAngle += Constants.STEER_CHANGE_SCALE) <= 90) { }
            else SteeringWheelAngle = 90;
        }
        public void SteerRight()
        {
            if ((SteeringWheelAngle -= Constants.STEER_CHANGE_SCALE) >= -90) { }
            else SteeringWheelAngle = -90;
        }
    }
}
