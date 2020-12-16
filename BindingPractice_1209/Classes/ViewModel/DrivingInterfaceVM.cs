
using RobotDiagnosticApp.Classes;
using RobotDiagnosticApp.Classes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RobotDiagnosticApp.Classes.ViewModel
{
    //this is the View model for the driver interface. It handles the gearshift and the speedometer text
    public class DrivingInterfaceVM : ObservableObject
    {
        private DrivingInterfaceModel Model;

        private string _speedtext;

        public bool GearShiftInReverse
        {
            get => Model.GearShiftInReverse;
            set => Model.GearShiftInReverse = value;
        }
        public int Speed
        {
            get => Model.Speed;
            set => Model.Speed = value;
        }
        public string SpeedText
        {
            get => _speedtext;
            set
            {
                _speedtext = value;
                Notify();
            }
        }

        //Commands for the buttons
        public ICommand AccelerateButtonClicked
        {
            get
            {
                return new DelegateCommand(Model.Accelerate);
            }
        }
        public ICommand BrakeButtonClicked
        {
            get
            {
                return new DelegateCommand(Model.Brake);
            }
        }
        public ICommand EStopButtonClicked
        {
            get
            {
                return new DelegateCommand(Model.EStop);
            }
        }
        
        //Constructor
        public DrivingInterfaceVM(double SteeringWheelAngle = 0, bool GearShiftInReverse = false, double X=0, double Y=0, int Speed=0, int Orientation = 0)
        {
            Model = new DrivingInterfaceModel(GearShiftInReverse, Speed);
            Model.PropertyChanged += Model_PropertyChanged;
        }


        private void Model_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Speed))
            {
                WriteNewSpeed();
            }
            Notify(e.PropertyName);
        }

        //resets the values of the model class
        internal async Task Reset()
        {
            Speed = 0;
            GearShiftInReverse = false;
        }

        //writes the speed
        private async Task WriteNewSpeed()
        {
            SpeedText = String.Format("{0:0.00} km/h", (Speed * Constants.MAX_SPEED/100));
        }

    }
}
