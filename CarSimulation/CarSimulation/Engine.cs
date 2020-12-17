using System;
using System.Collections.Generic;
using System.Text;

namespace CarSimulation
{
    class Engine
    {

        public Engine(int power, int max_rpm)
        {
            horsepower = power;
            rpm_max = max_rpm;
        }


        double torque;
        int horsepower;
        int rpm;
        int rpm_max;


        public double Torque
        {
            get { return torque; }
            set { torque = value; }
        }
        public int Horsepower
        {
            get { return horsepower; }
            set { horsepower = value; }
        }
        public int Rpm
        {
            get { return rpm; }
            set { rpm = value; }
        }
        public int Rpm_max
        {
            get { return rpm_max; }
            set { rpm_max = value; }
        }

        void Engine_Set_RPM(double accelerator_value)
        {
            if(accelerator_value>1)
            {
                accelerator_value = 1;
            }
            else if(accelerator_value <0)
            {
                accelerator_value = 0;
            }
            rpm = (int)(accelerator_value * rpm_max);
            if(rpm < 10)
            {
                rpm = 10;
            }
        }
        void Engine_Calc_Torque()
        {
            torque = (double)horsepower * rpm*10;
        }

        public void Engine_Refresh(double accelerator_value)
        {
            Engine_Set_RPM(accelerator_value);
            Engine_Calc_Torque();
        }
    }
}
