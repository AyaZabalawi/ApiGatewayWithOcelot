using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Author.Core.Domain.Entities
{
    public class AuthorE
    {
        [Key]
        public Guid AuthorId { get; set; }
        public string AuthorName { get; set; }
    }
}
