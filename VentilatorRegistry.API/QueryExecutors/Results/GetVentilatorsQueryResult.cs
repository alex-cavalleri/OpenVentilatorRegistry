namespace VentilatorRegistry.API.QueryExecutors.Results
{
    public class GetVentilatorsQueryResult
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public string StateCode { get; set; }
        public string StateDescription { get; set; }
        public string SerialNumber { get; set; }
    }
}
