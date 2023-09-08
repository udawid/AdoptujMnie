using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Schronisko.Data;
using Schronisko.Data.Migrations;
using Schronisko.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Schronisko.Controllers
{
    public class UserFormQuestionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserFormQuestionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        //// GET: UserFormQuestions
        //[Authorize(Roles = "admin, opiekun")]
        //public async Task<IActionResult> Index()
        //{
        //    var applicationDbContext = _context.UserFormQuestions.Include(u => u.Form).Include(u => u.QuestionType);
        //    return View(await applicationDbContext.ToListAsync());
        //}

        // GET: UserFormQuestions/Details/5
        [Authorize(Roles = "admin, opiekun")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UserFormQuestions == null)
            {
                return NotFound();
            }

            var userFormQuestion = await _context.UserFormQuestions
                .Include(u => u.Form)
                .Include(u => u.QuestionType)
                .FirstOrDefaultAsync(m => m.UserFormQuestionID == id);
            if (userFormQuestion == null)
            {
                return NotFound();
            }

            return View(userFormQuestion);
        }

        // GET: UserFormQuestions/Create
        [Authorize(Roles = "admin, opiekun")]
        //id - identyfikator ankiety, nie jest możliwe utworzenie pytania bez przypisania do ankiety
        public IActionResult Create(int? id)
        {
            ViewData["UserFormID"] = id;
            ViewData["UserFormQuestionTypeID"] = new SelectList(_context.UserFormQuestionTypes.Where(t => t.Active == true), "UserFormQuestionTypeID", "Name");
            ViewData["QuestionOrder"] = (_context.UserFormQuestions.Where(q => q.UserFormID == id)
                                        .Max(q => q.QuestionOrder) ?? 0) + 1; //domyślnie nowe pytanie trafia na koniec, czyli wyznaczamy nr porządkowy jako max+1
            return View();
        }

        // POST: UserFormQuestions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin, opiekun")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserFormQuestionID,UserFormID,QuestionOrder,QuestionText,Description,UserFormQuestionTypeID,AddedDate")] UserFormQuestion userFormQuestion)
        {
            if (ModelState.IsValid)
            {
                // ustawienie użytkownika i daty
                userFormQuestion.Id = User.FindFirstValue(ClaimTypes.NameIdentifier);
                userFormQuestion.AddedDate = DateTime.Now;

                _context.Add(userFormQuestion);
                await _context.SaveChangesAsync();

                //jeśli pytanie typu 'Tak/Nie' to automatycznie dodajemy dwie opcje do pytania
                var typeYesNo = _context.UserFormQuestionTypes.FirstOrDefault(t => t.Name == "Tak/Nie" || t.Name == "TakNie");
                if (userFormQuestion.UserFormQuestionTypeID == typeYesNo.UserFormQuestionTypeID)
                {
                    var optionYes = new UserFormQuestionOption();
                    optionYes.OptionOrder = 1;
                    optionYes.OptionText = "Tak";
                    optionYes.UserFormQuestionID = userFormQuestion.UserFormQuestionID;
                    optionYes.Id = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    optionYes.AddedDate = DateTime.Now;
                    _context.Add(optionYes);


                    var optionNo = new UserFormQuestionOption();
                    optionNo.OptionOrder = 1;
                    optionNo.OptionText = "Nie";
                    optionNo.UserFormQuestionID = userFormQuestion.UserFormQuestionID;
                    optionNo.Id = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    optionNo.AddedDate = DateTime.Now;
                    _context.Add(optionNo);

                    await _context.SaveChangesAsync();
                }

                //jeśli już istnieją pytania z daną wartością QuestionOrder
                //to dla wszystkich rekordów z QuestionOrder większycm lub równym podbijamy wartość o 1
                if (_context.UserFormQuestions.Any(q => q.QuestionOrder == userFormQuestion.QuestionOrder && q.UserFormQuestionID != userFormQuestion.UserFormQuestionID))
                {
                    var questions = _context.UserFormQuestions.Where(q => q.QuestionOrder >= userFormQuestion.QuestionOrder && q.UserFormQuestionID != userFormQuestion.UserFormQuestionID).ToList();
                    questions.ForEach(q => q.QuestionOrder++);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction("Edit", "UserForms", new { id = userFormQuestion.UserFormID });
            }
            //ViewData["UserFormID"] = new SelectList(_context.UserForms, "UserFormID", "Description", userFormQuestion.UserFormID);
            ViewData["UserFormID"] = userFormQuestion.UserFormID;
            ViewData["UserFormQuestionTypeID"] = new SelectList(_context.UserFormQuestionTypes.Where(t => t.Active == true), "UserFormQuestionTypeID", "Name", userFormQuestion.UserFormQuestionTypeID);
            return View(userFormQuestion);
        }

        // GET: UserFormQuestions/Edit/5
        [Authorize(Roles = "admin, opiekun")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UserFormQuestions == null)
            {
                return NotFound();
            }

            var userFormQuestion = await _context.UserFormQuestions.FindAsync(id);
            if (userFormQuestion == null)
            {
                return NotFound();
            }
            //ViewData["UserFormID"] = new SelectList(_context.UserForms, "UserFormID", "Description", userFormQuestion.UserFormID);
            ViewData["UserFormQuestionTypeID"] = new SelectList(_context.UserFormQuestionTypes.Where(t => t.Active == true), "UserFormQuestionTypeID", "Name", userFormQuestion.UserFormQuestionTypeID);
            return View(userFormQuestion);
        }

        // POST: UserFormQuestions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin, opiekun")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserFormQuestionID,UserFormID,QuestionOrder,QuestionText,Description,UserFormQuestionTypeID,AddedDate")] UserFormQuestion userFormQuestion)
        {
            if (id != userFormQuestion.UserFormQuestionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userFormQuestion);
                    await _context.SaveChangesAsync();



                    //jeśli już istnieją pytania z daną wartością QuestionOrder
                    //to dla wszystkich rekordów z QuestionOrder większycm lub równym podbijamy wartość o 1
                    if (_context.UserFormQuestions.Any(q => q.QuestionOrder == userFormQuestion.QuestionOrder && q.UserFormQuestionID != userFormQuestion.UserFormQuestionID))
                    {
                        var questions = _context.UserFormQuestions.Where(q => q.QuestionOrder >= userFormQuestion.QuestionOrder && q.UserFormQuestionID != userFormQuestion.UserFormQuestionID).ToList();
                        questions.ForEach(q => q.QuestionOrder++);
                        await _context.SaveChangesAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserFormQuestionExists(userFormQuestion.UserFormQuestionID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Edit", "UserForms", new { id = userFormQuestion.UserFormID });
            }
            //ViewData["UserFormID"] = new SelectList(_context.UserForms, "UserFormID", "Description", userFormQuestion.UserFormID);
            ViewData["UserFormQuestionTypeID"] = new SelectList(_context.UserFormQuestionTypes.Where(t => t.Active == true), "UserFormQuestionTypeID", "Name", userFormQuestion.UserFormQuestionTypeID);
            return View(userFormQuestion);
        }

        // GET: UserFormQuestions/Delete/5
        [Authorize(Roles = "admin, opiekun")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UserFormQuestions == null)
            {
                return NotFound();
            }

            var userFormQuestion = await _context.UserFormQuestions
                .Include(u => u.Form)
                .Include(u => u.QuestionType)
                .FirstOrDefaultAsync(m => m.UserFormQuestionID == id);
            if (userFormQuestion == null)
            {
                return NotFound();
            }

            return View(userFormQuestion);
        }

        // POST: UserFormQuestions/Delete/5
        [Authorize(Roles = "admin, opiekun")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UserFormQuestions == null)
            {
                return Problem("Entity set 'ApplicationDbContext.UserFormQuestions'  is null.");
            }
            var userFormQuestion = await _context.UserFormQuestions.FindAsync(id);
            if (userFormQuestion != null)
            {
                _context.UserFormQuestions.Remove(userFormQuestion);
            }

            await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
            return RedirectToAction("Edit", "UserForms", new { id = userFormQuestion.UserFormID });
        }

        private bool UserFormQuestionExists(int id)
        {
            return (_context.UserFormQuestions?.Any(e => e.UserFormQuestionID == id)).GetValueOrDefault();
        }
    }
}
