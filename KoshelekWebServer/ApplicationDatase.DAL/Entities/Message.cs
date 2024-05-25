using System.ComponentModel.DataAnnotations;

namespace DatabaseLevel.DAL.Entities
{
    public class Message
    {
        public int Id { get; set; }
        [MaxLength(128)]
        public string? MessageText { get; set; }
        public DateTime Date { get; set; }
    }
}