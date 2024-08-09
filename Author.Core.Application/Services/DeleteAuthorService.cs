using Author.Core.Domain.Common;
using Author.Core.Domain.RepositoryContracts;
using Author.Core.Domain.ServiceContracts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Author.Core.Application.Services
{
    public class DeleteAuthorService : IDeleteAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly ILogger<DeleteAuthorService> _log;

        public DeleteAuthorService(IAuthorRepository authorRepository, ILogger<DeleteAuthorService> log)
        {
            _authorRepository = authorRepository;
            _log = log;
        }

        public async Task<Response> DeleteAuthor(Guid id)
        {
            try
            {
                _log.LogInformation($"Deleting author {id} from the database");
                var isDeleted = await _authorRepository.DeleteAuthor(id);
                if (!isDeleted)
                {
                    _log.LogWarning($"Author {id} was not found in the database");
                }

                _log.LogInformation($"Author {id} deleted successfully");
                var response = new Response()
                {
                    Succeeded = true,
                    Errors = null,
                    Data = isDeleted
                };

                return response;
            }
            catch (Exception ex)
            {
                _log.LogError($"Error while executing {ex.Message}");
                return new Response();
            }
        }
    }
}
