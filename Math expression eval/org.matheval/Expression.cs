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
using org.matheval.Node;
using org.matheval.Operators;
using org.matheval.Operators.Binop;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using static org.matheval.Common.Afe_Common;

namespace org.matheval
{
    public class Expression
    {
        /// <summary>
        /// Parser
        /// </summary>
        private readonly Parser Parser;

        /// <summary>
        /// Root
        /// </summary>
        private Implements.Node? Root;

        /// <summary>
        /// Dc
        /// </summary>
        private readonly ExpressionContext Dc;

        /// <summary>
        /// VariableParams
        /// </summary>
        private readonly Dictionary<string, object> VariableParams;

        /// <summary>
        /// NotAllowedFunctions
        /// </summary>
        private List<string>? NotAllowedFunctions;


        /// <summary>
        /// Initializes a new instance structure
        /// </summary>
        public Expression()
        {
            Dc = new ExpressionContext(6, MidpointRounding.ToEven, "yyyy-MM-dd", "yyyy-MM-dd HH:mm", @"hh\:mm", CultureInfo.InvariantCulture);
            VariableParams = new Dictionary<string, object>();
            Parser = new Parser(Dc);
        }

        /// <summary>
        /// Initializes a new instance of Expression
        /// </summary>
        /// <param name="formular">Input fomular text or math expression string</param>
        public Expression(string formular)
        {
            Dc = new ExpressionContext(6, MidpointRounding.ToEven,"yyyy-MM-dd", "yyyy-MM-dd HH:mm", @"hh\:mm", CultureInfo.InvariantCulture);
            VariableParams = new Dictionary<string, object>();
            Parser = new Parser(Dc, formular);
        }

        /// <summary>
        /// Initializes using parser
        /// </summary>
        /// <param name="parser">Parser instance</param>
        public Expression(Parser parser)
        {
            Dc = new ExpressionContext(6, MidpointRounding.ToEven, "yyyy-MM-dd", "yyyy-MM-dd HH:mm", @"hh\:mm", CultureInfo.InvariantCulture);
            VariableParams = new Dictionary<string, object>();
            Parser = parser;
        }

        /// <summary>
        /// Get Parser
        /// </summary>
        /// <returns>The parser</returns>
        public Parser GetParser()
        {
            return Parser;
        }

        /// <summary>
        /// Bind value to variable in expression
        /// </summary>
        /// <param name="key">variable name</param>
        /// <param name="value">value to bind</param>
        /// <returns>Expression instance</returns>
        public Expression Bind(string key, object value)
        {
            if (!VariableParams.ContainsKey(key.ToLowerInvariant()))
            {
                VariableParams.Add(key.ToLowerInvariant(), value);
            }
            else
            {
                VariableParams[key.ToLowerInvariant()] = value;
            }
            return this;
        }

        /// <summary>
        /// Set Input fomular text for current expression instance
        /// </summary>
        /// <param name="formular">Input fomular text or math expression string</param>
        /// <returns>Expression instance</returns>
        public Expression SetFomular(string formular)
        {
            Gc();
            GetParser().SetFomular(formular);
            return this;
        }

        /// <summary>
        /// Set rounding scale number, default is 6
        /// </summary>
        /// <param name="scale">scale</param>
        /// <returns>Expression instance</returns>
        public Expression SetScale(int scale)
        {
            Dc.Scale = scale;
            return this;
        }

        /// <summary>
        /// Set Math context rounding mode, default is HALFEVENT
        /// </summary>
        /// <param name="rd">rounding mode</param>
        /// <returns>Value Afe_Evaluator</returns>
        public Expression SetRoundingMode(MidpointRounding rd)
        {
            Dc.Rd = rd;
            return this;
        }

        /// <summary>
        /// Set date system
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public Expression SetDateSystem(int year, int month, int day)
        {
            Dc.DateSystem = new DateTime(year, month, day);
            return this;
        }

        /// <summary>
        /// Set input date format, example: yyyy-MM-dd
        /// </summary>
        /// <param name="format">date format</param>
        /// <returns>Expression instance</returns>
        public Expression SetInputDateFormat(string format)
        {
            Dc.DateFormat = format;
            return this;
        }

