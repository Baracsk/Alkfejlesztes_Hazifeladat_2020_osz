﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindingPractice_1209.Classes
{
    public interface IEnvironment
    {
        event OnTickDelegate onTick;

        void Tick();

    }

    public delegate void OnTickDelegate();
}