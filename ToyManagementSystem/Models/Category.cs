using System;
using System.Collections.Generic;

#nullable disable
//some changes
namespace ToyManagementSystem.Models
{
    public partial class Category
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
