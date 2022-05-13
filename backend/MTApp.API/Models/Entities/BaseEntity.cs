using System;

namespace MTApp.API.Models.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime DeletedDate { get; set; }
    }
}
