﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Models
{
    public class ResponseModel<T>
    {
        public bool Status { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public ResponseModel(bool status = true, int statusCode = 0, string message = null, T data = default)
        {
            Status = status;
            StatusCode = statusCode;
            Message = message;
            Data = data;
        }
    }
}
