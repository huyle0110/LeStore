using LeStoreLibrary.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeStoreLibrary
{
    public class ResponseModel
    {
        public ResponseType Code { get; set; }
        public object ResponseData { get; set; }
        public string Message { get; set; }
    }

    public class ResponseFactory
    {
        public static ResponseModel getInstace(LeStoreException ex)
        {
            ResponseType Code = ResponseType.UNKNOWN;
            string Message = string.Empty;
            switch (ex.Code)
            {
                case ExceptionType.LOST_SESSION:
                    Message = "Lost Session";
                    Code = ResponseType.LOST_SESSION;
                    break;
                case ExceptionType.UNKNOWN:
                    Message = "Has error when processing";
                    Code = ResponseType.UNKNOWN;
                    break;
            }
            return new ResponseModel()
            {
                Code = Code,
                Message = Message,
            };
        }

        public static ResponseModel getInstace(ResponseType type)
        {
            return new ResponseModel()
            {
                Code = type,
                Message = string.Empty,
                ResponseData = null
            };
        }
    }
}
