using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Domain.Entities
{
    public class BookE
    {
        [Key]
        public Guid BookId { get; set; }
        public string BookTitle { get; set; }
    }
}
