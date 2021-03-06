﻿using System;
using Jopalesha.CheckWhenDoIt.Conditions;
using Xunit;

namespace Jopalesha.CheckWhenDoIt.Tests
{
    public class WhenTests
    {
        [Fact]
        public void When_ReturnsExpected()
        {
            Assert.True(When.True(true).Return(true));
            Assert.False(When.True(false).Return(true));
        }

        [Fact]
        public void WhenThenElse_ReturnsExpected()
        {
            Assert.True(When.True(true).Then(true).Else(false));
            Assert.False(When.True(false).Then(true).Else(false));
        }

        [Fact]
        public void WhenThenElseThrows_ReturnsExpected()
        {
            Assert.True(When.True(true).Then(true).ElseThrows());
            Assert.Throws<ArgumentException>(() => When.True(false).Then(true).ElseThrows());
            Assert.Throws<CustomException>(() => When.True(false).Then(true).ElseThrows(new CustomException()));
        }

        [Fact]
        public void WhenDo_ReturnsExpected()
        {
            var value = string.Empty;
            When.True(true).Do(() => value = "test");
            Assert.NotEmpty(value);
            When.True(false).Do(() => throw new ArgumentException());
            Assert.Throws<ArgumentException>(() => When.True(true).Do(() => throw new ArgumentException()));
        }

        [Fact]
        public void WhenTryDo_ReturnsExpected()
        {
            Assert.True(When.True(true).TryDo(It.DoNothing));
            Assert.False(When.True(true).TryDo(() => throw new ArgumentNullException()));
            Assert.False(When.True(false).TryDo(It.DoNothing));
        }

        [Fact]
        public void WhenEquals_ReturnsExpected()
        {
            Assert.True(When.Equals(1, 1).Return(true));
            Assert.True(When.Equals("abc", "ABC", StringComparer.OrdinalIgnoreCase).Return(true));
            Assert.False(When.Equals(1, 2).Return(true));
        }

        [Fact]
        public void WhenNotEquals_ReturnsExpceted()
        {
            Assert.True(When.NotEquals(1, 2).Return(true));
            Assert.True(When.NotEquals("abc", "ABC", StringComparer.Ordinal).Return(true));
            Assert.False(When.NotEquals(1, 1).Return(true));
        }
    }
}
