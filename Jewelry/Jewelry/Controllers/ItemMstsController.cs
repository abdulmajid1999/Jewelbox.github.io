using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Jewelry.Data;
using Jewelry.Models;

namespace Jewelry.Controllers
{
    public class ItemMstsController : Controller
    {
        private readonly JewelryContext _context;

        public ItemMstsController(JewelryContext context)
        {
            _context = context;
        }

        // GET: ItemMsts
        public async Task<IActionResult> Index()
        {
            var jewelryContext = _context.itemMsts.Include(i => i.brandMst).Include(i => i.catMst).Include(i => i.certifyMst).Include(i => i.goldKrtMst).Include(i => i.prodMst);
            return View(await jewelryContext.ToListAsync());
        }

        // GET: ItemMsts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.itemMsts == null)
            {
                return NotFound();
            }

            var itemMst = await _context.itemMsts
                .Include(i => i.brandMst)
                .Include(i => i.catMst)
                .Include(i => i.certifyMst)
                .Include(i => i.goldKrtMst)
                .Include(i => i.prodMst)
                .FirstOrDefaultAsync(m => m.ItemMstID == id);
            if (itemMst == null)
            {
                return NotFound();
            }

            return View(itemMst);
        }

        // GET: ItemMsts/Create
        public IActionResult Create()
        {
            ViewData["BrandMstID"] = new SelectList(_context.brandMsts, "BrandMstID", "Brand_Type");
            ViewData["CatMstId"] = new SelectList(_context.catMsts, "CatMstId", "Cat_Name");
            ViewData["CertifyMstID"] = new SelectList(_context.CertifyMsts, "CertifyMstID", "Cat_Name");
            ViewData["GoldKrtMstID"] = new SelectList(_context.goldKrtMsts, "GoldKrtMstID", "Gold_Crt");
            ViewData["ProdMstID"] = new SelectList(_context.prodMsts, "ProdMstID", "Prod_Type");
            return View();
        }

        // POST: ItemMsts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ItemMst itemMst)
        {
            //if (ModelState.IsValid)
            //{
                _context.Add(itemMst);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}
            //ViewData["BrandMstID"] = new SelectList(_context.brandMsts, "BrandMstID", "Brand_Type", itemMst.BrandMstID);
            //ViewData["CatMstId"] = new SelectList(_context.catMsts, "CatMstId", "Cat_Name", itemMst.CatMstId);
            //ViewData["CertifyMstID"] = new SelectList(_context.CertifyMsts, "CertifyMstID", "Cat_Name", itemMst.CertifyMstID);
            //ViewData["GoldKrtMstID"] = new SelectList(_context.goldKrtMsts, "GoldKrtMstID", "Gold_Crt", itemMst.GoldKrtMstID);
            //ViewData["ProdMstID"] = new SelectList(_context.prodMsts, "ProdMstID", "Prod_Type", itemMst.ProdMstID);
            //return View(itemMst);
        }

        // GET: ItemMsts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.itemMsts == null)
            {
                return NotFound();
            }

            var itemMst = await _context.itemMsts.FindAsync(id);
            if (itemMst == null)
            {
                return NotFound();
            }
            ViewData["BrandMstID"] = new SelectList(_context.brandMsts, "BrandMstID", "Brand_Type", itemMst.BrandMstID);
            ViewData["CatMstId"] = new SelectList(_context.catMsts, "CatMstId", "Cat_Name", itemMst.CatMstId);
            ViewData["CertifyMstID"] = new SelectList(_context.CertifyMsts, "CertifyMstID", "Cat_Name", itemMst.CertifyMstID);
            ViewData["GoldKrtMstID"] = new SelectList(_context.goldKrtMsts, "GoldKrtMstID", "Gold_Crt", itemMst.GoldKrtMstID);
            ViewData["ProdMstID"] = new SelectList(_context.prodMsts, "ProdMstID", "Prod_Type", itemMst.ProdMstID);
            return View(itemMst);
        }

        // POST: ItemMsts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,ItemMst itemMst)
        {
            if (id != itemMst.ItemMstID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemMst);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemMstExists(itemMst.ItemMstID))
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
            ViewData["BrandMstID"] = new SelectList(_context.brandMsts, "BrandMstID", "Brand_Type", itemMst.BrandMstID);
            ViewData["CatMstId"] = new SelectList(_context.catMsts, "CatMstId", "Cat_Name", itemMst.CatMstId);
            ViewData["CertifyMstID"] = new SelectList(_context.CertifyMsts, "CertifyMstID", "Cat_Name", itemMst.CertifyMstID);
            ViewData["GoldKrtMstID"] = new SelectList(_context.goldKrtMsts, "GoldKrtMstID", "Gold_Crt", itemMst.GoldKrtMstID);
            ViewData["ProdMstID"] = new SelectList(_context.prodMsts, "ProdMstID", "Prod_Type", itemMst.ProdMstID);
            return View(itemMst);
        }

        // GET: ItemMsts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.itemMsts == null)
            {
                return NotFound();
            }

            var itemMst = await _context.itemMsts
                .Include(i => i.brandMst)
                .Include(i => i.catMst)
                .Include(i => i.certifyMst)
                .Include(i => i.goldKrtMst)
                .Include(i => i.prodMst)
                .FirstOrDefaultAsync(m => m.ItemMstID == id);
            if (itemMst == null)
            {
                return NotFound();
            }

            return View(itemMst);
        }

        // POST: ItemMsts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.itemMsts == null)
            {
                return Problem("Entity set 'JewelryContext.itemMsts'  is null.");
            }
            var itemMst = await _context.itemMsts.FindAsync(id);
            if (itemMst != null)
            {
                _context.itemMsts.Remove(itemMst);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemMstExists(int id)
        {
          return (_context.itemMsts?.Any(e => e.ItemMstID == id)).GetValueOrDefault();
        }
    }
}
