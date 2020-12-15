using RobotInterfaceApp.Classes.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Core;

namespace RobotInterfaceApp.Classes.View
{
    public class MiniMapView : INotifyPropertyChanged
    {
        public int X 
        {
            get { return X; }
            set {
                X = value;
                OnPropertyChanged("X");
            }
        }
        public int Y
        {
            get { return Y; }
            set
            {
                Y = value;
                OnPropertyChanged("Y");
            }
        }
        public int Orientation
        {
            get { return Orientation; }
            set
            {
                Orientation = value;
                OnPropertyChanged("Orientation");
            }
        }

        //Propertychanged functions for updating the change of the values
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
               PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MiniMapView()
        { 

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
