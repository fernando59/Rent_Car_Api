using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccess.Models
{
    public class PhotosVehicle
    {
        public int Id { get; set; }


        [Required]
        [StringLength(600)]
        public string path { get; set; }

        public int VehicleId { get; set; }
        //public Vehicle Vehicle { get; set; }
        //public ICollection<Vehicle> Vehicle { get; set; }



    }
}
