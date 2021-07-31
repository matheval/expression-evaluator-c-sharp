using org.matheval.Operators;
using System;

namespace org.matheval.Node
{
    /// <summary>
    /// Create class BinanyNode implements node
    /// </summary>
    public class BinanyNode : Implements.Node
    {
        /// <summary>   
        /// Node Left
        /// </summary>
        public Implements.Node LHS;

        /// <summary>
        /// Node Right
        /// </summary>
        public Implements.Node RHS;

        /// <summary>
        /// iOp
        /// </summary>
        public IOperator iOp;

        /// <summary>
        /// Initializes a new instance structure to a specified
        /// 1. IOperator value
        /// 2. Node left
        /// 3. Node right
        /// 4. Return type
        /// </summary>
        /// <param name="iop">iop</param>
        /// <param name="lhs">lhs</param>
        /// <param name="rhs">rhs</param>
        /// <param name="returnType">returnType</param>
        public BinanyNode(IOperator iop, Implements.Node lhs, Implements.Node rhs, Type returnType) : base(returnType)
        {
            this.iOp = iop;
            this.LHS = lhs;
            this.RHS = rhs;
        }
    }
}
