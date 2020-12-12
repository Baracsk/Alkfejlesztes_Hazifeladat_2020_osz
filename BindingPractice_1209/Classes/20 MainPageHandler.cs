using BindingPractice_1209.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindingPractice_1209
{
    public class MainPageHandler 
    {
        //Binded to the steeringwheel function
        public double SteeringValue { get; set; }
        public string PositionText { get; set; }
        public string SpeedText { get; set; }

        private List<Double[]> prevCoords;

        public RobotModel robotModel;


        public MainPageHandler(int speedPercentage = 0)
        {
            PositionText = "alle";
            SpeedText = "alle";
            SteeringValue = 10;

            robotModel = new RobotModel();
            prevCoords = new List<double[]>();
        }

        public void WritePosition()
        {
            PositionText = "x: " + robotModel.Coord[0] + "\ny: " + robotModel.Coord[1];
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
            SpeedText = "reset happened";
            SteeringValue = 0.0;
            robotModel.Reset();
        }

    }
}
