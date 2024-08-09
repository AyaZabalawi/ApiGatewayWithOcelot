using Author.Core.Domain.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Author.Core.Domain.Common;
using Author.Core.Domain.DTO;

namespace AuthorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAddAuthorService _add;
        private readonly IDeleteAuthorService _delete;
        private readonly IGetAuthorService _get;    
        private readonly IUpdateAuthorService _update;
        private readonly ILogger<AuthorController> _log;

        public AuthorController(IAddAuthorService add, IDeleteAuthorService delete, IGetAuthorService get, IUpdateAuthorService update)
        {
            _add = add;
            _delete = delete;
            _get = get;
            _update = update;
        }

        [HttpGet("GetAllAuthors")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task <Response> GetAllAuthors()
        {
            return await _get.GetAllAuthors();
        }

        [HttpGet("GetAuthorById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task <Response> GetAuthorById(Guid id)
        {
            return await _get.GetAuthorById(id);
        }

        [HttpPost("AddAuthor")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task <Response> AddAuthor([FromBody] AuthorAddRequest addAuthorRequest)
        {
            return await _add.AddAuthor(addAuthorRequest);
        }

        [HttpPost("DeleteAuthor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task <Response> DeleteAuthor(Guid id)
        {
            return await _delete.DeleteAuthor(id);
        }

        [HttpPut("UpdateAuthor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task <Response> UpdateAuthor(AuthorUpdateRequest updateAuthorRequest)
        {
            return await _update.UpdateAuthor(updateAuthorRequest);
        }
    }
}
