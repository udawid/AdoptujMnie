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
    public class AnnouncementsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnnouncementsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Announcements
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Announcements.Include(a => a.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Announcements
        public async Task<IActionResult> List(string Phrase, string Status, int PageNumber = 1)
        {
            var SelectedAnnouncements = _context.Announcements
               .OrderByDescending(a => a.AddedDate);

            if (!String.IsNullOrEmpty(Status))
            {
                SelectedAnnouncements = (IOrderedQueryable<Announcement>)SelectedAnnouncements
                .Where(a => a.Title == Status);
            }
            if (!String.IsNullOrEmpty(Phrase))
            {
                SelectedAnnouncements = (IOrderedQueryable<Announcement>)SelectedAnnouncements
                .Where(r => r.AnnouncementText.Contains(Phrase));
            }
            AnnouncementsViewModel AnnouncementsViewModel = new();
            AnnouncementsViewModel.AnnouncementsView = new AnnouncementsView();

            AnnouncementsViewModel.AnnouncementsView.TextCount = SelectedAnnouncements.Count();
            AnnouncementsViewModel.AnnouncementsView.PageNumber = PageNumber;

            AnnouncementsViewModel.AnnouncementsView.Status = Status;
            AnnouncementsViewModel.AnnouncementsView.Phrase = Phrase;

            AnnouncementsViewModel.Announcements = (IEnumerable<Announcement>?)await SelectedAnnouncements
                .Skip((PageNumber - 1) * AnnouncementsViewModel.AnnouncementsView.PageSize)
                .Take(AnnouncementsViewModel.AnnouncementsView.PageSize)
                .ToListAsync();

            var statusList = new List<SelectListItem>();
            statusList.Add(new SelectListItem("Zaginione", "Zaginione"));
            statusList.Add(new SelectListItem("Znaleziono", "Znaleziono"));

            ViewData["Status"] = new SelectList(statusList, "Value", "Text", Status);

            return View(AnnouncementsViewModel);
        }

        // GET: Announcements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Announcements == null)
            {
                return NotFound();
            }

            var announcement = await _context.Announcements
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.AnnouncementID == id);
            if (announcement == null)
            {
                return NotFound();
            }

            return View(announcement);
        }

        // GET: Announcements/Create
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(_context.AppUsers, "Id", "Id");
            return View();
        }

        // POST: Announcements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AnnouncementID,Title,AnnouncementText,Status,Type,Id,Photo,AddedDate")] Announcement announcement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(announcement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.AppUsers, "Id", "Id", announcement.Id);
            return View(announcement);
        }

        // GET: Announcements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Announcements == null)
            {
                return NotFound();
            }

            var announcement = await _context.Announcements.FindAsync(id);
            if (announcement == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.AppUsers, "Id", "Id", announcement.Id);
            return View(announcement);
        }

        // POST: Announcements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AnnouncementID,Title,AnnouncementText,Status,Type,Id,Photo,AddedDate")] Announcement announcement)
        {
            if (id != announcement.AnnouncementID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(announcement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnnouncementExists(announcement.AnnouncementID))
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
            ViewData["Id"] = new SelectList(_context.AppUsers, "Id", "Id", announcement.Id);
            return View(announcement);
        }

        // GET: Announcements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Announcements == null)
            {
                return NotFound();
            }

            var announcement = await _context.Announcements
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.AnnouncementID == id);
            if (announcement == null)
            {
                return NotFound();
            }

            return View(announcement);
        }

        // POST: Announcements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Announcements == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Announcements'  is null.");
            }
            var announcement = await _context.Announcements.FindAsync(id);
            if (announcement != null)
            {
                _context.Announcements.Remove(announcement);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnnouncementExists(int id)
        {
          return _context.Announcements.Any(e => e.AnnouncementID == id);
        }
    }
}
