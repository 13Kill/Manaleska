#region

using Lidgren.Network;

#endregion

namespace Framework.Network
{
    public interface IGameMessage
    {
        short Opcode { get; }

        void Decode(NetIncomingMessage im);
        void Encode(NetOutgoingMessage om);
    }
}