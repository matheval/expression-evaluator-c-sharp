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
using System.Collections.Generic;

namespace org.matheval.Functions
{
    /// <summary>
    /// Calculates the number of days, months, or years between two dates.
    /// </summary>
    public class datedifFunction : IFunction
    {
        /// <summary>
        /// Get Information
        /// </summary>
        /// <returns>FunctionDefs</returns>
        public List<FunctionDef> GetInfo()
        {
            return new List<FunctionDef>{
                    new FunctionDef(Afe_Common.Const_DateDif, new System.Type[]{typeof(string), typeof(string), typeof(string)}, typeof(decimal), 3)};
        }

        /// <summary>
        /// Execute
        /// </summary>
        /// <param name="args">args</param>
        /// <param name="dc">dc</param>
        /// <returns>Value</returns>
        public Object Execute(Dictionary<string, Object> args, ExpressionContext dc)
        {
            var startDate = Afe_Common.ToDateTime(args[Afe_Common.Const_Key_One], dc.WorkingCulture);
            var endDate = Afe_Common.ToDateTime(args[Afe_Common.Const_Key_Two], dc.WorkingCulture);
            var unit = Afe_Common.ToString(args[Afe_Common.Const_Key_Three], dc.WorkingCulture);
            return Afe_Common.ToDecimal(SubtractDates(startDate, endDate, unit), dc.WorkingCulture);
        }

        private static string SubtractDates(DateTime startDate, DateTime endDate, string unit)
        {
            switch (unit)
            {
                case "day":
                    return endDate.Subtract(startDate).TotalDays.ToString();
                case "month":
                    return (((endDate.Year - startDate.Year) * 12) + endDate.Month - startDate.Month).ToString();
                case "year":
                    return ((decimal)(((endDate.Year - startDate.Year) * 12) + endDate.Month - startDate.Month) / 12).ToString(".##");
                default:
                    return null;
            }
        }
    }
}
