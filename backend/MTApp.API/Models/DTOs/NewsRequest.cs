namespace MTApp.API.Models.DTOs
{
    public class NewsRequest
    {
        public int Id { get; set; }
        public NewsLanguageDto NewsLanguages { get; set; }
    }
}
