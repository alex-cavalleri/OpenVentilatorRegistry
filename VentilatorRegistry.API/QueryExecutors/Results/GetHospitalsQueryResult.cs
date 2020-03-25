using System;

namespace VentilatorRegistry.API.QueryExecutors.Results
{
    public class GetHospitalsQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NationalProviderIdentifier { get; set; }
        public bool IsVerified { get; set; }
    }
}
