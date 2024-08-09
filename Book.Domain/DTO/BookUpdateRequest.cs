using Book.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Domain.DTO
{
    public class BookUpdateRequest
    {
        public string BookTitle { get; set; }

        public BookE ToBook()
        {
            return new BookE() {  BookTitle = BookTitle };
        }
    }
}
