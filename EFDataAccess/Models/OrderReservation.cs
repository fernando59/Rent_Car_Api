using EFDataAccess.ClassesAux;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccess.Models
{
    public class OrderReservation
    {
        public int Id { get; set; }

        public DateTime createAt{ get; set; } = DateTime.Now;

        public DateTime startDate{ get; set; } = DateTime.Now;
        public DateTime endDate{ get; set; } = DateTime.Now;

        public int days { get;set; }

        [Column(TypeName = "money")]
        public decimal price { get; set; }

        public int status { get; set; } = OrderStates.Pending;

        



        public string UserId { get; set; }
        
        public int VehicleId { get; set; }
        public virtual IdentityUser User { get; set; }
        public virtual Vehicle Vehicle { get; set; }

    }
}
