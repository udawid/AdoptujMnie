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
using Schronisko.Models.ViewModels;
using Microsoft.AspNetCore.Identity;


namespace Schronisko.Controllers
{
    public class AnimalsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public AnimalsController(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Animals
        [Authorize(Roles = "admin, opiekun")]
        public async Task<IActionResult> Index()
        {
              return View(await _context.Animals
                .Include(a => a.AnimalType).ToListAsync());
        }

        // GET: Animals
        public async Task<IActionResult> List(string Phrase, string Status, int? AnimalType, int PageNumber = 1)
        {
            var SelectedAnimals = _context.Animals
                .Include(a => a.AnimalType)
                //.Where(a => a.Dostepnosc == true)
                .OrderByDescending(a => a.AddedDate);

            if (AnimalType != null)
            {
                SelectedAnimals = (IOrderedQueryable<Animal>)SelectedAnimals
                .Where(a => a.AnimalType.AnimalTypeID == AnimalType);
            }
            if (!String.IsNullOrEmpty(Status))
            {
                SelectedAnimals = (IOrderedQueryable<Animal>)SelectedAnimals
                .Where(a => a.Status == Status);
            }
            if (!String.IsNullOrEmpty(Phrase))
            {
                SelectedAnimals = (IOrderedQueryable<Animal>)SelectedAnimals
                .Where(r => r.Name.Contains(Phrase) || r.Description.Contains(Phrase));
            }

            AnimalsViewModel animalsViewModel = new();
            animalsViewModel.AnimalsView = new AnimalsView();

            animalsViewModel.AnimalsView.TextCount = SelectedAnimals.Count();
            animalsViewModel.AnimalsView.PageNumber = PageNumber;

            animalsViewModel.AnimalsView.Status = Status;
            animalsViewModel.AnimalsView.Phrase = Phrase;
            animalsViewModel.AnimalsView.AnimalType = AnimalType;

            animalsViewModel.Animals = (IEnumerable<Animal>?)await SelectedAnimals
                .Skip((PageNumber - 1) * animalsViewModel.AnimalsView.PageSize)
                .Take(animalsViewModel.AnimalsView.PageSize)
                .ToListAsync();

            ViewData["AnimalType"] = new SelectList(_context.AnimalTypes?
                .AsQueryable(),//.Where(t => t.Active == true),
                "AnimalTypeID", "Name", AnimalType);

            var statusList = new List<SelectListItem>();
            statusList.Add(new SelectListItem("W trakcie badań","W trakcie badań"));
            statusList.Add(new SelectListItem("Szuka domu", "Szuka domu"));
            statusList.Add(new SelectListItem("W trakcie adopcji", "W trakcie adopcji"));
            ViewData["Status"] = new SelectList(statusList, "Value", "Text", Status);

            return View(animalsViewModel);
        }

        // GET: Animals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
/*            if (id == null || _context.Animals == null)
            {
                return NotFound();
            }

            AnimalWithOpinions animalWithOpinions = new AnimalWithOpinions();
            animalWithOpinions.SelectedAnimal = await _context.Animals
                .Include(t => t.Name)
                .Include(t => t.Description)
                .Include(t => t.Comments)
                .Where(t => t.Dostepnosc == true)
                .FirstOrDefaultAsync(m => m.AnimalID == id);

            if (animalWithOpinions.SelectedAnimal == null)
            {
                return NotFound();
            }
            if (animalWithOpinions.CommentsNumber != 0)
            {
                animalWithOpinions.CommentsNumber = _context.Comments.Where(o => o.AnimalId == id).Count();
            }*/

            var animal = await _context.Animals
                .Include(a => a.AnimalType)
                .FirstOrDefaultAsync(m => m.AnimalID == id);
            if (animal == null)
            {
                return NotFound();
            }
            return View(animal);
            //return View(animalWithOpinions);
        }

        // GET: Animals/Create
        public IActionResult Create()
        {
            ViewData["AnimalTypeID"] = new SelectList(_context.AnimalTypes, "AnimalTypeID", "Name");
            return View();
        }

        // POST: Animals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AnimalID,Name,Description,AnimalTypeID,Status,Dostepnosc,Photo,AddedDate,AdoptowanyPrzez")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(animal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnimalTypeID"] = new SelectList(_context.AnimalTypes, "AnimalTypeID", "Name", animal.AnimalTypeID);
            return View(animal);
        }

        // GET: Animals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Animals == null)
            {
                return NotFound();
            }

            var animal = await _context.Animals.FindAsync(id);
            if (animal == null)
            {
                return NotFound();
            }
            
                // Pobierz listę e-maili użytkowników
            var emails = _userManager.Users.Select(u => u.Email).ToList();
            ViewBag.UsersEmails = new SelectList(emails);

            ViewData["AnimalTypeID"] = new SelectList(_context.AnimalTypes, "AnimalTypeID", "Name", animal.AnimalTypeID);
            return View(animal);
        }

        // POST: Animals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AnimalID,Name,Description,AnimalTypeID,Status,Dostepnosc,Photo,AddedDate,AdoptowanyPrzez")] Animal animal)
        {
            if (id != animal.AnimalID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(animal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimalExists(animal.AnimalID))
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
            ViewData["AnimalTypeID"] = new SelectList(_context.AnimalTypes, "AnimalTypeID", "Name", animal.AnimalTypeID);
            return View(animal);
        }

        // GET: Animals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Animals == null)
            {
                return NotFound();
            }

            var animal = await _context.Animals
                .Include(a => a.AnimalType)
                .FirstOrDefaultAsync(m => m.AnimalID == id);
            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }

        // POST: Animals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Animals == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Animals'  is null.");
            }
            var animal = await _context.Animals.FindAsync(id);
            if (animal != null)
            {
                _context.Animals.Remove(animal);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnimalExists(int id)
        {
          return _context.Animals.Any(e => e.AnimalID == id);
        }
    }
}
