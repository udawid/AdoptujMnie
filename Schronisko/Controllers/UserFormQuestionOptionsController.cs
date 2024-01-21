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
    public class UserFormQuestionOptionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserFormQuestionOptionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        //// GET: UserFormQuestionOptions
        //public async Task<IActionResult> Index()
        //{
        //    var applicationDbContext = _context.UserFormQuestionOptions.Include(u => u.Question).Include(u => u.User);
        //    return View(await applicationDbContext.ToListAsync());
        //}

        // GET: UserFormQuestionOptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UserFormQuestionOptions == null)
            {
                return NotFound();
            }

            var userFormQuestionOption = await _context.UserFormQuestionOptions
                .Include(u => u.Question)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.UserFormQuestionOptionID == id);
            if (userFormQuestionOption == null)
            {
                return NotFound();
            }

            return View(userFormQuestionOption);
        }

        // GET: UserFormQuestionOptions/Create
        [Authorize(Roles = "admin, opiekun")]
        //id - identyfikator pytania, nie jest możliwe utworzenie odpiedzi bez przypisania do pytania
        public IActionResult Create(int? id)
        {
            ViewData["UserFormQuestionID"] = id;
            ViewData["UserFormID"] = _context.UserFormQuestions.FirstOrDefault(q => q.UserFormQuestionID == id).UserFormID;
            //ViewData["UserFormQuestionID"] = new SelectList(_context.UserFormQuestions, "UserFormQuestionID", "QuestionText");
            ViewData["OptionOrder"] = (_context.UserFormQuestionOptions.Where(o => o.UserFormQuestionID == id)
                .Max(q => q.OptionOrder) ?? 0) + 1; //domyślnie nowa opcja trafia na koniec, czyli wyznaczamy nr porządkowy jako max+1
            return View();
        }

        // POST: UserFormQuestionOptions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin, opiekun")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserFormQuestionOptionID,UserFormQuestionID,OptionOrder,OptionText,Id,AddedDate,Disqualifying,Points")] UserFormQuestionOption userFormQuestionOption)
        {
            if (ModelState.IsValid)
            {
                // ustawienie użytkownika i daty
                userFormQuestionOption.Id = User.FindFirstValue(ClaimTypes.NameIdentifier);
                userFormQuestionOption.AddedDate = DateTime.Now;

                _context.Add(userFormQuestionOption);
                await _context.SaveChangesAsync();

                //jeśli już istnieją pytania z daną wartością OptionOrder
                //to dla wszystkich rekordów z OptionOrder większym lub równym podbijamy wartość o 1
                if (_context.UserFormQuestionOptions.Any(q => q.OptionOrder == userFormQuestionOption.OptionOrder && q.UserFormQuestionOptionID != userFormQuestionOption.UserFormQuestionOptionID))
                {
                    var questions = _context.UserFormQuestionOptions.Where(q => q.OptionOrder >= userFormQuestionOption.OptionOrder && q.UserFormQuestionOptionID != userFormQuestionOption.UserFormQuestionOptionID).ToList();
                    questions.ForEach(q => q.OptionOrder++);
                    await _context.SaveChangesAsync();
                }

                int formID = _context.UserFormQuestions
                    .Where(q => q.UserFormQuestionID == userFormQuestionOption.UserFormQuestionID)
                    .Select(q => q.UserFormID).FirstOrDefault();
                return RedirectToAction("Edit", "UserForms", new { id = formID });
            }
            //ViewData["UserFormQuestionID"] = new SelectList(_context.UserFormQuestions, "UserFormQuestionID", "QuestionText", userFormQuestionOption.UserFormQuestionID);
            //ViewData["Id"] = new SelectList(_context.AppUsers, "Id", "Id", userFormQuestionOption.Id);
            ViewData["UserFormQuestionID"] = userFormQuestionOption.UserFormQuestionID;
            ViewData["UserFormID"] = _context.UserFormQuestions.FirstOrDefault(q => q.UserFormQuestionID == userFormQuestionOption.UserFormQuestionID).UserFormID;
            return View(userFormQuestionOption);
        }

        // GET: UserFormQuestionOptions/Edit/5
        [Authorize(Roles = "admin, opiekun")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UserFormQuestionOptions == null)
            {
                return NotFound();
            }

            var userFormQuestionOption = await _context.UserFormQuestionOptions.FindAsync(id);
            if (userFormQuestionOption == null)
            {
                return NotFound();
            }

            ViewData["UserFormID"] = _context.UserFormQuestions.FirstOrDefault(q => q.UserFormQuestionID == userFormQuestionOption.UserFormQuestionID).UserFormID;
            return View(userFormQuestionOption);
        }

        // POST: UserFormQuestionOptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin, opiekun")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserFormQuestionOptionID,UserFormQuestionID,OptionOrder,OptionText,Id,AddedDate,Disqualifying,Points")] UserFormQuestionOption userFormQuestionOption)
        {
            if (id != userFormQuestionOption.UserFormQuestionOptionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userFormQuestionOption);
                    await _context.SaveChangesAsync();

                    //jeśli już istnieją pytania z daną wartością OptionOrder
                    //to dla wszystkich rekordów z OptionOrder większym lub równym podbijamy wartość o 1
                    if (_context.UserFormQuestionOptions.Any(q => q.OptionOrder == userFormQuestionOption.OptionOrder && q.UserFormQuestionOptionID != userFormQuestionOption.UserFormQuestionOptionID))
                    {
                        var questions = _context.UserFormQuestionOptions.Where(q => q.OptionOrder >= userFormQuestionOption.OptionOrder && q.UserFormQuestionOptionID != userFormQuestionOption.UserFormQuestionOptionID).ToList();
                        questions.ForEach(q => q.OptionOrder++);
                        await _context.SaveChangesAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserFormQuestionOptionExists(userFormQuestionOption.UserFormQuestionOptionID))
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

            ViewData["UserFormID"] = _context.UserFormQuestions.FirstOrDefault(q => q.UserFormQuestionID == userFormQuestionOption.UserFormQuestionID).UserFormID;
            return View(userFormQuestionOption);
        }

        // GET: UserFormQuestionOptions/Delete/5
        [Authorize(Roles = "admin, opiekun")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UserFormQuestionOptions == null)
            {
                return NotFound();
            }

            var userFormQuestionOption = await _context.UserFormQuestionOptions
                .Include(u => u.Question)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.UserFormQuestionOptionID == id);
            if (userFormQuestionOption == null)
            {
                return NotFound();
            }

            ViewData["UserFormID"] = _context.UserFormQuestions.FirstOrDefault(q => q.UserFormQuestionID == userFormQuestionOption.UserFormQuestionID).UserFormID;

            return View(userFormQuestionOption);
        }

        // POST: UserFormQuestionOptions/Delete/5
        [Authorize(Roles = "admin, opiekun")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UserFormQuestionOptions == null)
            {
                return Problem("Entity set 'ApplicationDbContext.UserFormQuestionOptions'  is null.");
            }
            var userFormQuestionOption = await _context.UserFormQuestionOptions.FindAsync(id);
            if (userFormQuestionOption != null)
            {
                _context.UserFormQuestionOptions.Remove(userFormQuestionOption);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserFormQuestionOptionExists(int id)
        {
            return (_context.UserFormQuestionOptions?.Any(e => e.UserFormQuestionOptionID == id)).GetValueOrDefault();
        }
    }
}
