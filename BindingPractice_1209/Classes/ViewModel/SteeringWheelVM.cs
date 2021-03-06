﻿using System;
using RobotDiagnosticApp.Classes.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RobotDiagnosticApp.Classes.ViewModel
{
    //Viewmodel of the steeringwheel class
    public class SteeringWheelVM : ObservableObject
    {
        SteeringWheelModel Model;

        public int Angle
        {
            get => Model.Angle;
            set => Model.Angle = value;
        }

        public SteeringWheelVM(int SteeringWheelAngle = 0)
        {
            Model = new SteeringWheelModel(SteeringWheelAngle);
            Model.PropertyChanged += Model_PropertyChanged;
        }

        private void Model_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Notify(nameof(Angle));
        }

        public async Task Reset()
        {
            Angle = 0;
        }
    }
}
