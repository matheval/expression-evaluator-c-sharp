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
using org.matheval.Functions;
using org.matheval.Node;
using org.matheval.Operators;
using org.matheval.Operators.Binop;
using org.matheval.Operators.Unary;
using System;
using System.Collections.Generic;
using static org.matheval.Common.Afe_Common;

namespace org.matheval
{
    public class Parser
    {
        /// <summary>
        /// Create object Lexer
        /// </summary>
        private Lexer Lexer;

        /// <summary>
        /// Create Dictionary Operators have key is string and value is interface IOperator
        /// </summary>
        private Dictionary<string, IOperator> Operators = null;

        /// <summary>
        /// Create Dictionary UnaryOperators have key is string and value is interface IOperator
        /// </summary>
        private Dictionary<string, IOperator> UnaryOperators = null;

        /// <summary>
        /// Create Dictionary Constants have key is string and value is interface IOperator
        /// </summary>
        private Dictionary<string, Object> Constants = null;

        /// <summary>
        /// Initializes a new instance structure with no param
        /// </summary>
        public Parser()
        {
            this.InitOperators();
            this.InitConstants();
        }

        /// <summary>
        /// Initializes a new instance structure to a specified type string value input expression
        /// </summary>
        /// <param name="formular">formular</param>
        public Parser(string formular)
        {
            this.InitOperators();
            this.InitConstants();
            this.Lexer = new Lexer(formular, this);
            //this.Lexer.GetToken();
        }

        /// <summary>
        /// Provide expression for lexer
        /// @param fumular input expression
        /// </summary>
        /// <param name="formular">formular</param>
        public void SetFomular(string formular)
        {
            this.Lexer = new Lexer(formular, this);
            //this.Lexer.GetToken();
        }

        /// <summary>
        /// Add Operator
        /// @param op Operator instance
        /// </summary>
        /// <param name="op">op</param>
        public void AddOperator(IOperator op)
        {
            if (Operators == null)
            {
                Operators = new Dictionary<string, IOperator>();
            }
            Operators.Add(op.GetOp(), op);
        }

        /// <summary>
        /// Add Unary Operator
        /// @param op Unary operator instance
        /// </summary>
        /// <param name="op">op</param>
        public void AddUnaryOperator(IOperator op)
        {
            if (UnaryOperators == null)
            {
                UnaryOperators = new Dictionary<string, IOperator>();
            }
            UnaryOperators.Add(op.GetOp(), op);
        }

        /// <summary>
        /// Get operator list
        /// </summary>
        /// <returns>Dictionary operators</returns>
        public Dictionary<string, IOperator> GetOperators()
        {
            return Operators;
        }

        /// <summary>
        /// Get Unary Operators
        /// </summary>
        /// <returns>Dictionary UnaryOperators</returns>
        public Dictionary<string, IOperator> GetUnaryOperators()
        {
            return UnaryOperators;
        }

        /// <summary>
        /// Add Constant
        /// </summary>
        /// <param name="constantName">constantName constant name</param>
        /// <param name="value">Constant value</param>
        public void AddConstant(string constantName, Object value)
        {
            if (Constants == null)
            {
                Constants = new Dictionary<string, Object>();
            }
            Constants.Add(constantName.ToLower(), value);
        }

