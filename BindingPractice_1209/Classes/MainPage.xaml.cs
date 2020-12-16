using System;
using System.Timers;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using RobotDiagnosticApp.Classes;
using System.Threading.Tasks;
using RobotDiagnosticApp.Classes.ViewModel;
using BindingPractice_1209.Classes.Model;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DiagnosticApp
{
    
    public sealed partial class MainPage : Page
    {
        public CommunicationInterface Interface;

        public MainPage()
        {
            this.InitializeComponent();

            Interface = new CommunicationInterface();
            
        }


        }
    }
}
