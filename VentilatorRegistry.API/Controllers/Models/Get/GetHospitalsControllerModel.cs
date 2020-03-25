namespace VentilatorRegistry.API.Controllers.Models.Get
{
    public class GetHospitalsControllerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NationalProviderIdentifier { get; set; }
        public bool IsVerified { get; set; }
    }
}
