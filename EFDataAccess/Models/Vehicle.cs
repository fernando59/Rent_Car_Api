using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccess.Models
{
    internal class Vehicle
    {
        public int Id { get; set; }

        public BrandVehicle brandId { get; set; }    
        public ModelVehicle modelId { get; set; }    
        public decimal price{ get; set; }    
        public int year{ get; set; }    
        public bool hasAir{ get; set; }    
        public int capacity{ get; set; }    

        public BrandVehicle BrandVehicle { get; set; }
        public ModelVehicle ModelVehicle { get; set; }


    }
}
