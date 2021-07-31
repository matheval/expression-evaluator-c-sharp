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
using static org.matheval.Common.Afe_Common;

namespace org.matheval
{
    public class Expression
    {
        /// <summary>
        /// Parser
        /// </summary>
        private Parser Parser;

        /// <summary>
        /// Root
        /// </summary>
        private Implements.Node Root;

        /// <summary>
        /// Dc
        /// </summary>
        private ExpressionContext Dc;

        /// <summary>
        /// VariableParams
        /// </summary>
        private Dictionary<string, object> VariableParams;

        /// <summary>
        /// NotAllowedFunctions
        /// </summary>
        private List<string> NotAllowedFunctions;


        /// <summary>
        /// Initializes a new instance structure
        /// </summary>
        public Expression()
        {
            this.Dc = new ExpressionContext(6, MidpointRounding.ToEven, "yyyy-MM-dd", "yyyy-MM-dd HH:mm", @"hh\:mm");
            this.VariableParams = new Dictionary<string, object>();
            this.Parser = new Parser();
        }

        /// <summary>
        /// Initializes a new instance of Expression
        /// </summary>
        /// <param name="formular">Input fomular text or math expression string</param>
        public Expression(string formular)
        {
            this.Dc = new ExpressionContext(6, MidpointRounding.ToEven,"yyyy-MM-dd", "yyyy-MM-dd HH:mm", @"hh\:mm");
            this.VariableParams = new Dictionary<string, object>();
            this.Parser = new Parser(formular);
        }

        /// <summary>
        /// Initializes using parser
        /// </summary>
        /// <param name="parser">Parser instance</param>
        public Expression(Parser parser)
        {
            this.Dc = new ExpressionContext(6, MidpointRounding.ToEven, "yyyy-MM-dd", "yyyy-MM-dd HH:mm", @"hh\:mm");
            this.VariableParams = new Dictionary<string, object>();
            this.Parser = parser;
        }

        /// <summary>
        /// Get Parser
        /// </summary>
        /// <returns>The parser</returns>
        public Parser GetParser()
        {
            return this.Parser;
        }

        /// <summary>
        /// Bind value to variable in expression
        /// </summary>
        /// <param name="key">variable name</param>
        /// <param name="value">value to bind</param>
        /// <returns>Expression instance</returns>
        public Expression Bind(string key, Object value)
        {
            if (!this.VariableParams.ContainsKey(key.ToLower()))
            {
                this.VariableParams.Add(key.ToLower(), value);
            }
            else
            {
                this.VariableParams[key.ToLower()] = value;
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
            this.Gc();
            this.GetParser().SetFomular(formular);
            return this;
        }

        /// <summary>
        /// Set rounding scale number, default is 6
        /// </summary>
        /// <param name="scale">scale</param>
        /// <returns>Expression instance</returns>
        public Expression SetScale(int scale)
        {
            this.Dc.Scale = scale;
            return this;
        }

        /// <summary>
        /// Set Math context rounding mode, default is HALFEVENT
        /// </summary>
        /// <param name="rd">rounding mode</param>
        /// <returns>Value Afe_Evaluator</returns>
        public Expression SetRoundingMode(MidpointRounding rd)
        {
            this.Dc.Rd = rd;
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
            this.Dc.DateSystem = new DateTime(year, month, day);
            return this;
        }

        /// <summary>
        /// Set input date format, example: yyyy-MM-dd
        /// </summary>
        /// <param name="format">date format</param>
        /// <returns>Expression instance</returns>
        public Expression SetInputDateFormat(string format)
        {
            this.Dc.DateFormat = format;
            return this;
        }

        /// <summary>
        /// Input datetime format, example: yyyy-MM-dd HH:mm"
        /// </summary>
        /// <param name="format">datetime format</param>
        /// <returns>Expression instance</returns>
        public Expression SetInputDateTimeFormat(string format)
        {
            this.Dc.DatetimeFormat = format;
            return this;
        }

        /// <summary>
        /// Input time format, example: hh\\:mm\\:ss"
        /// </summary>
        /// <param name="format"></param>
        /// <returns>Expression instance</returns>
        public Expression SetInputTimeFormat(string format)
        {
            this.Dc.TimeFormat = format;
            return this;
        }

        /// <summary>
        /// Set Holidays of year
        /// </summary>
        /// <param name="holidays">Array of holidays/param>
        /// <returns>Expression instance</returns>
        public Expression SetHolidays(DateTime[] holidays)
        {
            this.Dc.Holidays = holidays;
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
            this.Dc.Weekends = weekends;
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
                if (this.NotAllowedFunctions == null)
                {
                    this.NotAllowedFunctions = new List<String>();
                }
                this.NotAllowedFunctions.Add(functionName.Trim().ToLower());
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
                    if (this.NotAllowedFunctions == null)
                    {
                        this.NotAllowedFunctions = new List<String>();
                    }
                    this.NotAllowedFunctions.Add(functionName.Trim().ToLower());
                }
            }
            return this;
        }

