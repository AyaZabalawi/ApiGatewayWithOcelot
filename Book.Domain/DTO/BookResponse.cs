using Book.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Book.Domain.DTO
{
    public class BookResponse
    {
        [Key]
        public Guid BookId { get; set; }
        public string BookTitle { get; set; }
    }

    public static class BookExtensions
    { 
        public static BookResponse ToBookResponse(this BookE book)
        {
            return new BookResponse()
            { 
                BookId = book.BookId,
                BookTitle = book.BookTitle
            };
        }

        public static List<BookResponse> ToBookResponseList(this List<BookE> books)
        {
           var bookResponseList = new List<BookResponse>();
           foreach(BookE book in books)
           {
                var bookResponse = book.ToBookResponse();
                bookResponseList.Add(bookResponse);
           }
            return bookResponseList;
        }
    }

}
