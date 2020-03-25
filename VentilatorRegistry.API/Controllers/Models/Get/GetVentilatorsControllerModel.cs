namespace VentilatorRegistry.API.Controllers.Models.Get
{
    public class GetVentilatorsControllerModel
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public string StateCode { get; set; }
        public string StateDescription { get; set; }
        public string SerialNumber { get; set; }
    }
}
