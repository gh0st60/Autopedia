using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autopedia.Data;
using Autopedia.Models;

namespace Autopedia.Controllers
{
    public class CarsController : Controller
    {
        private readonly CarsDBContext _context ;

        public CarsController(CarsDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Car> cars = _context.Cars.ToList();
            return View(cars);
        }
    }
}
