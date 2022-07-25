using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccess.Models
{
    public class Vehicle
    {
        public int Id { get; set; }


        [Required]
        [Column(TypeName = "money")]
        public decimal price{ get; set; }

        public int state { get; set; } = 1;
        public int year{ get; set; }    
        public bool hasAir{ get; set; }    

        [StringLength(150)]
        public string plate{ get; set; }    
        public int capacity{ get; set; }



        public int BrandVehicleId { get; set; }
        public int ModelVehicleId{ get; set; }
        public int TypeVehicleId { get; set; }
        public virtual BrandVehicle BrandVehicle { get; set; }
        public virtual ModelVehicle ModelVehicle { get; set; }
        public virtual TypeVehicle TypeVehicle{ get; set; }


    }
}
