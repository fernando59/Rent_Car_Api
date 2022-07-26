namespace Rent_Car_Api.DTOs.Vehicle
{
    public class QueryVehicleDTO
    {
        string sortOrder { get; set; }
        string searchString { get; set; }
        int quantity { get; set; }  
        int page { get; set; }  

    }
}
