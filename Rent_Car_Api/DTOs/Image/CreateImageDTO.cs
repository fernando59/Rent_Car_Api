
namespace Rent_Car_Api.DTOs.Image
{
    public class CreateImageDTO
    {
        public IFormFile fileImage { get; set; }
        public string vehicleId { get; set; }
    }
}
