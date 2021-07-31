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
using System.Text.RegularExpressions;

namespace org.matheval.Functions
{
    /// <summary>
    /// Convert a numeric value, datetime value into a text string
    /// TEXT(123) -> 123 (string)
    /// TEXT(DATEVALUE("2021-01-23"),"dd-MM-yyyy") -> 23-01-2021 (string)
    /// TEXT(2.61,"hh:mm") -> 14:38 (string)
    /// TEXT(2.61,"[hh]") -> 62 (string)
    /// TEXT(0.1,"h") -> 2 (string)
    /// TEXT(2.61,"[mm]") -> 3758 (string)
    /// TEXT(2.61,"hh-mm-ss") -> 14-38-24 (string)
    /// TEXT(DATEVALUE("2021-01-03")-DATEVALUE("2021-01-01"),"[h]") -> 48 (string)
    /// TEXT(TIME(12,00,00)-TIME(10,30,10),"hh hours and mm minutes and ss seconds") -> "01 hours and 29 minutes and 50 seconds"
    /// </summary>
    public class textFunction : IFunction
    {
        /// <summary>
        /// Get Information
        /// </summary>
        /// <returns>FunctionDefs</returns>
        public List<FunctionDef> GetInfo()
        {
            return new List<FunctionDef>{
                    new FunctionDef(Afe_Common.Const_Text, new System.Type[]{typeof(Object) }, typeof(string), 1),
                    new FunctionDef(Afe_Common.Const_Text, new System.Type[] { typeof(Object), typeof(string)}, typeof(string), 2)};
        }

        /// <summary>
        /// Execute
        /// </summary>
        /// <param name="args">args</param>
        /// <param name="dc">dc</param>
        /// <returns>Value</returns>
        public Object Execute(Dictionary<string, Object> args, ExpressionContext dc)
        {
            if (args.Count == 2)
            {
                string pattern = Afe_Common.ToString(args[Afe_Common.Const_Key_Two]);
                /*if (args[Afe_Common.Const_Key_One] is TimeSpan){
                    TimeSpan t = (TimeSpan)args[Afe_Common.Const_Key_One];
                    args[Afe_Common.Const_Key_One] = decimal.Parse((t.Hours * 60 * 60 + t.Minutes * 60 + t.Seconds).ToString()) / decimal.Parse((60 * 60 * 24).ToString());
                    return this.Execute(args, dc);
                }
                else if (args[Afe_Common.Const_Key_One] is DateTime)
                {
                    DateTime t = (DateTime)args[Afe_Common.Const_Key_One];
                    return t.ToString(pattern);
                }
                else*/
                if (args[Afe_Common.Const_Key_One] is decimal)
                {
                    string ret = pattern;
                    decimal t = Afe_Common.ToDecimal(args[Afe_Common.Const_Key_One]);
                    // Hours
                    if (pattern.ToLower().Contains("[hh]"))
                    {
                        decimal hh = Afe_Common.Round(t * 24,dc);
                        ret = Regex.Replace(ret, "\\[[hH]{2,2}\\]", ((int)hh).ToString().PadLeft(2, '0'));
                    }
                    else if (pattern.ToLower().Contains("hh"))
                    {
                        decimal hh = Afe_Common.Round((t - (int)(t)) * 24,dc);
                        ret = Regex.Replace(ret, "[hH]{2,2}", ((int)hh).ToString().PadLeft(2, '0'));
                    }
                    else if (pattern.ToLower().Contains("[h]"))
                    {
                        decimal hh = Afe_Common.Round(t * 24,dc);
                        ret = Regex.Replace(ret, "\\[[hH]{1,1}\\]", ((int)hh).ToString());
                    }
                    else if (pattern.ToLower().Contains("h"))
                    {
                        decimal hh = Afe_Common.Round((t - (int)(t)) * 24,dc);
                        ret = Regex.Replace(ret, "[hH]{1,1}", ((int)hh).ToString());
                    }
                    //minute
                    if (pattern.Contains("[mm]"))
                    {
                        decimal hh = Afe_Common.Round(t * 24 * 60,dc);
                        ret = Regex.Replace(ret, "\\[[m]{2,2}\\]", ((int)hh).ToString().PadLeft(2, '0'));
                    }
                    else if (pattern.Contains("mm"))
                    {
                        decimal hh = Afe_Common.Round(((t * 24) - (int)(t * 24)) * 60,dc);
                        ret = Regex.Replace(ret, "[m]{2,2}", ((int)hh).ToString().PadLeft(2, '0'));
                    }
                    else if (pattern.Contains("[m]"))
                    {
                        decimal hh = Afe_Common.Round(t * 24 * 60,dc);
                        ret = Regex.Replace(ret, "\\[[m]{1,1}\\]", ((int)hh).ToString());
                    }
                    else if (pattern.Contains("m"))
                    {
                        decimal hh = Afe_Common.Round(((t * 24) - (int)(t * 24)) * 60,dc);
                        ret = Regex.Replace(ret, "[m]{1,1}", ((int)hh).ToString());
                    }
                    //sec
                    if (pattern.ToLower().Contains("[ss]"))
                    {
                        decimal hh = Afe_Common.Round(t * 24 * 60 * 60,dc);
                        ret = Regex.Replace(ret, "\\[[s]{2,2}\\]", ((int)hh).ToString().PadLeft(2, '0'));
                    }
                    else if (pattern.ToLower().Contains("ss"))
                    {
                        decimal hh = Afe_Common.Round(
                            ((t * 24m * 60m) - Decimal.ToInt32((t * 24m * 60m))) * 60m,
                            dc);
                        ret = Regex.Replace(ret, "[s]{2,2}", (Decimal.ToInt32(hh)).ToString().PadLeft(2, '0'));
                    }
                    else if (pattern.ToLower().Contains("[s]"))
                    {
                        decimal hh = Afe_Common.Round(t * 24 * 60 * 60,dc);
                        ret = Regex.Replace(ret, "\\[[s]{1,1}\\]", ((int)hh).ToString());
                    }
                    else if (pattern.ToLower().Contains("s"))
                    {
                        decimal hh = Afe_Common.Round(
                            ((t * 24 * 60) - (int)(t * 24 * 60)) * 60,
                            dc);
                        ret = Regex.Replace(ret, @"[sS]{1,1}", ((int)hh).ToString());
                    }
                    if (ret!=null && ret.Equals(pattern))
                    {
                        return t.ToString(pattern);
                    }
                    return ret;
                }
            }
            return Afe_Common.ToString(args[Afe_Common.Const_Key_One]);
        }
    }
}
