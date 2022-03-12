using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Takke.Models;

namespace Takke.Controllers
{
    [Authorize]
    public class SmsconfigsController : Controller
    {
        private readonly TakkeContext _context;

        public SmsconfigsController(TakkeContext context)
        {
            _context = context;
        }

        // GET: Smsconfigs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Smsconfigs.ToListAsync());
        }


        // GET: Smsconfigs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Smsconfigs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Username,Password")] Smsconfig smsconfig)
        {
            if (ModelState.IsValid)
            {
                _context.Add(smsconfig);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(smsconfig);
        }

        // GET: Smsconfigs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var smsconfig = await _context.Smsconfigs.FindAsync(id);
            if (smsconfig == null)
            {
                return NotFound();
            }
            return View(smsconfig);
        }

        // POST: Smsconfigs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Username,Password")] Smsconfig smsconfig)
        {
            if (id != smsconfig.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(smsconfig);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SmsconfigExists(smsconfig.Id))
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
            return View(smsconfig);
        }


        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var smsconfig = await _context.Smsconfigs
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (smsconfig == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(smsconfig);
        //}

        //// POST: Cars/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var smsconfig = await _context.Smsconfigs.FindAsync(id);
        //    _context.Smsconfigs.Remove(smsconfig);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool SmsconfigExists(int id)
        {
            return _context.Smsconfigs.Any(e => e.Id == id);
        }

        [HttpPost]
        [Route("/SendMeassge")]
        public async Task<IActionResult> SendMeassgeAsync(string phone, string msg, string lang)
        {

            msg = Helpers.StringToHex.ConvertStringToHex(msg);
            var smsconfig = await _context.Smsconfigs
            .FirstOrDefaultAsync();
            var url = "https://services.mtnsyr.com:7443/general/MTNSERVICES/ConcatenatedSender.aspx?" +
                "User=" + smsconfig.Username + "&Pass=" + smsconfig.Password + "&From=Takke&" +
                "Gsm=" +
                 phone +
                "&Msg=" +
                msg +
                "&Lang=" +
                 lang;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    //client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");

                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
