namespace org.matheval.Node
{
    /// <summary>
    /// Doublenode, used to hold number value
    /// </summary>
    public class NumberNode : Implements.Node
    {
        /// <summary>
        /// Number Value
        /// </summary>
        public decimal NumberValue;

        /// <summary>
        /// Need to be rounded
        /// </summary>
        public bool mustRoundFlag;

        /// <summary>
        /// Initializes a new instance structure to a specified type decimal value
        /// </summary>
        /// <param name="numberVal">numberVal</param>
        /// <param name="mustRoundFlag">mustRoundFlag</param>
        public NumberNode(decimal numberVal, bool mustRoundFlag) : base(typeof(decimal))
        {
            this.NumberValue = numberVal;
            this.mustRoundFlag = mustRoundFlag;
        }
    }
}
