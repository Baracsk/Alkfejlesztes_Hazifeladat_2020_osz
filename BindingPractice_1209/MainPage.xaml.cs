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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DiagnosticApp
{
    
    public sealed partial class MainPage : Page
    {
        private int RotationAngle;
        public MainPageHandler PageHandler;

        public MainPage()
        {
            this.InitializeComponent();

            PageHandler = new MainPageHandler();
        }

        //Event handling functions

        //Connecting the slider to the steeringwheel image
        private void RotationSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            Slider slider = sender as Slider;
            if (slider != null)
            {
                RotationAngle = (int)slider.Value;
            }

            RotatingImage.RenderTransform = new RotateTransform
            {
                Angle = RotationAngle
            };

            PageHandler.Steer();
        }

        //
        private void Reset_Button_Click(object sender, RoutedEventArgs e)
        {
            PageHandler.Reset();
        }

        private void Test_Button_Click(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();
            //**********TEST**************************
            double[] Position = { 0.1110, 0.11101 };
            PageHandler.WritePosition( Position ); 
        }

        private void Brake_Button_Click(object sender, RoutedEventArgs e)
        {
            PageHandler.Brake();
        }

        private void Accelerate_Button_Click(object sender, RoutedEventArgs e)
        {
            PageHandler.Accelerate();
        }

        private void Emergency_Button_Click(object sender, RoutedEventArgs e)
        {
            PageHandler.E_Stop();
        }

        private void Gearshift_Toggled(object sender, RoutedEventArgs e)
        {
            PageHandler.ChangeShift(GearShift.IsOn);
        }
    }
}
