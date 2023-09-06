namespace Schronisko.Models.ViewModels
{
    public class NewsViewModel
    {
        public IEnumerable<News>? News { get; set; }
        public NewsView? NewsView { get; set; }
    }
}
