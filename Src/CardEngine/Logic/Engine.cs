using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardEngine.Interfaces;
using CardEngine.Model;

namespace CardEngine.Logic
{
    public class Engine : IEngine
    {
        public IPlayer CreatePlayer(PlayerCreationParameters creationParameters)
        {
            return new Player();
        }
    }
}
