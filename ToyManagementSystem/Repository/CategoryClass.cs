using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToyManagementSystem.Models;

namespace ToyManagementSystem.Repository
{
    public class CategoryClass : ICategoryClass
    {
        ToyManagementProjectContext context;
        public CategoryClass()
        {
            context = new ToyManagementProjectContext();
        }

        public bool addCategory(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
            return true;
        }

        public List<Category> GetCategories()
        {
            var list= context.Categories.ToList();
            return list;
        }

        public Category GetCategory(int id)
        {
            var category = context.Categories.First(i=>i.CategoryId==id);
            return category;
        }
    }
}
