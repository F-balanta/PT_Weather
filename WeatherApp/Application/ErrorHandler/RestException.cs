﻿using System;
using System.Net;

namespace Application.ErrorHandler
{
    public class RestException : Exception
    {
        public HttpStatusCode Code { get;  }
        public object Errors { get;  }

        public RestException(HttpStatusCode code, object errors = null)
        {
            Code = code;
            Errors = errors;
        }
    }
}
