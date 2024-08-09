using Book.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Domain.ServiceContracts
{
    public interface IGetBookService
    {
        Task<Response> GetAllBooks();
        Task<Response> GetBookById (Guid id);
    }
}
