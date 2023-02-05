using KBC_demoCore.Helper;
using KBC_demoCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace KBC_demoCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private ApiHelper _apiHelper = new ApiHelper();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {

            var patients = new List<Patient>();
            var client = _apiHelper.Inital();
            var response = await client.GetAsync("api/all");
            if (response.IsSuccessStatusCode)
            {
                patients = JsonConvert.DeserializeObject<List<Patient>>(response.Content.ReadAsStringAsync().Result);
            }
            return View(patients);
        }

        

    }
}
