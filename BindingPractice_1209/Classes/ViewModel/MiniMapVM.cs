using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotDiagnosticApp.Classes;
using RobotDiagnosticApp.Classes.Model;

namespace RobotDiagnosticApp.Classes.ViewModel
{
    public class MiniMapVM : ObservableObject
    {
        private const int CENTERX_OFFSET = 120;
        private const int CENTERY_OFFSET = 115;

        MiniMapModel Model;

        public int X
        {
            get { return X; }
            set
            {
                X = value + CENTERX_OFFSET;
                RaisePropertyChangedEvent("X");
            }
        }
        public int Y
        {
            get { return Y; }
            set
            {
                Y = value - CENTERY_OFFSET;
                RaisePropertyChangedEvent("Y");
            }
        }
        public int Orientation
        {
            get { return Orientation; }
            set
            {
                Orientation = ScaleDegreeTo360(value);
                RaisePropertyChangedEvent("Orientation");
            }
        }


        public MiniMapVM(int X = 0, int Y = 0, int Orientation = 0)
        {
            Model = new MiniMapModel();

            this.Y = Y;
            this.X = X;
            this.Orientation = Orientation;
        }

        public static int ScaleDegreeTo360(int degree)
        {
            return (int)degree % 360;
        }

    }
}
