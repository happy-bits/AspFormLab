using AspFormLab.Models;

namespace AspFormLab.Services;

public class DataService
{
    private readonly List<Author> _authors;
    private readonly List<Book> _books;
    private readonly List<User> _users;
    private readonly List<Review> _reviews;

    public DataService()
    {
        // Create authors
        _authors = new List<Author>
        {
            new Author 
            { 
                Id = 1,
                Name = "J.K. Rowling",
                BirthDate = new DateTime(1965, 7, 31)
            },
            new Author 
            { 
                Id = 2,
                Name = "George R.R. Martin",
                BirthDate = new DateTime(1948, 9, 20)
            }
        };

        // Create users
        _users = new List<User>
        {
            new User 
            { 
                Id = 1,
                Username = "bookworm",
                Email = "bookworm@example.com"
            },
            new User 
            { 
                Id = 2,
                Username = "readinglover",
                Email = "reader@example.com"
            }
        };

        // Create books
        _books = new List<Book>
        {
            new Book 
            { 
                Id = 1,
                Title = "Harry Potter and the Philosopher's Stone",
                ISBN = "978-0747532699",
                PublishedDate = new DateTime(1997, 6, 26),
                Author = _authors[0]
            },
            new Book 
            { 
                Id = 2,
                Title = "A Game of Thrones",
                ISBN = "978-0553103540",
                PublishedDate = new DateTime(1996, 8, 1),
                Author = _authors[1]
            }
        };

        // Add books to authors
        _authors[0].Books.Add(_books[0]);
        _authors[1].Books.Add(_books[1]);

        // Create reviews
        _reviews = new List<Review>
        {
            new Review 
            { 
                Id = 1,
                Content = "Amazing book, couldn't put it down!",
                Rating = 5,
                CreatedDate = DateTime.Now.AddDays(-30),
                User = _users[0],
                Book = _books[0]
            },
            new Review 
            { 
                Id = 2,
                Content = "A masterpiece of fantasy literature",
                Rating = 5,
                CreatedDate = DateTime.Now.AddDays(-15),
                User = _users[1],
                Book = _books[1]
            }
        };

        // Add reviews to books and users
        _books[0].Reviews.Add(_reviews[0]);
        _books[1].Reviews.Add(_reviews[1]);
        _users[0].Reviews.Add(_reviews[0]);
        _users[1].Reviews.Add(_reviews[1]);
    }

    // Get all authors
    public IEnumerable<Author> GetAllAuthors() => _authors;

    // Get specific author by ID
    public Author? GetAuthor(int id) => _authors.FirstOrDefault(a => a.Id == id);

    // Get all books
    public IEnumerable<Book> GetAllBooks() => _books;

    // Get all books with reviews
    public IEnumerable<Book> GetAllBooksWithReviews() => _books.Where(b => b.Reviews.Any());

    // Get specific book by ID
    public Book? GetBook(int id) => _books.FirstOrDefault(b => b.Id == id);

    // Get all reviews
    public IEnumerable<Review> GetAllReviews() => _reviews;

    // Get reviews for specific book
    public IEnumerable<Review> GetReviewsForBook(int bookId) => 
        _reviews.Where(r => r.Book?.Id == bookId);

    // Get all users
    public IEnumerable<User> GetAllUsers() => _users;

    // Get specific user by ID
    public User? GetUser(int id) => _users.FirstOrDefault(u => u.Id == id);

    // Get reviews by user
    public IEnumerable<Review> GetReviewsByUser(int userId) => 
        _reviews.Where(r => r.User?.Id == userId);
} 