namespace Rent_Car_Api.DTOs.Vehicle
{
    public class CreateVehicleDTO
    {
        
        public int capacity { get; set; }
        public int year{ get; set; }
        public string plate{ get; set; }
        public bool hasAir { get; set; }    
        public decimal price { get; set; }
        public int brand{ get; set; }
        public int model{ get; set; }
        public int typeVehicle{ get; set; }


    }
}
