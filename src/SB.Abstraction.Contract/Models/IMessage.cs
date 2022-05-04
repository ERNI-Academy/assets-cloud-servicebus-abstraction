namespace SB.Abstraction.Contract.Models
{
    public interface IMessage:IAbstractMessage
    {
        dynamic Value { get; }
    }
}
