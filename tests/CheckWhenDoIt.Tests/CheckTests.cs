﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Jopalesha.CheckWhenDoIt.Tests
{
    public class CheckTests
    {
        [Fact]
        public void NotEmptyEnumerable_ReturnsExpected()
        {
            Assert.True(Check.NotEmpty(new List<int> { 5 }).Any());
            Assert.True(Check.NotEmpty(new Dictionary<int, int> { { 5, 5 } }).Any());
            Assert.Throws<ArgumentException>(() => Check.NotEmpty(Enumerable.Empty<int>()).Any());
            Assert.Throws<ArgumentException>(() => Check.NotEmpty((IEnumerable)null));
        }

        [Fact]
        public void NotEmptyString_ReturnsExpected()
        {
            Assert.True(!string.IsNullOrWhiteSpace(Check.NotEmpty("val")));
            Assert.Throws<ArgumentException>(() => Check.NotEmpty(null));
            Assert.Throws<ArgumentException>(() => Check.NotEmpty(""));
        }

        [Fact]
        public void IsTrue_ReturnsExpected()
        {
            Assert.True(Check.IsTrue(5, It.IsNatural.Integer) == 5);
            Assert.Throws<ArgumentException>(() => Check.IsTrue(false));
            Assert.Throws<CustomException>(() => Check.IsTrue(false, new CustomException()));
        }

        [Fact]
        public void InBounds_ReturnsExpected()
        {
            Assert.Equal(1, Check.InBounds(1, 1, 3));
            Assert.Equal(2, Check.InBounds(2, 1, 3));
            Assert.Equal(3, Check.InBounds(3, 1, 3));
            Assert.Throws<ArgumentException>(() => Check.InBounds(-1, 1, 3));
            Assert.Throws<ArgumentException>(() => Check.InBounds(4, 1, 3));
        }

        [Fact]
        public void IsPositive_ReturnsExpected()
        {
            Assert.Equal(1, Check.IsPositive(1));
            Assert.Equal(1.2, Check.IsPositive(1.2));
            Assert.Throws<ArgumentException>(() => Check.IsPositive(-2));
        }

        [Fact]
        public void Contains_ReturnsExpected()
        {
            var values = new[] { 1, 2, 3 };

            Assert.Equal(1, Check.In(1, values));
            Assert.Throws<ArgumentException>(() => Check.In(5, values));
        }

        [Fact]
        public void Equals_ReturnsExpected()
        {
            Assert.True(Check.Equals(true, true));
            Assert.Equal("val", Check.Equals("val", "Val", StringComparer.OrdinalIgnoreCase));
            Assert.Throws<ArgumentException>(() => Check.Equals(true, false));
            Assert.Throws<CustomException>(() => Check.Equals(true, false, new CustomException()));
        }

        [Fact]
        public void Greater_ReturnsExpected()
        {
            Assert.Equal(2, Check.Greater(2, 1));
            Assert.Throws<ArgumentException>(() => Check.Greater(2, 3));
            Assert.Throws<CustomException>(() => Check.Greater(2, 2, new CustomException()));
        }

        [Fact]
        public void Less_ReturnsExpected()
        {
            Assert.Equal(2, Check.Less(2, 3));
            Assert.Throws<ArgumentException>(() => Check.Less(2, 1));
            Assert.Throws<CustomException>(() => Check.Less(2, 2, new CustomException()));
        }
    }
}
