using Author.Core.Domain.DTO;
using Author.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Author.Core.Domain.RepositoryContracts
{
    public interface IAuthorRepository
    {
        Task<List<AuthorE>> GetAuthors();
        Task<AuthorE> GetAuthorById(Guid id);
        Task<AuthorE> AddAuthor(AuthorE addedAuthor);
        Task<AuthorE> UpdateAuthor(AuthorE updatedAuthor);
        Task<bool> DeleteAuthor(Guid id);
    }
}
