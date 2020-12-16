using System;
using System.Collections.Generic;
using System.Text;

namespace CarSimulation
{
    class Position
    {

        public Position(double posx_base = 0.0, double posy_base = 0.0, double posz_base = 0.0)
        {
            pos_x = posx_base;
            pos_y = posy_base;
            pos_z = posz_base;
        }


        double pos_x;
        double pos_y;
        double pos_z;
        public double Pos_x
        {
            get { return pos_x; }
            set { pos_x = value; }
        }
        public double Pos_y
        {
            get { return pos_y; }
            set { pos_y = value; }
        }
        public double Pos_z
        {
            get { return pos_z; }
            set { pos_z = value; }
        }

        public void Position_refresh_position(double delta_x, double delta_y, double delta_z)
        {
            pos_x += delta_x;
            pos_y += delta_y;
            pos_z += delta_z;
        }
    }
}
