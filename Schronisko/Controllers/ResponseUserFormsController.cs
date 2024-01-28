using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        public async Task<IActionResult> Index(int? id)
        {
            ViewData["userFormName"] = _context.UserForms.FirstOrDefault(f => f.UserFormID == id).Name;

            var applicationDbContext = _context.ResponseUserForms.Where(r => r.UserFormID==id).Include(r => r.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ResponseUserForms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ResponseUserForms == null)
            {
                return NotFound();
            }

            var responseUserForm = _context.ResponseUserForms
                .Include("ResponseQuestions")
                .Include("ResponseQuestions.ResponseOptions")
                .FirstOrDefault(f => f.ResponseUserFormID == id);
            if (responseUserForm == null)
            {
                return NotFound();
            }

            ViewData["ResponseUserFormID"] = id;
            ViewData["responseUserForm"] = responseUserForm;
            ViewData["userForm"] = _context.UserForms
                .Include("Questions").Include("Questions.QuestionType")
                .Include("Questions.Options")//.Include("Questions.Options.OptionType")
                .FirstOrDefault(f => f.UserFormID == responseUserForm.UserFormID);

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
            ViewData["userForm"] = _context.UserForms
                .Include("Questions").Include("Questions.QuestionType")
                .Include("Questions.Options")//.Include("Questions.Options.OptionType")
                .FirstOrDefault(f => f.UserFormID == id);
            ViewData["Id"] = new SelectList(_context.AppUsers, "Id", "Id");
            return View();
        }

        // POST: ResponseUserForms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(List<int> ids, List<string> values, int userFormID)//[Bind("ResponseUserFormID,UserFormID,Name,Title,Description,UserFormTypeID,Id,AddedDate")] ResponseUserForm responseUserForm)
        {
            //if (ModelState.IsValid)
            //{
            //    _context.Add(responseUserForm);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //ViewData["Id"] = new SelectList(_context.AppUsers, "Id", "Id", responseUserForm.Id);
            //return View(responseUserForm);

            var userForm = _context.UserForms
                .Include("Questions").Include("Questions.QuestionType")
                .Include("Questions.Options")//.Include("Questions.Options.OptionType")
                .FirstOrDefault(f => f.UserFormID == userFormID);

            var responseUserForm = new ResponseUserForm();
            responseUserForm.Id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            responseUserForm.UserFormID = userFormID;
            responseUserForm.AddedDate = DateTime.Now;
            _context.ResponseUserForms.Add(responseUserForm);
            _context.SaveChanges();
            foreach (var question in userForm.Questions)
            {
                var responseQuestion = new ResponseUserFormQuestion();
                responseQuestion.ResponseUserFormID = responseUserForm.ResponseUserFormID;
                responseQuestion.UserFormQuestionID = question.UserFormQuestionID;
                _context.Add(responseQuestion);
                _context.SaveChanges();

                foreach (var option in question.Options)
                {
                    var responseOption = new ResponseUserFormQuestionOption();
                    responseOption.UserFormQuestionOptionID = option.UserFormQuestionOptionID;
                    responseOption.ResponseUserFormQuestionID = responseQuestion.ResponseUserFormQuestionID;
                    responseOption.Checked = ids.Contains(responseOption.UserFormQuestionOptionID);
                    if (option.Points != null) responseUserForm.TotalPoints += option.Points.Value;
                    if (responseOption.Checked)
                    {
                        if (option.Disqualifying) responseUserForm.Points = -100;
                        if (option.Points != null && responseUserForm.Points >= 0) responseUserForm.Points += option.Points.Value;
                    }
                    _context.Add(responseOption);
                    await _context.SaveChangesAsync();
                }
            }

            //return RedirectToAction("Index", "Home");
            return Json(new { result = "Redirect", url = Url.Action("Index", "Home") });
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
