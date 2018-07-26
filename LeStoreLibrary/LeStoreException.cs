using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeStoreLibrary
{
    public enum ExceptionType
    {
        UNKNOWN = -1,
        LOST_SESSION = -2
    }
    public class LeStoreException : Exception
    {
        public LeStoreException(ExceptionType type)
        {
            Code = type;
        }
        public ExceptionType Code { get; set; }
    }
}
