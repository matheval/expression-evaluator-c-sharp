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
    /// Logical xor function
    /// XOR(2>1,3<9/2) -> false
    /// XOR(2>1,3<9/2,6<10) -> true
    /// XOR(2>1,3<9/2,6<10,100<200) -> false
    /// </summary>
    public class xorFunction : IFunction
    {
        /// <summary>
        /// Get Information
        /// </summary>
        /// <returns>FunctionDefs</returns>
        public List<FunctionDef> GetInfo()
        {
            return new List<FunctionDef>{
                    new FunctionDef(Afe_Common.Const_Xor, new System.Type[]{ typeof(Boolean) }, typeof(Boolean), -1)};
        }

        /// <summary>
        /// Execute
        /// </summary>
        /// <param name="args">args</param>
        /// <param name="dc">dc</param>
        /// <returns>Value</returns>
        public Object Execute(Dictionary<string, Object> args, ExpressionContext dc)
        {
            return this.LogicalXor(args);
        }

        /// <summary>
        /// LogicalXor
        /// </summary>
        /// <param name="args">args</param>
        /// <returns>Value</returns>
        public Boolean LogicalXor(Dictionary<string, Object> args)
        {
            if (args.Count < 2)
            {
                throw new Exception(string.Format("{0} {1}", "Too few agrument for method", "XOR"));
            }
            else if (args.Count == 2)
            {
                return ((Boolean)args[Afe_Common.Const_Key_One]) ^ ((Boolean)args[Afe_Common.Const_Key_Two]);
            }
            else
            {
                int trueCount = 0;
                foreach (Object obj in args.Values)
                {
                    if (obj is Boolean || (Boolean)obj)
                    {
                        trueCount++;
                    }
                }
                return (trueCount > 0 && trueCount % 2 == 1);
            }
        }
    }
}
