﻿using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotDiagnosticApp.Classes;
using RobotDiagnosticApp.Classes.Model;

namespace RobotDiagnosticApp.Classes.ViewModel
{
    //This class contains the viewmodel of the minimap
    public class MiniMapVM : ObservableObject
    {
        //defining the offset from the basepoint of the minimap
        private const int CENTERX_OFFSET = 145;
        private const int CENTERY_OFFSET = 140;

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
        public int Orientation
        {
            get => Model.Orientation;
            set => Model.Orientation = value;
        }

        //offset values for corrigating the minimap basepoint
        public int mapX
        {
            get => (int)Model.X + Constants.CENTERX_OFFSET;
        }
        public int mapY
        {
            get => Constants.CENTERY_OFFSET - (int)Model.Y;
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

        //resets the position related values asyncronously
        internal async Task Reset()
        {
            positionTextList.Clear();
            await UpdatePositionParameters(0, 0, 0);
        }

        //
        private void Model_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(X) || e.PropertyName == nameof(Y))
            {
                Notify("map" + e.PropertyName);
            }
            Notify(e.PropertyName);
        }

        //Converting position into a text and appending to the queue of last 10 position elements
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
            //checking if vehicle moved
            bool isPositionChanged = (this.X != X || this.Y != Y);

            this.X = X;
            this.Y = Y;
            Orientation = orientation;

            if (isPositionChanged)
            { 
                await WriteNewPosition(); 
            }
        }
    }
}
