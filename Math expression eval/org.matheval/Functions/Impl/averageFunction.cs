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
using System.Collections;
using System.Collections.Generic;

namespace org.matheval.Functions
{
    /// <summary>
    /// average(1,2,3) -> 2
    /// new Afe_Evaluator('average(abc)').bind('abc',new List<Decimal>{1,2,3}).eval() -> 2
    /// </summary>
    public class averageFunction : IFunction
    {
        /// <summary>
        /// Get Information
        /// </summary>
        /// <returns>FunctionDefs</returns>
        public List<FunctionDef> GetInfo()
        {
            return new List<FunctionDef>{
                       new FunctionDef(Afe_Common.Const_Verage, new System.Type[]{ typeof(decimal) }, typeof(decimal), -1),
                       new FunctionDef(Afe_Common.Const_Verage, new System.Type[] { typeof(Object) }, typeof(decimal), 1)};
        }

        /// <summary>
        /// Execute
        /// </summary>
        /// <param name="args">args</param>
        /// <param name="dc">dc</param>
        /// <returns>Value</returns>
        public Object Execute(Dictionary<string, Object> args, ExpressionContext dc)
        {
            if (args.Count == 1 && Afe_Common.IsList(args[Afe_Common.Const_Key_One]))
            {
                return this.AvgList((IEnumerable)args[Afe_Common.Const_Key_One]);
            }
            return this.Avg(args);
        }

        /// <summary>
        /// Avg
        /// </summary>
        /// <param name="args">args</param>
        /// <returns>Value Avg</returns>
        private decimal Avg(Dictionary<string, Object> args)
        {
            decimal sum = 0;
            foreach (Object item in args.Values)
            {
                if(!Afe_Common.IsNumber(item))
                {
                    throw new Exception(string.Format("{0} {1}", Afe_Common.ShowMessage, "AVG"));
                }
                sum += Afe_Common.ToDecimal(item);
            }
            return sum / args.Count;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private decimal AvgList(IEnumerable arg)
        {
            decimal sum = 0;
            int elementCount = 0;

            foreach (Object item in arg)
            {
                if (Afe_Common.IsNumber(item))
                {
                    sum += Afe_Common.ToDecimal(item);
                    elementCount++;
                }
            }
            return sum / elementCount;
        }
    }
}
