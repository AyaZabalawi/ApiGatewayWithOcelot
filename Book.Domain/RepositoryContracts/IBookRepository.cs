using Book.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Domain.RepositoryContracts
{
    public interface IBookRepository 
    {
        Task<List<BookE>> GetAllBooks();
        Task<BookE> GetBookById(Guid id);
        Task<BookE> AddBook(BookE book);
        Task<BookE> UpdateBook(BookE book);
        Task<bool> DeleteBook (Guid id);
    }
}
