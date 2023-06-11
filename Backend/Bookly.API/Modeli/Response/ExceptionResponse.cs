﻿namespace Bookly.API.Modeli.Response
{
    public class ExceptionResponse
    {
        public string Message { get; set; }
        public string? StackTrace { get; set; }

        public ExceptionResponse(Exception exception)
        {
            Message = exception.Message;
        }

        public ExceptionResponse(Exception exception, string stackTrace)
        {
            Message = exception.Message;
            StackTrace = stackTrace;
        }
    }
}
