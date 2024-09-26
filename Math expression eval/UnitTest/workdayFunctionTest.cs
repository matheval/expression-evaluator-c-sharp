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

namespace UnitTest
{
    [TestClass]
    public class WorkDayFunctionTest
    {
        [TestMethod]
        public void ReturnDatePositiveWorkDay()
        {
            Expression expression = new Expression("workday('01/01/2023 04:50:45',3)");
            Assert.AreEqual("01/05/2023 04:50:45", expression.Eval());
            
            expression = new Expression("workday('01/01/2023',7)");
            Assert.AreEqual("01/11/2023 00:00:00", expression.Eval());
        }
            [TestMethod]
            public void ReturnDateNegativeWorkDay()
            {
                Expression expression = new Expression("workday('01/01/2023 04:50:45',-3)");
                Assert.AreEqual("12/27/2022 04:50:45", expression.Eval());

                expression = new Expression("workday('01/01/2023',-7)");
                Assert.AreEqual("12/21/2022 00:00:00", expression.Eval());
        }
    }
}
