using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autopedia.Data;
using Autopedia.Models;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult Details(int Id)
        {
            Car car = _context.Cars.Where(p => p.Id == Id).FirstOrDefault();
            return View(car);
        }
        [HttpGet]
        public IActionResult Edit (int Id)
        {
            Car car = _context.Cars.Where(p => p.Id == Id).FirstOrDefault();
            return View(car);
        }
        [HttpPost]
        public IActionResult Edit(Car car)
        {
            _context.Attach(car);
            _context.Entry(car).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Car car = _context.Cars.Where(p => p.Id == Id).FirstOrDefault();
            return View(car);
        }
        [HttpPost]
        public IActionResult Delete(Car car)
        {
            _context.Attach(car);
            _context.Entry(car).State = EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Create(int Id)
        {
            Car car = _context.Cars.Where(p => p.Id == Id).FirstOrDefault();
            return View(car);
        }
        [HttpPost]
        public IActionResult Create(Car car)
        {
            var carid = _context.Cars.Max(car_id => car_id.Id);
           
            
            car.Id = carid+1;

            _context.Attach(car);
            _context.Entry(car).State = EntityState.Added;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

    }
}
