﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Author.Core.Domain.Entities;

namespace Author.Core.Domain.DTO
{
    public class AuthorAddRequest
    {
        public string AuthorName { get; set; }

        public AuthorE ToAuthor()
        {
            return new AuthorE{AuthorName = this.AuthorName};
        }
    }
}
