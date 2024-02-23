using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafidah.Business.Exceptions.Common
{
    public class NullException:Exception,IBaseException
    {
        public string ErrorMessage { get; }
        public NullException()
        {
            ErrorMessage = "Category can not null.";
        }
        public NullException(string? message) : base(message)
        {
            ErrorMessage = message;
        }
    }
}
