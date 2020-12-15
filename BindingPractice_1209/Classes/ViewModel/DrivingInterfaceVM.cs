using RobotDiagnosticApp.Classes;
using RobotDiagnosticApp.Classes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotDiagnosticApp.Classes.ViewModel
{
    public class DrivingInterfaceVM : ObservableObject
    {
        DrivingInterfaceModel Model;

        public double SteeringWheelAngle
        {
            get { return SteeringWheelAngle; }
            set
            {
                SteeringWheelAngle = value;
                RaisePropertyChangedEvent("SteeringWheelAngle");
            }
        }

        public bool GearShiftInReverse
        {
            get { return GearShiftInReverse; }
            set
            {
                GearShiftInReverse = value;
                RaisePropertyChangedEvent("GearShiftInReverse");
            }
        }


        public DrivingInterfaceVM(double SteeringWheelAngle = 0, bool GearShiftInReverse = false)
        {
            Model = new DrivingInterfaceModel();

            this.SteeringWheelAngle = SteeringWheelAngle;
            this.GearShiftInReverse = GearShiftInReverse;
        }

    }
}
