namespace Rent_Car_Api.DTOs.Order
{
    public class CreateOrderDTO
    {
        public int days { get; set; }
        public decimal price { get; set; }
        public int VehicleId { get; set; }

    }
}
