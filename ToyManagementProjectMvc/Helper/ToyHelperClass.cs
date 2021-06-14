using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ToyManagementProjectMvc.Helper
{
    public class ToyHelperClass
    {
        public HttpClient Initial()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44307/api/Toy");
            return client;
        }
    }
}
