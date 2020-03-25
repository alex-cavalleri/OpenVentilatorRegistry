using System;
using System.Linq;

namespace VentilatorRegistry.VentilatorAggregate
{
    public class VentilatorStatesTransaction
    {
        public virtual string Code { get; protected set; }
        public virtual string Description { get; protected set; }
        public virtual VentilatorState From { get; protected set; }
        public virtual VentilatorState To { get; protected set; }

        protected VentilatorStatesTransaction()
        {

        }

        public VentilatorStatesTransaction(string code, string description, VentilatorState from, VentilatorState to) : this()
        {
            if (string.IsNullOrEmpty(code = code?.Trim()))
            {
                throw new ArgumentNullException("code cannot be null or empty");
            }

            if (string.IsNullOrEmpty(description = description?.Trim()))
            {
                throw new ArgumentNullException("description cannot be null or empty");
            }

            From = VentilatorStatesList.AllVentilatorStates.FirstOrDefault(s => s.Code == from?.Code) ?? throw new ArgumentNullException($"state with code {from?.Code} not found");
            To = VentilatorStatesList.AllVentilatorStates.FirstOrDefault(s => s.Code == to?.Code) ?? throw new ArgumentNullException($"state with code {to?.Code} not found");
            Code = code;
            Description = description;
        }
    }
}
