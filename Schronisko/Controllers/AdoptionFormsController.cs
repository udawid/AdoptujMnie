using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        // GET: AdoptionForms/Create
        public IActionResult Create(int? AnimalID)
        {
            if (!User.Identity.IsAuthenticated)
            {
                TempData["ErrorMessage"] = "Formularz adopcyjny może wypełnić tylko użytkownik zalogowany.";
                return RedirectToAction("Details", "Animals", new { id = AnimalID });
            }

            if (AnimalID == null)
            {
                return NotFound();
            }

            // Przykładowa logika pobierania informacji o zwierzęciu na podstawie animalId
            Animal animal = _context.Animals.Find(AnimalID);

            if (animal == null)
            {
                return NotFound();
            }

            // Przygotuj dane do przekazania do widoku
            AdoptionForm viewModel = new()
            {
                AnimalId = (int)AnimalID,
                CurrentUserName = User.Identity.Name
                // Dodaj inne dane, które chcesz przekazać do widoku
            };

            return View(viewModel);
        }


        // POST: AdoptionForms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FormId,UserName,AnimalName,AnimalId,Answer1")] AdoptionForm adoptionForm)
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
        public async Task<IActionResult> Edit(int id, [Bind("FormId,UserName,AnimalName,AnimalId,Answer1")] AdoptionForm adoptionForm)
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
