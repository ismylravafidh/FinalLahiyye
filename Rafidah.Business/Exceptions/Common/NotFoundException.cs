using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafidah.Business.Exceptions.Common
{
    public class NotFoundException : Exception, IBaseException
    {
        public string ErrorMessage { get; }
        public NotFoundException()
        {
            ErrorMessage ="Not Found";
        }
        public NotFoundException(string? message) : base(message)
        {
            ErrorMessage = message;
        }
    }
}
