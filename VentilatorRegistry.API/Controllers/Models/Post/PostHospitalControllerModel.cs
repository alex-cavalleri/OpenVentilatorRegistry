namespace VentilatorRegistry.API.Controllers.Models
{
    public class PostHospitalControllerModel
    {
        public string Name { get; set; }
        public int NationalProviderIdentifier { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
