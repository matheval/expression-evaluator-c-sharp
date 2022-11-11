﻿/*
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
    /// MIN(1,2,3) -> 1
    /// new Afe_Evaluator('MIN(abc)').bind('abc',new List<decimal>{1,2,3}).eval() -> 1
    /// </summary>
    public class minFunction : IFunction
    {
        /// <summary>
        /// Get Information
        /// </summary>
        /// <returns>FunctionDefs</returns>
        public List<FunctionDef> GetInfo()
        {
            return new List<FunctionDef>{
                       new FunctionDef(Afe_Common.Const_Min, new System.Type[]{ typeof(decimal) }, typeof(decimal), -1),
                       new FunctionDef(Afe_Common.Const_Min, new System.Type[] { typeof(object)}, typeof(decimal), 1)};
        }

        /// <summary>
        /// Execute
        /// </summary>
        /// <param name="args">args</param>
        /// <param name="dc">dc</param>
        /// <returns>Value</returns>
        public object? Execute(Dictionary<string, object?> args, ExpressionContext dc)
        {
            if (args.Count == 1 && Afe_Common.IsList(args[Afe_Common.Const_Key_One]) && args[Afe_Common.Const_Key_One] is IEnumerable itor)
            {
                return this.MinList(itor, dc);
            }
            return this.Min(args, dc);
        }

        /// <summary>
        /// Min
        /// </summary>
        /// <param name="args">args</param>
        /// <returns>Value Min</returns>
        private object? Min(Dictionary<string, object?> args, ExpressionContext dc)
        {
            object? minEntry = null;
            foreach (object? item in args.Values)
            {
                if (minEntry == null || Afe_Common.ToDecimal(item, dc.WorkingCulture) < (decimal)minEntry)
                {
                    minEntry = Afe_Common.ToDecimal(item, dc.WorkingCulture);
                }
            }
            return minEntry;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private object? MinList(IEnumerable arg, ExpressionContext dc)
        {
            object? minEntry = null;
            foreach (object? item in arg)
            {
                if (!Afe_Common.IsNumber(item))
                {
                    continue;
                }
                if (minEntry == null || Afe_Common.ToDecimal(item, dc.WorkingCulture) < (decimal)minEntry)
                {
                    minEntry = Afe_Common.ToDecimal(item, dc.WorkingCulture);
                }
            }
            return minEntry;
        }
    }
}
