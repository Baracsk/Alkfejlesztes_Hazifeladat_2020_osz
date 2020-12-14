using RobotDiagnosticApp.Classes.View;
using DiagnosticApp.Classes;
using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingPractice_1209.Classes.View;

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
        public DisplayRobotView DisplayRobot;

        public MainPageHandler()
        {
            Task<RobotModel> T1 = Task.Run(()=>  new RobotModel());
            Task<SteeringWheelView> T2 = Task.Run(() => new SteeringWheelView());
            Task<ParameterTextView> T3 = Task.Run(() => new ParameterTextView());
            Task<GearShiftView> T4 = Task.Run(() => new GearShiftView());
            Task<DisplayRobotView> T5 = Task.Run(() => new DisplayRobotView());

            RobotModel = T1.Result;
            SteeringWheel = T2.Result;
            ParameterText = T3.Result;
            GearShift = T4.Result;
            DisplayRobot = T5.Result;
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
            DisplayRobot.TurnToDegree((int)SteeringWheel.SteeringValue);
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
            DisplayRobot.Reset();
        }

    }
}
