using System;
using System.Collections.Generic;

namespace org.matheval.Node
{
    /// <summary>
    /// Create class SwitchCaseNode implements node
    /// Condition node, used to hold CASE condition
    /// </summary>
    public class SwitchCaseNode : Implements.Node
    {
        /// <summary>
        /// Node condition
        /// </summary>
        public Implements.Node conditionExpr;

        /// <summary>
        /// List node result
        /// </summary>
        public List<Implements.Node> varResultExprs;

        /// <summary>
        /// Node default
        /// </summary>
        public Implements.Node defaultExpr;

        /// <summary>
        /// Initializes a new instance structure to a specified
        /// 1. Node condition
        /// 2. List node result
        /// 3. Node default
        /// 4. Return type
        /// </summary>
        /// <param name="conditionExpr">conditionExpr</param>
        /// <param name="varResultExprs">varResultExprs</param>
        /// <param name="defaultExpr">defaultExpr</param>
        /// <param name="returnType">returnType</param>
        public SwitchCaseNode(Implements.Node conditionExpr, List<Implements.Node> varResultExprs, Implements.Node defaultExpr, Type returnType) : base(returnType)
        {
            this.conditionExpr = conditionExpr;
            this.varResultExprs = varResultExprs;
            this.defaultExpr = defaultExpr;
        }
    }
}
