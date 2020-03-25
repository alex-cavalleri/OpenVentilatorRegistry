using System.Collections.Generic;
using VentilatorRegistry.VentilatorAggregate;

namespace VentilatorRegistry.API.Repositories
{
    public interface IVentilatorRepository
    {
        IEnumerable<Ventilator> AllVentilators { get; }
        Ventilator GetById(int id);
        Ventilator Save(Ventilator ventilator);
        Ventilator Update(Ventilator ventilator);
    }
}
