using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tours.Context.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int? UserId { get; set; }
        public virtual User User { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public DateTimeOffset OrderDate { get; set; }

        [Required]
        public int AllSale { get; set; }

        [Required]
        public DateTimeOffset DateReceipt { get; set; }

        [Required]
        public int ReceivingPointId { get; set; }
        public virtual ReceivingPoint ReceivingPoint { get; set; }

        [Required]
        public int Code { get; set; }
        public virtual ICollection<Tour> Tours { get; set; }

        public Order()
        {
            Tours = new List<Tour>();
        }
    }
}
