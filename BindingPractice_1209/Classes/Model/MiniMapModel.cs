using RobotDiagnosticApp.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotDiagnosticApp.Classes.Model
{
    class MiniMapModel : ObservableObject
    {
        public double X
        {
            get { return X; }
            set
            {
                X = value;
            }

        }
        public double Y
        {
            get { return Y; }
            set
            {
                Y = value;
            }
        }
        public int Orientation
        {
            get { return Orientation; }
            set
            {
                Orientation = ScaleDegreeTo360(value);
            }
        }

        public MiniMapModel(double X = 0, double Y = 0, int orientaion = 0)
        {
            this.X = X;
            this.Y = Y;
            this.Orientation = Orientation;
        }

        public static int ScaleDegreeTo360(int degree)
        {
            return (int)degree % 360;
        }
    }
}
