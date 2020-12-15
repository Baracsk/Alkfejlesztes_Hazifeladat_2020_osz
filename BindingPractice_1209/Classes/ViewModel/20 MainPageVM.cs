using RobotDiagnosticApp.Classes.View;
using DiagnosticApp.Classes;
using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotInterfaceApp.Classes.View;
using RobotInterfaceApp.Classes;

namespace DiagnosticApp
{
    //This class contains the setting and getting method of the main page visual elements
    public class MainPageHandler 
    { 
        //The used classes
        public RobotModel RobotModel;

        public MainPageHandler()
        {
            RobotModel = new RobotModel();
        }

        //*************ONLY FOR TEST***************
        //(write given coords
        public void WritePosition(double[] coord)
        {
            RobotModel.Coord = coord;
        }

        //Handling acceleration from the display
        public void Accelerate()
        {
            RobotModel.Accelerate();
        }

        //Handling braking from the display
        public void Brake()
        {
            RobotModel.Brake();
        }

        //Stops the robot immediately
        public void E_Stop()
        {
            RobotModel.E_Stop();
        }

        //resetting the values of the app and the robot modell
        public void Reset()
        {
            RobotModel.Reset();
        }

    }
}
