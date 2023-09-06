namespace Schronisko.Models.ViewModels
{
    public class AnnouncementsView
    {
        public AnnouncementsView(int pageSize = 5)
        {
            PageSize = pageSize;
        }

        public int TextCount { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int PageCount => (int)Math.Ceiling((decimal)TextCount / PageSize);

        public string? Status { get; set; }
        public string? Phrase { get; set; }
    }
}
