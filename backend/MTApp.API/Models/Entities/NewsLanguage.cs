namespace MTApp.API.Models.Entities
{
    public class NewsLanguage : BaseEntity
    {
        public string Title { get; set; }
        public string Context { get; set; }
        public int NewsId { get; set; }
        public News News { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }
    }
}
