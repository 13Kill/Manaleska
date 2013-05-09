using CardEngine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardEngine.Interfaces
{
    public interface IEngine
    {
        IPlayer CreatePlayer(PlayerCreationParameters creationParameteres);

    }
}
