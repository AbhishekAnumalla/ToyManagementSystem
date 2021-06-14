using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToyManagementProjectMvc.Controllers
{
    public class JToyController : Controller
    {
        public IActionResult IndexT()
        {
            return View();
        }
    }
}
