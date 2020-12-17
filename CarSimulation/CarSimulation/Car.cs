using System;
using System.Collections.Generic;
using System.Text;

namespace CarSimulation
{
    class Car
    {

        public Car(int frontal, int weigh, int wheelrad, double air_coef, int time)
        {

            carPosition = new Position(126, 126);
            carRoad = new Road(1, 1, 252, 252);
            carRoad.Road_Refresh_Tile(carPosition);
            carGearbox = new Gear_Box(2, 3, -3);
            carEngine = new Engine(10, 3000);
            carCalculator = new Calculator();
            carMovement = new Movement();

            frontal_area = frontal;
            weight = weigh;
            wheel_radius = wheelrad;
            air_drag_coef = air_coef;
            tim_in_sec = time;
            wheel_direction = 0;
        }


        CarSimulation.Engine carEngine;
        CarSimulation.Road carRoad;
        CarSimulation.Calculator carCalculator;
        CarSimulation.Gear_Box carGearbox;
        CarSimulation.Position carPosition;
        CarSimulation.Movement carMovement;
        int frontal_area;
        int weight;
        double wheel_direction;
        int wheel_radius;
        double air_drag_coef;
        int tim_in_sec;
        double accelerator_value;
        double break_value;
        double desired_speed;

        public double Desired_speed
        {
            get { return desired_speed; }
            set { desired_speed = value; }
        }
        public int Time_in_sec
        {
            get { return tim_in_sec; }
            set { tim_in_sec = value; }
        }
        public void Car_Refresh()
        {
            Car_Set_Pedals_for_desired_speed();
            carEngine.Engine_Refresh(accelerator_value);
            double acceleration = carCalculator.Calc_Car_Acceleration(carEngine.Torque, carGearbox.Gear_box_return_ratio(), wheel_radius, weight, carRoad.Road_Get_Angle(), carRoad.Road_Get_Load_Coef(), air_drag_coef, carMovement.Speed, frontal_area);
            if(break_value != 0)
            {
                if (carMovement.Speed != 0)
                {
                    if (carMovement.Speed > 0)
                    {
                        acceleration -= break_value * 1000 / weight;
                    }
                    else if (carMovement.Speed < 0)
                    {
                        acceleration += break_value * 1000 / weight;
                    }
                }
                else
                {
                    acceleration = 0;
                }
            }
            carMovement.Movement_Refresh(wheel_direction, carRoad.Road_Get_Angle(), acceleration, tim_in_sec, break_value);
            carPosition.Position_refresh_position(carMovement.Delta_x, carMovement.Delta_y, carMovement.Delta_z);
            carRoad.Road_Refresh_Tile(carPosition);
            if(carRoad.Road_IsBlocked)
            {
                carMovement.Speed = 0;
            }
        }

        public void Car_Refresh_Pedals(double accelerator, double break_v)
        {
            accelerator_value = accelerator;
            break_value = break_v;
        }

        public void Car_Set_Pedals_for_desired_speed()
        {
            if(carMovement.Speed < desired_speed)
            {
                break_value = 0;
                if (carMovement.Speed < (desired_speed-0.5))
                {
                    accelerator_value = 0.5;
                }
                else
                {
                    accelerator_value = 0.15;
                }
            }
            else
            {
                accelerator_value = 0;
                if (carMovement.Speed > (desired_speed + 2))
                {
                    break_value = 0.5;
                }
                else
                {
                    break_value = 0.05;
                }
            }
        }
        public void Car_Change_Gear(int new_gear)
        {
            carGearbox.Gear_box_change_gear(new_gear);
        }
        public void Car_Change_Direction(double wheel)
        {
            if(wheel > 30)
            {
                wheel = 30;
            }
            else if(wheel < -30)
            {
                wheel = -30;
            }
            wheel_direction = wheel;
        }
        public double Car_Get_Direction()
        {​​​​​​
            return carMovement.Direction;
        }​​​​​​

        public double Car_Get_XPos()
        {
            return carPosition.Pos_x;
        }
        public double Car_Get_YPos()
        {
            return carPosition.Pos_y;
        }
        public double Car_Get_Speed()
        {
            return carMovement.Speed;
        }

        public void Car_Reset()
        {
            carPosition.Pos_x = 126;
            carPosition.Pos_y = 126;
            carRoad.Road_Refresh_Tile(carPosition);
            for (int x = 0; x < carGearbox.Number_of_gear - 1; x++)
            {
                carGearbox.Gear_box_change_gear(0);
            }
            carEngine.Rpm = 0;
            carMovement.Speed = 0;
            carMovement.Direction = 0;
            carMovement.Acceleration = 0;
            carMovement.Movement_Refresh(0, 0, 0, 1, 0);



            accelerator_value = 0;
            break_value = 0;
            desired_speed = 0;
            wheel_direction = 0;
        }
    }
}
