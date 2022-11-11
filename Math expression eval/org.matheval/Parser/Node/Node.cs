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
        public System.Type ReturnType { get; }

        /// <summary>
        /// Initializes a new instance structure to a specified System.Type returnType
        /// </summary>
        /// <param name="returnType">returnType</param>
        public Node(System.Type returnType)
        {
            ReturnType = returnType;
        }
    }
}
