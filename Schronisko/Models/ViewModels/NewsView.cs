namespace Schronisko.Models.ViewModels
{
    public class NewsView
    {
        public NewsView(int pageSize = 5)
        {
            PageSize = pageSize;
        }

        public int TextCount { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int PageCount => (int)Math.Ceiling((decimal)TextCount / PageSize);

        public string? Phrase { get; set; }
    }
}
