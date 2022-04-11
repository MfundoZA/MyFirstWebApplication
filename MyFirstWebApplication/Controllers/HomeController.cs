using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyFirstWebApplication.Models;
using MyFirstWebApplication.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MyFirstWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        // public JsonFileCakeService CakeService;
        public static string ConnnectionString { get; private set; }
        public static SqlConnection Connection { get; set; }
        public List<Cake> Cakes { get; private set; }

        public HomeController(ILogger<HomeController> logger,
            JsonFileCakeService cakeService)
        {
            _logger = logger;
            // CakeService = cakeService;
            ConnnectionString = "Data Source=JORDAN;Initial Catalog=\"Mbali'sBakery\";Integrated Security=True";
            Connection = new SqlConnection(ConnnectionString);
        }

        public IActionResult Index()
        {
            Cakes = new List<Cake>();

            

            Connection.Open();
            if (Connection.State == System.Data.ConnectionState.Open)
            {
                string getAllCakes = "SELECT * FROM Cake";
                SqlCommand command = new SqlCommand(getAllCakes, Connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    Cake cake = new Cake();
                    cake.cakeId = (int) reader[0];
                    cake.name = (string) reader[1];
                    cake.description = (string) reader[2];
                    cake.price = Decimal.ToDouble((decimal)reader[3]);
                    cake.path = (string) reader[4];

                    Cakes.Add(cake);
                }
            }
            return View(this);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
