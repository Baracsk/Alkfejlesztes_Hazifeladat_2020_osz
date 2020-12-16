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
        private bool _gearShiftInReverse;
        private int _speed;

        public bool GearShiftInReverse
        {
            get => _gearShiftInReverse;
            set
            {
                _gearShiftInReverse = value;
                Notify();
            }
        }

        public int Speed 
        {
            get => _speed;
            set
            {
                _speed = value;
                Notify();
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
            Notify(nameof(Speed));
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
