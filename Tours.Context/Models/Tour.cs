using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tours.Context.Models
{
    public class Tour
    {
        public int Id { get; set; }

        [Required]
        public int TicketCount { get; set; }

        public string CountryCode { get; set; }
        public virtual Country Country { get; set; }

        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[] ImagePreview { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public bool IsActual { get; set; }

        public virtual ICollection<Hotel> Hotels { get; set; }
        public virtual ICollection<TypeTour> Types { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        public Tour()
        {
            Hotels = new List<Hotel>();
            Orders = new List<Order>();
            Types = new List<TypeTour>();
        }

        public override int GetHashCode()
         => Id.GetHashCode();

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj is Tour tour)
            {
                return tour.Id.Equals(Id);
            }

            return false;
        }

    }
}
