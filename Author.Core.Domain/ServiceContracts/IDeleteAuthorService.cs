using Author.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Author.Core.Domain.ServiceContracts
{
    public interface IDeleteAuthorService
    {
        Task<Response> DeleteAuthor(Guid id);
    }
}
