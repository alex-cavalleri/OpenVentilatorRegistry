using System.Collections.Generic;
using System.Linq;
using VentilatorRegistry.VentilatorAggregate;

namespace VentilatorRegistry.API.Repositories
{
    public class VentilatorInMemoryRepository : IVentilatorRepository
    {
        public IEnumerable<Ventilator> AllVentilators => _AllVentilators.AsEnumerable();
        private List<Ventilator> _AllVentilators { get; set; }
        private int lastId = 0;
        private readonly object _lock = new object();

        public VentilatorInMemoryRepository()
        {
            _AllVentilators = new List<Ventilator>();
        }

        public Ventilator GetById(int id)
        {
            return AllVentilators.FirstOrDefault(v => v.Id == id);
        }

        public Ventilator Save(Ventilator ventilator)
        {
            lock (_lock)
            {
                ventilator.SetId(++lastId);
            }

            _AllVentilators.Add(ventilator);
            return ventilator;
        }

        public Ventilator Update(Ventilator ventilator)
        {
            var repositoryVentilator = _AllVentilators.FirstOrDefault(v => v.Id == ventilator.Id);
            if (repositoryVentilator != null)
            {
                lock (_lock)
                {
                    repositoryVentilator = ventilator;
                }
            }

            //TODO: consider throwing an exception and defensive approach if a repositoryVentilator is null
            return repositoryVentilator;
        }
    }
}
