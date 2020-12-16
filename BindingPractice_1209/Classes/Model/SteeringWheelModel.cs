using RobotDiagnosticApp.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotDiagnosticApp.Classes.Model
{
    //this model class has the value of the SteewingWheel andle
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
    }
}
