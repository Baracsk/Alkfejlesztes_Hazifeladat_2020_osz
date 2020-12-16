using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RobotDiagnosticApp.Classes.Model
{
    class DrivingInterfaceModel : ObservableObject
    {
        public bool GearShiftInReverse
        {
            get { return GearShiftInReverse; }
            set
            {
                GearShiftInReverse = value;
                RaisePropertyChangedEvent("GearShiftInReverse");
            }
        }
        public int Speed 
        { 
            get { return Speed; } 
            set
            {
                Speed = value;
            }
        }

        public DrivingInterfaceModel(bool GearShiftInReverse = false, int Speed = 0)
        {
            this.GearShiftInReverse = GearShiftInReverse;
            this.Speed = Speed;
        }

        public void Accelerate()
        {
            if ((Speed += Constants.SPEED_CHANGE_SCALE) <= 100) { }
            else Speed = 100;
        }
        public void Brake()
        {
            if ((Speed -= Constants.SPEED_CHANGE_SCALE) >= 0) { }
            else Speed = 0;
        }
        public void EStop()
        {
            Speed = 0;
        }
    }
}
