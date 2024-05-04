using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bazo.Data;
using Bazo.Models;

namespace Bazo.Controllers
{
    public class ShoppigCartsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShoppigCartsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ShoppigCarts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ShoppigCart.Include(s => s.ApplicationUser).Include(s => s.Product);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ShoppigCarts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppigCart = await _context.ShoppigCart
                .Include(s => s.ApplicationUser)
                .Include(s => s.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shoppigCart == null)
            {
                return NotFound();
            }

            return View(shoppigCart);
        }

        // GET: ShoppigCarts/Create
        public IActionResult Create()
        {
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUser, "Id", "Id");
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Author");
            return View();
        }

        // POST: ShoppigCarts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductId,Count,ApplicationUserId")] ShoppigCart shoppigCart)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shoppigCart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", shoppigCart.ApplicationUserId);
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Author", shoppigCart.ProductId);
            return View(shoppigCart);
        }

        // GET: ShoppigCarts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppigCart = await _context.ShoppigCart.FindAsync(id);
            if (shoppigCart == null)
            {
                return NotFound();
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", shoppigCart.ApplicationUserId);
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Author", shoppigCart.ProductId);
            return View(shoppigCart);
        }

        // POST: ShoppigCarts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductId,Count,ApplicationUserId")] ShoppigCart shoppigCart)
        {
            if (id != shoppigCart.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shoppigCart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShoppigCartExists(shoppigCart.Id))
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
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", shoppigCart.ApplicationUserId);
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Author", shoppigCart.ProductId);
            return View(shoppigCart);
        }

        // GET: ShoppigCarts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppigCart = await _context.ShoppigCart
                .Include(s => s.ApplicationUser)
                .Include(s => s.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shoppigCart == null)
            {
                return NotFound();
            }

            return View(shoppigCart);
        }

        // POST: ShoppigCarts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shoppigCart = await _context.ShoppigCart.FindAsync(id);
            if (shoppigCart != null)
            {
                _context.ShoppigCart.Remove(shoppigCart);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShoppigCartExists(int id)
        {
            return _context.ShoppigCart.Any(e => e.Id == id);
        }
    }
}
