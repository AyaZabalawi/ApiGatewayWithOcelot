using Author.Core.Domain.Common;
using Author.Core.Domain.DTO;
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
    public class GetAuthorService : IGetAuthorService
    {
        private IAuthorRepository _authorRepository;
        private readonly ILogger <GetAuthorService> _log;

        public async Task<Response> GetAllAuthors()
        {
            try
            {
                _log.LogInformation("Getting list of all authors from database");
                var authors = await _authorRepository.GetAuthors();
                authors.ToAuthorResponseList();
                var response = new Response()
                {
                    Succeeded = true,
                    Errors = null,
                    Data = authors
                };
                _log.LogInformation("Retrieved list of authors from database");
                return response;
            }
            catch(Exception ex)
            {
                _log.LogError($"Error executing {ex.Message}");
                return new Response();
            }
        }

        public async Task<Response> GetAuthorById(Guid id)
        {
            try
            {
                _log.LogInformation($"Retrieving author {id} from database");
                var searchedAuthor = await _authorRepository.GetAuthorById(id);
                if (searchedAuthor == null)
                {
                    _log.LogWarning($"Author {id} not found in the database");
                }
                var searchedAuthorResponse = searchedAuthor.ToAuthorResponse();
                var response = new Response()
                {
                    Succeeded = true,
                    Errors = null,
                    Data = searchedAuthorResponse
                };
                return response;
            }
            catch(Exception ex)
            {
                _log.LogError($"Error loading {ex.Message}");
                return new Response();
            }   
        }
    }
}
