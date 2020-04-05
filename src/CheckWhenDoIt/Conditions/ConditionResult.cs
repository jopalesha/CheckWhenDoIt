namespace Jopalesha.CheckWhenDoIt.Conditions
{
    public class ConditionResult<T> : IConditionResult<T>
    {
        public ConditionResult(T value, bool isTrue)
        {
            Value = value;
            IsTrue = isTrue;
        }

        public T Value { get; }

        public bool IsTrue { get; }
    }
}