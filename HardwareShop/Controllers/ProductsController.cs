using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HardwareShop.Data;
using HardwareShop.Models;
using Microsoft.AspNetCore.Authorization;

namespace HardwareShop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly HardwareShopDbContext _context;

        public ProductsController(HardwareShopDbContext context)
        {
            _context = context;
        }

        // GET: Products

        public async Task<IActionResult> Index(string searchName, string searchCategory, int? pageNumber)
        {

            var producten = from p in _context.Product
                            select p;

            var productcategories = (from categories in _context.ProductCategory
                                     select new SelectListItem()
                                     {
                                         Text = categories.CategoryName,
                                         Value = categories.CategoryID.ToString(),


                                     }).ToList();

            productcategories.Insert(0, new SelectListItem()
            {
                Text = "----Select----",
                Value = string.Empty
            });

            ViewBag.Listofcategories = productcategories;
           


            if (!String.IsNullOrEmpty(searchName))
            {
                var hardwareShopDbContext = _context.Product.Include(p => p.Category);
                producten = producten.Where(p => p.ProductName.Contains(searchName));

            }
            if (!String.IsNullOrEmpty(searchCategory))
            {
                var hardwareShopDbContext = _context.Product.Include(p => p.Category);
                producten = producten.Where(p => p.Category.CategoryID.ToString() == searchCategory);

            }
           
          
            int pageSize = 2;
            // return View(hardwareShopDbContext.ToString());
            return View(await PaginatedList<Product>.CreateAsync(producten.AsNoTracking(), pageNumber ?? 1, pageSize));

        }

        public ActionResult Data()
        {
            var getCategories = _context.ProductCategory.ToList();
            SelectList list = new SelectList(getCategories, "Category name");
            ViewBag.categories = list;
            return View();
        
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }



        // GET: Products/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["CategoryID"] = new SelectList(_context.ProductCategory, "CategoryID", "CategoryName");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductID,ProductName,Description,ImagePath,Price,CategoryID")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryID"] = new SelectList(_context.ProductCategory, "CategoryID", "CategoryName", product.CategoryID);
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryID"] = new SelectList(_context.ProductCategory, "CategoryID", "CategoryName", product.CategoryID);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductID,ProductName,Description,ImagePath,Price,CategoryID")] Product product)
        {
            if (id != product.ProductID)
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
                    if (!ProductExists(product.ProductID))
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
            ViewData["CategoryID"] = new SelectList(_context.ProductCategory, "CategoryID", "CategoryName", product.CategoryID);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Product.FindAsync(id);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.ProductID == id);
        }
    }
}
