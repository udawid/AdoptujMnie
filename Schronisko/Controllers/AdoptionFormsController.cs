using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Schronisko.Data;
using Schronisko.Models;

namespace Schronisko.Controllers
{
    public class AdoptionFormsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdoptionFormsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AdoptionForms
        public async Task<IActionResult> Index()
        {
              return _context.AdoptionForms != null ? 
                          View(await _context.AdoptionForms.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.AdoptionForms'  is null.");
        }

        // GET: AdoptionForms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AdoptionForms == null)
            {
                return NotFound();
            }

            var adoptionForm = await _context.AdoptionForms
                .FirstOrDefaultAsync(m => m.FormId == id);
            if (adoptionForm == null)
            {
                return NotFound();
            }

            return View(adoptionForm);
        }

        // GET: AdoptionForms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdoptionForms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FormId,AnimalId,CurrentUserName,Answer1,Answer2,Answer3,Answer4,Answer5,Answer6,Answer7,Answer8,Answer9,Answer10,Answer11,Answer12,Answer13,Answer14,Answer15,Answer16,Answer17,Answer18,Answer19,Answer20,Answer21,Answer22,Answer23,Answer24")] AdoptionForm adoptionForm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adoptionForm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(adoptionForm);
        }

        // GET: AdoptionForms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AdoptionForms == null)
            {
                return NotFound();
            }

            var adoptionForm = await _context.AdoptionForms.FindAsync(id);
            if (adoptionForm == null)
            {
                return NotFound();
            }
            return View(adoptionForm);
        }

        // POST: AdoptionForms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FormId,AnimalId,CurrentUserName,Answer1,Answer2,Answer3,Answer4,Answer5,Answer6,Answer7,Answer8,Answer9,Answer10,Answer11,Answer12,Answer13,Answer14,Answer15,Answer16,Answer17,Answer18,Answer19,Answer20,Answer21,Answer22,Answer23,Answer24")] AdoptionForm adoptionForm)
        {
            if (id != adoptionForm.FormId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adoptionForm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdoptionFormExists(adoptionForm.FormId))
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
            return View(adoptionForm);
        }

        // GET: AdoptionForms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AdoptionForms == null)
            {
                return NotFound();
            }

            var adoptionForm = await _context.AdoptionForms
                .FirstOrDefaultAsync(m => m.FormId == id);
            if (adoptionForm == null)
            {
                return NotFound();
            }

            return View(adoptionForm);
        }

        // POST: AdoptionForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AdoptionForms == null)
            {
                return Problem("Entity set 'ApplicationDbContext.AdoptionForms'  is null.");
            }
            var adoptionForm = await _context.AdoptionForms.FindAsync(id);
            if (adoptionForm != null)
            {
                _context.AdoptionForms.Remove(adoptionForm);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdoptionFormExists(int id)
        {
          return (_context.AdoptionForms?.Any(e => e.FormId == id)).GetValueOrDefault();
        }
    }
}
