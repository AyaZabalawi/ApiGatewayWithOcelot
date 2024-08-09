using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Book.Domain.Entities;
using Book.Domain.RepositoryContracts;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace Book.Infrastructure.Repositories
{

    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<BookRepository> _logger;
        public BookRepository(ApplicationDbContext db, ILogger<BookRepository> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task<BookE> AddBook(BookE book)
        {
            _db.Books.Add(book);
            await _db.SaveChangesAsync();
            _logger.LogInformation($"Book {book.BookId} added successfully");
            return book;
        }

        public async Task<bool> DeleteBook(Guid id)
        {
            var book = _db.Books.Find(id);

            if (book == null)
            {
                _logger.LogWarning($"Book with id {id} not found");
                return false;
            }

            _db.Books.Remove(book);
            await _db.SaveChangesAsync();
            _logger.LogInformation($"Book {id} deleted successfully");
            return true;

        }

        public async Task<List<BookE>> GetAllBooks()
        {
            var books = await _db.Books.ToListAsync();
            _logger.LogInformation("All books retrieved successfully");
            return books;
        }

        public async Task<BookE?> GetBookById(Guid ID)
        {
            var book = _db.Books.Find(ID);
            if (book == null)
            {
                _logger.LogWarning($"Book {ID} does not exist");
            }
            _logger.LogInformation($"Book {ID} retrieved successfully");
            return book;
        }

        public async Task<BookE> UpdateBook(BookE updated)
        {
            var searchid = updated.BookId;
            var book = _db.Books.Find(searchid);
            if (book == null)
            {
                _logger.LogWarning($"Book {searchid} does not exist");
                return updated;
            }

            book.BookId = searchid;
            book.BookTitle = updated.BookTitle;

            await _db.SaveChangesAsync();
            _logger.LogInformation($"Book {searchid} updated successfully");
            return book;
        }
    }
}