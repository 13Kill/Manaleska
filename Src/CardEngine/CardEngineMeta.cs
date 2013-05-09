using CardEngine.Interfaces;
using CardEngine.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardEngine
{
    public static class CardEngineMeta
    {
        public static IEngine CreateEngine()
        {
            return new Engine();
        }
    }
}
