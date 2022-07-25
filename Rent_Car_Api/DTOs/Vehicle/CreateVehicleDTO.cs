namespace Rent_Car_Api.DTOs.Vehicle
{
    public class CreateVehicleDTO
    {
        
        public int capacity { get; set; }
        public int year{ get; set; }
        public string plate{ get; set; }
        public bool hasAir { get; set; }    
        public decimal price { get; set; }
        public int brandVehicle{ get; set; }
        public int modelVehicle{ get; set; }
        public int typeVehicle{ get; set; }


    }
}
