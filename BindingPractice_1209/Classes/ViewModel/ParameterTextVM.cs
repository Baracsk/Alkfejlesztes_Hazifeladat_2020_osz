using RobotDiagnosticApp.Classes.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotInterfaceApp.Classes.ViewModel
{
    public class ParameterTextVM
    {
        private Queue<string> positionTextList;
        public ParameterTextView View;

        public double[] Coord 
        { 
            get { return Coord; }
            set 
            {
                Coord = value;
                WritePositionInView(Coord[0], Coord[1]);
            }
        }

        public double Speed 
        {
            get { return Speed; }
            set
            {
                Speed = value;
                WriteSpeedInView();
            }
        }

        public ParameterTextVM()
        {
            View = new ParameterTextView();

            positionTextList = new Queue<string>();

        }

        public void WritePositionInView(double X, double Y)
        {
            string OutPutText = "";

            UpdatePositionTextList("x: " + String.Format("{0:0.00}", X) + " y: " + String.Format("{0:0.00}", Y));

            foreach (string element in positionTextList)
            {
                OutPutText += element + '\n';
            }

            View.PositionText = OutPutText;
        }

        private void UpdatePositionTextList(string newText)
        {
            if (positionTextList.Count() >= 10)
            {
                positionTextList.Dequeue();
            }

            positionTextList.Enqueue(newText);
        }

        private void WriteSpeedInView()
        {
            View.SpeedText = String.Format("{0:0.00}", Speed) + " km/h";
        }



    }
}