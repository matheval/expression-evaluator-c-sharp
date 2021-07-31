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
    public class boolFunction : IFunction
    {
        /// <summary>
        /// Get Information
        /// </summary>
        /// <returns>FunctionDefs</returns>
        public List<FunctionDef> GetInfo()
        {
            return new List<FunctionDef>{
                    new FunctionDef(Afe_Common.Const_Bool, new System.Type[]{ typeof(string) }, typeof(Boolean), 1),
                    new FunctionDef(Afe_Common.Const_Bool, new System.Type[] { typeof(decimal) }, typeof(Boolean), 1)};
        }

        /// <summary>
        /// Execute
        /// </summary>
        /// <param name="args">args</param>
        /// <param name="dc">dc</param>
        /// <returns>Value</returns>
        public Object Execute(Dictionary<String, Object> args, ExpressionContext dc)
        {
            return this.ToBool(args[Afe_Common.Const_Key_One]);
        }

        /// <summary>
        /// ToBool
        /// </summary>
        /// <param name="value">value</param>
        /// <returns>Value ToBool</returns>
        private Boolean ToBool(Object value)
        {
            if (value is decimal)
            {
                return (decimal)value == 1;
            }
            else if (!(value.ToString().Equals(Afe_Common.Const_Key_One) || value.ToString().Equals(Afe_Common.Const_Key_Zero)))
            {
                throw new Exception(string.Format("{0} {1}", Afe_Common.ShowMessage, "BOOL(), expect 1 or 0"));
            }
            return value.ToString().Equals(Afe_Common.Const_Key_One);
        }
    }
}
