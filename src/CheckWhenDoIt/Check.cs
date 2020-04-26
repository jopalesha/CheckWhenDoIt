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

        #region True

        public static T True<T>(
            T value,
            Func<T, bool> condition,
            string? paramName = null,
            string? message = IsNotTrueMessage)
        {
            True(NotNull(condition)(value), paramName, message);
            return value;
        }

        public static T True<T>(
            T value,
            Func<T, bool> condition,
            Exception exception)
        {
            True(NotNull(condition)(value), NotNull(exception));
            return value;
        }

        public static T True<T>(
            T value,
            bool condition,
            Exception exception)
        {
            True(condition, NotNull(exception));
            return value;
        }

        public static T True<T>(
            T value,
            bool condition,
            string? paramName = null,
            string? message = IsNotTrueMessage)
        {
            True(condition, paramName, message);
            return value;
        }

        public static void True(
            bool condition,
            string? paramName = null,
            string? message = IsNotTrueMessage)
        {
            True(condition, new ArgumentException(message, paramName));
        }

        public static void True(
            bool condition,
            Exception exception)
        {
            if (!condition) throw NotNull(exception);
        }

        #endregion

        #region False

        public static void False(
            bool condition,
            string? paramName = null,
            string? message = IsNotTrueMessage)
        {
            False(condition, new ArgumentException(message, paramName));
        }

        public static void False(
            bool condition,
            Exception exception) => True(!condition, exception);

        public static T False<T>(
            T value,
            Func<T, bool> condition,
            string? paramName = null,
            string? message = IsNotTrueMessage)
        {
            return False(value, condition, new ArgumentException(message, paramName));
        }

        public static T False<T>(
            T value,
            Func<T, bool> condition,
            Exception exception)
        {
            False(NotNull(condition)(value), NotNull(exception));
            return value;
        }

        public static T False<T>(
            T value,
            bool condition,
            string? paramName = null,
            string? message = IsNotTrueMessage)
        {
            return False(value, condition, new ArgumentException(message, paramName));
        }

        public static T False<T>(
            T value,
            bool condition,
            Exception exception)
        {
            False(condition, exception);
            return value;
        }

        #endregion

        #region IsPositive

        public static int IsPositive(int value, string? paramName = null, string? message = IsNotTrueMessage) =>
            True(value, It.IsPositive.Integer, paramName, message);

        public static double IsPositive(double value, string? paramName = null, string? message = IsNotTrueMessage) =>
            True(value, It.IsPositive.Double, paramName, message);

        public static double IsPositive(float value, string? paramName = null, string? message = IsNotTrueMessage) =>
            True(value, It.IsPositive.Float, paramName, message);

        public static double IsPositive(long value, string? paramName = null, string? message = IsNotTrueMessage) =>
            True(value, It.IsPositive.Long, paramName, message);

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
            return True(value, NotNull(comparer).Compare(value, equalValue) == 0, exception);
        }

        #endregion

        public static int IsNatural(int value, string? paramName = null, string? message = IsNotTrueMessage)
        {
            return True(value, It.IsNatural, paramName, message);
        }

        public static T InBounds<T>(
            T value,
            T min,
            T max,
            string? paramName = null,
            string? message = IsNotTrueMessage) where T : IComparable<T> =>
            True(value, It.InBounds(min, max), paramName, message);

        public static T NotNull<T>(
            T value,
            string? paramName = null,
            string? message = IsNullMessage) => NotNull(value, new ArgumentNullException(paramName, message));

        public static T NotNull<T>(
            T value,
            Exception exception) => value ?? throw exception;

        public static TEnumerable NotEmpty<TEnumerable>(
            TEnumerable values,
            string? paramName = null,
            string? message = IsEmptyMessage)
            where TEnumerable : IEnumerable => True(values, it => !it.IsNullOrEmpty(), paramName, message);

        public static string NotEmpty(
            string value,
            string? paramName = null,
            string? message = IsEmptyMessage) =>
            True(value, it => !string.IsNullOrWhiteSpace(it), paramName, message);

        public static T In<T>(
            T value,
            IEnumerable<T> values,
            string? paramName = null,
            string? message = "Collection does not contain value") =>
            True(value, it => it.In(NotNull(values)), paramName, message);

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
            return True(value, It.Greater(less), exception);
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
            return True(value, It.Less(greater), exception);
        }

        public static T NotDefault<T>(
            T value,
            string? paramName = null,
            string? message = IsNotTrueMessage)
        {
            return NotDefault(value, new ArgumentException(message, paramName));
        }

        public static T NotDefault<T>(
            T value,
            Exception exception)
        {
            return True(value, It.IsNotDefault<T>(), exception);
        }
    }
}
