using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace RobotInterfaceApp.Classes
{
    public interface IEnvironment
    {
        //event OnTickDelegate onTick;
        //void Tick();

        event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName);
        

    }

    public delegate void OnPropertyChanged();
    //public delegate void OnTickDelegate();


}