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
    public class ResponseUserFormsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ResponseUserFormsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ResponseUserForms
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ResponseUserForms.Include(r => r.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ResponseUserForms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ResponseUserForms == null)
            {
                return NotFound();
            }

            var responseUserForm = await _context.ResponseUserForms
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.ResponseUserFormID == id);
            if (responseUserForm == null)
            {
                return NotFound();
            }

            return View(responseUserForm);
        }

        // GET: ResponseUserForms/Create
        public IActionResult Create(int? id)
        {
            if (id == null)
            {
                //jeśli nie podano id ankiety, to wyświetlana jest pierwsza aktywna ankieta ogólna
                id = _context.UserForms.FirstOrDefault(f => (f.Active == true && f.FormType.Name == "Adopcja ogólny"))
                    .UserFormID;
            }
            ViewData["UserFormID"] = id;
            //ViewData["UserFormID"] = _context.UserFormQuestions.FirstOrDefault(q => q.UserFormQuestionID == id).UserFormID;
            ViewData["Id"] = new SelectList(_context.AppUsers, "Id", "Id");
            return View();
        }

        // POST: ResponseUserForms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ResponseUserFormID,UserFormID,Name,Title,Description,UserFormTypeID,Id,AddedDate")] ResponseUserForm responseUserForm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(responseUserForm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.AppUsers, "Id", "Id", responseUserForm.Id);
            return View(responseUserForm);
        }

        // GET: ResponseUserForms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ResponseUserForms == null)
            {
                return NotFound();
            }

            var responseUserForm = await _context.ResponseUserForms.FindAsync(id);
            if (responseUserForm == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.AppUsers, "Id", "Id", responseUserForm.Id);
            return View(responseUserForm);
        }

        // POST: ResponseUserForms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ResponseUserFormID,UserFormID,Name,Title,Description,UserFormTypeID,Id,AddedDate")] ResponseUserForm responseUserForm)
        {
            if (id != responseUserForm.ResponseUserFormID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(responseUserForm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResponseUserFormExists(responseUserForm.ResponseUserFormID))
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
            ViewData["Id"] = new SelectList(_context.AppUsers, "Id", "Id", responseUserForm.Id);
            return View(responseUserForm);
        }

        // GET: ResponseUserForms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ResponseUserForms == null)
            {
                return NotFound();
            }

            var responseUserForm = await _context.ResponseUserForms
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.ResponseUserFormID == id);
            if (responseUserForm == null)
            {
                return NotFound();
            }

            return View(responseUserForm);
        }

        // POST: ResponseUserForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ResponseUserForms == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ResponseUserForms'  is null.");
            }
            var responseUserForm = await _context.ResponseUserForms.FindAsync(id);
            if (responseUserForm != null)
            {
                _context.ResponseUserForms.Remove(responseUserForm);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResponseUserFormExists(int id)
        {
            return (_context.ResponseUserForms?.Any(e => e.ResponseUserFormID == id)).GetValueOrDefault();
        }
    }
}
