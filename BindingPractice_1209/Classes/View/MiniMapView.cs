using BindingPractice_1209.Classes.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Core;

namespace BindingPractice_1209.Classes.View
{
    public class MiniMapView : INotifyPropertyChanged
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

        public MiniMapView(int x = 0, int y = 0, int orientation = 0)
        { 
            X = MiniMapVM.GetDisplayedX(x);
            Y = MiniMapVM.GetDisplayedY(y);

            Orientation = orientation;
        }

        public void Update(double X, double Y, int orientation)
        {
            GoToPoint((int)X, (int)Y);
            TurnToDegree(orientation);
        }

        public void GoToPoint(int x, int y)
        {
            X = MiniMapVM.GetDisplayedX(x);
            Y = MiniMapVM.GetDisplayedY(y);

            OnPropertyChanged("X");
            OnPropertyChanged("Y");
        }

        public void TurnToDegree (int degree)
        {
            Orientation = MiniMapVM.ScaleDegreeTo360(degree);

            OnPropertyChanged("Orientation");
        }

        public void MoveForward(bool isReverse)
        {
            int sign = (isReverse) ? -1 : 1;
            MiniMapVM.MoveForward(Orientation, out int newX, out int newY);
            X += sign*newX;
            Y -= sign*newY;

            OnPropertyChanged("X");
            OnPropertyChanged("Y");
        }

        public void Reset()
        {

            X = MiniMapVM.GetDisplayedX(0);
            Y = MiniMapVM.GetDisplayedY(0);

            Orientation = 0;

            OnPropertyChanged("X");
            OnPropertyChanged("Y");
            OnPropertyChanged("Orientation");

        }
    }
}
