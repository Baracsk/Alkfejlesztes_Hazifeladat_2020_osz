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

namespace BindingPractice_1209
{
    
    public sealed partial class MainPage : Page
    {
        private int RotationAngle;
        private MainPageHandler pageHandler;

        public MainPage()
        {
            pageHandler = new MainPageHandler(-20);
            this.InitializeComponent();

            DataContext = pageHandler;


        }

        //Event handling functions

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

        }

        private void Reset_Button_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Test_Button_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Brake_Button_Click(object sender, RoutedEventArgs e)
        {
            pageHandler.Brake();
        }

        private void Accelerate_Button_Click(object sender, RoutedEventArgs e)
        {
            pageHandler.Accelerate();
        }

    }
}
