using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Models;

namespace Utilities.Helpers
{
    public static class ResponseHelper
    {
        public static ResponseModel<T> Success<T>(T data, string message = "İşlem başarılı.")
        {
            return new ResponseModel<T>(true, 0, message, data);
        }

        public static ResponseModel<T> Fail<T>(T data, string message = "İşlem başarısız.")
        {
            return new ResponseModel<T>(false, -1, message, data);
        }

        public static ResponseModel<object> Error(string message = "Bir hata oluştu.", int statusCode = -1)
        {
            return new ResponseModel<object>(false, statusCode, message);
        }
    }
}
