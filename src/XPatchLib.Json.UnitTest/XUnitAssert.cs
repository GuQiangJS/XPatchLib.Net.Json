﻿// Copyright © 2013-2017 - GuQiang
// Licensed under the LGPL-3.0 license. See LICENSE file in the project root for full license information.


#if XUNIT
using System;
using System.Globalization;
using Xunit;

namespace XPatchLib.Json.UnitTest
{
    internal class XUnitAssert
    {
        public static void IsInstanceOf(Type expectedType, object o)
        {
            Assert.IsType(expectedType, o);
        }

        public static void IsInstanceOf<T>(object o)
        {
            Assert.IsType(typeof(T), o);
        }

        public static void AreEqual(double expected, double actual, double r)
        {
            Assert.Equal(expected, actual, 5); // hack
        }

        public static void AreEqual(object expected, object actual, string message = null)
        {
            Assert.Equal(expected, actual);
        }

        public static void AreEqual<T>(T expected, T actual, string message = null)
        {
            Assert.Equal(expected, actual);
        }

        public static void AreNotEqual(object expected, object actual, string message = null)
        {
            Assert.NotEqual(expected, actual);
        }

        public static void AreNotEqual<T>(T expected, T actual, string message = null)
        {
            Assert.NotEqual(expected, actual);
        }

        public static void Fail(string message = null, params object[] args)
        {
            if (message != null)
                message = string.Format(CultureInfo.InvariantCulture, message, args);

            Assert.True(false, message);
        }

        public static void Pass()
        {
        }

        public static void IsTrue(bool condition, string message = null)
        {
            Assert.True(condition);
        }

        public static void IsFalse(bool condition)
        {
            Assert.False(condition);
        }

        public static void IsNull(object o)
        {
            Assert.Null(o);
        }

        public static void IsNotNull(object o)
        {
            Assert.NotNull(o);
        }

        public static void IsNull(object o, string message, params object[] args)
        {
            IsNull(o);
        }

        public static void IsNotNull(object o, string message, params object[] args)
        {
            IsNotNull(o);
        }

        public static void AreNotSame(object expected, object actual)
        {
            Assert.NotSame(expected, actual);
        }

        public static void AreSame(object expected, object actual)
        {
            Assert.Same(expected, actual);
        }

        public static TException Throws<TException>(Action action, params string[] possibleMessages)
            where TException : Exception
        {
            try
            {
                action();

                Fail("Exception of type {0} expected. No exception thrown.", typeof(TException).Name);
                return null;
            }
            catch (TException ex)
            {
                if (possibleMessages == null || possibleMessages.Length == 0)
                    return ex;
                foreach (string possibleMessage in possibleMessages)
                    if (string.Equals(possibleMessage, ex.Message))
                        return ex;

                throw new Exception("Unexpected exception message." + Environment.NewLine + "Expected one of: " +
                                    string.Join(Environment.NewLine, possibleMessages) + Environment.NewLine + "Got: " +
                                    ex.Message + Environment.NewLine + Environment.NewLine + ex);
            }
            catch (Exception ex)
            {
                throw new Exception(
                    string.Format("Exception of type {0} expected; got exception of type {1}.", typeof(TException).Name,
                        ex.GetType().Name), ex);
            }
        }
    }
}
#endif