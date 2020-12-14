using BindingPractice_1209.Classes.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindingPractice_1209.Classes.View
{
    public class DisplayRobotView : INotifyPropertyChanged
    {
        
        public int X { get; set; }
        public int Y { get; set; }
        public int Orientation { get; set; }

        //Propertychanged functions for updating the change of the values
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public DisplayRobotView(int x = 0, int y = 0, int orientation = 0)
        { 
            X = DisplayRobotVM.GetDisplayedX(x);
            Y = DisplayRobotVM.GetDisplayedY(y);

            Orientation = orientation;
        }

        public void GoToPoint(int x, int y)
        {
            X = DisplayRobotVM.GetDisplayedX(x);
            Y = DisplayRobotVM.GetDisplayedY(y);

            OnPropertyChanged("X");
            OnPropertyChanged("Y");
        }

        public void TurnToDegree (int degree)
        {
            Orientation = DisplayRobotVM.ScaleDegreeTo360(degree);

            OnPropertyChanged("Orientation");
        }

        /*public void MoveForward(bool isReverse)
        {
            int sign = (isReverse) ? -1 : 1;
            DisplayRobotVM.MoveForward(Orientation, out int newX, out int newY);
            X += sign*newX;
            Y -= sign*newY;

            OnPropertyChanged("X");
            OnPropertyChanged("Y");
        }*/

        public void Reset()
        {

            X = DisplayRobotVM.GetDisplayedX(0);
            Y = DisplayRobotVM.GetDisplayedY(0);

            Orientation = 0;

            OnPropertyChanged("X");
            OnPropertyChanged("Y");

            OnPropertyChanged("Orientation");

        }
    }
}
