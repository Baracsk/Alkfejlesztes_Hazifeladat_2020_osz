using RobotDiagnosticApp.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotDiagnosticApp.Classes.Model
{
    //this observable model class is for handling the minimap and the written positions
    class MiniMapModel : ObservableObject
    {
        private double _x;
        private double _y;
        private int _orientation;

        public double X
        {
            get => _x;
            set
            {
                _x = value;
                Notify();
            }

        }
        public double Y
        {
            get => _y;
            set
            {
                _y = value;
                Notify();
            }
        }

        public int Orientation
        {
            get { return _orientation; }
            set
            {
                _orientation = ScaleDegreeTo360(value);
                Notify();
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
