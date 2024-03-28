namespace Bookeventapplication.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Rating { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }

        public string Description { get; set; }
    }
}
