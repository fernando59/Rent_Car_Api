using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccess.Models
{
    public class TypeVehicle
    {
        public int Id { get; set; }

        [StringLength(250)]
        [Required]
        public string name { get; set; }

        [StringLength(600)]
        public string? pathImage { get; set; }


    }
}
