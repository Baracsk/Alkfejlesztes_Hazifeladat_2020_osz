using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindingPractice_1209.Classes
{
    class DefaultEnvironment : IEnvironment
    {
        public event OnTickDelegate onTick;

        public void Tick()
        {
            onTick?.Invoke();
        }
    }
}
