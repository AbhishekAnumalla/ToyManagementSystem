using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToyManagementSystem.Models;

namespace ToyManagementSystem.Repository
{
    public interface ICategoryClass
    {
        bool addCategory(Category category);
        List<Category> GetCategories();
        Category GetCategory(int id);
    }
}
