﻿using Author.Core.Domain.Common;
using Author.Core.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Author.Core.Domain.ServiceContracts
{
   public interface IGetAuthorService
    {
        Task<Response>GetAllAuthors();
        Task<Response>GetAuthorById(Guid id);
    }
}