        /// <summary>
        /// Input datetime format, example: yyyy-MM-dd HH:mm"
        /// </summary>
        /// <param name="format">datetime format</param>
        /// <returns>Expression instance</returns>
        public Expression SetInputDateTimeFormat(string format)
        {
            Dc.DatetimeFormat = format;
            return this;
        }

        /// <summary>
        /// Input time format, example: hh\\:mm\\:ss"
        /// </summary>
        /// <param name="format"></param>
        /// <returns>Expression instance</returns>
        public Expression SetInputTimeFormat(string format)
        {
            Dc.TimeFormat = format;
            return this;
        }

        /// <summary>
        /// Set Holidays of year
        /// </summary>
        /// <param name="holidays">Array of holidays/param>
        /// <returns>Expression instance</returns>
        public Expression SetHolidays(DateTime[] holidays)
        {
            Dc.Holidays = holidays;
            return this;
        }

        /// <summary>
        /// Set weekends days of week
        /// </summary>
        /// <param name="weekends">
        /// Sunday = 0
        /// Monday = 1,
        /// Tuesday = 2,
        /// Wednesday = 3,
        /// Thursday = 4,
        /// Friday = 5,
        /// Saturday = 6
        /// </param>
        /// <returns></returns>
        public Expression SetWeekends(int[] weekends)
        {
            Dc.Weekends = weekends;
            return this;
        }

        /// <summary>
        /// Set the culture used to parse the numbers
        /// </summary>
        /// <param name="workingCulture">The culture that will be used to parse the numbers</param>
        /// <returns></returns>
        public Expression SetWorkingCulture(CultureInfo workingCulture)
        {
            Dc.WorkingCulture = workingCulture;
            return this;
        }

        /// <summary>
        /// Disable single function
        /// </summary>
        /// <param name="functionName">function name</param>
        /// <returns>Current instance</returns>
        public Expression DisableFunction(string functionName)
        {
            if (functionName!=null && !functionName.Trim().Equals(""))
            {
                if (NotAllowedFunctions == null)
                {
                    NotAllowedFunctions = new List<string>();
                }
                NotAllowedFunctions.Add(functionName.Trim().ToLowerInvariant());
            }
            return this;
        }

        /// <summary>
        /// Disable multiple functions
        /// </summary>
        /// <param name="functionNames">Array of function name to be disabled</param>
        /// <returns>Current instance</returns>
        public Expression DisableFunction(string[] functionNames)
        {
            foreach (string functionName in functionNames)
            {
                if (functionName != null && !functionName.Trim().Equals(""))
                {
                    if (NotAllowedFunctions == null)
                    {
                        NotAllowedFunctions = new List<string>();
                    }
                    NotAllowedFunctions.Add(functionName.Trim().ToLowerInvariant());
                }
            }
            return this;
        }

        //TODO set CultureInfo

        /// <summary>
        /// Validate fomular string is valid or not
        /// </summary>
        /// <returns>List of error. If no error, return emtpy array</returns>
        public List<string> GetError()
        {
            List<string> errors = new List<string>();
            try
            {
                if (Parser.ParseTop() == null)
                {
                    errors.Add(Afe_Common.MSG_UNABLE_PARSE_EXPR);
                }
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
            }
            return errors;
        }

        /// <summary>
        /// Eval fomular string and return valua in object instance
        /// </summary>
        /// <returns>value</returns>
        public object? Eval()
        {
            if (Root == null)
            {
                Root = Parser.ParseTop();
            }

            object? result = VisitNode(Root);
            if (result is decimal)
            {
                decimal resultDec =  Afe_Common.Round(result, Dc);
                if (resultDec < 0)
                {
                   // return resultDec;
                }
                return resultDec;
            }
            return result;
        }

