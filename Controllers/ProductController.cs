using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using E_Commerce_Project.Data;
using E_Commerce_Project.Models.Products;
using System.Globalization;

namespace E_Commerce_Project.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Product
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Product.Include(p => p.image).Include(p => p.productBrand).Include(p => p.productDetails).Include(p => p.productTechno).Include(p => p.productType);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Product/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.image)
                .Include(p => p.productBrand)
                .Include(p => p.productDetails)
                .Include(p => p.productTechno)
                .Include(p => p.productType)
                .FirstOrDefaultAsync(m => m.id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            //ViewData["imageId"] = new SelectList(_context.Image, "id", "id");
            ViewData["productBrandId"] = new SelectList(_context.Brand, "id", "name");
            //ViewData["productDetailsId"] = new SelectList(_context.ProductDetails, "id", "id");
            ViewData["productTechnoId"] = new SelectList(_context.Techno, "id", "name");
            ViewData["productTypeId"] = new SelectList(_context.ProductType, "id", "name");
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(/*[Bind("id,name,price,productDetailsId,imageId,productTypeId,productTechnoId,productBrandId,image.formFile")]*/
            Product product, [FromServices] IWebHostEnvironment _hostEnvironment)
        {
            ProductDetails prodDetails = product.productDetails;
            _context.ProductDetails.Add(prodDetails);
            
            Image prodImage = product.image;
            string wwwRootPath = _hostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(product.image.formFile.FileName);
            string extension = Path.GetExtension(product.image.formFile.FileName);
            product.image.name = product.name + /*product.productDetails.productBrand.name +*/ extension;
            string path = Path.Combine(wwwRootPath + "/Content/" + product.image.name);
            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                product.image.formFile.CopyTo(fileStream);
            }
            _context.Image.Add(prodImage);


            ModelState.Remove("ProductBrand");
            ModelState.Remove("ProductType");
            ModelState.Remove("ProductTechno");
            ModelState.Remove("image.name");
            ModelState.Remove("image.formFile");
            ModelState.Remove("productDetails.resolution");
            ModelState.Remove("productDetails.zoomOptic");
            ModelState.Remove("productDetails.video");
            ModelState.Remove("productDetails.stabilisator");
            ModelState.Remove("productDetails.isoMax");
            //ModelState.Append("imageId", prodImage.id);
            //ModelState.Append("productDetailsId", prodDetails.id);
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["imageId"] = new SelectList(_context.Image, "id", "id", product.imageId);
            ViewData["productBrandId"] = new SelectList(_context.Brand, "id", "name", product.productBrandId);
            //ViewData["productDetailsId"] = new SelectList(_context.ProductDetails, "id", "id", product.productDetailsId);
            ViewData["productTechnoId"] = new SelectList(_context.Techno, "id", "name", product.productTechnoId);
            ViewData["productTypeId"] = new SelectList(_context.ProductType, "id", "name", product.productTypeId);
            return View(product);
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            //ViewData["imageId"] = new SelectList(_context.Image, "id", "id", product.imageId);
            ViewData["productBrandId"] = new SelectList(_context.Brand, "id", "name", product.productBrandId);
            //ViewData["productDetailsId"] = new SelectList(_context.ProductDetails, "id", "id", product.productDetailsId);
            ViewData["productTechnoId"] = new SelectList(_context.Techno, "id", "name", product.productTechnoId);
            ViewData["productTypeId"] = new SelectList(_context.ProductType, "id", "name", product.productTypeId);
            return View(product);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,price,productDetailsId,imageId,productTypeId,productTechnoId,productBrandId")] Product product)
        {
            if (id != product.id)
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
                    if (!ProductExists(product.id))
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
            ViewData["imageId"] = new SelectList(_context.Image, "id", "id", product.imageId);
            ViewData["productBrandId"] = new SelectList(_context.Brand, "id", "name", product.productBrandId);
            ViewData["productDetailsId"] = new SelectList(_context.ProductDetails, "id", "id", product.productDetailsId);
            ViewData["productTechnoId"] = new SelectList(_context.Techno, "id", "name", product.productTechnoId);
            ViewData["productTypeId"] = new SelectList(_context.ProductType, "id", "name", product.productTypeId);
            return View(product);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.image)
                .Include(p => p.productBrand)
                .Include(p => p.productDetails)
                .Include(p => p.productTechno)
                .Include(p => p.productType)
                .FirstOrDefaultAsync(m => m.id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Product == null)
            {
                return Problem("Entity set 'AppDbContext.Product'  is null.");
            }
            var product = await _context.Product.FindAsync(id);
            if (product != null)
            {
                _context.Product.Remove(product);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
          return (_context.Product?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
