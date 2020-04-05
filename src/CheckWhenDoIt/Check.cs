using System;
using System.Collections;
using System.Collections.Generic;
using Jopalesha.CheckWhenDoIt.Helpers;

namespace Jopalesha.CheckWhenDoIt
{
    public static class Check
    {
        private const string IsNullMessage = "Value is null";
        private const string IsEmptyMessage = "Value is null of empty";
        private const string IsNotTrueMessage = "Condition is not true";

        #region IsTrue

        public static T IsTrue<T>(
            T value,
            Func<T, bool> condition,
            string? paramName = null,
            string? message = IsNotTrueMessage)
        {
            IsTrue(NotNull(condition)(value), paramName, message);
            return value;
        }

        public static T IsTrue<T>(
            T value,
            Func<T, bool> condition,
            Exception exception)
        {
            IsTrue(NotNull(condition)(value), NotNull(exception));
            return value;
        }

        public static T IsTrue<T>(
            T value,
            bool condition,
            Exception exception)
        {
            IsTrue(condition, NotNull(exception));
            return value;
        }

        public static T IsTrue<T>(
            T value,
            bool condition,
            string? paramName = null,
            string? message = IsNotTrueMessage)
        {
            IsTrue(condition, paramName, message);
            return value;
        }

        public static void IsTrue(
            bool condition,
            string? paramName = null,
            string? message = IsNotTrueMessage)
        {
            IsTrue(condition, new ArgumentException(message, paramName));
        }

        public static void IsTrue(
            bool condition,
            Exception exception)
        {
            if (!condition) throw exception;
        }

        #endregion

        #region IsPositive

        public static int IsPositive(int value, string? paramName = null, string? message = IsNotTrueMessage) =>
            IsTrue(value, It.IsPositive.Integer, paramName, message);

        public static double IsPositive(double value, string? paramName = null, string? message = IsNotTrueMessage) =>
            IsTrue(value, It.IsPositive.Double, paramName, message);

        public static double IsPositive(float value, string? paramName = null, string? message = IsNotTrueMessage) =>
            IsTrue(value, It.IsPositive.Float, paramName, message);

        public static double IsPositive(long value, string? paramName = null, string? message = IsNotTrueMessage) =>
            IsTrue(value, It.IsPositive.Long, paramName, message);

        #endregion

        #region Equals

        public static T Equals<T>(
            T value,
            T equalValue,
            string? paramName = null,
            string? message = IsNotTrueMessage)
        {
            return Equals(value, equalValue, Comparer<T>.Default, paramName, message);
        }

        public static T Equals<T>(
            T value,
            T equalValue,
            IComparer<T> comparer,
            string? paramName = null,
            string? message = IsNotTrueMessage)
        {
            return Equals(value, equalValue, comparer, new ArgumentException(message, paramName));
        }

        public static T Equals<T>(
            T value,
            T equalValue,
            Exception exception)
        {
            return Equals(value, equalValue, Comparer<T>.Default, exception);
        }

        public static T Equals<T>(
            T value,
            T equalValue,
            IComparer<T> comparer,
            Exception exception)
        {
            return IsTrue(value, NotNull(comparer).Compare(value, equalValue) == 0, exception);
        }

        #endregion

        public static T InBounds<T>(
            T value,
            T min,
            T max,
            string? paramName = null,
            string? message = IsNotTrueMessage) where T : IComparable<T> =>
            IsTrue(value, It.InBounds(min, max), paramName, message);

        public static T NotNull<T>(
            T value,
            string? paramName = null,
            string? message = IsNullMessage) => value ?? throw new ArgumentNullException(paramName, message);

        public static TEnumerable NotEmpty<TEnumerable>(
            TEnumerable values,
            string? paramName = null,
            string? message = IsEmptyMessage)
            where TEnumerable : IEnumerable => IsTrue(values, it => !it.IsNullOrEmpty(), paramName, message);

        public static string NotEmpty(
            string value,
            string? paramName = null,
            string? message = IsEmptyMessage) =>
            IsTrue(value, it => !string.IsNullOrWhiteSpace(it), paramName, message);

        public static T In<T>(
            T value,
            IEnumerable<T> values,
            string? paramName = null,
            string? message = "Collection does not contain value") =>
            IsTrue(value, it => it.In(NotNull(values)), paramName, message);

        public static T Greater<T>(
            T value,
            T less,
            string? paramName = null,
            string? message = IsNotTrueMessage) where T : IComparable<T>
        {
            return Greater(value, less, new ArgumentException(message, paramName));
        }

        public static T Greater<T>(
            T value,
            T less,
            Exception exception) where T : IComparable<T>
        {
            return IsTrue(value, It.Greater(less), exception);
        }

        public static T Less<T>(
            T value,
            T greater,
            string? paramName = null,
            string? message = IsNotTrueMessage) where T : IComparable<T>
        {
            return Less(value, greater, new ArgumentException(message, paramName));
        }

        public static T Less<T>(
            T value,
            T greater,
            Exception exception) where T:IComparable<T>
        {
            return IsTrue(value, It.Less(greater), exception);
        }
    }
}
