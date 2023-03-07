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
using System.Globalization;

namespace org.matheval.Functions
{
    /// <summary>
    /// Returns the day of the week corresponding to a date. The day is given as an integer, ranging from 1 (Sunday) to 7 (Saturday)
    /// </summary>
    public class networkdaysFunction : IFunction
    {
        /// <summary>
        /// Get Information
        /// </summary>
        /// <returns>FunctionDefs</returns>
        public List<FunctionDef> GetInfo()
        {
            return new List<FunctionDef>{
                    new FunctionDef(Afe_Common.Const_NetWorkdays, new System.Type[]{typeof(string),typeof(string) }, typeof(decimal), 2)};
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
            var endDate = DateTime.Parse(Afe_Common.ToString(args[Afe_Common.Const_Key_Two], dc.WorkingCulture));
            TimeSpan span = endDate - startDate;
          
            //adjusted from https://stackoverflow.com/questions/1617049/calculate-the-number-of-business-days-between-two-dates
            int businessDays = span.Days + 1;
            int fullWeekCount = businessDays / 7;
            // find out if there are weekends
            if (businessDays > fullWeekCount * 7)
            {
                int firstDayOfWeek = startDate.DayOfWeek == DayOfWeek.Sunday
                    ? 7 : (int)startDate.DayOfWeek;
                int lastDayOfWeek = endDate.DayOfWeek == DayOfWeek.Sunday
                    ? 7 : (int)endDate.DayOfWeek;
                if (lastDayOfWeek < firstDayOfWeek)
                    lastDayOfWeek += 7;
                if (firstDayOfWeek <= 6)
                {
                    if (lastDayOfWeek >= 7)
                        businessDays -= 2;
                    else if (lastDayOfWeek >= 6)
                        businessDays -= 1;
                }
                else if (firstDayOfWeek <= 7 && lastDayOfWeek >= 7)
                    businessDays -= 1;
            }
            //subtract the weekends during the full weeks in the interval
            businessDays -= fullWeekCount + fullWeekCount;
            return Afe_Common.ToInteger(businessDays, dc.WorkingCulture);
        }
    }
}
