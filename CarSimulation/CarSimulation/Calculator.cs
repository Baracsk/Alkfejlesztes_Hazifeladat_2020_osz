using System;
using System.Collections.Generic;
using System.Text;


namespace CarSimulation
{
    class Calculator
    {
        private double Calc_Traction_Force(double Torque, double ratio, int wheel_radius)
        {
            double returnValue = 0.0;
            returnValue = Torque * ratio / ((double)wheel_radius)/100;
            return returnValue;
        }
        private double Calc_Road_Slope_Force(int mass, double road_angle)
        {
            double returnValue = 0.0;
            returnValue = (double)mass * System.Math.Sin(road_angle) * 9.81 ;
            return returnValue;
        }
        private double Calc_Road_load_Force(int mass, double road_angle, double road_load_coef)
        {
            double returnValue = 0.0;
            returnValue = (double)mass * System.Math.Cos(road_angle) * 9.81 * road_load_coef;
            return returnValue;
        }
        private double Calc_aerodynamic_resistance_Force(double air_drag_coef, double speed, int Frontal_area)
        {
            double returnValue = 0.0;
            returnValue = (double)Frontal_area * speed * speed * air_drag_coef * 1.2 * 0.5;
            return returnValue;
        }
        private double Calc_acceleration(double AeroDyn_Res_F, double Road_Slope_F, double Road_Load_F, double Traction_F, int mass)
        {
            double returnValue = 0.0;
            returnValue = (Traction_F - (Road_Slope_F + Road_Load_F + AeroDyn_Res_F)) / (double)mass;
            return returnValue;
        }
        public double Calc_Car_Acceleration(double Torque, double ratio, int wheel_radius, int mass, double road_angle, double road_load_coef, double air_drag_coef, double speed, int Frontal_area)
        {
            double traction_force = Calc_Traction_Force(Torque, ratio, wheel_radius);
            double road_slope_force = Calc_Road_Slope_Force(mass, road_angle)/100;
            double road_load_force = Calc_Road_load_Force(mass, road_angle, road_load_coef)/100;
            double aerodynamic_res_force = Calc_aerodynamic_resistance_Force(air_drag_coef, speed, Frontal_area)/100;
            double acceleration = Calc_acceleration(aerodynamic_res_force, road_slope_force, road_load_force, traction_force, mass);
            return acceleration;
        }
    }
}