        /// <summary>
        /// Validate fomular string is valid or not
        /// </summary>
        /// <returns>List of error. If no error, return emtpy array</returns>
        public List<string> GetError()
        {
            List<string> errors = new List<string>();
            try
            {
                if (this.Parser.ParseTop() == null)
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
        public Object Eval()
        {
            if (this.Root == null)
            {
                this.Root = Parser.ParseTop();
            }

            Object result = this.VisitNode(Root);
            if (result is decimal)
            {
                decimal resultDec =  Afe_Common.Round(result, this.Dc);
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
                                 new String[] { typeof(T).ToString() }));
            }

            //parse expression
            if (this.Root == null)
            {
                this.Root = Parser.ParseTop();
            }
            //and then evaluate
            Object result = this.VisitNode(Root);
            //Convert all numeric type to decimal
            if (Afe_Common.IsNumber(result) && !(typeof(T) == typeof(DateTime) || typeof(T) == typeof(TimeSpan)))
            {
                result = Afe_Common.ToDecimal(result);
                result = Afe_Common.Round(result, this.Dc);
            }

            //convert decimal to appropiate numeric type
            if (result is decimal && typeof(T) == typeof(int))
            {
                result = Decimal.ToInt32(((decimal)result));
            }
            else if (result is decimal && typeof(T) == typeof(Int64))
            {
                result = Decimal.ToInt64(((decimal)result));
            }
            else if (result is decimal && typeof(T) == typeof(double))
            {
                result = Decimal.ToDouble(((decimal)result));
            }
            //convert object to expected type and return
            return (T)Convert.ChangeType(result, typeof(T));
        }


        /// <summary>
        /// Clear expression
        /// </summary>
        public void Gc()
        {
            if (this.Root != null)
            {
                this.Root = null;
            }
        }

        /// <summary>
        /// Set all variables in the fomular
        /// </summary>
        /// <returns>List of variable</returns>
        public List<String> getVariables()
        {
            List<String> variables = new List<String>();
            if (this.Root == null)
            {
                this.Root = Parser.ParseTop();
            }
            VisitVariableNode(this.Root, variables);
            return variables;
        }

        /// <summary>
        /// Node visitor
        /// </summary>
        /// <param name="root"></param>
        /// <param name="holder"></param>
        private void VisitVariableNode(Implements.Node root, List<String> holder)
        {
            if (root is VariableNode){
                VariableNode varNode = (VariableNode)root;
                if (!holder.Contains(varNode.Name))
                {
                    holder.Add(varNode.Name);
                }
            }else if (root is BinanyNode){
                BinanyNode binNode = (BinanyNode)root;
                VisitVariableNode(binNode.LHS, holder);
                VisitVariableNode(binNode.RHS, holder);
            }else if (root is IfElseNode){
                IfElseNode ifElseNode = (IfElseNode)root;
                VisitVariableNode(ifElseNode.Condition, holder);
                VisitVariableNode(ifElseNode.IfTrue, holder);
                VisitVariableNode(ifElseNode.IfFalse, holder);
            }else if (root is SwitchCaseNode){
                SwitchCaseNode caseNode = (SwitchCaseNode)root;
                VisitVariableNode(caseNode.conditionExpr, holder);
                for (int i = 0; i < caseNode.varResultExprs.Count - 1; i = i + 1)
                {
                    VisitVariableNode(caseNode.varResultExprs[i], holder);
                }
                VisitVariableNode(caseNode.defaultExpr, holder);
            }else if (root is CallFuncNode){
                CallFuncNode callFunc = (CallFuncNode)root;
                for (int i = 0; i < callFunc.args.Count; i++)
                {
                    Implements.Node expr = callFunc.args[i];
                    VisitVariableNode(expr, holder);
                }
            }else if (root is UnaryNode){
                UnaryNode unaryNode = (UnaryNode)root;
                VisitVariableNode(unaryNode.Expr, holder);
            }
        }

