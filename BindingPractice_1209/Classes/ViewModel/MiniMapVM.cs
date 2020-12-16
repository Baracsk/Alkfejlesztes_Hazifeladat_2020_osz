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

        //Array for collecting the previous coordinates
        private Queue<string> positionTextList;

        public double X 
        {
            get => Model.X;
            set => Model.X = value;
        }
        public double Y
        {
            get => Model.Y;
            set => Model.Y = value;
        }
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
            set => Model.Orientation = value;
        }
        public string PositionText
        {
            get; set;
        }

        public MiniMapVM(double X = 10.0, double Y = 0, int Orientation = 0)
        {
            Model = new MiniMapModel(X, Y, Orientation);

            Model.PropertyChanged += Model_PropertyChanged;

            positionTextList = new Queue<string>();

        }

        private void Model_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "X" || e.PropertyName == "Y" )
            {
                WriteNewPosition();
                Notify(e.PropertyName);
            }
            if (e.PropertyName == "Orientation")
            {
                Notify(e.PropertyName);
            }
        }
        private void WriteNewPosition()
        {
            string NewTextElement = String.Format("x: {0:0.00} y: {1:0.00}", X, Y);

            UpdatePositionTextList(NewTextElement);

            string Merged = "";
            foreach (string element in positionTextList)
            {
                Merged += element + '\n';
            }
            PositionText = Merged;
        }

        private void UpdatePositionTextList(string newText)
        {
            if (positionTextList.Count() >= 10)
            {
                positionTextList.Dequeue();
            }

            positionTextList.Enqueue(newText);
        }

        public void UpdatePositionParameters(double X, double Y, int orientation)
        {
            this.X = X;
            this.Y = Y;
            Orientation = orientation;
        }

        //notify 
        private void Notify(string PropertyName)
        {
            RaisePropertyChangedEvent(PropertyName);
        }
    }
}
