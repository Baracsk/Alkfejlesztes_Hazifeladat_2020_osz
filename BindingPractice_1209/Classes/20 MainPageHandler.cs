using DiagnosticApp.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagnosticApp
{
    public class MainPageHandler : INotifyPropertyChanged
    {
        //Binded to the steeringwheel function
        private double _steeringValue { get; set; }
        private string _positionText { get; set; }
        private string _speedText { get; set; }
        public double SteeringValue
        {
            get { return _steeringValue; }
            set
            {
                _steeringValue = value;
                OnPropertyChanged("SteeringValue");
            }
        }
        public string PositionText
        {
            get { return _positionText; }
            set
            {
                _positionText = value;
                OnPropertyChanged("PositionText");
            }
        }
        public string SpeedText
        {
            get { return _speedText; }
            set
            {
                _speedText = value;
                OnPropertyChanged("SpeedText");
            }
        }

        private List<Double[]> prevCoords;

        public RobotModel robotModel;

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainPageHandler(int speedPercentage = 0)
        {
            PositionText = "none";
            SpeedText = "none";
            SteeringValue = 10;

            robotModel = new RobotModel();
            prevCoords = new List<double[]>();
        }

        public void WritePosition()
        {
            PositionText = "x: " + robotModel.Coord[0] + "\ny: " + robotModel.Coord[1];
            OnPropertyChanged("PositionText");
        }

        public void WriteSpeed()
        {
            SpeedText = String.Format("{0:0.00}", robotModel.SpeedPercentage.ToString()) + " m/s";
            OnPropertyChanged("SpeedText");
        }

        public void Accelerate()
        {
            robotModel.Accelerate();
        }

        public void Brake()
        {
            robotModel.Brake();
        }

        public void Steer()
        {
            robotModel.changeSteeringWheelAngle(SteeringValue);
        }

        public void Reset()
        {
            PositionText = "reset happened";
            OnPropertyChanged("PositionText");

            SpeedText = "reset happened";
            OnPropertyChanged("SpeedText");

            SteeringValue = 0;
            OnPropertyChanged("SteeringValue");
            robotModel.Reset();

        }

    }
}
