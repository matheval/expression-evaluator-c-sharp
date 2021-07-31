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
    /// Replaces characters specified by location 
    /// in a given text string with another text string
    /// REPLACE("ABC123",4,3,"456") -> ABC456
    /// REPLACE("ABC123",1,3,"45") -> 45123
    /// REPLACE("123-455-3321","-","") -> 1234553321
    /// </summary>
    public class replaceFunction : IFunction
    {
        /// <summary>
        /// Get Information
        /// </summary>
        /// <returns>FunctionDefs</returns>
        public List<FunctionDef> GetInfo()
        {
            return new List<FunctionDef>{
                    new FunctionDef(Afe_Common.Const_Replace, new System.Type[]{ typeof(string), typeof(string), typeof(string) }, typeof(string), 3),
                    new FunctionDef(Afe_Common.Const_Replace, new System.Type[] { typeof(string), typeof(decimal), typeof(decimal), typeof(string) }, typeof(string), 4) };
        }

        /// <summary>
        /// Execute
        /// </summary>
        /// <param name="args">args</param>
        /// <param name="dc">dc</param>
        /// <returns>Value</returns>
        public Object Execute(Dictionary<string, Object> args, ExpressionContext dc)
        {
            if (args.Count == 3)
            {
                return Afe_Common.ToString(args[Afe_Common.Const_Key_One]).Replace(Afe_Common.ToString(args[Afe_Common.Const_Key_Two]), Afe_Common.ToString(args[Afe_Common.Const_Key_Three]));
            }
            else
            {
                string text = Afe_Common.ToString(args[Afe_Common.Const_Key_One]);
                string left = text.Substring(0, Decimal.ToInt32(Afe_Common.ToDecimal(args[Afe_Common.Const_Key_Two])) - 1);
                string right = text.Substring(Decimal.ToInt32(Afe_Common.ToDecimal(args[Afe_Common.Const_Key_Two])) - 1 + Decimal.ToInt32(Afe_Common.ToDecimal(args[Afe_Common.Const_Key_Three])));
                return left + args[Afe_Common.Const_Key_Four].ToString() + right;
            }
        }
    }
}
