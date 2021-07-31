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
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace org.matheval.Common
{
    public static class Afe_Common
    {

        #region Messenger

        public const string MSG_WRONG_OP_ACOS = "Value input must be greater than or equal to -1, but less than or equal to 1.";
        public const string MSG_WRONG_OP_PARAM = "The operator {0} is undefined for the argument type(s) {1}, {2}";
        public const string MSG_WRONG_OP_PARAM_EX = "{0} operator can only be applied to {1}";
        public const string MSG_WRONG_METH_PARAM = "Check params for function {0}";
        public const string MSG_METH_NOTFOUND = "Function {0} does not exist";
        public const string MSG_METH_NOT_ALLOWED = "Function {0} is not alowed. Please contact your system\"s administrator";
        public const string MSG_METH_PARAM_INVALID = "The parameter for function {0} is supplied with wrong format.";
        public const string MSG_UNEXPECT_TOKEN = "Unexpected token {0}";
        public const string MSG_UNEXPECT_TOKEN_AT_POS = "Unexpected token {0} at position {1}";
        public const string MSG_CONDITIONAL_WRONG_PARAMS = "Incorrect parameter type for function {0}. Expected {1}, received {2}";
        public const string MSG_IFELSE_WRONG_CONDITION = "Incorrect condition type for function IF. Expected Boolean, received {0}";
        public const string MSG_IFELSE_NESTIF_CONDITION = "Nested 'if' expression in condition param is not accepted!";
        public const string MSG_IFELSE_WRONG_SYNTAX = "Check ifelse syntax";
        public const string MSG_CASE_WRONG_PARAMS = "Incorrect number of parameters for function CASE";
        public const string MSG_UNSUPPORT_CONST = "Unsupported constant type";
        public const string MSG_PAREN_NULL_BODY = "Require parentheses body near position {0}";
        public const string MSG_UNARY_INVALID = "Invalid unary operator";
        public const string MSG_UNABLE_PARSE_EXPR = "Unable to parse expression";
        public const string MSG_RESULT_WRONG = "Result is not a {0}";
        public const string MSG_VAR_NOTSET = "The value for variable {0} was not set!";
        public const string MSG_RETURN_TYPE_NOT_SUPPORT = "Return type of {0} is not supported!";
        public const string ShowMessage = "Check argument for method";

        #endregion
        #region Const

        /// <summary>
        /// Default value is white space
        /// </summary>
        //public const string Const_WhiteSpace = " ";
        public const char Const_WhiteSpace = ' ';

        /// <summary>
        /// Condition expression IF
        /// </summary>
        public const string Const_IF = "IF";

        /// <summary>
        /// Condition expression SWITCH
        /// </summary>
        public const string Const_SWITCH = "SWITCH";

        /// <summary>
        /// Condition expression CASE
        /// </summary>
        public const string Const_CASE = "CASE";

        /// <summary>
        /// Condition expression WHEN
        /// </summary>
        //public const string Const_WHEN = "WHEN";

        /// <summary>
        /// Condition expression BRACKETS OPEN
        /// </summary>
        public const char Const_BRACKETS_OPEN = '(';

        /// <summary>
        /// Condition expression BRACKETS CLOSE
        /// </summary>
        public const char Const_BRACKETS_CLOSE = ')';

        /// <summary>
        /// Condition expression COMMA
        /// </summary>
        public const char Const_COMMA = ',';

        /// <summary>
        /// Condition expression PERIODT quotation marks
        /// </summary>
        public const char Const_PERIODT = '.';

        /// <summary>
        /// Double quotation marks
        /// </summary>
        public const char Const_DOUBLE_QUOTATION = '"';

        /// <summary>
        /// Single quotation marks
        /// </summary>
        public const char Const_SINGLE_QUOTATION = '\'';

        /// <summary>
        /// Condition expression EOF
        /// </summary>
        public const string Const_EOF = "EOF";

        #endregion
        #region Operator

        /// <summary>
        /// Or
        /// </summary>
        public const string Const_OrOperator = "||";

        /// <summary>
        /// And
        /// </summary>
        public const string Const_AndOperator = "&&";

        /// <summary>
        /// Eqs
        /// </summary>
        public const string Const_EqsOperator = "==";

        /// <summary>
        /// Eq
        /// </summary>
        public const string Const_EqOperator = "=";

        /// <summary>
        /// Neq
        /// </summary>
        public const string Const_NeqOperator = "!=";

        /// <summary>
        /// Neq
        /// </summary>
        public const string Const_Neq1Operator = "<>";

        /// <summary>
        /// Lt
        /// </summary>
        public const string Const_LtOperator = "<";

        /// <summary>
        /// Le
        /// </summary>
        public const string Const_LeOperator = "<=";

        /// <summary>
        /// Gt
        /// </summary>
        public const string Const_GtOperator = ">";

        /// <summary>
        /// Ge
        /// </summary>
        public const string Const_GeOperator = ">=";

        /// <summary>
        /// Plus
        /// </summary>
        public const string Const_PlusOperator = "+";

        /// <summary>
        /// Concat
        /// </summary>
        public const string Const_ConcatOperator = "&";

        /// <summary>
        /// Minus
        /// </summary>
        public const string Const_MinusOperator = "-";

        /// <summary>
        /// Mul
        /// </summary>
        public const string Const_MulOperator = "*";

        /// <summary>
        /// Div
        /// </summary>
        public const string Const_DivOperator = "/";

        /// <summary>
        /// Remainder
        /// </summary>
        public const string Const_RemainderOperator = "%";

        /// <summary>
        /// UnaryPos
        /// </summary>
        public const string Const_UnaryPosOperator = "+";

        /// <summary>
        /// UnaryNeg
        /// </summary>
        public const string Const_UnaryNegOperator = "-";

        /// <summary>
        /// Power
        /// </summary>
        public const string Const_PowerOperator = "^";

        #endregion

        #region Function

        /// <summary>
        /// Funtion Text
        /// </summary>
        public const string Const_Text = "text";

        /// <summary>
        /// Funtion TODAY
        /// </summary>
        public const string Const_TODAY = "TODAY";

        /// <summary>
        /// Funtion left
        /// </summary>
        public const string Const_LEFT = "left";

        /// <summary>
        /// Function Second
        /// </summary>
        public const string Const_Second = "second";

        /// <summary>
        /// Function code
        /// </summary>
        public const string Const_Code = "code";

        /// <summary>
        /// Function hour
        /// </summary>
        public const string Const_Hour = "hour";

        /// <summary>
        /// Function int
        /// </summary>
        public const string Const_Int = "int";

        /// <summary>
        /// Function isblank
        /// </summary>
        public const string Const_Isblank = "isblank";

        /// <summary>
        /// Function Minute
        /// </summary>
        public const string Const_Minute = "minute";


        /// <summary>
        /// Function proper
        /// </summary>
        public const string Const_Proper = "proper";

        /// <summary>
        /// Function substitute
        /// </summary>
        public const string Const_Substitute = "substitute";

        /// <summary>
        /// Function Abs
        /// </summary>
        public const string Const_Abs = "abs";

        /// <summary>
        /// Function Search
        /// </summary>
        public const string Const_Search = "search";

        /// <summary>
        /// Function Acos
        /// </summary>
        public const string Const_Acos = "acos";

        /// <summary>
        /// Function Acot
        /// </summary>
        public const string Const_Acot = "acot";

        /// <summary>
        /// Function Acot
        /// </summary>
        public const string Const_Csc = "csc";


        /// <summary>
        /// Function Cot
        /// </summary>
        public const string Const_Cot = "cot";

        /// <summary>
        /// Function Coth
        /// </summary>
        public const string Const_Coth = "coth";

        /// <summary>
        /// Function Degrees
        /// </summary>
        public const string Const_Degrees = "degrees";

        /// <summary>
        /// Function RIGHT
        /// </summary>
        public const string Const_RIGHT = "right";

        /// <summary>
        /// Function Concat
        /// </summary>
        public const string Const_Concat = "concat";

        /// <summary>
        /// Function MID
        /// </summary>
        public const string Const_MID = "mid";

        /// <summary>
        /// Function LPAD
        /// </summary>
        public const string Const_LPAD = "lpad";

        /// <summary>
        /// Function RPAD
        /// </summary>
        public const string Const_RPAD = "rpad";

        /// <summary>
        /// Function Sec
        /// </summary>
        public const string Const_Sec = "sec";

        /// <summary>
        /// Function Reverse
        /// </summary>
        public const string Const_Reverse = "reverse";

        /// <summary>
        /// Function Isnumeric
        /// </summary>
        public const string Const_Isnumeric = "isnumeric";

        /// <summary>
        /// Function Isnumber
        /// </summary>
        public const string Const_Isnumber = "isnumber";

        /// <summary>
        /// Function Lower
        /// </summary>
        public const string Const_Lower = "lower";

        /// <summary>
        /// Function Upper
        /// </summary>
        public const string Const_Upper = "upper";

        /// <summary>
        /// Function Trim
        /// </summary>
        public const string Const_Trim = "trim";

        /// <summary>
        /// Function Length
        /// </summary>
        public const string Const_Length = "length";

        /// <summary>
        /// Function Len
        /// </summary>
        public const string Const_Len = "len";

        /// <summary>
        /// Function String
        /// </summary>
        public const string Const_String = "string";

        /// <summary>
        /// Function Value
        /// </summary>
        public const string Const_Value = "value";

        /// <summary>
        /// Function Bool
        /// </summary>
        public const string Const_Bool = "bool";

        /// <summary>
        /// Function Ceiling
        /// </summary>
        public const string Const_Ceiling = "ceiling";

        /// <summary>
        /// Function And
        /// </summary>
        public const string Const_And = "and";

        /// <summary>
        /// Function asin
        /// </summary>
        public const string Const_Asin = "asin";

        /// <summary>
        /// Function Atan2
        /// </summary>
        public const string Const_Atan2 = "atan2";

        /// <summary>
        /// Function atan
        /// </summary>
        public const string Const_atan = "atan";

        /// <summary>
        /// Function Or
        /// </summary>
        public const string Const_Or = "or";

        /// <summary>
        /// Function Pi
        /// </summary>
        public const string Const_Pi = "pi";

        /// <summary>
        /// Function Radians
        /// </summary>
        public const string Const_Radians = "radians";

        /// <summary>
        /// Function Replace
        /// </summary>
        public const string Const_Replace = "replace";

        /// <summary>
        /// Function Not
        /// </summary>
        public const string Const_Not = "not";

        /// <summary>
        /// Function Sum
        /// </summary>
        public const string Const_Sum = "sum";

        /// <summary>
        /// Function Min
        /// </summary>
        public const string Const_Min = "min";

        /// <summary>
        /// Function Max
        /// </summary>
        public const string Const_Max = "max";

        /// <summary>
        /// Function Verage
        /// </summary>
        public const string Const_Verage = "average";

        /// <summary>
        /// Function Bitand
        /// </summary>
        public const string Const_Bitand = "bitand";

        /// <summary>
        /// Function Tan
        /// </summary>
        public const string Const_Tan = "tan";

        /// <summary>
        /// Function Tanh
        /// </summary>
        public const string Const_Tanh = "tanh";

        /// <summary>
        /// Function Bitnot
        /// </summary>
        public const string Const_Bitnot = "bitnot";

        /// <summary>
        /// Function Bitlshift
        /// </summary>
        public const string Const_Bitlshift = "bitlshift";

        /// <summary>
        /// Function Bitor
        /// </summary>
        public const string Const_Bitor = "bitor";

        /// <summary>
        /// Function Bitrshift
        /// </summary>
        public const string Const_Bitrshift = "bitrshift";

        /// <summary>
        /// Function Bitxor
        /// </summary>
        public const string Const_Bitxor = "bitxor";

        /// <summary>
        /// Function Xor
        /// </summary>
        public const string Const_Xor = "xor";

        /// <summary>
        /// Function Sin
        /// </summary>
        public const string Const_Sin = "sin";

        /// <summary>
        /// Function Sinh
        /// </summary>
        public const string Const_Sinh = "sinh";

        /// <summary>
        /// Function Cos
        /// </summary>
        public const string Const_Cos = "cos";

        /// <summary>
        /// Function Cosh
        /// </summary>
        public const string Const_Cosh = "cosh";

        /// <summary>
        /// Function Sqrt
        /// </summary>
        public const string Const_Sqrt = "sqrt";

        /// <summary>
        /// Function Floor
        /// </summary>
        public const string Const_Floor = "floor";

        /// <summary>
        /// Function Ln
        /// </summary>
        public const string Const_Ln = "ln";

        /// <summary>
        /// Function Log10
        /// </summary>
        public const string Const_Log10 = "log10";

        /// <summary>
        /// Function Mod
        /// </summary>
        public const string Const_Mod = "mod";

        /// <summary>
        /// Function power
        /// </summary>
        public const string Const_Power = "power";

        /// <summary>
        /// Function Random
        /// </summary>
        public const string Const_Random = "random";

        /// <summary>
        /// Function Ceil
        /// </summary>
        public const string Const_Ceil = "ceil";

        /// <summary>
        /// Function Round
        /// </summary>
        public const string Const_Round = "round";


        /// <summary>
        /// Function time
        /// </summary>
        public const string Const_Time = "time";

        /// <summary>
        /// Function Exp
        /// </summary>
        public const string Const_Exp = "exp";

        /// <summary>
        /// Function Fact
        /// </summary>
        public const string Const_Fact = "fact";

        /// <summary>
        /// Function Find
        /// </summary>
        public const string Const_Find = "find";


        #endregion

        #region Key

        /// <summary>
        /// Key is 0
        /// </summary>
        public const string Const_Key_Zero = "0";

        /// <summary>
        /// Key is 1
        /// </summary>
        public const string Const_Key_One = "1";

        /// <summary>
        /// Key is 2
        /// </summary>
        public const string Const_Key_Two = "2";

        /// <summary>
        /// Key is 3
        /// </summary>
        public const string Const_Key_Three = "3";

        /// <summary>
        /// Key is 4
        /// </summary>
        public const string Const_Key_Four = "4";

        /// <summary>
        /// Key is 5
        /// </summary>
        public const string Const_Key_Five = "5";

        /// <summary>
        /// Key is 6
        /// </summary>
        public const string Const_Key_Six = "6";

        #endregion      

        #region Function

        /// <summary>
        /// A string extension method that query if value is Alpha.
        /// </summary>
        /// <param name="value">The value to act on.</param>
        /// <returns>true if Alpha, false if not.</returns>
        /*public static bool IsAlpha(string value)
        {
            //return !Regex.IsMatch(value, "[^a-zA-Z]");
            Regex rg = new Regex(@"^[a-zA-Z_]+$");
            return rg.IsMatch(value);
        }*/
        public static bool IsAlpha(char value)
        {
            Regex rg = new Regex(@"^[a-zA-Z_]+$");
            return rg.IsMatch(value.ToString());
        }

        /// <summary>
        /// A string extension method that query if value is IsAlphaNumeric.
        /// </summary>
        /// <param name="value">The value to act on.</param>
        /// <returns>true if IsAlphaNumeric, false if not.</returns>
        /*public static bool IsAlphaNumeric(string value)
        {
            Regex rg = new Regex(@"^[a-zA-Z0-9_]+$");
            return rg.IsMatch(value);
        }*/
        public static bool IsAlphaNumeric(char value)
        {
            Regex rg = new Regex(@"^[a-zA-Z0-9_]+$");
            return rg.IsMatch(value.ToString());
        }

        /// <summary>
        /// A string extension method that query if value is isNumeric.
        /// </summary>
        /// <param name="value">The value to act on.</param>
        /// <returns>true if IsNumeric, false if not.</returns>
        /*public static bool IsNumeric(string value)
        {
            //Regex rg = new Regex(@"^(-?)(0|([1-9][0-9]*))(\\.[0-9]+)?$");
            Regex rg = new Regex(@"^[0-9]+$");
            return rg.IsMatch(value);
        }*/
        public static bool IsNumeric(char value)
        {
            Regex rg = new Regex(@"^[0-9]+$");
            return rg.IsMatch(value.ToString());
        }

        /// <summary>
        /// Formula Right
        /// </summary>
        /// <param name="stringValue">stringValue</param>
        /// <param name="count">count</param>
        /// <returns>Value Right</returns>
        public static string Right(string stringValue, int count)
        {
            if (!string.IsNullOrEmpty(stringValue))
            {
                return stringValue.Substring(stringValue.Length - count, count);
            }
            return string.Empty;
        }

        /// <summary>
        /// Round
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="dc">dc</param>
        /// <returns>Value Round</returns>
        public static decimal Round(object value, ExpressionContext dc)
        {
            return Math.Round(Convert.ToDecimal(value), dc.Scale, dc.Rd);
        }

        /// <summary>
        /// Check object is number instance
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNumber(object value)
        {
            return value is sbyte
                    || value is byte
                    || value is short
                    || value is ushort
                    || value is int
                    || value is uint
                    || value is long
                    || value is ulong
                    || value is float
                    || value is double
                    || value is decimal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static decimal ToDecimal(object value)
        {
            if(value is decimal)
            {
                return (decimal)value;
            }
            else
            {
                return Convert.ToDecimal(value);
            }
        }

        /// <summary>
        /// Connvert object to string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToString(object value)
        {
            if (value is string)
            {
                return (string)value;
            }
            else
            {
                return Convert.ToString(value);
            }
        }



        /// <summary>
        /// Check object instance of List
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static bool IsList(object o)
        {
            if (o == null) return false;
            return o is IList &&
                   o.GetType().IsGenericType &&
                   o.GetType().GetGenericTypeDefinition().IsAssignableFrom(typeof(List<>));
        }

        /// <summary>
        /// Round Manual Scale
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="dc">dc</param>
        /// <returns>Value Round</returns>
        public static decimal RoundManualScale(object value, object digit, ExpressionContext dc)
        {
            return Math.Round((decimal)value, (int)digit, dc.Rd);
        }

        /// <summary>
        /// DateDif
        /// </summary>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="unit">unit</param>
        /// <returns>Total Value</returns>
        public static int DateDif(DateTime startDate, DateTime endDate, string unit)
        {
            if (unit != null && unit.ToLower().Equals("d"))
            {
                return (endDate - startDate).Days;
            }
            else if (unit != null && unit.ToLower().Equals("m"))
            {
                int monthDiff = endDate.Year * 12 + endDate.Month - (startDate.Year * 12 + startDate.Month);
                if (endDate.Day < startDate.Day)
                {
                    monthDiff--;
                }
                return monthDiff;
            }
            else if (unit != null && unit.ToLower().Equals("y"))
            {
                int monthDiff = endDate.Year * 12 + endDate.Month - (startDate.Year * 12 + startDate.Month);
                if (endDate.Day < startDate.Day)
                {
                    monthDiff--;
                }
                return monthDiff / 12;
            }
            else if (unit != null && unit.ToLower().Equals("ym"))
            {
                DateTime stDate = startDate;
                int yearDiff = DateDif(startDate, endDate, "y");
                stDate = stDate.AddYears(yearDiff);
                return DateDif(stDate, endDate, "m");
            }
            else if (unit != null && unit.ToLower().Equals("yd"))
            {
                DateTime stDate = startDate;
                int yearDiff = DateDif(startDate, endDate, "y");
                stDate = stDate.AddYears(yearDiff);
                return DateDif(stDate, endDate, "d");
            }
            else if (unit != null && unit.ToLower().Equals("md"))
            {
                DateTime stDate = startDate;
                int mDiff = DateDif(startDate, endDate, "m");
                stDate = stDate.AddMonths(mDiff);
                return DateDif(stDate, endDate, "d");
            }
            throw new Exception("Please set M or D or Y for UNIT param");
        }

        #endregion

        #region Enum

        /// <summary>
        /// Create enum Assoc have value is 0.LEFT and 1.RIGHT
        /// </summary>
        public enum Assoc
        {
            LEFT,
            RIGHT
        }

        /// <summary>
        /// Type token
        /// </summary>
        public enum TokenType
        {
            TOKEN_ASCII,
            TOKEN_NUMBER_DECIMAL,
            TOKEN_BOOL,
            TOKEN_STRING,
            TOKEN_IDENTIFIER,
            TOKEN_PAREN_OPEN,
            TOKEN_PAREN_CLOSE,
            TOKEN_COMMA,
            TOKEN_OP,
            TOKEN_UOP,
            TOKEN_IF,
            TOKEN_CASE,
            TOKEN_EOF
        }

        #endregion
    }
}
