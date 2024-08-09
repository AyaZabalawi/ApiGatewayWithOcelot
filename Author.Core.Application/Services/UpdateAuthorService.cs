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
    public class UpdateAuthorService : IUpdateAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly ILogger <UpdateAuthorService> _log;

        public UpdateAuthorService(IAuthorRepository authorRepository, ILogger<UpdateAuthorService> log)
        {
            _authorRepository = authorRepository;
            _log = log;
        }

        public async Task<Response> UpdateAuthor(AuthorUpdateRequest authorUpdateRequest)
        {
            try
            {
                var requestedAuthor = authorUpdateRequest.ToAuthor();
                var requestedAuthorId = requestedAuthor.AuthorId;
                var searchAuthor = await _authorRepository.GetAuthorById(requestedAuthorId);
                _log.LogInformation($"Updating author {searchAuthor.AuthorId}");
                if (searchAuthor == null)
                {
                    _log.LogWarning($"Author {requestedAuthorId} not found in the database");
                }
                var updatedAuthor = await _authorRepository.UpdateAuthor(requestedAuthor);
                _log.LogInformation($"Author {searchAuthor.AuthorId} updated successfully");
                var updatedAuthorResponse = updatedAuthor.ToAuthorResponse();
                var response = new Response()
                {
                    Succeeded = true,
                    Errors = null,
                    Data = updatedAuthorResponse
                };
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
