namespace org.matheval.Node
{
    /// <summary>
    /// Variablenode, used to hold variable
    /// </summary>
    public class VariableNode : Implements.Node
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name;

        /// <summary>
        /// Initializes a new instance structure to a specified type string value
        /// </summary>
        /// <param name="name">name</param>
        //public VariableNode(string name) : base(typeof(VariableNode))
        public VariableNode(string name) : base(typeof(object))
        {
            this.Name = name;
        }
    }
}
