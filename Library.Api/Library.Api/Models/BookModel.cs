namespace Library.Api.Models
{
    public class BookModel
    {
        public BookModel()
        {
        }

        public long ID { get; set; }

        public string Name { get; set; }

        public string Genre { get; set; }

        public string Author { get; set; }

        public string PublishedYear { get; set; }
    }
}
