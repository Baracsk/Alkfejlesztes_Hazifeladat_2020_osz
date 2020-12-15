using RobotInterfaceApp.Classes.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Threading;
using RobotInterfaceApp.Classes;

namespace RobotDiagnosticApp.Classes.View
{
    //Class for handling the coordinate and speed texts on the display
    public class ParameterTextView : INotifyPropertyChanged
    {
        private const string DEFAULT_POSITION_TEXT = "x: 0 y: 0";
        private const string DEFAULT_SPEED_TEXT = "0 m/s";

        //Array for collecting the previous coordinates
        private Queue<string> positionTextList;

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

        public ParameterTextView( string postext = DEFAULT_POSITION_TEXT, string speedtext = DEFAULT_SPEED_TEXT)
        {

            PositionText = postext;
            SpeedText = speedtext;

            positionTextList = new Queue<string>();
            positionTextList.Enqueue(postext);

        }


        //Propertychanged functions for updating the change of the values
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
