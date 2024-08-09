using Azure;
using Book.Domain.DTO;
using Book.Domain.RepositoryContracts;
using Book.Domain.ServiceContracts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Application.Services
{
    public class AddBookService : IAddBookService
    {
        private readonly IBookRepository _repository;
        private readonly ILogger<AddBookService> _logger;

        public AddBookService(IBookRepository repository, ILogger<AddBookService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<Response> AddBook(BookAddRequest bookAddRequest)
        {
            try
            {
                var book = bookAddRequest.ToBook();
                book.BookId = Guid.NewGuid();

                var addedBook = await _repository.AddBook(book);
                var addedBookResponse = addedBook.ToBookResponse();

                var response = new Response()
                { 
                    Succeeded = true,
                    Errors = null,
                    Data = addedBookResponse
                };


                _logger.LogInformation($"Book {book.BookId} added successfully");
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $" Error while executing {ex.Message}");
                return new Response();
            }
        }
    }
}
