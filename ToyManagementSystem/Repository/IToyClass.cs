using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToyManagementSystem.Models;

namespace ToyManagementSystem.Repository
{
    public interface IToyClass
    {
        bool addToy(Toy toy);
        List<Toy> getToys();
        Toy getToy(int id);
        bool updateToy(Toy toy);
        bool deleteToy(int id);
        Toy getToyy(int id);
    }
}
