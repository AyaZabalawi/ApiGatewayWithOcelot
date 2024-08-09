using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Author.Core.Domain.Common
{
    public class Response
    {
        public bool Succeeded { get; set; }
        public string[] Errors { get; set; }
        public object Data { get; set; }
    }
}
