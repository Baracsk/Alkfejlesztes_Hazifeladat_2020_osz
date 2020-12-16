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

        public int mapX
        {
            get => (int)Model.X + CENTERX_OFFSET;
        }
        public int mapY
        {
            get => CENTERY_OFFSET - (int)Model.Y;
        }
        public int Orientation
        {
            get => Model.Orientation;
        }
        public string PositionText
        {
            get { return PositionText; }
            set { PositionText = value; }
        }

        public MiniMapVM(int X = 0, int Y = 0, int Orientation = 0)
        {
            Model = new MiniMapModel();

            Model.PropertyChanged += Model_PropertyChanged;

        }

        private void Model_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "X" || e.PropertyName == "Y" )
            {
                WriteNewSpeed();
                Notify(e.PropertyName);
            }
            if (e.PropertyName == "Orientation")
            {
                Notify(e.PropertyName);
            }
        }
        private void WriteNewSpeed()
        {
            PositionText = String.Format("x: {0:0.00} y: {1:0.00}", Model.X, Model.Y);
        }

        //notify 
        private void Notify(string PropertyName)
        {
            RaisePropertyChangedEvent(PropertyName);
        }

        public void UpdatePositionParameters(double X, double Y, int orientation)
        {
            Model.X = X;
            Model.Y = Y;
            Model.Orientation = orientation;
        }
    }
}
