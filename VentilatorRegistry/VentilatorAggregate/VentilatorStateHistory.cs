using System;

namespace VentilatorRegistry.VentilatorAggregate
{
    public class VentilatorStateHistory
    {
        public virtual Ventilator Ventilator { get; protected set; }
        public virtual VentilatorStatesTransaction Transaction { get; protected set; }
        public virtual DateTimeOffset DateHourCreation { get; protected set; }
        public virtual int IdUser { get; protected set; }

        protected VentilatorStateHistory()
        {
            DateHourCreation = DateTimeOffset.UtcNow;
        }

        public VentilatorStateHistory(Ventilator ventilator, VentilatorStatesTransaction transaction, int idUser) : this()
        {
            Ventilator = ventilator ?? throw new ArgumentNullException("ventilator cannot be null");
            Transaction = transaction ?? throw new ArgumentNullException("transaction cannot be null");
            IdUser = idUser;
        }
    }
}
