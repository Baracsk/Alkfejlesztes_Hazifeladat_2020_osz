using RobotDiagnosticApp.Classes.View;
using DiagnosticApp.Classes;
using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagnosticApp
{
    //This class contains the setting and getting method of the main page visual elements
    public class MainPageHandler 
    { 
        //The used classes
        public RobotModel RobotModel;
        public SteeringWheelView SteeringWheel;
        public ParameterTextView ParameterText;
        public GearShiftView GearShift;

        public MainPageHandler()
        {
            RobotModel = new RobotModel();
            SteeringWheel = new SteeringWheelView();
            ParameterText = new ParameterTextView();
            GearShift = new GearShiftView();
            
        }

        //writing the current position of the robot
        public void WritePosition()
        {
            ParameterText.WritePosition(
                String.Format("{0:0.00}", RobotModel.Coord[0]),
                String.Format("{0:0.00}", RobotModel.Coord[1])
                );
        }

        public void WritePosition(double[] coord)
        {
            ParameterText.WritePosition(
                String.Format("{0:0.00}", coord[0]),
                String.Format("{0:0.00}", coord[1])
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


        //Stops the robot immediately
        public void E_Stop()
        {
            RobotModel.E_Stop();
        }

        public void ChangeShift(bool value)
        {
            RobotModel.IsReverse(value);
        }

        //resetting the values of the app and the robot modell
        public void Reset()
        {
            ParameterText.Reset();
            SteeringWheel.Reset();
            RobotModel.Reset();
            GearShift.Reset();
            
        }

    }
}
