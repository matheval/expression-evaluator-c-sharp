namespace org.matheval.Node
{
    /// <summary>
    /// Nullnode, used to hold null value
    /// </summary>
    public class NullNode : Implements.Node
    {
        /// <summary>
        /// Initializes a new instance
        /// </summary>
        /// <param name="numberVal">numberVal</param>
       // public NullNode() : base(typeof(int))
        public NullNode() : base(typeof(object))
        {
        }
    }
}
