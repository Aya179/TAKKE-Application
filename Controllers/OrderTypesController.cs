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
    public class OrderTypesController : Controller
    {
        private readonly TakkeContext _context;

        public OrderTypesController(TakkeContext context)
        {
            _context = context;
        }

        // GET: OrderTypes
        public async Task<IActionResult> Index()
        {
            var takkeContext = _context.OrderTypes.Include(o => o.IdNavigation);
            return View(await takkeContext.ToListAsync());
        }

        // GET: OrderTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderType = await _context.OrderTypes
                .Include(o => o.IdNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderType == null)
            {
                return NotFound();
            }

            return View(orderType);
        }

        // GET: OrderTypes/Create
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(_context.Orders, "OrderId", "DestenationDetails");
            return View();
        }

        // POST: OrderTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Typename,Description")] OrderType orderType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.Orders, "OrderId", "DestenationDetails", orderType.Id);
            return View(orderType);
        }

        // GET: OrderTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderType = await _context.OrderTypes.FindAsync(id);
            if (orderType == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.Orders, "OrderId", "DestenationDetails", orderType.Id);
            return View(orderType);
        }

        // POST: OrderTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Typename,Description")] OrderType orderType)
        {
            if (id != orderType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderTypeExists(orderType.Id))
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
            ViewData["Id"] = new SelectList(_context.Orders, "OrderId", "DestenationDetails", orderType.Id);
            return View(orderType);
        }

        // GET: OrderTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderType = await _context.OrderTypes
                .Include(o => o.IdNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderType == null)
            {
                return NotFound();
            }

            return View(orderType);
        }

        // POST: OrderTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderType = await _context.OrderTypes.FindAsync(id);
            _context.OrderTypes.Remove(orderType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderTypeExists(int id)
        {
            return _context.OrderTypes.Any(e => e.Id == id);
        }
    }
}
