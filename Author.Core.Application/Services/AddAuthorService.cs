using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Author.Core.Domain.Common;
using Author.Core.Domain.DTO;
using Author.Core.Domain.RepositoryContracts;
using Author.Core.Domain.ServiceContracts;
using Microsoft.Extensions.Logging;

namespace Author.Core.Application.Services
{
    public class AddAuthorService : IAddAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly ILogger<AddAuthorService> _log;

        public AddAuthorService(IAuthorRepository authorRepository, ILogger<AddAuthorService> log)
        {
            _authorRepository = authorRepository;
            _log = log;
        }

        public async Task<Response> AddAuthor(AuthorAddRequest authorAddRequest)
        {
            try
            {
                var author = authorAddRequest.ToAuthor();
                author.AuthorId = Guid.NewGuid();

                _log.LogInformation($"Adding author {author.AuthorId} to the database");

                var addedAuthor = await _authorRepository.AddAuthor(author);
                var addedAuthorResponse = addedAuthor.ToAuthorResponse();

                var response = new Response()
                {
                    Succeeded = true,
                    Errors = null,
                    Data = addedAuthorResponse
                };
                _log.LogInformation($"Author {addedAuthor.AuthorId} successfully added to the database");
                return response;
            }
            catch(Exception ex)
            {
                _log.LogError($"Error while executing {ex.Message}");
                return new Response();
            }
        }
    }
}
