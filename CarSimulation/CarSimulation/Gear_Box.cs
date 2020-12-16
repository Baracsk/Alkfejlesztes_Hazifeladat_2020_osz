using System;
using System.Collections.Generic;
using System.Text;

namespace CarSimulation
{
    class Gear_Box
    {

        public Gear_Box(int gear_num, double ratio1 = 0.0, double ratio2 = 0.0, double ratio3 = 0.0, double ratio4 = 0.0, double ratio5 = 0.0, double ratio6 = 0.0)
        {
            number_of_gear = gear_num;
            if(number_of_gear > 6 || number_of_gear < 0)
            { 
                number_of_gear = 6;
            }
            gear_ratios = new double[6];
            gear_ratios[0] = ratio1;
            gear_ratios[1] = ratio2;
            gear_ratios[2] = ratio3;
            gear_ratios[3] = ratio4;
            gear_ratios[4] = ratio5;
            gear_ratios[5] = ratio6;
            actual_gear = 0;
        }


        int actual_gear;
        double[] gear_ratios;
        int number_of_gear;
        public int Number_of_gear
        {
            get { return number_of_gear; }
            set { number_of_gear = value; }
        }

        public void Gear_box_change_gear(int direction)
        {
            if (direction == 1)
            {
                if(actual_gear < (number_of_gear-1))
                {
                    actual_gear++;
                }
            }
            else if(direction == 0)
            {
                if (actual_gear > 0)
                {
                    actual_gear--;
                }
            }
        }

        public double Gear_box_return_ratio()
        {
            return gear_ratios[actual_gear];
        }
    }
}
