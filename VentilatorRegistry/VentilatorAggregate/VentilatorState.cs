using System;

namespace VentilatorRegistry.VentilatorAggregate
{
    public class VentilatorState
    {
        public virtual string Code { get; protected set; }
        public virtual string Description { get; protected set; }

        protected VentilatorState()
        {

        }

        public VentilatorState(string code, string description) : this()
        {
            if (string.IsNullOrEmpty(code = code?.Trim()))
            {
                throw new ArgumentNullException("code cannot be null or empty");
            }

            if (string.IsNullOrEmpty(description = description?.Trim()))
            {
                throw new ArgumentNullException("description cannot be null or empty");
            }

            Code = code;
            Description = description;
        }
    }
}