using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Takke.Models;

namespace Takke.Controllers
{
    public class DriverSalariesController : Controller
    {
        private readonly TakkeContext _context;

        public DriverSalariesController(TakkeContext context)
        {
            _context = context;
        }

        // GET: DriverSalaries
        public async Task<IActionResult> Index()
        {
            var takkeContext = _context.DriverSalaries.Include(d => d.Driver);
            return View(await takkeContext.ToListAsync());
        }

        // GET: DriverSalaries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driverSalary = await _context.DriverSalaries
                .Include(d => d.Driver)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (driverSalary == null)
            {
                return NotFound();
            }

            return View(driverSalary);
        }

        // GET: DriverSalaries/Create
        public IActionResult Create()
        {
            ViewData["DriverId"] = new SelectList(_context.Drivers, "DriverId", "Certificate");
            return View();
        }

        // POST: DriverSalaries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ReceiptNumber,Salary,Date,DriverId")] DriverSalary driverSalary)
        {
            if (ModelState.IsValid)
            {
                _context.Add(driverSalary);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DriverId"] = new SelectList(_context.Drivers, "DriverId", "Certificate", driverSalary.DriverId);
            return View(driverSalary);
        }

        // GET: DriverSalaries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driverSalary = await _context.DriverSalaries.FindAsync(id);
            if (driverSalary == null)
            {
                return NotFound();
            }
            ViewData["DriverId"] = new SelectList(_context.Drivers, "DriverId", "Certificate", driverSalary.DriverId);
            return View(driverSalary);
        }

        // POST: DriverSalaries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ReceiptNumber,Salary,Date,DriverId")] DriverSalary driverSalary)
        {
            if (id != driverSalary.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(driverSalary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DriverSalaryExists(driverSalary.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DriverId"] = new SelectList(_context.Drivers, "DriverId", "Certificate", driverSalary.DriverId);
            return View(driverSalary);
        }

        // GET: DriverSalaries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driverSalary = await _context.DriverSalaries
                .Include(d => d.Driver)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (driverSalary == null)
            {
                return NotFound();
            }

            return View(driverSalary);
        }

        // POST: DriverSalaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var driverSalary = await _context.DriverSalaries.FindAsync(id);
            _context.DriverSalaries.Remove(driverSalary);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DriverSalaryExists(int id)
        {
            return _context.DriverSalaries.Any(e => e.Id == id);
        }
    }
}
