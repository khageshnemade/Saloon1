﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Saloon1.Models;

namespace Saloon1.Controllers
{
 [Authorize]
 public class StylistsController : Controller
    {
        private readonly Saloon1Context _context;

        public StylistsController(Saloon1Context context)
        {
            _context = context;
        }

        // GET: Stylists
        public async Task<IActionResult> Index()
        {
              return _context.Stylists != null ? 
                          View(await _context.Stylists.ToListAsync()) :
                          Problem("Entity set 'Saloon1Context.Stylists'  is null.");
        }

        // GET: Stylists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Stylists == null)
            {
                return NotFound();
            }

            var stylist = await _context.Stylists
                .FirstOrDefaultAsync(m => m.StylistId == id);
            if (stylist == null)
            {
                return NotFound();
            }

            return View(stylist);
        }

        // GET: Stylists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Stylists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StylistId,FirstName,LastName,Gender,ContactNumber,Email,Specialization")] Stylist stylist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stylist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stylist);
        }

        // GET: Stylists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Stylists == null)
            {
                return NotFound();
            }

            var stylist = await _context.Stylists.FindAsync(id);
            if (stylist == null)
            {
                return NotFound();
            }
            return View(stylist);
        }

        // POST: Stylists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StylistId,FirstName,LastName,Gender,ContactNumber,Email,Specialization")] Stylist stylist)
        {
            if (id != stylist.StylistId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stylist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StylistExists(stylist.StylistId))
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
            return View(stylist);
        }

        // GET: Stylists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Stylists == null)
            {
                return NotFound();
            }

            var stylist = await _context.Stylists
                .FirstOrDefaultAsync(m => m.StylistId == id);
            if (stylist == null)
            {
                return NotFound();
            }

            return View(stylist);
        }

        // POST: Stylists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Stylists == null)
            {
                return Problem("Entity set 'Saloon1Context.Stylists'  is null.");
            }
            var stylist = await _context.Stylists.FindAsync(id);
            if (stylist != null)
            {
                _context.Stylists.Remove(stylist);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StylistExists(int id)
        {
          return (_context.Stylists?.Any(e => e.StylistId == id)).GetValueOrDefault();
        }
    }
}
