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
    public class DimMstsController : Controller
    {
        private readonly JewelryContext _context;

        public DimMstsController(JewelryContext context)
        {
            _context = context;
        }

        // GET: DimMsts
        public async Task<IActionResult> Index()
        {
            var jewelryContext = _context.dimMsts.Include(d => d.dimQltyMst).Include(d => d.dimQltySubMst).Include(d => d.itemMst);
            return View(await jewelryContext.ToListAsync());
        }

        // GET: DimMsts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.dimMsts == null)
            {
                return NotFound();
            }

            var dimMst = await _context.dimMsts
                .Include(d => d.dimQltyMst)
                .Include(d => d.dimQltySubMst)
                .Include(d => d.itemMst)
                .FirstOrDefaultAsync(m => m.DimMstId == id);
            if (dimMst == null)
            {
                return NotFound();
            }

            return View(dimMst);
        }

        // GET: DimMsts/Create
        public IActionResult Create()
        {
            ViewData["DimQltyMstID"] = new SelectList(_context.dimQltyMsts, "DimQltyMstID", "DimQlty");
            ViewData["DimQltySubMstID"] = new SelectList(_context.dimQltySubMsts, "DimQltySubMstID", "DimQlty");
            ViewData["ItemMstID"] = new SelectList(_context.itemMsts, "ItemMstID", "Prod_Quality");
            return View();
        }

        // POST: DimMsts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DimMstId,ItemMstID,DimQltyMstID,DimQltySubMstID,Dim_Crt,Dim_Pcs,Dim_Gm,Dim_Size,Dim_Rate,Dim_Amt")] DimMst dimMst)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dimMst);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DimQltyMstID"] = new SelectList(_context.dimQltyMsts, "DimQltyMstID", "DimQlty", dimMst.DimQltyMstID);
            ViewData["DimQltySubMstID"] = new SelectList(_context.dimQltySubMsts, "DimQltySubMstID", "DimQlty", dimMst.DimQltySubMstID);
            ViewData["ItemMstID"] = new SelectList(_context.itemMsts, "ItemMstID", "Prod_Quality", dimMst.ItemMstID);
            return View(dimMst);
        }

        // GET: DimMsts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.dimMsts == null)
            {
                return NotFound();
            }

            var dimMst = await _context.dimMsts.FindAsync(id);
            if (dimMst == null)
            {
                return NotFound();
            }
            ViewData["DimQltyMstID"] = new SelectList(_context.dimQltyMsts, "DimQltyMstID", "DimQlty", dimMst.DimQltyMstID);
            ViewData["DimQltySubMstID"] = new SelectList(_context.dimQltySubMsts, "DimQltySubMstID", "DimQlty", dimMst.DimQltySubMstID);
            ViewData["ItemMstID"] = new SelectList(_context.itemMsts, "ItemMstID", "Prod_Quality", dimMst.ItemMstID);
            return View(dimMst);
        }

        // POST: DimMsts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DimMstId,ItemMstID,DimQltyMstID,DimQltySubMstID,Dim_Crt,Dim_Pcs,Dim_Gm,Dim_Size,Dim_Rate,Dim_Amt")] DimMst dimMst)
        {
            if (id != dimMst.DimMstId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dimMst);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DimMstExists(dimMst.DimMstId))
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
            ViewData["DimQltyMstID"] = new SelectList(_context.dimQltyMsts, "DimQltyMstID", "DimQlty", dimMst.DimQltyMstID);
            ViewData["DimQltySubMstID"] = new SelectList(_context.dimQltySubMsts, "DimQltySubMstID", "DimQlty", dimMst.DimQltySubMstID);
            ViewData["ItemMstID"] = new SelectList(_context.itemMsts, "ItemMstID", "Prod_Quality", dimMst.ItemMstID);
            return View(dimMst);
        }

        // GET: DimMsts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.dimMsts == null)
            {
                return NotFound();
            }

            var dimMst = await _context.dimMsts
                .Include(d => d.dimQltyMst)
                .Include(d => d.dimQltySubMst)
                .Include(d => d.itemMst)
                .FirstOrDefaultAsync(m => m.DimMstId == id);
            if (dimMst == null)
            {
                return NotFound();
            }

            return View(dimMst);
        }

        // POST: DimMsts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.dimMsts == null)
            {
                return Problem("Entity set 'JewelryContext.dimMsts'  is null.");
            }
            var dimMst = await _context.dimMsts.FindAsync(id);
            if (dimMst != null)
            {
                _context.dimMsts.Remove(dimMst);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DimMstExists(int id)
        {
          return (_context.dimMsts?.Any(e => e.DimMstId == id)).GetValueOrDefault();
        }
    }
}
