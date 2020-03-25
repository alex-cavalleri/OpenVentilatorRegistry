using System;

namespace VentilatorRegistry.VentilatorAggregate
{
    public class VentilatorModel
    {
        public virtual int Id { get; protected set; }
        public virtual string Name { get; protected set; }
        public virtual DateTimeOffset ProductionYear { get; protected set; }
        //TODO: add some other infos here eg manufacturer, isInCommerce...

        protected VentilatorModel()
        {

        }

        public VentilatorModel(string name, DateTimeOffset productionYear)
        {
            if (string.IsNullOrEmpty(name = name?.Trim()))
            {
                throw new ArgumentNullException("name cannot be null or empty");
            }

            if (productionYear > DateTimeOffset.UtcNow)
            {
                throw new InvalidOperationException("a ventilator model can't have production year greater than current year");
            }

            Name = name;
            ProductionYear = productionYear;
        }

        public void SetId(int id)
        {
            Id = id; //TODO: temporary solution to have unique ids
        }
    }
}