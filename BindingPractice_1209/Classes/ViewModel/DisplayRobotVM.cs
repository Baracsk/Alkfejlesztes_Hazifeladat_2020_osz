using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindingPractice_1209.Classes.ViewModel
{
    public static class DisplayRobotVM
    {
        private const int CENTERX_OFFSET = 120;
        private const int CENTERY_OFFSET = 115;

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

        /*public static void MoveForward(int orientation, out int newx, out int newy)
        {
            Task<Double> Tx = Task.Run(() => 5*Math.Sin(orientation * Math.PI / 180));
            Task<Double> Ty = Task.Run(() => 5*Math.Cos(orientation * Math.PI / 180));

            newx = (int)Tx.Result;
            newy = (int)Ty.Result;
            
        }*/

    }
}
