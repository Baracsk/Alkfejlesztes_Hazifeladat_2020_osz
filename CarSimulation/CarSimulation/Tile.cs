using System;
using System.Collections.Generic;
using System.Text;

namespace CarSimulation
{
    class Tile
    {

        public Tile(double angle = 0.0, double coef = 0.0, bool block = false)
        {
            road_angle = angle;
            road_load_coef = coef;
            blocked = block;
        }


        double road_angle;
        double road_load_coef;
        bool blocked;

        public bool Blocked
        {
            get { return blocked; }
            set { blocked = value; }
        }
        public double Road_angle
        {
            get { return road_angle; }
            set { road_angle = value; }
        }
        public double Road_load_coef
        {
            get { return road_load_coef; }
            set { road_load_coef = value; }
        }
    }
}
