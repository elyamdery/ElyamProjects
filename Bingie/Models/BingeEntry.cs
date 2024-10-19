using SQLite;

namespace Bingie.Models
{
    public class BingeEntry
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Duration { get; set; }
    }
}