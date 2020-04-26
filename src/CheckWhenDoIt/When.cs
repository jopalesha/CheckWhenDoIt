using System;
using System.Collections;
using System.Collections.Generic;
using Jopalesha.CheckWhenDoIt.Conditions;
using Jopalesha.CheckWhenDoIt.Helpers;

namespace Jopalesha.CheckWhenDoIt
{
    public static class When
    {
        public static ICondition True(bool condition)
        {
            return new BoolCondition(condition);
        }

        public static ICondition False(bool condition)
        {
            return new BoolCondition(!condition);
        }

        public static ICondition NotEmpty(string value)
        {
            return new BoolCondition(!string.IsNullOrWhiteSpace(value));
        }

        public static ICondition NotEmpty(IEnumerable value)
        {
            return new BoolCondition(!value.IsNullOrEmpty());
        }

        public static ICondition InBounds<T>(T value, T min, T max) where T : IComparable<T> =>
            new BoolCondition(It.InBounds(min, max)(value));

        public static ICondition NotNull<T>(T value)
        {
            return new BoolCondition(value != null);
        }

        public static ICondition In<T>(T value, IEnumerable<T> values)
        {
            return new BoolCondition(value.In(values));
        }

        public static ICondition Equals<T>(T value, T equalValue)
        {
            return Equals(value, equalValue, Comparer<T>.Default);
        }

        public static ICondition NotEquals<T>(T value, T notEqualValue)
        {
            return NotEquals(value, notEqualValue, Comparer<T>.Default);
        }

        public static ICondition NotEquals<T>(T value, T equalValue, IComparer<T> comparer)
        {
            return new BoolCondition(Check.NotNull(comparer).Compare(value, equalValue) != 0);
        }

        public static ICondition Equals<T>(T value, T equalValue, IComparer<T> comparer)
        {
            return new BoolCondition(Check.NotNull(comparer).Compare(value, equalValue) == 0);
        }

        public static ICondition Greater<T>(T value, T less) where T : IComparable<T>
        {
            return new BoolCondition(It.Greater(less)(value));
        }

        public static ICondition Less<T>(T value, T greater) where T : IComparable<T>
        {
            return new BoolCondition(It.Less(greater)(value));
        }
    }
}
