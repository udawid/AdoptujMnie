using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Schronisko.Data;
using Schronisko.Models;

namespace Schronisko.Controllers
{
    public class UserFormsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserFormsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserForms
        [Authorize(Roles = "admin, opiekun")]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.UserForms.Include(u => u.FormType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: UserForms/Details/5
        [Authorize(Roles = "admin, opiekun")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UserForms == null)
            {
                return NotFound();
            }

            var userForm = await _context.UserForms
                .Include("Questions").Include("Questions.QuestionType")
                .Include("Questions.Options")//.Include("Questions.Options.OptionType")
                .Include(u => u.FormType)
                .FirstOrDefaultAsync(m => m.UserFormID == id);
            if (userForm == null)
            {
                return NotFound();
            }

            return View(userForm);
        }

        // GET: UserForms/Create
        [Authorize(Roles = "admin, opiekun")]
        public IActionResult Create()
        {
            ViewData["UserFormTypeID"] = new SelectList(_context.UserFormTypes.Where(t => t.Active == true), "FormTypeID", "Name");
            return View();
        }

        // POST: UserForms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin, opiekun")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserFormID,Name,Title,Description,UserFormTypeID,Active,AddedDate")] UserForm userForm)
        {
            if (ModelState.IsValid)
            {
                // ustawienie użytkownika i daty
                userForm.Id = User.FindFirstValue(ClaimTypes.NameIdentifier);
                userForm.AddedDate = DateTime.Now;

                _context.Add(userForm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserFormTypeID"] = new SelectList(_context.UserFormTypes.Where(t => t.Active == true), "FormTypeID", "Name", userForm.UserFormTypeID);
            return View(userForm);
        }

        // GET: UserForms/Edit/5
        [Authorize(Roles = "admin, opiekun")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UserForms == null)
            {
                return NotFound();
            }

            var userForm = await _context.UserForms
                .Include("Questions").Include("Questions.QuestionType")
                .Include("Questions.Options")//.Include("Questions.Options.OptionType")
                .FirstOrDefaultAsync(f => f.UserFormID == id);
            if (userForm == null)
            {
                return NotFound();
            }
            ViewData["UserFormTypeID"] = new SelectList(_context.UserFormTypes.Where(t => t.Active == true), "FormTypeID", "Name", userForm.UserFormTypeID);
            return View(userForm);
        }

        // POST: UserForms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin, opiekun")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserFormID,Name,Title,Description,UserFormTypeID,Active,AddedDate")] UserForm userForm)
        {
            if (id != userForm.UserFormID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userForm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserFormExists(userForm.UserFormID))
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
            ViewData["UserFormTypeID"] = new SelectList(_context.UserFormTypes.Where(t => t.Active == true), "FormTypeID", "Name", userForm.UserFormTypeID);
            return View(userForm);
        }

        // GET: UserForms/Delete/5
        [Authorize(Roles = "admin, opiekun")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UserForms == null)
            {
                return NotFound();
            }

            var userForm = await _context.UserForms
                .Include(u => u.FormType)
                .FirstOrDefaultAsync(m => m.UserFormID == id);
            if (userForm == null)
            {
                return NotFound();
            }

            return View(userForm);
        }

        // POST: UserForms/Delete/5
        [Authorize(Roles = "admin, opiekun")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UserForms == null)
            {
                return Problem("Entity set 'ApplicationDbContext.UserForms'  is null.");
            }
            var userForm = await _context.UserForms.FindAsync(id);
            if (userForm != null)
            {
                _context.UserForms.Remove(userForm);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserFormExists(int id)
        {
            return (_context.UserForms?.Any(e => e.UserFormID == id)).GetValueOrDefault();
        }
    }
}
