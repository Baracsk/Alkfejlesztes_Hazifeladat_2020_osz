using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotDiagnosticApp
{
    // this class contains all the constants used in te project
    static class Constants
    {
        //scale for accelerating and for absolute position
        public const int SPEED_CHANGE_SCALE = 10;
        public const int MAX_SPEED = 50;

        //offset for the minimap
        public const int CENTERX_OFFSET = 145;
        public const int CENTERY_OFFSET = 140;
        
        //Value for the system ticksource
        public const int SYSTEM_TICK_MS = 100;
    }
}
