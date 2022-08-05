namespace Rent_Car_Api.DTOs.Order
{
    public class CreateOrderDTO
    {
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public int VehicleId { get; set; }

    }
}