        /// <summary>
        /// Init Operators
        /// </summary>
        private void InitOperators()
        {
            AddOperator(new OrOperator(Afe_Common.Const_OrOperator, 100, Assoc.LEFT));
            AddOperator(new AndOperator(Afe_Common.Const_AndOperator, 200, Assoc.LEFT));
            AddOperator(new EqOperator(Afe_Common.Const_EqOperator, 300, Assoc.LEFT));
            AddOperator(new EqOperator(Afe_Common.Const_EqsOperator, 300, Assoc.LEFT));
            AddOperator(new NeqOperator(Afe_Common.Const_NeqOperator, 300, Assoc.LEFT));
            AddOperator(new NeqOperator(Afe_Common.Const_Neq1Operator, 300, Assoc.LEFT));
            AddOperator(new LtOperator(Afe_Common.Const_LtOperator, 400, Assoc.LEFT));
            AddOperator(new LeOperator(Afe_Common.Const_LeOperator, 400, Assoc.LEFT));
            AddOperator(new GtOperator(Afe_Common.Const_GtOperator, 400, Assoc.LEFT));
            AddOperator(new GeOperator(Afe_Common.Const_GeOperator, 400, Assoc.LEFT));
            AddOperator(new PlusOperator(Afe_Common.Const_PlusOperator, 500, Assoc.LEFT));
            AddOperator(new ConcatOperator(Afe_Common.Const_ConcatOperator, 500, Assoc.LEFT));
            AddOperator(new MinusOperator(Afe_Common.Const_MinusOperator, 500, Assoc.LEFT));
            AddOperator(new MulOperator(Afe_Common.Const_MulOperator, 600, Assoc.LEFT));
            AddOperator(new DivOperator(Afe_Common.Const_DivOperator, 600, Assoc.LEFT));
            AddOperator(new RemainderOperator(Afe_Common.Const_RemainderOperator, 600, Assoc.LEFT));
            AddUnaryOperator(new UnaryPosOperator(Afe_Common.Const_UnaryPosOperator, 700));
            AddUnaryOperator(new UnaryNegOperator(Afe_Common.Const_UnaryNegOperator, 700));
            AddOperator(new PowerOperator(Afe_Common.Const_PowerOperator, 800, Assoc.RIGHT));
        }

        /// <summary>
        /// Init Constants
        /// </summary>
        private void InitConstants()
        {
            AddConstant("e", Math.E);
            AddConstant("pi", Math.PI);
            AddConstant("true", true);
            AddConstant("false", false);
            AddConstant("null", null);
        }

        /// <summary>
        /// Parse Double Number
        /// </summary>
        /// <returns>Node Base node instance</returns>
        private Implements.Node ParseDoubleNumber()
        {
            NumberNode nbrNode = new NumberNode(this.Lexer.CurrentToken.DoubleValue, true);
            Lexer.GetToken();
            return nbrNode;
        }

        /// <summary>
        /// Parse String
        /// </summary>
        /// <returns>Node Base node instance</returns>
        private Implements.Node ParseString()
        {
            StringNode strNode = new StringNode(this.Lexer.CurrentToken.IdentifierValue);
            Lexer.GetToken();
            return strNode;
        }

        /// <summary>
        /// Parse Bool
        /// </summary>
        /// <returns>Node Base node instance</returns>
        private Implements.Node ParseBool()
        {
            BoolNode boolNode = new BoolNode(this.Lexer.CurrentToken.BoolValue);
            Lexer.GetToken();
            return boolNode;
        }

