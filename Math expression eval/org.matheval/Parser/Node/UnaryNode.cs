using org.matheval.Operators;

namespace org.matheval.Node
{
    /// <summary>
    /// Create class UnaryNode implements node
    /// Unary node, used to hold unary operator
    /// </summary>
    public class UnaryNode : Implements.Node
    {
        /// <summary>
        /// Expr
        /// </summary>
        public Implements.Node Expr;

        /// <summary>
        /// Iop
        /// </summary>
        public IOperator Iop;

        /// <summary>
        /// Initializes a new instance structure to a specified type IOperator iop and type Node expr
        /// </summary>
        /// <param name="iop">iop</param>
        /// <param name="expr">expr</param>
        public UnaryNode(IOperator iop, Implements.Node expr) : base(typeof(decimal))
        {
            this.Iop = iop;
            this.Expr = expr;
        }
    }
}
