#region

using CardEngine.Interfaces;
using CardEngine.Model;

#endregion

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