        /// <summary>
        /// Parse Constant
        /// </summary>
        /// <param name="identifier">identifier</param>
        /// <returns>Node Base node instance</returns>
        private Implements.Node ParseConstant(string identifier)
        {
            if (Constants.ContainsKey(identifier))
            {
                Object constant = Constants[identifier];
                if (constant == null)
                {
                    return new NullNode();
                }
                else if (Afe_Common.IsNumber(constant))
                {
                    if(!identifier.Equals("pi") && !identifier.Equals("e"))
                    {
                        return new NumberNode(Afe_Common.ToDecimal(constant), true);
                    }
                    else
                    {
                        return new NumberNode(Afe_Common.ToDecimal(constant), false);
                    }
                }
                else if (constant is string)
                {
                    return new StringNode(constant.ToString());
                }
                else if (constant is Boolean)
                {
                    return new BoolNode((Boolean)constant);
                }
                else
                {
                    throw new Exception(Afe_Common.MSG_UNSUPPORT_CONST);
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Parse variable, function call and constant
        /// </summary>
        /// <returns>Node Base node instance</returns>
        private Implements.Node ParseIdentifier()
        {
            string identifierStr = this.Lexer.CurrentToken.IdentifierValue;
            this.Lexer.GetToken();
            if (this.Lexer.CurrentToken.Type != TokenType.TOKEN_PAREN_OPEN)
            {
                Implements.Node constantNode;
                if ((constantNode = this.ParseConstant(identifierStr.ToLower())) != null)
                {
                    return constantNode;
                }
                VariableNode node = new VariableNode(identifierStr);
                return node;
            }
            else
            {
                this.Lexer.GetToken();// eat (
                List<Implements.Node> args = new List<Implements.Node>();
                if (this.Lexer.CurrentToken.Type != TokenType.TOKEN_PAREN_CLOSE)
                {
                    while (true)
                    {
                        Implements.Node arg = this.ParseEx();
                        args.Add(arg);
                        if (this.Lexer.CurrentToken.Type == TokenType.TOKEN_PAREN_CLOSE)
                        {
                            break;
                        }
                        if (this.Lexer.CurrentToken.Type != TokenType.TOKEN_COMMA)
                        {
                            throw new Exception(string.Format(Afe_Common.MSG_UNEXPECT_TOKEN_AT_POS, new String[] { this.Lexer.CurrentToken.ToString(), Lexer.LexerPosition.ToString() }));
                        }
                        Lexer.GetToken();
                    }
                }
                this.Lexer.GetToken();// eat )
                IFunction funcExecuter;
                try
                {
                    Type t = Type.GetType("org.matheval.Functions." + identifierStr.ToLower() + "Function", true);
                    Object obj = (Activator.CreateInstance(t));

                    if (obj == null)
                    {
                        throw new Exception();
                    }
                    funcExecuter = (IFunction)obj;
                }
                catch (Exception e)
                {
                    throw new Exception(string.Format(Afe_Common.MSG_METH_NOTFOUND, new string[] { identifierStr.ToUpper() }));
                }
                
                List<FunctionDef> functionInfos = funcExecuter.GetInfo();
                foreach (FunctionDef functionInfo in functionInfos)
                {
                    //getParamCount() = -1 when params is unlimited
                    if ((functionInfo.ParamCount != -1 && args.Count != functionInfo.ParamCount) ||
                        (functionInfo.ParamCount == -1 && args.Count < 1))
                    {
                        continue;
                    }

                    Boolean paramsValid = true;
                    for (int i = 0; i < args.Count; i++)
                    {
                        Implements.Node arg = args[i];
                        System.Type compareTarget = functionInfo.ParamCount == -1 ? functionInfo.Args[0] : functionInfo.Args[i];
                        //if (!arg.ReturnType.Equals(typeof(VariableNode)) &&
                        if (!arg.ReturnType.Equals(typeof(object)) &&
                        !functionInfo.Args[functionInfo.ParamCount == -1 ? 0 : i].Equals(typeof(Object)) &&
                        !arg.ReturnType.Equals(compareTarget))
                        {
                            paramsValid = false;
                        }
                    }

                    if (paramsValid)
                    {
                        CallFuncNode callFuncNode = new CallFuncNode(identifierStr, args, functionInfo.ReturnType, funcExecuter);
                        return callFuncNode;
                    }
                }
                throw new Exception(string.Format(Afe_Common.MSG_WRONG_METH_PARAM, new string[] { identifierStr.ToUpper() }));
            }
        }

        /// <summary>
        /// Parse Pr of math expression
        /// </summary>
        /// <returns>Node Base node instance</returns>
        private Implements.Node ParsePr()
        {
            this.Lexer.GetToken();

            //check if Parentheses has null body
            if (this.Lexer.CurrentToken.Type == TokenType.TOKEN_PAREN_CLOSE)
            {
                this.Lexer.GetToken();
                throw new Exception(string.Format(Afe_Common.MSG_PAREN_NULL_BODY, new String[] { Lexer.LexerPosition.ToString() }));
            }

            // Parse Parentheses body
            Implements.Node subNode = this.ParseEx();
            if (this.Lexer.CurrentToken.Type != TokenType.TOKEN_PAREN_CLOSE)
            {
                throw new Exception(string.Format(Afe_Common.MSG_UNEXPECT_TOKEN_AT_POS, new String[] { this.Lexer.CurrentToken.ToString(), Lexer.LexerPosition.ToString() }));
            }

            this.Lexer.GetToken();
            return subNode;
        }

        /// <summary>
        /// Parse Top of math expression
        /// </summary>
        /// <returns>Node Base node instance</returns>
        public Implements.Node ParseTop()
        {
            this.Lexer.resetLexer();
            this.Lexer.GetToken();
            Implements.Node root = this.ParseEx();
            if (this.Lexer.CurrentToken.Type != TokenType.TOKEN_EOF)
            {
                throw new Exception(string.Format(Afe_Common.MSG_UNEXPECT_TOKEN_AT_POS, new string[] { this.Lexer.CurrentToken.ToString(), Lexer.LexerPosition.ToString() }));
            }
            return root;
        }

        /// <summary>
        /// Parse Ex of math expression
        /// </summary>
        /// <returns>Node Base node instance</returns>
        private Implements.Node ParseEx()
        {
            Implements.Node lhs = this.ParsePrm();
            if (null != lhs)
            {
                //return this.ParseBo(0, lhs);
                return this.ParseBo(100, lhs);
            }
            throw new Exception(Afe_Common.MSG_UNABLE_PARSE_EXPR);
        }

        /// <summary>
        /// Parse Bo of math expression
        /// </summary>
        /// <param name="inputPrec">inputPrec</param>
        /// <param name="lhs">lhs</param>
        /// <returns>Node Base node instance</returns>
        private Implements.Node ParseBo(int inputPrec, Implements.Node lhs)
        {
            while (true)
            {
                IOperator iopCurr = this.GetOperator();
                if (iopCurr == null || iopCurr.GetPrec() < inputPrec)
                {
                    return lhs;
                }

                this.Lexer.GetToken();
                Implements.Node rhs = this.ParsePrm();
                if (rhs == null)
                {
                    throw new Exception(Afe_Common.MSG_UNABLE_PARSE_EXPR);
                }
                while (true)
                {
                    IOperator iopNext = this.GetOperator();
                    if (iopNext == null || 
                        !(iopCurr.GetPrec() < iopNext.GetPrec() ||
                        (iopCurr.GetPrec() == iopNext.GetPrec() && 
                        iopNext.GetAss() == Assoc.RIGHT)))
                    {
                        break;
                    }
                    //rhs = this.ParseBo(iopCurr.GetPrec(), rhs);
                    rhs = this.ParseBo(iopNext.GetPrec(), rhs);
                }
                //if (!lhs.ReturnType.Equals(typeof(VariableNode)) && !rhs.ReturnType.Equals(typeof(VariableNode)))

                System.Type t = iopCurr.Validate(lhs.ReturnType, rhs.ReturnType);
                if (t == null)
                {
                    /*if (!lhs.ReturnType.Equals(typeof(object)) && !rhs.ReturnType.Equals(typeof(object)))
                    {*/
                        throw new Exception(string.Format(Afe_Common.MSG_WRONG_OP_PARAM,
                                      new String[] { iopCurr.GetOp(), lhs.ReturnType.ToString(), rhs.ReturnType.ToString() }));
                    /*}
                    else if (!lhs.ReturnType.Equals(typeof(object)))
                    {
                        lhs = new BinanyNode(iopCurr, lhs, rhs, lhs.ReturnType);
                    }
                    else if (!rhs.ReturnType.Equals(typeof(object)))
                    {
                        lhs = new BinanyNode(iopCurr, lhs, rhs, rhs.ReturnType);
                    }
                    else
                    {
                        lhs = new BinanyNode(iopCurr, lhs, rhs, typeof(object));
                    }*/
                }
                else
                {
                    lhs = new BinanyNode(iopCurr, lhs, rhs, t);
                }
            }
        }

        /// <summary>
        /// Get relate operator excuter
        /// </summary>
        /// <returns>IOperator operator executer</returns>
        private IOperator GetOperator()
        {
            string op = this.Lexer.CurrentToken.IdentifierValue;
            return (this.Lexer.CurrentToken.Type == TokenType.TOKEN_OP && this.Operators.ContainsKey(op)) ? this.Operators[op] : null;
        }

        /// <summary>
        /// Parse Unary
        /// </summary>
        /// <returns>Node Base node instance</returns>
        private Implements.Node ParseUnary()
        {
            string op = this.Lexer.CurrentToken.IdentifierValue;
            IOperator iop = this.UnaryOperators[op];
            this.Lexer.GetToken();
            Implements.Node lhs = this.ParsePrm();
            Implements.Node expr = this.ParseBo(iop.GetPrec(), lhs);

            if (expr == null)
            {
                throw new Exception(string.Format(Afe_Common.MSG_UNEXPECT_TOKEN_AT_POS,
                              new string[] { this.Lexer.CurrentToken.ToString(), Lexer.LexerPosition.ToString() }));
            }

            return new UnaryNode(iop, expr);
        }

        /// <summary>
        /// Parse ifelse condition
        /// Example:
        /// new Afe_Evaluator('IF(abc > 1 && true,if(cde + 1 <6.5, "amazing", "n/a"), "n/a")')
        /// .bind('abc',2).bind('cde',3).eval() -> return "amazing"
        /// </summary>
        /// <returns>Node Base node instance</returns>
        private Implements.Node ParseIfElse()
        {
            this.Lexer.GetToken();

            //parse IF condition
            if (this.Lexer.CurrentToken.Type != TokenType.TOKEN_PAREN_OPEN)
            {
                throw new Exception(string.Format(Afe_Common.MSG_UNEXPECT_TOKEN_AT_POS,
                                  new String[] { this.Lexer.CurrentToken.ToString(), Lexer.LexerPosition.ToString() }));
            }

            this.Lexer.GetToken();//eat (
            Implements.Node condition = this.ParseEx();

            //parse if true condition
            if (this.Lexer.CurrentToken.Type != TokenType.TOKEN_COMMA)
            {
                throw new Exception(string.Format(Afe_Common.MSG_UNEXPECT_TOKEN_AT_POS,
                              new string[] { this.Lexer.CurrentToken.ToString(), Lexer.LexerPosition.ToString() }));
            }

            this.Lexer.GetToken(); //eat ,
            Implements.Node ifTrueNode = this.ParseEx();

            //parse if false condition
            if (this.Lexer.CurrentToken.Type != TokenType.TOKEN_COMMA)
            {
                throw new Exception(string.Format(Afe_Common.MSG_UNEXPECT_TOKEN_AT_POS,
                              new String[] { this.Lexer.CurrentToken.ToString(), this.Lexer.LexerPosition.ToString() }));
            }

            this.Lexer.GetToken(); //eat ,
            Implements.Node ifFalseNode = this.ParseEx();

            //check endif token
            if (this.Lexer.CurrentToken.Type != TokenType.TOKEN_PAREN_CLOSE)
            {
                throw new Exception(string.Format(Afe_Common.MSG_UNEXPECT_TOKEN_AT_POS,
                              new string[] { this.Lexer.CurrentToken.ToString(), this.Lexer.LexerPosition.ToString() }));
            }

            this.Lexer.GetToken(); //eat )
            //if (!condition.ReturnType.Equals(typeof(VariableNode)) && !condition.ReturnType.Equals(typeof(Boolean)))
            if (!condition.ReturnType.Equals(typeof(object)) && !condition.ReturnType.Equals(typeof(Boolean)))
            {
                throw new Exception(string.Format(Afe_Common.MSG_IFELSE_WRONG_CONDITION,
                              new string[] { condition.ReturnType.ToString() }));
            }
           // else if (!ifTrueNode.ReturnType.Equals(typeof(VariableNode)) &&
           //          !ifFalseNode.ReturnType.Equals(typeof(VariableNode)) &&
            else if (!ifTrueNode.ReturnType.Equals(typeof(object)) &&
                     !ifFalseNode.ReturnType.Equals(typeof(object)) &&
                     !ifTrueNode.ReturnType.Equals(ifFalseNode.ReturnType))
            {
                throw new Exception(string.Format(Afe_Common.MSG_CONDITIONAL_WRONG_PARAMS,
                              new String[] { Afe_Common.Const_IF, ifTrueNode.ReturnType.ToString(), ifFalseNode.ReturnType.ToString() }));
            }

            /*if (ifTrueNode.ReturnType.Equals(typeof(VariableNode)) || ifFalseNode.ReturnType.Equals(typeof(VariableNode)))
            {
                return new IfElseNode(condition, ifTrueNode, ifFalseNode, typeof(VariableNode));
            }
            else
            {
                return new IfElseNode(condition, ifTrueNode, ifFalseNode, ifTrueNode.ReturnType);
            }*/
            if (!ifTrueNode.ReturnType.Equals(typeof(object)))
            {
                return new IfElseNode(condition, ifTrueNode, ifFalseNode, ifTrueNode.ReturnType);
            }
            else if (!ifFalseNode.ReturnType.Equals(typeof(object)))
            {
                return new IfElseNode(condition, ifTrueNode, ifFalseNode, ifFalseNode.ReturnType);
            }
            else
            {
                return new IfElseNode(condition, ifTrueNode, ifFalseNode, typeof(object));
            }
        }

        /// <summary>
        /// Parse switch, case condition
        /// Example:
        /// new Afe_Evaluator('CASE(abc,1,"amazing",2,"good",3,"bad","n/a")').bind('abc',2).eval() -> return "good"
        /// </summary>
        /// <returns>Node Base node instance</returns>
        private Implements.Node ParseSwitchCase()
        {
            this.Lexer.GetToken();//eat Switch, case

            //parse switch condition
            if (this.Lexer.CurrentToken.Type != TokenType.TOKEN_PAREN_OPEN)
            {
                throw new Exception(string.Format(Afe_Common.MSG_UNEXPECT_TOKEN_AT_POS,
                             new string[] { this.Lexer.CurrentToken.ToString(), this.Lexer.LexerPosition.ToString() }));
            }

            this.Lexer.GetToken();//eat (
            Implements.Node condition = this.ParseEx();
            if (condition == null)
            {
                throw new Exception(Afe_Common.MSG_CASE_WRONG_PARAMS);
            }

            //Parse var and result.
            List<Implements.Node> varResultExprs = new List<Implements.Node>();
            while (true)
            {
                if (this.Lexer.CurrentToken.Type == TokenType.TOKEN_PAREN_CLOSE)
                {
                    if (varResultExprs.Count < 1)
                    {
                        throw new Exception(Afe_Common.MSG_CASE_WRONG_PARAMS);
                    }
                    else if (varResultExprs.Count % 2 == 0)
                    {
                        throw new Exception(Afe_Common.MSG_CASE_WRONG_PARAMS);
                    }
                    this.Lexer.GetToken(); //eat )  				

                    System.Type temp = varResultExprs[varResultExprs.Count - 1].ReturnType;
                    for (int i = 1; i < varResultExprs.Count - 1; i += 2)
                    {
                        //if (!temp.Equals(typeof(VariableNode)) && !temp.Equals(varResultExprs[i].ReturnType))
                        if (!temp.Equals(typeof(object)) && !temp.Equals(varResultExprs[i].ReturnType))
                            {
                            throw new Exception(string.Format(Afe_Common.MSG_CONDITIONAL_WRONG_PARAMS,
                                          new string[] { Afe_Common.Const_SWITCH, temp.ToString(), varResultExprs[i].ReturnType.ToString() }));
                        }
                    }

                    return new SwitchCaseNode(condition, varResultExprs, varResultExprs[varResultExprs.Count - 1], temp);
                }
                if (this.Lexer.CurrentToken.Type != TokenType.TOKEN_COMMA)
                {
                    throw new Exception(string.Format(Afe_Common.MSG_UNEXPECT_TOKEN_AT_POS,
                                 new string[] { this.Lexer.CurrentToken.ToString(), Lexer.LexerPosition.ToString() }));
                }

                this.Lexer.GetToken(); //eat ,
                Implements.Node tempExpr = this.ParseEx();
                varResultExprs.Add(tempExpr);
            }
        }

        /// <summary>
        /// Start parse anything inside a binary expression
        /// </summary>
        /// <returns>Node Base node instance</returns>
        private Implements.Node ParsePrm()
        {
            if (this.Lexer.CurrentToken.Type == TokenType.TOKEN_IDENTIFIER)
            {
                return this.ParseIdentifier();
            }
            else if (this.Lexer.CurrentToken.Type == TokenType.TOKEN_IF)
            {
                return this.ParseIfElse();
            }
            else if (this.Lexer.CurrentToken.Type == TokenType.TOKEN_CASE)
            {
                return this.ParseSwitchCase();
            }
            else if (this.Lexer.CurrentToken.Type == TokenType.TOKEN_NUMBER_DECIMAL)
            {
                return this.ParseDoubleNumber();
            }
            else if (this.Lexer.CurrentToken.Type == TokenType.TOKEN_STRING)
            {
                return this.ParseString();
            }
            else if (this.Lexer.CurrentToken.Type == TokenType.TOKEN_BOOL)
            {
                return this.ParseBool();
            }
            else if (this.Lexer.CurrentToken.Type == TokenType.TOKEN_PAREN_OPEN)
            {
                return this.ParsePr();
            }
            else if (this.Lexer.CurrentToken.Type == TokenType.TOKEN_UOP)
            {
                return this.ParseUnary();
            }
            throw new Exception(string.Format(Afe_Common.MSG_UNEXPECT_TOKEN_AT_POS,
                             new String[] { this.Lexer.CurrentToken.ToString(), this.Lexer.LexerPosition.ToString() }));
        }

    }
}
