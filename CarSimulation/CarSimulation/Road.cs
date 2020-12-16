using System;
using System.Collections.Generic;
using System.Text;

namespace CarSimulation
{
    class Road
    {

        public Road(double tile_x = 1.0, double tile_y = 1.0, double x = 0.0, double y = 0.0)
        {
            Random rand = new Random();
            tile_size_x = tile_x;
            tile_size_y = tile_y;
            size_x = x;
            size_y = y;
            x_max = (int)(size_x / tile_size_x) - 1;
            y_max = (int)(size_y / tile_size_y) - 1;
            road = new Tile[(int)(size_x / tile_size_x), (int)(size_y / tile_size_y)];
            for(int i = 0; i < (int)(size_x / tile_size_x); i++ )
            {
                for (int j = 0; j < (int)(size_y / tile_size_y); j++)
                {
                    road[i, j] = new Tile();
                    if (i == x_max || j == y_max || i == 0 || j == 0)
                    {
                        road[i, j].Blocked = true;
                    }
                    else
                    {
                        road[i, j].Blocked = false;
                    }
                    road[i, j].Road_angle = ((double)rand.Next(1,200))/10;
                    road[i, j].Road_load_coef = ((double)rand.Next(1, 4))/100;
                }
            }

        }


        Tile[,] road;
        Tile road_actualtile;
        double tile_size_x;
        double tile_size_y;
        double size_x;
        double size_y;
        int x_max;
        int y_max;
        int x_actual;
        int y_actual;
        public double Size_x
        {
            get { return size_x; }
            set { size_x = value; }
        }
        public double Size_y
        {
            get { return size_y; }
            set { size_y = value; }
        }

        public bool Road_IsBlocked
        {
            get { return road_actualtile.Blocked;  }
        }

        public double Road_Get_Angle()
        {
            return road_actualtile.Road_angle;
        }
        public double Road_Get_Load_Coef()
        {
            return road_actualtile.Road_load_coef;
        }
        public void Road_Refresh_Tile(Position actual_pos)
        {
            x_actual = (int)(actual_pos.Pos_x / tile_size_x) - 1;
            if(x_actual > x_max)
            {
                x_actual = x_max;
                actual_pos.Pos_x = x_max;
            }
            else if(x_actual < 0)
            {
                x_actual = 0;
                actual_pos.Pos_x = 0;
            }
            y_actual = (int)(actual_pos.Pos_y / tile_size_y) - 1;
            if (y_actual > y_max)
            {
                y_actual = y_max;
                actual_pos.Pos_y = y_max;
            }
            else if (y_actual < 0)
            {
                y_actual = 0;
                actual_pos.Pos_y = 0;
            }
            road_actualtile = road[x_actual, y_actual];
        }
    }
}
