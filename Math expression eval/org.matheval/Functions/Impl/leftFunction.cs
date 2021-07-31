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
using System.Collections.Generic;

namespace org.matheval.Functions
{
    /// <summary>
    /// Extracts a given number of characters from 
    /// the left side of a supplied text string
    /// Example:
    /// LEFT("abcd",3) -> abc
    /// </summary>
    public class leftFunction : IFunction
    {
        /// <summary>
        /// Get Information
        /// </summary>
        /// <returns>FunctionDefs</returns>
        public List<FunctionDef> GetInfo()
        {
            return new List<FunctionDef> { new FunctionDef(Afe_Common.Const_LEFT, new System.Type[] { typeof(string), typeof(decimal) }, typeof(string), 2) };
        }

        /// <summary>
        /// Execute
        /// </summary>
        /// <param name="args">args</param>
        /// <param name="dc">dc</param>
        /// <returns>Value</returns>
        public Object Execute(Dictionary<string, Object> args, ExpressionContext dc)
        {
            return this.Left(Afe_Common.ToString(args[Afe_Common.Const_Key_One]), Decimal.ToInt32(Afe_Common.ToDecimal(args[Afe_Common.Const_Key_Two])));
        }

        /// <summary>
        /// Formula Left
        /// </summary>
        /// <param name="stringValue">stringValue</param>
        /// <param name="count">count</param>
        /// <returns>Value Left</returns>
        private string Left(string stringValue, int count)
        {
            if (!string.IsNullOrEmpty(stringValue))
            {
                return stringValue.Substring(0, count > stringValue.Length ? stringValue.Length : count);
            }
            return string.Empty;
        }
    }
}
