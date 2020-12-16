
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
    public class DrivingInterfaceVM : ObservableObject
    {
        private DrivingInterfaceModel Model;

        public bool GearShiftInReverse
        {
            get => Model.GearShiftInReverse;
        }
        public int Speed
        {
            get => Model.Speed;
        }
        public string SpeedText
        {
            get; set;
        }


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
            if (e.PropertyName == "Speed" || e.PropertyName == "GearShiftInReverse")
            {
                if(e.PropertyName == "Speed")
                {
                    WriteNewSpeed();
                }
                Notify(e.PropertyName);
            }
        }

        //notify 
        private void Notify(string PropertyName)
        {
            RaisePropertyChangedEvent(PropertyName);
        }
        private void WriteNewSpeed()
        {
            SpeedText = String.Format("{0:00} km/h", (Speed/100 * Constants.MAX_SPEED));
        }

    }
}
