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
    public class FormulaTeamController : Controller
    {
        private readonly CarsDBContext _context;
        public FormulaTeamController(CarsDBContext context)
        {
            _context = context;
        }

        public IActionResult Index(int pg = 1)
        {
            const int pageSize = 3;
            if (pg < 1)
                pg = 1;
            int recsCount = _context.FormulaTeams.Count();
            var pager = new Pager(recsCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;

            List<FormulaTeam> formula = _context.FormulaTeams.Skip(recSkip).Take(pager.PageSize).ToList();
            this.ViewBag.Pager = pager;
            return View(formula);
        }
        public IActionResult Details(int Id)
        {
            FormulaTeam formula = _context.FormulaTeams.Where(p => p.Id == Id).FirstOrDefault();
            return View(formula);
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            FormulaTeam formula = _context.FormulaTeams.Where(p => p.Id == Id).FirstOrDefault();
            return View(formula);
        }
        [HttpPost]
        public IActionResult Edit(FormulaTeam formula)
        {
            _context.Attach(formula);
            _context.Entry(formula).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            FormulaTeam formula = _context.FormulaTeams.Where(p => p.Id == Id).FirstOrDefault();
            return View(formula);
        }
        [HttpPost]
        public IActionResult Delete(FormulaTeam formula)
        {
            _context.Attach(formula);
            _context.Entry(formula).State = EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Create(int Id)
        {
            FormulaTeam formula = _context.FormulaTeams.Where(p => p.Id == Id).FirstOrDefault();
            return View(formula);
        }
        [HttpPost]
        public IActionResult Create(FormulaTeam formula)
        {
            var formulaid = _context.FormulaTeams.Max(formula_id => formula_id.Id);


            formula.Id = formulaid + 1;

            _context.Attach(formula);
            _context.Entry(formula).State = EntityState.Added;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

    }
}
