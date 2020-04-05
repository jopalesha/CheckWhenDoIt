using System;

namespace Jopalesha.CheckWhenDoIt
{
    public static class It
    {
        public static void DoNothing() { }
        
        public static void DoNothing<T>(T value) { }
        
        public static void DoNothing<T1, T2>(T1 value1, T2 value2) { }
        
        public static void DoNothing<T1, T2, T3>(T1 value1, T2 value2, T3 value3) { }
        
        public static void DoNothing<T1, T2, T3,T4>(T1 value1, T2 value2, T3 value3, T4 value4) { }

        public static void DoNothing<T1, T2, T3, T4,T5>(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5) { }

        public static Func<T, bool> InBounds<T>(T min, T max) where T : IComparable<T> => it => it.CompareTo(min) >= 0 && it.CompareTo(max) <= 0;

        public static Func<T, bool> Greater<T>(T value) where T : IComparable<T> => it => it.CompareTo(value) > 0;

        public static Func<T, bool> Less<T>(T value) where T : IComparable<T> => it => it.CompareTo(value) < 0;

        public static class IsPositive
        {
            public static Func<int, bool> Integer => it => it > 0;

            public static Func<double, bool> Double => it => it > 0;

            public static Func<float, bool> Float => it => it > 0;

            public static Func<long, bool> Long => it => it > 0;
        }

        public static class IsNatural
        {
            public static Func<int, bool> Integer => it => it >= 0;
        }
    }
}
