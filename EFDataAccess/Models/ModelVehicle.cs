using System.ComponentModel.DataAnnotations;

namespace EFDataAccess.Models
{
    public  class ModelVehicle
    {
        public int Id { get; set; }
        [Required]
        [StringLength(250)]
        public string name{ get; set; }
    }
}
