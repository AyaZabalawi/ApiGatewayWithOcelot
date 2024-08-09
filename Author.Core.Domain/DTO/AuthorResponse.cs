using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Author.Core.Domain.Entities;

namespace Author.Core.Domain.DTO
{
    public class AuthorResponse
    {
        [Key]
        public Guid AuthorId { get; set; }

        public string AuthorName { get; set; }
    }

    public static class AuthorResponseExtensions
    {
        public static AuthorResponse ToAuthorResponse(this AuthorE author)
        {
            return new AuthorResponse
            {
                AuthorId = author.AuthorId,
                AuthorName = author.AuthorName
            };
        }

        public static List<AuthorResponse> ToAuthorResponseList(this List<AuthorE> authors)
        {
            return authors.Select(a => a.ToAuthorResponse()).ToList();
        }
    }
}
