using DiagnosticApp.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotDiagnosticApp.Classes.View
{
    public class DrivingInterfaceView : INotifyPropertyChanged
    {
        private double _steeringWheelAngle;
        public double SteeringWheelAngle
        {
            get { return _steeringWheelAngle; }
            set
            {
                _steeringWheelAngle = value;
                OnPropertyChanged("SteeringWheelAngle");
            }
        }
        private bool _gearShiftInReverse;
        public bool GearShiftInReverse
        {
            get { return _gearShiftInReverse; }
            set
            {
                _gearShiftInReverse = value;
                OnPropertyChanged("GearShiftInReverse");
            }
        }

        public DrivingInterfaceView(int SteeringWheelValue = 0, bool GearShiftValue = false)
        {
            this.SteeringWheelAngle = SteeringWheelValue;
            this.GearShiftInReverse = GearShiftValue;

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Reset()
        {
            SteeringWheelAngle = 0;
            GearShiftInReverse = false;
            OnPropertyChanged("SteeringWheelAngle");
            OnPropertyChanged("GearShiftInReverse");
        }
    }
}
