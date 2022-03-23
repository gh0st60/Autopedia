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

        public IActionResult Index(int pg = 1)
        {
            const int pageSize = 3;
            if (pg < 1)
                 pg = 1;
            int recsCount = _context.Cars.Count();
            var pager = new Pager(recsCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;

            List<Car> cars = _context.Cars.Skip(recSkip).Take(pager.PageSize).ToList();
            this.ViewBag.Pager = pager;
            return View(cars);
        }
    }
}
