﻿using BindingPractice_1209.Classes.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private ParameterTextVM TextVM;

        public ParameterTextView(string postext = DEFAULT_POSITION_TEXT, string speedtext = DEFAULT_SPEED_TEXT)
        {
            PositionText = postext;
            SpeedText = speedtext;

            positionTextList = new Queue<string>();
            positionTextList.Enqueue(postext);

            TextVM = new ParameterTextVM(PositionText);
        }

        //Propertychanged functions for updating the change of the values
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void WritePosition(string X, string Y)
        { 
            Task<string> WriteposTask = Task.Run(() =>  TextVM.WritePosition(X, Y));

            PositionText = WriteposTask.Result; 
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
            positionTextList.Clear();

        }
    }
}