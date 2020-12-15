using System;
using RobotInterfaceApp.Classes.View;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotInterfaceApp.Classes.ViewModel
{
    public class MiniMapVM
    {
        private const int CENTERX_OFFSET = 120;
        private const int CENTERY_OFFSET = 115;

        public double[] Coord
        {
            get { return Coord; }
            set 
            {
                Coord = value;
                View.X = CENTERX_OFFSET + (int)Coord[0];
                View.Y = CENTERY_OFFSET - (int)Coord[1];
            }
        }
        public int Orientation
        {
            get { return Orientation; }
            set 
            {
                View.Orientation = ScaleDegreeTo360(value);
            }
        }

        public MiniMapView View;

        public MiniMapVM(double X = 0, double Y = 0, int Orientation = 0)
        {
            View = new MiniMapView();
        }


        public static int GetDisplayedX(int x)
        {
            return CENTERX_OFFSET + x;
        }

        public static int GetDisplayedY(int y)
        {
            return CENTERY_OFFSET - y;
        }

        public static int GetBasePointX()
        {
            return CENTERX_OFFSET;
        }

        public static int GetBasePointY()
        {
            return CENTERY_OFFSET;
        }

        public static int ScaleDegreeTo360(int degree)
        {
            return (int)degree % 360;
        }

        public void MoveForward()
        {
            Task<Double> Tx = Task.Run(() => 5*Math.Sin(Orientation * Math.PI / 180));
            Task<Double> Ty = Task.Run(() => 5*Math.Cos(Orientation * Math.PI / 180));

            Coord[0] = (int)Tx.Result;
            Coord[1] = (int)Ty.Result;
            
        }

    }
}
