using System;
using RobotDiagnosticApp.Classes.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RobotDiagnosticApp.Classes.ViewModel
{
    public class SteeringWheelVM : ObservableObject
    {
        SteeringWheelModel Model;

        public int Angle
        {
            get => Model.SteeringWheelAngle;
            set => Model.SteeringWheelAngle = value;
        }

        public ICommand SteerLeftClicked
        {
            get
            {
                return new DelegateCommand(Model.SteerLeft);
            }
        }
        public ICommand SteerRightClicked
        {
            get
            {
                return new DelegateCommand(Model.SteerRight);
            }
        }

        public SteeringWheelVM(int SteeringWheelAngle = 0)
        {
            Model = new SteeringWheelModel(SteeringWheelAngle);
            Model.PropertyChanged += Model_PropertyChanged;

        }

        private void Model_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Notify(e.PropertyName);
        }

        private void Notify(string PropertyName)
        {
            RaisePropertyChangedEvent(PropertyName);
        }
    }
}
