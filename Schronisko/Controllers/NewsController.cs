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

namespace Schronisko.Controllers
{
    public class NewsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NewsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: News
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Newses.Include(n => n.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: News
        public async Task<IActionResult> List(string Phrase, int PageNumber = 1)
        {
            var SelectedNews = _context.Newses
               .OrderByDescending(n => n.AddedDate);
          
            if (!String.IsNullOrEmpty(Phrase))
            {
                SelectedNews = (IOrderedQueryable<News>)SelectedNews
                .Where(r => r.NewsText.Contains(Phrase));
            }
            NewsViewModel NewsViewModel = new();
            NewsViewModel.NewsView = new NewsView();

            NewsViewModel.NewsView.TextCount = SelectedNews.Count();
            NewsViewModel.NewsView.PageNumber = PageNumber;

            NewsViewModel.NewsView.Phrase = Phrase;

            NewsViewModel.News = (IEnumerable<News>?)await SelectedNews
                .Skip((PageNumber - 1) * NewsViewModel.NewsView.PageSize)
                .Take(NewsViewModel.NewsView.PageSize)
                .ToListAsync();

            return View(NewsViewModel);
        }

        // GET: News/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Newses == null)
            {
                return NotFound();
            }

            var news = await _context.Newses
                .Include(n => n.User)
                .FirstOrDefaultAsync(m => m.NewsID == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        // GET: News/Create
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(_context.AppUsers, "Id", "Id");
            return View();
        }

        // POST: News/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NewsID,Title,NewsText,Status,Id,Photo,AddedDate")] News news)
        {
            if (ModelState.IsValid)
            {
                if (!NewsNameExists(news.Title))
                {
                    _context.Add(news);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    ViewBag.ErrorMessage = "Aktualność o takiej nazwie już istnieje!";
                    return View("Create");
                }

            }

            return View(news);
        }

        // GET: News/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Newses == null)
            {
                return NotFound();
            }

            var news = await _context.Newses.FindAsync(id);
            if (news == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.AppUsers, "Id", "Id", news.Id);
            return View(news);
        }

        // POST: News/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NewsID,Title,NewsText,Status,Id,Photo,AddedDate")] News news)
        {
            if (id != news.NewsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(news);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsExists(news.NewsID))
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
            ViewData["Id"] = new SelectList(_context.AppUsers, "Id", "Id", news.Id);
            return View(news);
        }

        // GET: News/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Newses == null)
            {
                return NotFound();
            }

            var news = await _context.Newses
                .Include(n => n.User)
                .FirstOrDefaultAsync(m => m.NewsID == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        // POST: News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Newses == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Newses'  is null.");
            }
            var news = await _context.Newses.FindAsync(id);
            if (news != null)
            {
                _context.Newses.Remove(news);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewsExists(int id)
        {
            return _context.Newses.Any(e => e.NewsID == id);
        }

        private bool NewsNameExists(string? Title)
        {
            return (_context.Newses?.Any(e => e.Title == Title)).GetValueOrDefault();
        }
    }
}
