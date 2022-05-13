using System.Collections.Generic;

namespace MTApp.API.Models.Entities
{
    public class News : BaseEntity
    {
        public ICollection<NewsLanguage> NewsLanguages { get; set; }
    }
}
