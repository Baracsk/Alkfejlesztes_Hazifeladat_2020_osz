using System;
using System.Collections.Generic;
using System.Text;

namespace CarSimulation
{
    class Communication
    {
        public Communication(Car car)
        {
            Com_car = car;
        }

        Car Com_car;

        //To Receive
        public void Com_Set_Desired_Speed(double speed)
        {
            Com_car.Desired_speed = speed/3.6;
        }
        public void Com_Set_Wheel(double wheel_angle)
        {
            Com_car.Car_Change_Direction(wheel_angle);
        }
        public void Com_Set_Gear(bool gear_to_reverse)
        {
            int x = 0;
            if(gear_to_reverse)
            {
                x = 1;
            }
            Com_car.Car_Change_Gear(x);
        }

        //To Send
        public double Com_Get_X_Position()
        {
            return Com_car.Car_Get_XPos() - 125;
        }
        public double Com_Get_Y_Position()
        {
            return Com_car.Car_Get_YPos() - 125;
        }
        public double Com_Get_Orientation()
        {​​​​​​
            return Com_car.Car_Get_Direction();
        }​​​​​​
    }
}
