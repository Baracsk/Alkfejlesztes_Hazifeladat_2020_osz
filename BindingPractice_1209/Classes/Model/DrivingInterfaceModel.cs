using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RobotDiagnosticApp.Classes.Model
{
    //this model class is for handling the gearbox and the speedometer of the page
    class DrivingInterfaceModel : ObservableObject
    {
        private bool _gearShiftInReverse;
        private int _speed;

        public bool GearShiftInReverse
        {
            get => _gearShiftInReverse;
            set
            {
                if (Speed == 0 && value != _gearShiftInReverse)
                {
                    _gearShiftInReverse = value;
                }
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
            //Checking the movement direction
            int MAX_SPEED = (GearShiftInReverse) ? 50 : 100;

            if ((Speed += Constants.SPEED_CHANGE_SCALE) <= MAX_SPEED) { }
            else Speed = MAX_SPEED;

            Notify(nameof(Speed));
        }
        public void Brake()
        {
            if ((Speed -= Constants.SPEED_CHANGE_SCALE*2) >= 0) { }
            else Speed = 0;
        }
        public void EStop()
        {
            Speed = 0;
        }
    }
}
