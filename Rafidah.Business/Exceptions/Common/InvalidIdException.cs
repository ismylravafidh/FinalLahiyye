using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafidah.Business.Exceptions.Common
{
    public class InvalidIdException : Exception , IBaseException
    {
        public InvalidIdException()
        {
            ErrorMessage = "Id menfi ola bilmez";
        }
        public InvalidIdException(string message) : base(message)
        {
            ErrorMessage = message;
        }
        public string ErrorMessage { get; }
    }
}
