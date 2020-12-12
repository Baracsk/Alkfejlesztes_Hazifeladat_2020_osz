using BindingPractice_1209.Classes.View;
using DiagnosticApp.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagnosticApp
{
    //This class contains the setting and getting method of the main page visual elements
    public class MainPageHandler : INotifyPropertyChanged
    {
        //list for collecting coordinates through the way
        private List<Double[]> prevCoords;

        //The used classes
        public RobotModel RobotModel;
        public SteeringWheelView SteeringWheel;
        public ParameterTextView ParameterText;

        //Propertychanged functions for updating the change of the values
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainPageHandler(int speedPercentage = 0)
        {
            RobotModel = new RobotModel();
            SteeringWheel = new SteeringWheelView();
            ParameterText = new ParameterTextView();
            
        }

        //writing the current position of the robot
        public void WritePosition()
        {
            ParameterText.WritePosition(
                String.Format("{0}:0.00", RobotModel.Coord[0].ToString()),
                String.Format("{0}:0.00", RobotModel.Coord[1].ToString())
                );
        }

        //writing the current speed of the robot
        public void WriteSpeed()
        {
            ParameterText.WriteSpeed(String.Format("{0:0.00}", RobotModel.SpeedPercentage.ToString()));
        }

        //Handling acceleration from the display
        public void Accelerate()
        {
            RobotModel.Accelerate();
        }

        //Handling braking from the display
        public void Brake()
        {
            RobotModel.Brake();
        }

        //updating the current steering value
        public void Steer()
        {
            RobotModel.changeSteeringWheelAngle(SteeringWheel.SteeringValue);
        }


        //resetting the values of the app and the robot modell
        public void Reset()
        {
            ParameterText.Reset();
            SteeringWheel.Reset();
            RobotModel.Reset();

        }

    }
}
