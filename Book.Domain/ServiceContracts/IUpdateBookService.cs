using Book.Domain.Common;
using Book.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Domain.ServiceContracts
{
    public interface IUpdateBookService
    {
        Task<Response> UpdateBook(BookUpdateRequest bookUpdateRequest);
    }
}
