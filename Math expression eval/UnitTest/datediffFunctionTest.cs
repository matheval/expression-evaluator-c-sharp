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
using System;

namespace UnitTest
{
    [TestClass]
    public class DateDiffFunctionTest
    {
        [TestMethod]
        public void DayDifference()
        {
            Expression expression = new Expression("datediff('01/01/2023 04:50:45','02/05/2023 04:50:45','day')");
            Assert.AreEqual((decimal)35, expression.Eval());

            expression = new Expression("datediff('01/01/2023','01/01/2024','day')");
            Assert.AreEqual((decimal)365, expression.Eval());

            expression = new Expression("datediff('01/01/2023','04/11/2023','day')");
            Assert.AreEqual((decimal)100, expression.Eval());
        }

        [TestMethod]
        public void MonthDifference()
        {
            Expression  expression = new Expression("datediff('01/01/2023','03/03/2023','month')");
            Assert.AreEqual((decimal)2, expression.Eval());

            expression = new Expression("datediff('01/01/2023','04/25/2024','month')");
            Assert.AreEqual((decimal)15, expression.Eval());
        }

        [TestMethod]
        public void YearDifference()
        {
            Expression expression = new Expression("datediff('01/01/2023','07/01/2023','year')");
            Assert.AreEqual((decimal).50, expression.Eval());

            expression = new Expression("datediff('01/01/2023','04/25/2025','year')");
            Assert.AreEqual((decimal)2.25, expression.Eval());
        }
    }
}

