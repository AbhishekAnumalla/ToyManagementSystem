using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToyManagementProjectMvc.Controllers
{
    public class JCategoryController : Controller
    {
        public IActionResult IndexC()
        {
            return View();
        }
    }
}
