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
    public class FamousCarsController : Controller
    {
        private readonly CarsDBContext _context;
        public FamousCarsController(CarsDBContext context)
        {
            _context = context;
        }

        public IActionResult Index(int pg = 1)
        {
            const int pageSize = 3;
            if (pg < 1)
                pg = 1;
            int recsCount = _context.FamousCars.Count();
            var pager = new Pager(recsCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;

            List<FamousCar> formula = _context.FamousCars.Skip(recSkip).Take(pager.PageSize).ToList();
            this.ViewBag.Pager = pager;
            return View(formula);
        }
        public IActionResult Details(int Id)
        {
            FamousCar famous = _context.FamousCars.Where(p => p.Id == Id).FirstOrDefault();
            return View(famous);
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            FamousCar famous = _context.FamousCars.Where(p => p.Id == Id).FirstOrDefault();
            return View(famous);
        }
        [HttpPost]
        public IActionResult Edit(FamousCar famous)
        {
            _context.Attach(famous);
            _context.Entry(famous).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            FamousCar famous = _context.FamousCars.Where(p => p.Id == Id).FirstOrDefault();
            return View(famous);
        }
        [HttpPost]
        public IActionResult Delete(FamousCar famous)
        {
            _context.Attach(famous);
            _context.Entry(famous).State = EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Create(int Id)
        {
            FamousCar famous = _context.FamousCars.Where(p => p.Id == Id).FirstOrDefault();
            return View(famous);
        }
        [HttpPost]
        public IActionResult Create(FamousCar famous)
        {
            var famousCarsId = _context.FamousCars.Max(formula_id => formula_id.Id);


            famous.Id = famousCarsId + 1;

            _context.Attach(famous);
            _context.Entry(famous).State = EntityState.Added;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

    }
}
