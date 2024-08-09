using Author.Core.Domain.Entities;
using Author.Core.Domain.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Author.Infrastucture.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<AuthorRepository> _log;
        public AuthorRepository(ApplicationDbContext db, ILogger<AuthorRepository> logger)
        {
            _db = db;
            _log = logger;
        }
        public async Task<AuthorE> AddAuthor(AuthorE addedAuthor)
        {
            _log.LogInformation("Adding author to database");
            _db.Authors.Add(addedAuthor);
            await _db.SaveChangesAsync();
            _log.LogInformation("Author added to database");
            return addedAuthor;
        }

        public async Task<bool> DeleteAuthor(Guid id)
        {
            _log.LogInformation($"Deleting author {id} from database");
            var toDelete = await _db.Authors.FindAsync(id);
            if(toDelete==null)
            {
                _log.LogWarning($"Author {id} not found in database");
                return false;
            }
            _db.Authors.Remove(_db.Authors.Find(id));
            await _db.SaveChangesAsync();
            _log.LogInformation($"Author {id} deleted from database");
            return true;
        }

        public async Task<AuthorE?> GetAuthorById(Guid id)
        {
            _log.LogInformation($"Retrieving author {id} from database");
            var searchedAuthor = await _db.Authors.FindAsync(id);
            if(searchedAuthor==null)
            {
                _log.LogWarning($"Author {id} not found in database");
            }
                _log.LogInformation($"Author {id} retrieved from database");
                return searchedAuthor;
        }

        public async Task<List<AuthorE>> GetAuthors()
        {
            _log.LogInformation("Retrieving all authors from database");
            var authors = await _db.Authors.ToListAsync();
            _log.LogInformation($"Retrieved {authors.Count} authors from database");
            return authors;
        }

        public async Task<AuthorE> UpdateAuthor(AuthorE updatedAuthor)
        {
            var authorID = updatedAuthor.AuthorId;
            _log.LogInformation($"Updating author {authorID} in database");
            var existing = await _db.Authors.FindAsync(authorID);
            if (existing == null)
            {
                _log.LogWarning($"Author {authorID} not found in database");
                return updatedAuthor;
            }
            existing.AuthorId = authorID;
            existing.AuthorName = updatedAuthor.AuthorName;
            _log.LogInformation($"Updated author {authorID}");
            return existing;
        }
    }
}
