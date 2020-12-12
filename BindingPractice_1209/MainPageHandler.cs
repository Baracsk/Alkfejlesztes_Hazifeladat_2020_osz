using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindingPractice_1209
{
    class MainPageHandler
    {
        //Binded to the steeringwheel function
        public int SteeringValue { get; set; }
        public string PositionText { get; set; }
        public string SpeedText { get; set; }

        private int speedPercentage; 
        private double[] coord;
        private List<Double[]> prevCoords;


        public MainPageHandler(double X = 0, double Y = 0, int speedPercentage = 0)
        {
            PositionText = "none";
            SpeedText = "none";
            SteeringValue = 0;

            if (speedPercentage >= 0 && speedPercentage <= 100)
            {
                this.speedPercentage = speedPercentage;
            } 
            else
            {
                throw new ArgumentException("speeding value should be between 0 and 100");
            }

            coord = new double[] { X, Y };

            prevCoords = new List<double[]>();
            prevCoords.Add(coord);
        }

        public void WritePosition()
        {

        }

        public void Accelerate()
        {
            if ((speedPercentage += Constants.SPEED_CHANGE_SCALE) < 100) { }
        }

        public void Brake()
        {
            if ((speedPercentage -= Constants.SPEED_CHANGE_SCALE) > 0) { }
        }


    }
}
