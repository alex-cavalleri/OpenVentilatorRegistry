using System.Collections.Generic;
using System.Linq;
using VentilatorRegistry.VentilatorAggregate;

namespace VentilatorRegistry.API.Repositories
{
    public class VentilatorModelInMemoryRepository : IVentilatorModelRepository
    {
        public IEnumerable<VentilatorModel> AllVentilatorModels => _AllVentilatorModels.AsEnumerable();
        private List<VentilatorModel> _AllVentilatorModels { get; set; }
        private int lastId = 0;

        public VentilatorModelInMemoryRepository()
        {
            _AllVentilatorModels = new List<VentilatorModel>();
        }

        public VentilatorModel GetById(int id)
        {
            return AllVentilatorModels.FirstOrDefault(m => m.Id == id);
        }

        public VentilatorModel Save(VentilatorModel ventilatorModel)
        {
            ventilatorModel.SetId(++lastId);
            _AllVentilatorModels.Add(ventilatorModel);
            return ventilatorModel;
        }
    }
}
