﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardEngine.Interfaces;

namespace CardEngine.Logic
{
    public class Card : ICard
    {
        public string Name
        {
            get;
            set;
        }
    }
}
