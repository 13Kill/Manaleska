#region

using CardEngine.Interfaces;
using CardEngine.Logic;

#endregion

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