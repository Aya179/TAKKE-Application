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
    public class ClientPaymentsController : Controller
    {
        private readonly TakkeContext _context;

        public ClientPaymentsController(TakkeContext context)
        {
            _context = context;
        }

        // GET: ClientPayments
        public async Task<IActionResult> Index()
        {
            var takkeContext = _context.ClientPayments.Include(c => c.Client);
            return View(await takkeContext.ToListAsync());
        }

        // GET: ClientPayments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientPayment = await _context.ClientPayments
                .Include(c => c.Client)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientPayment == null)
            {
                return NotFound();
            }

            return View(clientPayment);
        }

        // GET: ClientPayments/Create
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "ClientMobile");
            return View();
        }

        // POST: ClientPayments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Paid,Paymentdate,ClientId,Isfromorder")] ClientPayment clientPayment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientPayment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "ClientMobile", clientPayment.ClientId);
            return View(clientPayment);
        }

        // GET: ClientPayments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientPayment = await _context.ClientPayments.FindAsync(id);
            if (clientPayment == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "ClientMobile", clientPayment.ClientId);
            return View(clientPayment);
        }

        // POST: ClientPayments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Paid,Paymentdate,ClientId,Isfromorder")] ClientPayment clientPayment)
        {
            if (id != clientPayment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientPayment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientPaymentExists(clientPayment.Id))
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
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "ClientMobile", clientPayment.ClientId);
            return View(clientPayment);
        }

        // GET: ClientPayments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientPayment = await _context.ClientPayments
                .Include(c => c.Client)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientPayment == null)
            {
                return NotFound();
            }

            return View(clientPayment);
        }

        // POST: ClientPayments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientPayment = await _context.ClientPayments.FindAsync(id);
            _context.ClientPayments.Remove(clientPayment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientPaymentExists(int id)
        {
            return _context.ClientPayments.Any(e => e.Id == id);
        }
    }
}
