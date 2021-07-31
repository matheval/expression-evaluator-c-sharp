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
    /// Definition for MINUS(-) operator
    /// Examples:
    /// 1-2 -> -1
    /// VALUE("1")-VALUE("2") -> -1
    /// ---+(-(++-2)) -> -2
    /// TIME(10,10,0)-TIME(9,2,0) -> 01:08:00
    /// DATE(2021,2,28)-DATETIME(2021,2,21,23,0,0) -> 6.04167 (days)
    /// DATETIME(2021,2,28,15,50,0)-DATETIME(2021,2,21,23,0,0) -> 6.70139 (days)
    /// DATETIME(2021,2,28,15,50,0)-TIME(2,10,0) -> 2021-02-28 04:40:00 ( gio GMT)
    /// </summary>
    public class MinusOperator : AbstractBinOperator
    {
        /// <summary>
        /// Initializes a new instance structure to a specified type string value and type int value and value assoc
        /// </summary>
        /// <param name="op">op</param>
        /// <param name="precedence">precedence</param>
        /// <param name="assoc">assoc</param>
        public MinusOperator(string op, int precedence, Assoc assoc) : base(op, precedence, assoc)
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

            if (Common.Afe_Common.IsNumber(left) && Common.Afe_Common.IsNumber(right))
            {
                decimal leftDecimal = Afe_Common.ToDecimal(left);
                decimal rightDecimal = Afe_Common.ToDecimal(right);
                return decimal.Subtract(leftDecimal, rightDecimal);
            }
            throw new Exception(string.Format(MSG_WRONG_OP_PARAM_EX, new string[] { "MINUS", "numeric" }));
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
                && (typeRight.Equals(typeof(decimal))|| typeRight.Equals(typeof(object))))
            {
                return typeof(decimal);
            }
            return null;
        }
    }
}
