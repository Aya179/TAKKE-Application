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
    public class CobonsController : Controller
    {
        private readonly TakkeContext _context;

        public CobonsController(TakkeContext context)
        {
            _context = context;
        }

        // GET: Cobons
        public async Task<IActionResult> Index()
        {
            var takkeContext = _context.Cobons.Include(c => c.Client);
            return View(await takkeContext.ToListAsync());
        }

        // GET: Cobons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cobon = await _context.Cobons
                .Include(c => c.Client)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cobon == null)
            {
                return NotFound();
            }

            return View(cobon);
        }

        // GET: Cobons/Create
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "ClientMobile");
            return View();
        }

        // POST: Cobons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CobonValue,CreationDate,ActivationCode,Activated,ClientId,Cobontype")] Cobon cobon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cobon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "ClientName", cobon.ClientId);
            return View(cobon);
        }

        // GET: Cobons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cobon = await _context.Cobons.FindAsync(id);
            if (cobon == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "ClientName", cobon.ClientId);
            return View(cobon);
        }

        // POST: Cobons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CobonValue,CreationDate,ActivationCode,Activated,ClientId,Cobontype")] Cobon cobon)
        {
            if (id != cobon.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cobon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CobonExists(cobon.Id))
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
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "ClientName", cobon.ClientId);
            return View(cobon);
        }

        // GET: Cobons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cobon = await _context.Cobons
                .Include(c => c.Client)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cobon == null)
            {
                return NotFound();
            }

            return View(cobon);
        }

        // POST: Cobons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cobon = await _context.Cobons.FindAsync(id);
            _context.Cobons.Remove(cobon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CobonExists(int id)
        {
            return _context.Cobons.Any(e => e.Id == id);
        }
    }
}
