using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindingPractice_1209.Classes.View
{
    //Class for handling the coordinate and speed texts on the display
    public class ParameterTextView : INotifyPropertyChanged
    {
        private const string DEFAULT_POSITION_TEXT = "x: 0 y: 0";
        private const string DEFAULT_SPEED_TEXT = "0 m/s";

        //list for collecting coordinates through the way
        private List<Double[]> prevCoords;

        private string _positionText { get; set; }
        private string _speedText { get; set; }

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

        public ParameterTextView(string postext = DEFAULT_POSITION_TEXT, string speedtext = DEFAULT_SPEED_TEXT)
        {
            PositionText = postext;
            SpeedText = speedtext;
        }

        //Propertychanged functions for updating the change of the values
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void WritePosition(string X, string Y)
        {
            PositionText = "x: " + X + " y: " + Y;
            OnPropertyChanged("PositionText");
        }

        //writing the current speed of the robot
        public void WriteSpeed(string speed)
        {
            SpeedText = speed + " m/s";
            OnPropertyChanged("SpeedText");
        }

        public void Reset()
        {
            //resetting the text values to default
            PositionText = "x: 0 y: 0";
            OnPropertyChanged("PositionText");

            SpeedText = "0 m/s";
            OnPropertyChanged("SpeedText");

        }
    }
}
