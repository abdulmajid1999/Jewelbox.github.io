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
    public class StoneMstsController : Controller
    {
        private readonly JewelryContext _context;

        public StoneMstsController(JewelryContext context)
        {
            _context = context;
        }

        // GET: StoneMsts
        public async Task<IActionResult> Index()
        {
            var jewelryContext = _context.stoneMsts.Include(s => s.ItemMst).Include(s => s.ItemQltyMst);
            return View(await jewelryContext.ToListAsync());
        }

        // GET: StoneMsts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.stoneMsts == null)
            {
                return NotFound();
            }

            var stoneMst = await _context.stoneMsts
                .Include(s => s.ItemMst)
                .Include(s => s.ItemQltyMst)
                .FirstOrDefaultAsync(m => m.StoneMstId == id);
            if (stoneMst == null)
            {
                return NotFound();
            }

            return View(stoneMst);
        }

        // GET: StoneMsts/Create
        public IActionResult Create()
        {
            ViewData["ItemMstID"] = new SelectList(_context.itemMsts, "ItemMstID", "Prod_Quality");
            ViewData["StoneQltyMstID"] = new SelectList(_context.stoneQltyMsts, "StoneQltyMstID", "StoneQlty");
            return View();
        }

        // POST: StoneMsts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StoneMstId,ItemMstID,StoneQltyMstID,Stone_Gm,Stone_Pcs,Stone_Crt,Stone_Rate,Stone_Amt")] StoneMst stoneMst)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stoneMst);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ItemMstID"] = new SelectList(_context.itemMsts, "ItemMstID", "Prod_Quality", stoneMst.ItemMstID);
            ViewData["StoneQltyMstID"] = new SelectList(_context.stoneQltyMsts, "StoneQltyMstID", "StoneQlty", stoneMst.StoneQltyMstID);
            return View(stoneMst);
        }

        // GET: StoneMsts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.stoneMsts == null)
            {
                return NotFound();
            }

            var stoneMst = await _context.stoneMsts.FindAsync(id);
            if (stoneMst == null)
            {
                return NotFound();
            }
            ViewData["ItemMstID"] = new SelectList(_context.itemMsts, "ItemMstID", "Prod_Quality", stoneMst.ItemMstID);
            ViewData["StoneQltyMstID"] = new SelectList(_context.stoneQltyMsts, "StoneQltyMstID", "StoneQlty", stoneMst.StoneQltyMstID);
            return View(stoneMst);
        }

        // POST: StoneMsts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StoneMstId,ItemMstID,StoneQltyMstID,Stone_Gm,Stone_Pcs,Stone_Crt,Stone_Rate,Stone_Amt")] StoneMst stoneMst)
        {
            if (id != stoneMst.StoneMstId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stoneMst);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StoneMstExists(stoneMst.StoneMstId))
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
            ViewData["ItemMstID"] = new SelectList(_context.itemMsts, "ItemMstID", "Prod_Quality", stoneMst.ItemMstID);
            ViewData["StoneQltyMstID"] = new SelectList(_context.stoneQltyMsts, "StoneQltyMstID", "StoneQlty", stoneMst.StoneQltyMstID);
            return View(stoneMst);
        }

        // GET: StoneMsts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.stoneMsts == null)
            {
                return NotFound();
            }

            var stoneMst = await _context.stoneMsts
                .Include(s => s.ItemMst)
                .Include(s => s.ItemQltyMst)
                .FirstOrDefaultAsync(m => m.StoneMstId == id);
            if (stoneMst == null)
            {
                return NotFound();
            }

            return View(stoneMst);
        }

        // POST: StoneMsts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.stoneMsts == null)
            {
                return Problem("Entity set 'JewelryContext.stoneMsts'  is null.");
            }
            var stoneMst = await _context.stoneMsts.FindAsync(id);
            if (stoneMst != null)
            {
                _context.stoneMsts.Remove(stoneMst);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StoneMstExists(int id)
        {
          return (_context.stoneMsts?.Any(e => e.StoneMstId == id)).GetValueOrDefault();
        }
    }
}
