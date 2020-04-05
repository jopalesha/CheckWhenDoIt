namespace Jopalesha.CheckWhenDoIt.Conditions
{
    public interface IConditionResult<out T> : ICondition
    {
        T Value { get; }
    }
}