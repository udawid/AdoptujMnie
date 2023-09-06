namespace Schronisko.Models.ViewModels
{
    public class HomeDataVM
    {
        public IEnumerable<Announcement>? DisplayAnnouncements { get; set; }
        public IEnumerable<News>? DisplayNews { get; set; }
    }
}
