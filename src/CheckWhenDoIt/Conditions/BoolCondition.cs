namespace Jopalesha.CheckWhenDoIt.Conditions
{
    public class BoolCondition : ICondition
    {
        public BoolCondition(bool value)
        {
            IsTrue = value;
        }

        public bool IsTrue { get; }
    }
}
