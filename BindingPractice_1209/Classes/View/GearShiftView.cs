using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindingPractice_1209.Classes.View
{
    public class GearShiftView :INotifyPropertyChanged
    {
        private bool _gearShiftValue; 
        public bool GearShiftValue
        {
            get { return _gearShiftValue; }
            set
            {
                _gearShiftValue = value;
                OnPropertyChanged("GearShiftValue");
            }
        }
        //Propertychanged functions for updating the change of the values
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Reset()
        {
            _gearShiftValue = false;
            OnPropertyChanged("GearShiftValue");
        }
    }
}
