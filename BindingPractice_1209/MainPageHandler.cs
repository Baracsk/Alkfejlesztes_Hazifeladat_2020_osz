using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindingPractice_1209
{
    class MainPageHandler
    {
        public int SteeringValue { get; set; }


        public MainPageHandler(int value = 0)
        {
            if ( Math.Abs(value) <= 90)
            {
                SteeringValue = value;
            }
        }

    }
}
