using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToyManagementProjectMvc.Models
{
    public class Toy
    {
        public int ToyId { get; set; }
        public string Title { get; set; }
        public string ManufactureDate { get; set; }
        public int? Price { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
