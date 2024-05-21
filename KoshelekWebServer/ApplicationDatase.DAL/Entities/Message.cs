namespace DatabaseLevel.DAL.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public string? MessageText { get; set; }
        public DateTime? Date { get; set; } = DateTime.Now;
    }
}