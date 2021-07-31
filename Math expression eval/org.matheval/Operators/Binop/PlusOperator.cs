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
using static org.matheval.Common.Afe_Common;

namespace org.matheval.Operators.Binop
{
    /// <summary>
    /// Definition for PLUS(+) operator
    /// Examples:
    /// 1+2.5 -> 3.5
    /// "abc"+"def" -> abcdef
    /// "abc"+ 123 -> abc123
    /// TIME(10,10,0)+TIME(10,10,0) -> 20:20:00
    /// DATETIME(2021,03,30,10,10,0)+(1/1440/60) -> 2021-03-30 01:10:01 (GMT time), 2021-03-30 10:10:01 (local time)
    /// DATE(2021,03,30)+(1/1440/60) -> 2021-03-29 15:00:01 (GMT time), 2021-03-30 00:00:01(Local time)
    /// </summary>
    public class PlusOperator : AbstractBinOperator
    {
        /// <summary>
        /// Initializes a new instance structure to a specified type string value and type int value and value assoc
        /// </summary>
        /// <param name="op">op</param>
        /// <param name="precedence">precedence</param>
        /// <param name="assoc">assoc</param>
        public PlusOperator(string op, int precedence, Assoc assoc) : base(op, precedence, assoc)
        {
        }

        /// <summary>
        /// Calculate result
        /// </summary>
        /// <param name="left">left</param>
        /// <param name="right">right</param>
        /// <param name="dc">dc</param>
        /// <returns>value Calculate</returns>
        public override object Calculate(object left, object right, ExpressionContext dc)
        {

            if (Afe_Common.IsNumber(left) && Afe_Common.IsNumber(right))
            {
                decimal leftDecimal = Afe_Common.ToDecimal(left);
                decimal rightDecimal = Afe_Common.ToDecimal(right);
                return decimal.Add(leftDecimal, rightDecimal);
            }
            else if (left is string || right is string)
            {
                if(left is decimal)
                {
                    left = Afe_Common.Round(left, dc);
                }
                if (right is decimal)
                {
                    right = Afe_Common.Round(right, dc);
                }
                return left.ToString() + right.ToString();
            }
            throw new Exception(string.Format(MSG_WRONG_OP_PARAM_EX, new string[] { "PLUS", "numeric, string, date" }));
        }

        /// <summary>
        /// Validate
        /// </summary>
        /// <param name="typeLeft">typeLeft</param>
        /// <param name="typeRight">typeRight</param>
        /// <returns>Type</returns>
        public override Type Validate(Type typeLeft, Type typeRight)
        {
            if (
                (typeLeft.Equals(typeof(object)) && typeRight.Equals(typeof(object))) ||
                (typeLeft.Equals(typeof(object)) && typeRight.Equals(typeof(decimal)))
                )
            {
                return typeof(object);
            }

            if ((typeLeft.Equals(typeof(decimal)) || typeLeft.Equals(typeof(object)))
                && (typeRight.Equals(typeof(decimal)) || typeRight.Equals(typeof(object))))
            {
                return typeof(decimal);
            }
            else if (typeLeft.Equals(typeof(string)) || typeRight.Equals(typeof(string)))
            {
                return typeof(string);
            }
            return null;
        }
    }
}
