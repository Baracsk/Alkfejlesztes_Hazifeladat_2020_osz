using System;
using System.Collections.Generic;
using System.Text;

namespace CarSimulation
{
    class Movement
    {

        public Movement(double base_speed = 0.0, double base_acceleration = 0.0, double base_direction = 0.0, double base_dx = 0.0, double base_dy = 0.0, double base_dz = 0.0)
        {
            speed = base_speed;
            acceleration = base_acceleration;
            direction = base_direction;
            delta_x = base_dx;
            delta_y = base_dy;
            delta_z = base_dz;
        }


        double speed;
        double acceleration;
        double direction;
        double delta_x;
        double delta_y;
        double delta_z;

        public double Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        public double Acceleration
        {
            get { return acceleration; }
            set { acceleration = value; }
        }
        public double Delta_x
        {
            get { return delta_x; }
            set { delta_x = value; }
        }
        public double Delta_y
        {
            get { return delta_y; }
            set { delta_y = value; }
        }
        public double Delta_z
        {
            get { return delta_z; }
            set { delta_z = value; }
        }

        public void Movement_Refresh(double wheel_angle, double road_angle, double new_acceleration, int time_in_sec, double break_value)
        {
            delta_x = Math.Cos(direction) * speed * time_in_sec;
            delta_y = Math.Sin(direction) * speed * time_in_sec;
            delta_z = Math.Sin(road_angle) * speed * time_in_sec;
            if(break_value == 0)
            {
                speed += acceleration * time_in_sec;
            }
            else
            {
                if(speed>0)
                {
                    speed += acceleration * time_in_sec;
                    if(speed<0)
                    {
                        speed = 0;
                    }
                }
                if (speed < 0)
                {
                    speed += acceleration * time_in_sec;
                    if (speed > 0)
                    {
                        speed = 0;
                    }
                }
            }

            direction = direction + wheel_angle;

            acceleration = new_acceleration;
        }
    }
}