        /// <summary>
        /// Eval fomular and return value
        /// </summary>
        /// <typeparam name="T">Expected return type</typeparam>
        /// <returns>Value</returns>
        public T Eval<T>()
        {
            //Check expected datatype
            if (!(
                typeof(T) == typeof(decimal) ||
                typeof(T) == typeof(int) ||
                typeof(T) == typeof(Int64) ||
                typeof(T) == typeof(double) ||
                typeof(T) == typeof(bool) ||
                typeof(T) == typeof(object) ||
                typeof(T) == typeof(string) ||
                typeof(T) == typeof(DateTime) ||
                typeof(T) == typeof(TimeSpan)
                ))
            {
                throw new Exception(string.Format(Afe_Common.MSG_RETURN_TYPE_NOT_SUPPORT,
                                 new string[] { typeof(T).ToString() }));
            }

            //parse expression
            if (Root == null)
            {
                Root = Parser.ParseTop();
            }
            //and then evaluate
            object? result = VisitNode(Root);
            //Convert all numeric type to decimal
            if (Afe_Common.IsNumber(result) && !(typeof(T) == typeof(DateTime) || typeof(T) == typeof(TimeSpan)))
            {
                result = Afe_Common.ToDecimal(result, Dc.WorkingCulture);
                result = Afe_Common.Round(result, Dc);
            }

            //convert decimal to appropiate numeric type
            if (result is decimal dr)
            {
                if (typeof(T) == typeof(int))
                {
                    result = decimal.ToInt32(dr);
                }
                else if (typeof(T) == typeof(long))
                {
                    result = decimal.ToInt64(dr);
                }
                else if (typeof(T) == typeof(double))
                {
                    result = decimal.ToDouble(dr);
                }
            }

            //convert object to expected type and return
            object? changed = Convert.ChangeType(result, typeof(T));
            if (changed is null)
                throw new Exception(string.Format(Afe_Common.MSG_RETURN_TYPE_NOT_SUPPORT,
                                 new string[] { typeof(T).ToString() }));
            return (T)changed;
        }


        /// <summary>
        /// Clear expression
        /// </summary>
        public void Gc()
        {
            if (Root != null)
            {
                Root = null;
            }
        }

        /// <summary>
        /// Set all variables in the fomular
        /// </summary>
        /// <returns>List of variable</returns>
        public List<string> getVariables()
        {
            List<string> variables = new List<string>();
            if (Root == null)
            {
                Root = Parser.ParseTop();
            }
            VisitVariableNode(Root, variables);
            return variables;
        }

        /// <summary>
        /// Node visitor
        /// </summary>
        /// <param name="root"></param>
        /// <param name="holder"></param>
        private void VisitVariableNode(Implements.Node root, List<string> holder)
        {
            if (root is VariableNode varNode)
            {
                if (!holder.Contains(varNode.Name))
                {
                    holder.Add(varNode.Name);
                }
            }
            else if (root is BinanyNode binNode)
            {
                VisitVariableNode(binNode.LHS, holder);
                VisitVariableNode(binNode.RHS, holder);
            }
            else if (root is IfElseNode ifElseNode)
            {
                VisitVariableNode(ifElseNode.Condition, holder);
                VisitVariableNode(ifElseNode.IfTrue, holder);
                VisitVariableNode(ifElseNode.IfFalse, holder);
            }
            else if (root is SwitchCaseNode caseNode)
            {
                VisitVariableNode(caseNode.ConditionExpr, holder);
                for (int i = 0; i < caseNode.VarResultExprs.Count - 1; i++)
                {
                    VisitVariableNode(caseNode.VarResultExprs[i], holder);
                }
                VisitVariableNode(caseNode.DefaultExpr, holder);
            }
            else if (root is CallFuncNode callFunc)
            {
                for (int i = 0; i < callFunc.Args.Count; i++)
                {
                    Implements.Node expr = callFunc.Args[i];
                    VisitVariableNode(expr, holder);
                }
            }
            else if (root is UnaryNode unaryNode)
            {
                VisitVariableNode(unaryNode.Expr, holder);
            }
        }