        /// <summary>
        /// Visit tree node method
        /// this method can be process recursive itself
        /// </summary>
        /// <param name="root">root</param>
        /// <returns>Value Node</returns>
        private Object VisitNode(Implements.Node root)
        {
            // Check root is null then Exception
            if (root == null)
            {
                throw new Exception(Afe_Common.MSG_UNABLE_PARSE_EXPR);
            }
            else if (root is NumberNode)
            {
                NumberNode numberNode = (NumberNode)root;
                return numberNode.mustRoundFlag ? Afe_Common.Round(numberNode.NumberValue, this.Dc): numberNode.NumberValue;
            }
            else if (root is StringNode)
            {
                return ((StringNode)root).Value;
            }
            else if (root is BoolNode)
            {
                return ((BoolNode)root).Value;
            }
            else if (root is VariableNode)
            {
                VariableNode varNode = (VariableNode)root;
                if (!VariableParams.ContainsKey(varNode.Name.ToLower()))
                {
                    throw new Exception(string.Format(Afe_Common.MSG_VAR_NOTSET, new string[] { varNode.Name }));
                }
                Object value = VariableParams[varNode.Name.ToLower()];
                //if (value is decimal)
                if (Afe_Common.IsNumber(value))
                {
                    return Afe_Common.Round(Convert.ToDecimal(value), this.Dc);
                }
                else return value;
            }
            else if (root is BinanyNode)
            {
                BinanyNode binNode = (BinanyNode)root;
                Object left = this.VisitNode(binNode.LHS);
                Object right = this.VisitNode(binNode.RHS);
                return binNode.iOp.Calculate(left, right, Dc);
            }
            else if (root is IfElseNode)
            {
                IfElseNode ifElseNode = (IfElseNode)root;
                if (ifElseNode.Condition is IfElseNode)
                {
                    throw new Exception(Afe_Common.MSG_IFELSE_NESTIF_CONDITION);
                }
                Object ConditionResult = this.VisitNode(ifElseNode.Condition);
                if (ConditionResult is Boolean)
                {
                    return (Boolean)ConditionResult == true ? this.VisitNode(ifElseNode.IfTrue) : VisitNode(ifElseNode.IfFalse);
                }
                throw new Exception(Afe_Common.MSG_IFELSE_WRONG_SYNTAX);
            }
            else if (root is SwitchCaseNode)
            { 
                return this.ExecuteSwitchCase((SwitchCaseNode)root);
            }
            else if (root is CallFuncNode)
            {
                return this.ExecuteCallFunc((CallFuncNode)root);
            }
            else if (root is UnaryNode)
            {
                UnaryNode unaryNode = (UnaryNode)root;
                Object left = this.VisitNode(unaryNode.Expr);
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
        private Object ExecuteCallFunc(CallFuncNode callFunc)
        {
            if (NotAllowedFunctions != null && NotAllowedFunctions.Contains(callFunc.FuncName.ToLower()))
            {
                throw new Exception(string.Format(Afe_Common.MSG_METH_NOT_ALLOWED, new string[] { callFunc.FuncName }));
            }

            Dictionary<string, Object> argsMap = new Dictionary<string, Object>();
            int i = 0;

            foreach (Implements.Node expr in callFunc.args)
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
        private Object ExecuteSwitchCase(SwitchCaseNode root)
        {
            IOperator eq = new EqOperator(Afe_Common.Const_EqsOperator, 300, Assoc.LEFT);
            Object condition = this.VisitNode(root.conditionExpr);
            for (int i = 0; i < root.varResultExprs.Count - 1; i += 2)
            {
                Object var = this.VisitNode(root.varResultExprs[i]);
                bool compareResult = (bool)eq.Calculate(condition, var, this.Dc);
                if (compareResult)
                {
                    return this.VisitNode(root.varResultExprs[i+1]);
                }
            }
            return this.VisitNode(root.defaultExpr);
        }

    }
}
