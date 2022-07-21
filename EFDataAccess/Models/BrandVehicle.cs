using System.ComponentModel.DataAnnotations;

namespace EFDataAccess.Models
{
    public class BrandVehicle
    {
        public int Id { get; set; }
        [Required]
        [StringLength(250)]
        public string name { get; set; }
    }
}
