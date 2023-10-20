/*
    The MIT License

    Copyright (c) 2021 MathEval.org

    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in
    all copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
    THE SOFTWARE.
*/
using Microsoft.VisualStudio.TestTools.UnitTesting;
using org.matheval;
using org.matheval.Common;
using System;
using System.Globalization;

namespace UnitTest
{
    [TestClass]
    public class Afe_CommonTests
    {
        [TestMethod]
        public void ReturnsDateTime()
        {
            CultureInfo dc = new CultureInfo("en-US");
            var dateTimeString = "2023-01-01";
            Assert.IsInstanceOfType(Afe_Common.ToDateTime(dateTimeString, dc), typeof(DateTime));
            
            dateTimeString = "2023-01-01 12:12:12";
            Assert.IsInstanceOfType(Afe_Common.ToDateTime(dateTimeString, dc), typeof(DateTime));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ToDateTimeArgumentException()
        {
            CultureInfo dc = new CultureInfo("en-US");
            Afe_Common.ToDateTime("12:12:12", dc);
        }

        [TestMethod]
        public void TimeValidationReturnsDateTime()
        {
            DateTime dateTime= DateTime.Parse("2023-01-01 12:12:12");
            Assert.AreEqual(Afe_Common.TimeValidation(dateTime), dateTime);

            dateTime = DateTime.Parse("12:12:12");
            Assert.AreEqual(Afe_Common.TimeValidation(dateTime), dateTime);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TimeValidationTimeArgumentException()
        {
           DateTime dateTime = DateTime.Parse("2023-01-01");
           Afe_Common.TimeValidation(dateTime);
        }
    }
}

