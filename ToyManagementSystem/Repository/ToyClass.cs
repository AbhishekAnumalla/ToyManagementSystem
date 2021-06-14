using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToyManagementSystem.Models;

namespace ToyManagementSystem.Repository
{
    public class ToyClass : IToyClass
    {
        ToyManagementProjectContext context;
        public ToyClass()
        {
            context = new ToyManagementProjectContext();
        }

        public bool addToy(Toy toy)
        {
            context.Toys.Add(toy);
            context.SaveChanges();
            return true;
        }

        public bool deleteToy(int id)
        {
            var toy = context.Toys.FirstOrDefault(i => i.ToyId == id);
            context.Toys.Remove(toy);
            context.SaveChanges();
            return true;
        }

        public Toy getToy(int id)
        {
            Toy res = new Toy();
            res = context.Toys.FirstOrDefault(i => i.CategoryId == id);
            return res;
        }

        public List<Toy> getToys()
        {
            var list = context.Toys.ToList();
            return list;
        }

        public Toy getToyy(int id)
        {
            var toy = context.Toys.FirstOrDefault(i => i.ToyId == id);
            return toy;
        }

        public bool updateToy(Toy toy)
        {
            /*var res = context.Toys.First(i => i.ToyId == id);
            var s1 = res.ToyId;
            var s2 = res.ManufactureDate;
            var s3 = res.CategoryId;
            context.Entry(toy.ToyId).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
            context.Entry(toy.Price).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.Entry(toy.Title).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.Entry(toy.ManufactureDate).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
            context.Entry(toy.CategoryId).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
            context.Entry(toy.Category).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
            toy.ToyId = s1;
            toy.ManufactureDate = s2;
            toy.CategoryId = s3;*/
            context.Entry(toy).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return true;
        }
    }
}
