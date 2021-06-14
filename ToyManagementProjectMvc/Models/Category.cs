using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//changes
//changes in new branch
namespace ToyManagementProjectMvc.Models
{
    public class Category
    {
        public Category()
        {
            Toys = new HashSet<Toy>();
        }

        public int CategoryId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Toy> Toys { get; set; }
    }
}
