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

        private string _positionText;

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
            get => _positionText;
            set
            {
                _positionText = value;
                Notify();
            }
        }

        public MiniMapVM(double X = 0, double Y = 0, int Orientation = 0)
        {
            Model = new MiniMapModel(X, Y, Orientation);

            Model.PropertyChanged += Model_PropertyChanged;
            positionTextList = new Queue<string>();

        }

        internal async Task Reset()
        {
            positionTextList.Clear();
            await UpdatePositionParameters(0, 0, 0);
        }

        private void Model_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(X) || e.PropertyName == nameof(Y))
            {
                Notify("map" + e.PropertyName);
            }
            Notify(e.PropertyName);
        }

        private async Task WriteNewPosition()
        {
            string NewTextElement = String.Format("x: {0:0.00} y: {1:0.00}", X, Y);

            await UpdatePositionTextList(NewTextElement);

            string Merged = "";
            foreach (string element in positionTextList)
            {
                Merged += element + '\n';
            }
            PositionText = Merged;
        }

        private async Task UpdatePositionTextList(string newText)
        {
            if (positionTextList.Count() >= 10)
            {
                positionTextList.Dequeue();
            }

            positionTextList.Enqueue(newText);
        }

        public async Task UpdatePositionParameters(double X, double Y, int orientation)
        {
            this.X = X;
            this.Y = Y;
            await WriteNewPosition();
            Orientation = orientation;
        }
    }
}
