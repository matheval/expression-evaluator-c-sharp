using System;

namespace org.matheval.Node
{
    /// <summary>
    /// Boolnode, used to hold boolean value
    /// </summary>
    public class BoolNode : Implements.Node
    {
        /// <summary>
        /// Value
        /// </summary>
        public bool Value;

        /// <summary>
        /// Initializes a new instance structure to a specified type Boolean value
        /// </summary>
        /// <param name="value">value</param>
        public BoolNode(bool value) : base(typeof(bool))
        {
            Value = value;
        }
    }
}
