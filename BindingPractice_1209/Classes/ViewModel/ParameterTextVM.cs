using RobotDiagnosticApp.Classes;
using RobotDiagnosticApp.Classes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotDiagnosticApp.Classes.ViewModel
{
    public class ParameterTextVM :ObservableObject
    {
        private const string DEFAULT_POSITION_TEXT = "x: 0 y: 0";
        private const string DEFAULT_SPEED_TEXT = "0 m/s";

        private Queue<string> positionTextList;

        ParameterTextModel Model;

        private string _positionText;
        private string _speedText; 

        public string PositionText
        {
            get { return _positionText; }
            set
            {
                _positionText = value;
                RaisePropertyChangedEvent("PositionText");
            }
        }

        public string SpeedText
        {
            get { return _speedText; }
            set
            {
                _speedText = value;
                RaisePropertyChangedEvent("SpeedText");
            }
        }

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
            }
        }

        public ParameterTextVM()
        {
            Model = new ParameterTextModel();

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

            PositionText = OutPutText;
        }

        private void UpdatePositionTextList(string newText)
        {
            if (positionTextList.Count() >= 10)
            {
                positionTextList.Dequeue();
            }

            positionTextList.Enqueue(newText);
        }
    }
}