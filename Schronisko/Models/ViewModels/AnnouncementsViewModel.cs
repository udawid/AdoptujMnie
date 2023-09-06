namespace Schronisko.Models.ViewModels
{
    public class AnnouncementsViewModel
    {
        public IEnumerable<Announcement>? Announcements { get; set; }
        public AnnouncementsView? AnnouncementsView { get; set; }
    }
}