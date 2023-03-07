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
    public class EDateFunctionTest
    {
        [TestMethod]
        public void AddMonthsToDate()
        {
            Expression expression = new Expression("edate('05/30/2022 04:50:45',5)");
            Assert.AreEqual("10/30/2022 04:50:45", expression.Eval());

            expression = new Expression("edate('05/30/2022',15)");
            Assert.AreEqual("08/30/2023 00:00:00", expression.Eval());
        }

        [TestMethod]
        public void SubtractMonthsFromDate()
        {
            Expression expression = new Expression("edate('05/30/2022 04:50:45',-5)");
            Assert.AreEqual("12/30/2021 04:50:45", expression.Eval());

            expression = new Expression("edate('05/30/2022',-1)");
            Assert.AreEqual("04/30/2022 00:00:00", expression.Eval());
        }
    }
}

