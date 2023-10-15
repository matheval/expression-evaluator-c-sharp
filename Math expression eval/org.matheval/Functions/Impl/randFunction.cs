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
    /// RAND()
    /// </summary>
    public class randFunction : IFunction
    {
        /// <summary>
        /// Get Information
        /// </summary>
        /// <returns>FunctionDefs</returns>
        public List<FunctionDef> GetInfo()
        {
            return new List<FunctionDef>{
                // None
                new FunctionDef(Afe_Common.Const_Random, null, typeof(decimal), 0),
                // Seed
                new FunctionDef(Afe_Common.Const_Random, new[]{ typeof(object) }, typeof(decimal), 1),
                // Min, Max
                new FunctionDef(Afe_Common.Const_Random, new[]{ typeof(decimal), typeof(decimal) }, typeof(decimal), 2),
                // Seed, Min, Max
                new FunctionDef(Afe_Common.Const_Random, new[]{ typeof(object), typeof(decimal), typeof(decimal) }, typeof(decimal), 3)
            };
        }

        /// <summary>
        /// Execute
        /// </summary>
        /// <param name="args">args</param>
        /// <param name="dc">dc</param>
        /// <returns>Value</returns>
        public Object Execute(Dictionary<string, Object> args, ExpressionContext dc)
        {
            Random r = args.Count == 1 || args.Count == 3
                ? new Random(args[Afe_Common.Const_Key_One].GetHashCode())
                : new Random();

            switch (args.Count)
            {
                case 2:
                    return Convert.ToDecimal
                    (
                        r.Next
                        (
                            Convert.ToInt32
                            (
                                Afe_Common.ToDecimal(args[Afe_Common.Const_Key_One], dc.WorkingCulture)
                                , dc.WorkingCulture
                            ),
                            Convert.ToInt32
                            (
                                Afe_Common.ToDecimal(args[Afe_Common.Const_Key_Two], dc.WorkingCulture)
                                , dc.WorkingCulture
                            )
                        )
                    );
                case 3:
                    return Convert.ToDecimal
                    (
                        r.Next
                        (
                            Convert.ToInt32
                            (
                                Afe_Common.ToDecimal(args[Afe_Common.Const_Key_Two], dc.WorkingCulture)
                                , dc.WorkingCulture
                            ),
                            Convert.ToInt32
                            (
                                Afe_Common.ToDecimal(args[Afe_Common.Const_Key_Three], dc.WorkingCulture)
                                , dc.WorkingCulture
                            )
                        )
                    );
                default:
                    return Convert.ToDecimal(r.NextDouble(), dc.WorkingCulture);
            }
        }
    }
}
