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
using System;
using static org.matheval.Common.Afe_Common;

namespace org.matheval.Operators.Binop
{
    /// <summary>
    /// Create class Or Operator implements AbstractBinOperator
    /// Example:
    /// (2>1)||(6>7) -> true
    /// </summary>
    public class OrOperator : AbstractBinOperator
    {
        /// <summary>
        /// Initializes a new instance structure to a specified type string value and type int value and Assoc value
        /// </summary>
        /// <param name="op">op</param>
        /// <param name="precedence">precedence</param>
        /// <param name="assoc">assoc</param>
        public OrOperator(string op, int precedence, Assoc assoc) : base(op, precedence, assoc)
        {
        }

        /// <summary>
        /// Calculate
        /// </summary>
        /// <param name="left">left</param>
        /// <param name="right">right</param>
        /// <param name="dc">dc</param>
        /// <returns>Calculate value or Exception</returns>
        public override object Calculate(object left, object right, ExpressionContext dc)
        {
            if (left is bool && right is bool)
            {
                return (bool)left == true || (bool)right == true;
            }
            throw new Exception(string.Format(MSG_WRONG_OP_PARAM_EX, new string[] { "Logical OR", "Boolean" }));
        }

        /// <summary>
        /// Validate
        /// </summary>
        /// <param name="typeLeft">typeLeft</param>
        /// <param name="typeRight">typeRight</param>
        /// <returns>Type Boolean or null</returns>
        public override Type Validate(Type typeLeft, Type typeRight)
        {
            if (
                (typeLeft.Equals(typeof(bool)) || typeLeft.Equals(typeof(object)))
                &&
                (typeRight.Equals(typeof(bool)) || typeRight.Equals(typeof(object)))
                )
            {
                return typeof(bool);
            }
            return null;
        }
    }
}
