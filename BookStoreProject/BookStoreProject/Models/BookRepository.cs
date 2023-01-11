namespace BookStoreProject.Models
{
    public class BookRepository
    {
        private static List<Book> _books = new List<Book>()
        {
            new () { Id = 1, Author = "Maksim Gorki", Name = "Ekmeğimi Kazanırken", Year = 1916 },
            new () { Id = 2, Author = "Fyodor Dostoyevski", Name = "Suç ve Ceza", Year = 1866 }
        };

        public List<Book> GetAll() => _books;
        public void Add(Book newBook)=>_books.Add(newBook);
        public void Remove(int id)
        {
            var hasBook = _books.FirstOrDefault(x=>x.Id == id);
            if (hasBook==null)
            {
                throw new Exception("There is no product with this ID.");
            }
            _books.Remove(hasBook);
        }
        public void Update(Book updateBook)
        {
            var hasBook = _books.FirstOrDefault(x => x.Id == updateBook.Id);
            if (hasBook == null)
            {
                throw new Exception("There is no product with this ID.");
            }
            hasBook.Author = updateBook.Author;
            hasBook.Name = updateBook.Name;
            hasBook.Year = updateBook.Year;

            var index = _books.FindIndex(x => x.Id == updateBook.Id);
            _books[index] = hasBook;
        }
    }
}
