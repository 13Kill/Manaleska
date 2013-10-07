namespace CardEngine.Interfaces
{
    public interface IDeck
    {
        ICard this[int index] { get; }
    }
}