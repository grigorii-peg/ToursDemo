using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tours.Context.Models
{
    public class Country
    {
        [Key]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }
        public virtual ICollection<Hotel> Hotels { get; set; }
        public virtual ICollection<Tour> Tours { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
