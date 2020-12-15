using RobotDiagnosticApp.Classes.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotInterfaceApp.Classes.ViewModel
{
    public class DrivingInterfaceVM
    {

        public double SteeringWheelAngle
        {
            get { return View.SteeringWheelAngle; }
            set
            {
                View.SteeringWheelAngle = value;
            }
        }

        public bool GearShiftInReverse
        {
            get { return View.GearShiftInReverse; }
            set
            {
                View.GearShiftInReverse = value;
            }
        }

        public DrivingInterfaceView View;

        public DrivingInterfaceVM(double SteeringWheelAngle = 0, bool GearShiftInReverse = false)
        {
            View = new DrivingInterfaceView((int)SteeringWheelAngle, GearShiftInReverse);
        }

    }
}
