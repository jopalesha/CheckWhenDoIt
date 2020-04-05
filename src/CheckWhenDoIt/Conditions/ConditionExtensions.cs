using System;

namespace Jopalesha.CheckWhenDoIt.Conditions
{
    public static class ConditionExtensions
    {
        public static void Do(this ICondition condition, Action action)
        {
            if (condition.IsTrue)
            {
                action();
            }
        }

        public static bool TryDo(this ICondition condition, Action action)
        {
            return TryDo(condition, action, It.DoNothing);
        }

        public static bool TryDo(this ICondition condition, Action action, Action<Exception> logAction)
        {
            if (condition.IsTrue)
            {
                try
                {
                    action();
                    return true;
                }
                catch (Exception e)
                {
                    logAction(e);
                    return false;
                }
            }

            return false;
        }


        public static T Return<T>(this ICondition condition, Func<T> function)
        {
            return condition.IsTrue ? function() : default;
        }

        public static T Return<T>(this ICondition condition, T value)
        {
            return condition.IsTrue ? value : default;
        }

        public static IConditionResult<T> Then<T>(this ICondition condition, T value)
        {
            return new ConditionResult<T>(value, condition.IsTrue);
        }

        public static T Else<T>(this IConditionResult<T> condition, T value)
        {
            return condition.IsTrue ? condition.Value : value;
        }

        public static T ElseThrows<T>(this IConditionResult<T> condition)
        {
            return condition.ElseThrows(new ArgumentException("Condition is not true", nameof(condition)));
        }

        public static T ElseThrows<T>(this IConditionResult<T> condition, Exception exception)
        {
            if (condition.IsTrue)
            {
                return condition.Value;
            }

            throw exception;
        }
    }
}
