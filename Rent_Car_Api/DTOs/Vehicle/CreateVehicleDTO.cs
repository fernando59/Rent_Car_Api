namespace Rent_Car_Api.DTOs.Vehicle
{
    public class CreateVehicleDTO
    {
        
        public int capacity { get; set; }
        public int year{ get; set; }
        public string plate{ get; set; }

        public IFormFile imagePath { get; set; }
        public bool hasAir { get; set; }    
        public decimal price { get; set; }
        public string? description{ get; set; }
        public int brandVehicleId{ get; set; }
        public int modelVehicleId{ get; set; }
        public int typeVehicleId{ get; set; }


    }
}
