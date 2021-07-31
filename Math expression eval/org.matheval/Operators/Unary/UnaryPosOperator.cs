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
using org.matheval.Common;
using System;

namespace org.matheval.Operators.Unary
{
    /// <summary>
    /// Unary positive operator
    /// Examples:
    /// 3++2-+4 -> 1
    /// </summary>
    public class UnaryPosOperator : AbstractUnaryOperator
    {
        /// <summary>
        /// Initializes a new instance structure to a specified type string value and type int value
        /// </summary>
        /// <param name="op">op</param>
        /// <param name="precedence">precedence</param>
        public UnaryPosOperator(string op, int precedence) : base(op, precedence)
        {
        }

        /// <summary>
        /// Calculate
        /// </summary>
        /// <param name="left">left</param>
        /// <param name="right">right</param>
        /// <param name="dc">dc</param>
        /// <returns>Calculate value</returns>
        public override object Calculate(object left, object right, ExpressionContext dc)
        {
            base.Calculate(left, right, dc);
            if (left is decimal)
            {
                decimal retValue = +(decimal)left;
                return retValue;
            }
            throw new Exception(Afe_Common.MSG_UNARY_INVALID);
        }
    }
}
