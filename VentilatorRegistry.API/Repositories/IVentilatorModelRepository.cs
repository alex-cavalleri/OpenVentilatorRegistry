using System.Collections.Generic;
using VentilatorRegistry.VentilatorAggregate;

namespace VentilatorRegistry.API.Repositories
{
    public interface IVentilatorModelRepository
    {
        IEnumerable<VentilatorModel> AllVentilatorModels { get; }
        VentilatorModel GetById(int id);
        VentilatorModel Save(VentilatorModel ventilatorModel);
    }
}
