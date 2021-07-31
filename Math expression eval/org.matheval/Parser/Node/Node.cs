namespace org.matheval.Implements
{
    /// <summary>
    /// Create abstract Node
    /// </summary>
    public abstract class Node
    {
        /// <summary>
        /// Return Type
        /// </summary>
        public System.Type ReturnType;

        /// <summary>
        /// Initializes a new instance
        /// </summary>
        public Node()
        {
            ReturnType = null;
        }

        /// <summary>
        /// Initializes a new instance structure to a specified System.Type returnType
        /// </summary>
        /// <param name="returnType">returnType</param>
        public Node(System.Type returnType)
        {
            this.ReturnType = returnType;
        }
    }
}
