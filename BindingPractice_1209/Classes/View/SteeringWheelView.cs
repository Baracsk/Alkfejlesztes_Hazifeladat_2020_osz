using DiagnosticApp.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotDiagnosticApp.Classes.View
{
    public class SteeringWheelView : INotifyPropertyChanged
    {
        private double _steeringValue { get; set; }
        public double SteeringValue
        {
            get { return _steeringValue; }
            set
            {
                _steeringValue = value;
                OnPropertyChanged("SteeringValue");
            }
        }

        public SteeringWheelView(int value = 0)
        {
            SteeringValue = value;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Reset()
        {
            SteeringValue = 0;
            OnPropertyChanged("SteeringValue");
        }
    }
}
