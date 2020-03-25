using System;
using System.Collections.Generic;
using System.Linq;

namespace VentilatorRegistry.VentilatorAggregate
{
    public class Ventilator
    {
        public virtual int Id { get; protected set; }
        public virtual VentilatorModel Model { get; protected set; }
        public virtual VentilatorState State { get; protected set; }
        public virtual string SerialNumber { get; protected set; }
        public virtual int IdUserCreation { get; protected set; }
        public virtual DateTimeOffset DateHourCreation { get; protected set; }
        private List<VentilatorStateHistory> _stateHistories { get; set; }
        public IReadOnlyCollection<VentilatorStateHistory> StateHistories => _stateHistories.AsReadOnly();

        protected Ventilator()
        {
            DateHourCreation = DateTimeOffset.UtcNow;
            State = VentilatorStatesList.INSERTED;
            _stateHistories = new List<VentilatorStateHistory>();
        }

        public Ventilator(VentilatorModel model, string serialNumber, int idUserCreation) : this()
        {
            if (string.IsNullOrEmpty(serialNumber = serialNumber?.Trim()))
            {
                throw new ArgumentNullException("serialNumber cannot be null or empty");
            }

            Model = model ?? throw new ArgumentNullException("Model cannot be null");
            SerialNumber = serialNumber;
            IdUserCreation = idUserCreation;
        }

        public Ventilator SetAsAvaiable(int idUser)
        {
            ChangeState(from: State, to: VentilatorStatesList.AVAIABLE, idUser: idUser);
            return this;
        }

        public Ventilator SetAsInUse(int idUser)
        {
            ChangeState(from: State, to: VentilatorStatesList.INUSE, idUser: idUser);
            return this;
        }

        public void SetId(int id)
        {
            Id = id; //TODO: temporary solution to have unique ids
        }

        private void ChangeState(VentilatorState from, VentilatorState to, int idUser)
        {
            var transaction = VentilatorStatesTransactionsList.AllVentilatorStates.FirstOrDefault(t => t.From.Equals(from) && t.To.Equals(to)) ?? throw new InvalidOperationException($"transaction from state {from.Code} to {to.Code} not found");
            _stateHistories.Add(new VentilatorStateHistory(ventilator: this, transaction: transaction, idUser: idUser));
        }
    }
}
