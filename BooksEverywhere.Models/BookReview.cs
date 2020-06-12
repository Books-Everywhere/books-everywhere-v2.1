namespace BooksEverywhere.Models
{
    public class BookReview
    {
        public virtual Book Book { get; set; }
        public virtual User User { get; set; }
        public virtual string Review { get; set; }
    }
}