        /// <summary>
        /// Visit tree node method
        /// this method can be process recursive itself
        /// </summary>
        /// <param name="root">root</param>
        /// <returns>Value Node</returns>
        private object? VisitNode(Implements.Node root)
        {
            // Check root is null then Exception
            if (root == null)
            {
                throw new Exception(Afe_Common.MSG_UNABLE_PARSE_EXPR);
            }
            else if (root is NumberNode numberNode)
            {
                return numberNode.MustRoundFlag ? Afe_Common.Round(numberNode.NumberValue, Dc) : numberNode.NumberValue;
            }
            else if (root is StringNode strNode)
            {
                return strNode.Value;
            }
            else if (root is BoolNode boolNode)
            {
                return boolNode.Value;
            }
            else if (root is VariableNode varNode)
            {
                if (!VariableParams.ContainsKey(varNode.Name.ToLowerInvariant()))
                {
                    throw new Exception(string.Format(Afe_Common.MSG_VAR_NOTSET, new string[] { varNode.Name }));
                }
                object value = VariableParams[varNode.Name.ToLowerInvariant()];
                //if (value is decimal)
                if (Afe_Common.IsNumber(value))
                {
                    return Afe_Common.Round(Convert.ToDecimal(value, Dc.WorkingCulture), Dc);
                }
                else return value;
            }
            else if (root is BinanyNode binNode)
            {
                object? left = VisitNode(binNode.LHS);
                object? right = VisitNode(binNode.RHS);
                return binNode.iOp.Calculate(left, right, Dc);
            }
            else if (root is IfElseNode ifElseNode)
            {
                if (ifElseNode.Condition is IfElseNode)
                {
                    throw new Exception(Afe_Common.MSG_IFELSE_NESTIF_CONDITION);
                }
                object? ConditionResult = VisitNode(ifElseNode.Condition);
                if (ConditionResult is bool bc)
                {
                    return bc == true ? VisitNode(ifElseNode.IfTrue) : VisitNode(ifElseNode.IfFalse);
                }
                throw new Exception(Afe_Common.MSG_IFELSE_WRONG_SYNTAX);
            }
            else if (root is SwitchCaseNode switchNode)
            {
                return ExecuteSwitchCase(switchNode);
            }
            else if (root is CallFuncNode callNode)
            {
                return ExecuteCallFunc(callNode);
            }
            else if (root is UnaryNode unaryNode)
            {
                object? left = VisitNode(unaryNode.Expr);
                return unaryNode.Iop.Calculate(left, null, Dc);
            }
            else if (root is NullNode)
            {
                return null;
            }
            throw new Exception(Afe_Common.MSG_UNABLE_PARSE_EXPR);
        }

        /// <summary>
        /// Execute Call Function
        /// </summary>
        /// <param name="callFunc">call function base</param>
        /// <returns>funtion execute result</returns>
        private object? ExecuteCallFunc(CallFuncNode callFunc)
        {
            if (NotAllowedFunctions != null && NotAllowedFunctions.Contains(callFunc.FuncName.ToLowerInvariant()))
            {
                throw new Exception(string.Format(Afe_Common.MSG_METH_NOT_ALLOWED, new string[] { callFunc.FuncName }));
            }

            Dictionary<string, object?> argsMap = new Dictionary<string, object?>();
            int i = 0;

            foreach (Implements.Node expr in callFunc.Args)
            {
                i++;
                argsMap.Add(i.ToString(), VisitNode(expr));
            }
            return callFunc.Excuter.Execute(argsMap, Dc);
        }

        /// <summary>
        /// Execute switch case condition
        /// </summary>
        /// <param name="root">root</param>
        /// <returns>switch condition result </returns>
        private object? ExecuteSwitchCase(SwitchCaseNode root)
        {
            IOperator eq = new EqOperator(Afe_Common.Const_EqsOperator, 300, Assoc.LEFT);
            object? condition = VisitNode(root.ConditionExpr);
            for (int i = 0; i < root.VarResultExprs.Count - 1; i += 2)
            {
                object? var = VisitNode(root.VarResultExprs[i]);
                object? compareResult = eq.Calculate(condition, var, Dc);
                if (compareResult is bool b && b)
                {
                    return VisitNode(root.VarResultExprs[i+1]);
                }
            }
            return VisitNode(root.DefaultExpr);
        }

    }
}
