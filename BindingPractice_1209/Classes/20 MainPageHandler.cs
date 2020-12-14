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
using BindingPractice_1209.Classes;

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
        public MiniMapView MiniMap;
        private TickSource Tick;

        //environment for system tick
        private DefaultEnvironment environment;

        public MainPageHandler()
        {
            /*Task<RobotModel> T1 = Task.Run(()=>  );
            Task<SteeringWheelView> T2 = Task.Run(() => );
            Task<ParameterTextView> T3 = Task.Run(() => );
            Task<GearShiftView> T4 = Task.Run(() => new GearShiftView());
            Task<MiniMapView> T5 = Task.Run(() => new MiniMapView());*/

            RobotModel = new RobotModel();
            SteeringWheel = new SteeringWheelView();
            ParameterText = new ParameterTextView();
            GearShift = new GearShiftView();
            MiniMap = new MiniMapView();
            environment = new DefaultEnvironment();

            Tick = new TickSource(environment, Constants.SYSTEM_TICK_MS);
            environment.onTick += Environment_onTick;
            //Tick.Start();
        }

        //calls updater functions on system tick
        private void Environment_onTick()
        {
            WritePosition();
        }

        //writing the current position of the robot
        public void WritePosition()
        {
            ParameterText.WritePosition(RobotModel.Coord[0], RobotModel.Coord[1]);
        }

        //*************ONLY FOR TEST***************
        //(write given coords
        public void WritePosition(double[] coord)
        {
            ParameterText.WritePosition(RobotModel.Coord[0], RobotModel.Coord[1]);
        }

        //updating the minimap
        private void UpdateMiniMap()
        {
            MiniMap.Update(RobotModel.Coord[0], RobotModel.Coord[1], RobotModel.Orientation);
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
            MiniMap.TurnToDegree((int)SteeringWheel.SteeringValue);
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
            MiniMap.Reset();
        }

    }
}
