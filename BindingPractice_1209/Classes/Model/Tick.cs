using System;
using System.Timers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotInterfaceApp.Classes

{ }
    /*class TickSource
    {
        private Timer timer;
        private readonly IEnvironment env;

        public TickSource(IEnvironment env, int timerIntervalsMS)
        {
            timer = new Timer(timerIntervalsMS);
            timer.Elapsed += Timer_Elapsed;
            this.env = env;
        }

        public void Start()
        {
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            env.Tick();
        }
    }
}
    */