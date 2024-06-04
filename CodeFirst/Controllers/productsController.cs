using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CodeFirst.Models;

namespace CodeFirst.Controllers
{
    public class productsController : Controller
    {
        private readonly ProContext _context;
   

        public productsController(ProContext context)
        {
            _context = context;            
        }    
        public JsonResult GetProductByPrice(decimal price)
        {
            var product = _context.ProductTable.FirstOrDefault(p => p.product_Price == price);
            return Json(new { success = true, data = product });
        }

        public JsonResult GetProductByMonth(int month, int year)
        {
            var product = _context.ProductTable.FirstOrDefault(s => s.ProductPurchase_date.Month == month && s.ProductPurchase_date.Year == year);
            return Json(new { success = true, data = product });
        }

        public JsonResult GetProductByCode(string code)
        {
            var product = _context.ProductTable.FirstOrDefault(p => p.product_code == code);
            return Json(new { success = true, data = product });
        }

        public JsonResult GetProductByPriceRange()
        {
            var product = _context.ProductTable.FirstOrDefault(p => p.product_Price > 1000 && p.product_Price < 2000);
            return Json(new { success = true, data = product });
        }

        public JsonResult GetProductCountByMonth(int month, int year)
        {
            var count = _context.ProductTable.Count(p => p.ProductPurchase_date.Month == month && p.ProductPurchase_date.Year == year);
            return Json(new { success = true, data = count });
        }

        public JsonResult GetOrdersByProductIdAndMonth(int productId, int month, int year)
        {
            var order = _context.OrderTable.FirstOrDefault(o => o.orderid == productId && o.orderdate.Month == month && o.orderdate.Year == year);
            return Json(new { success = true, data = order });
        }
        // GET: products
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProductTable.ToListAsync());
        }

        // GET: products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.ProductTable
                .FirstOrDefaultAsync(m => m.product_Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("product_Id,product_Name,product_Price,ProductPurchase_date,product_code")] product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.ProductTable.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("product_Id,product_Name,product_Price,ProductPurchase_date,product_code")] product product)
        {
            if (id != product.product_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!productExists(product.product_Id))
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
            return View(product);
        }

        // GET: products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.ProductTable
                .FirstOrDefaultAsync(m => m.product_Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.ProductTable.FindAsync(id);
            if (product != null)
            {
                _context.ProductTable.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool productExists(int id)
        {
            return _context.ProductTable.Any(e => e.product_Id == id);
        }
    }
}
