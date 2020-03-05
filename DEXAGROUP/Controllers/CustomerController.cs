using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DEXAGROUP.Data;
using DEXAGROUP.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DEXAGROUP.Controllers
{
    //[Authorize]
    public class CustomerController : Controller
    {
        private readonly DexaDbContext _context;

        public CustomerController(DexaDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var customers = _context.Customers.Include(c => c.Outlet).ToListAsync();
            return View(await customers);
        }

        public IActionResult Create()
        {
            ViewData["OutletId"] = new SelectList(_context.Outlets, "OutletID", "OutletName");
            return View();
        }

        // POST: Test/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(List<Customers> item)
        {
            if (item != null)
            {
                foreach (Customers model in item)
                {
                    bool exist_id = _context.Customers.Where(x => x.CustomerID.Equals(model.CustomerID)).Any();

                    if (!exist_id)
                    {
                        _context.Add(model);
                    }
                    else
                    {
                        _context.Update(model);
                    }
                }
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

        // GET: Test/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customers = await _context.Customers.FindAsync(id);
            if (customers == null)
            {
                return NotFound();
            }

            ViewData["OutletId"] = new SelectList(_context.Outlets, "OutletID", "OutletName", customers.OutletId);
            return View(customers);
        }

        // POST: Test/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("CustomerID,CustomerName,Address,Code,StartDate,EndDate,OutletId")] Customers customers)
        {
            if (id != customers.CustomerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomersExists(customers.CustomerID))
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
            ViewData["OutletId"] = new SelectList(_context.Outlets, "OutletID", "OutletName", customers.OutletId);
            return View(customers);
        }

        // GET: Test/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customers = await _context.Customers
                .Include(c => c.Outlet)
                .FirstOrDefaultAsync(m => m.CustomerID == id);
            if (customers == null)
            {
                return NotFound();
            }

            return View(customers);
        }

        // POST: Test/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var customers = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomersExists(long id)
        {
            return _context.Customers.Any(e => e.CustomerID == id);
        }
    }
}