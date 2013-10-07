#region

using CardEngine.Model;

#endregion

namespace CardEngine.Interfaces
{
    public interface IEngine
    {
        IPlayer CreatePlayer(PlayerCreationParameters creationParameteres);
    }
}