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
using System.Globalization;

namespace org.matheval.Functions
{
    /// <summary>
    /// Returns a number that represents a date that is the indicated number of working days before or after a date (the starting date).
    /// </summary>
    public class workdayFunction : IFunction
    {
        /// <summary>
        /// Get Information
        /// </summary>
        /// <returns>FunctionDefs</returns>
        public List<FunctionDef> GetInfo()
        {
            return new List<FunctionDef>{
                    new FunctionDef(Afe_Common.Const_Tan, new System.Type[]{typeof(string),typeof(decimal)}, typeof(string), 2)};
        }

        /// <summary>
        /// Execute
        /// </summary>
        /// <param name="args">args</param>
        /// <param name="dc">dc</param>
        /// <returns>Value</returns>
        public Object Execute(Dictionary<string, Object> args, ExpressionContext dc)
        {
            var startDate = DateTime.Parse(Afe_Common.ToString(args[Afe_Common.Const_Key_One], dc.WorkingCulture));
            var days = Afe_Common.ToInteger(args[Afe_Common.Const_Key_Two], dc.WorkingCulture);
            int i = 0;
            while (i < days)
            {
                var dayOfWeek = startDate.DayOfWeek.ToString();
                if (dayOfWeek != "Saturday" && dayOfWeek != "Sunday")
                {
                    i++;
                }
                startDate = startDate.AddDays(1);
            }
            return Afe_Common.ToString(startDate, dc.WorkingCulture);
        }
    }
}