using System;

namespace VentilatorRegistry.API.QueryExecutors.Results
{
    public class GetVentilatorModelsQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset ProductionYear { get; set; }
    }
}
