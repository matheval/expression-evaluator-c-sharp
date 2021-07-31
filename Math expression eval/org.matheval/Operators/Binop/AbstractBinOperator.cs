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
using org.matheval.Node;
using org.matheval.Operators;
using System;
using static org.matheval.Common.Afe_Common;

namespace org.matheval.Operators.Binop
{
    /// <summary>
    /// Create abstract AbstractUnaryOperator implements abstract BaseOperator and interface IOperator
    /// Base class for executing binop
    /// </summary>
    public abstract class AbstractBinOperator : BaseOperator, IOperator
    {
        /// <summary>
        /// Assoc
        /// </summary>
        protected Assoc Assoc;

        /// <summary>
        /// Initializes a new instance structure
        /// </summary>
        public AbstractBinOperator()
        {
        }

        /// <summary>
        /// Initializes a new instance structure to a specified type string op and type int precedence
        /// </summary>
        /// <param name="op">op</param>
        /// <param name="precedence">precedence</param>
        public AbstractBinOperator(string op, int precedence)
        {
            Op = op;
            Prec = precedence;
            Assoc = Assoc.LEFT;
        }

        /// <summary>
        /// Initializes a new instance structure to a specified
        /// 1. Type string value 
        /// 2. Type int value
        /// 3. Type Assoc value
        /// </summary>
        /// <param name="op"></param>
        /// <param name="precedence"></param>
        /// <param name="assoc"></param>
        public AbstractBinOperator(string op, int precedence, Assoc assoc)
        {
            Op = op;
            Prec = precedence;
            Assoc = assoc;
        }

        /// <summary>
        /// GetAss
        /// </summary>
        /// <returns>Assoc</returns>
        public override Assoc GetAss()
        {
            return Assoc;
        }

        /// <summary>
        /// Calculate
        /// </summary>
        /// <param name="left">left</param>
        /// <param name="right">right</param>
        /// <param name="dc">dc</param>
        /// <returns>Value is type Object result Calculate</returns>
        public override object Calculate(object left, object right, ExpressionContext dc)
        {
            return new NotImplementedException();
        }

        /// <summary>
        /// Validate
        /// </summary>
        /// <param name="typeLeft">typeLeft</param>
        /// <param name="typeRight">typeRight</param>
        /// <returns>Type</returns>
        public override Type Validate(Type typeLeft, Type typeRight)
        {
            return typeof(VariableNode);
        }
    }
}
