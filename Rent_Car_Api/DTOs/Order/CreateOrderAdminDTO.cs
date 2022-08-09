namespace Rent_Car_Api.DTOs.Order
{
    public class CreateOrderAdminDTO
    {
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public int VehicleId { get; set; }
        public string userId{ get; set; }

    }
}
