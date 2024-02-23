using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafidah.Business.Exceptions.Common
{
    public class SaveChangesException : Exception, IBaseException
    {
        public SaveChangesException()
        {
            ErrorMessage = "The changes have not been saved.";
        }

        public SaveChangesException(string? message) : base(message)
        {
            ErrorMessage = message;
        }

        public string ErrorMessage { get; }
    }
}
