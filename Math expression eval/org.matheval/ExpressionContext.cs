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
using System;

namespace org.matheval
{
    /// <summary>
    /// Create class ExpressionContext
    /// </summary>
    public class ExpressionContext
    {
        /// <summary>
        /// Scale
        /// </summary>
        public int Scale;

        /// <summary>
        /// Rd
        /// </summary>
        public MidpointRounding Rd;

        /// <summary>
        /// DateSystem, default is 1900-01-01
        /// </summary>
        public DateTime DateSystem;

        /// <summary>
        /// Input Dateformat
        /// </summary>
        public String DateFormat;

        /// <summary>
        /// Input Datetime format
        /// </summary>
        public String DatetimeFormat;

        /// <summary>
        /// Input time format
        /// </summary>
        public String TimeFormat;

        /// <summary>
        /// Weekends days of week
        /// Sunday = 0
        /// Monday = 1,
        /// Tuesday = 2,
        /// Wednesday = 3,
        /// Thursday = 4,
        /// Friday = 5,
        /// Saturday = 6
        /// </summary>
        public int[] Weekends;

        /// <summary>
        /// List holidays or year 
        /// </summary>
        public DateTime[] Holidays;

        /// <summary>
        /// Initializes a new instance structure to a specified type int scale and type MidpointRounding rd
        /// </summary>
        /// <param name="scale"></param>
        /// <param name="rd"></param>
        /// <param name="dateFormat"></param>
        /// <param name="datetimeFormat"></param>
        public ExpressionContext(int scale, MidpointRounding rd, String dateFormat, String datetimeFormat, String timeFormat)
        {
            Scale = scale;
            Rd = rd;
            DateFormat = dateFormat;
            DatetimeFormat = datetimeFormat;
            TimeFormat = timeFormat;
            DateSystem = new DateTime(1899, 12, 30);
        }
    }
}
