﻿using NUnit.Framework;
using SuccincT.Parsers;
using static NUnit.Framework.Assert;

namespace SuccincTTests.SuccincT.BasicTypesParsers
{
    /// <summary>
    /// Defines a set of tests for the extension methods in the FloatParsers sealed class.
    /// </summary>
    [TestFixture]
    public sealed class FloatParsersTests
    {
        [Test]
        public void ValidFloatString_ResultsInValue()
        {
            var result = "6.7567E20".ParseFloat();
            AreEqual(6.7567E20f, result.Value);
        }

        [Test]
        public void ValidFloatString_ResultsInHasValue()
        {
            var result = "6.7567E20".ParseFloat();
            IsTrue(result.HasValue);
        }

        [Test]
        public void ValidNegativeFloatString_ResultsInValue()
        {
            var result = "-1.78".ParseFloat();
            AreEqual(-1.78f, result.Value);
        }

        [Test]
        public void ValidNegativeFloatString_ResultsInHasValue()
        {
            var result = "-1.78".ParseFloat();
            IsTrue(result.HasValue);
        }

        [Test]
        public void ValidIntString_ResultsInValue()
        {
            var result = "27".ParseFloat();
            AreEqual(27, result.Value);
        }

        [Test]
        public void ValidIntString_ResultsInHasValue()
        {
            var result = "27".ParseFloat();
            IsTrue(result.HasValue);
        }

        [Test]
        public void InvalidFloatString_ResultsInNone()
        {
            var result = "1.1.1.1.1".ParseFloat();
            IsFalse(result.HasValue);
        }

        [Test]
        public void ValidDoubleString_ResultsInValue()
        {
            var result = "5.0E-324".ParseDouble();
            AreEqual(5.0E-324d, result.Value);
        }

        [Test]
        public void ValidDoubleString_ResultsInHasValue()
        {
            var result = "5.0E-324".ParseDouble();
            IsTrue(result.HasValue);
        }

        [Test]
        public void InvalidDoubleString_ResultsInNone()
        {
            var result = "8.0E400".ParseDouble();
            IsFalse(result.HasValue);
        }

        [Test]
        public void NonNumberDoubleString_ResultsInNone()
        {
            var result = "hello".ParseDouble();
            IsFalse(result.HasValue);
        }

        [Test]
        public void ValidDecimalString_ResultsInValue()
        {
            var result = "12345678901234567890124567".ParseDecimal();
            AreEqual(12345678901234567890124567m, result.Value);
        }

        [Test]
        public void ValidDecimalString_ResultsInHasValue()
        {
            var result = "12345678901234567890124567".ParseDecimal();
            IsTrue(result.HasValue);
        }

        [Test]
        public void InvalidDecimalString_ResultsInNone()
        {
            var result = "8.1E10".ParseDecimal();
            IsFalse(result.HasValue);
        }
    }
}