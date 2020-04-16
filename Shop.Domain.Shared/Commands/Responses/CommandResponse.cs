using System;

namespace Shop.Domain.Shared.Commands.Responses
{
    public class CommandResponse
    {
        public CommandResponse(object data)
        {
            Date = DateTime.Now;
            Data = data;
        }

        public CommandResponse(int statusCode, string message, object data)
        {
            StatusCode = statusCode;
            Message = message;
            Date = DateTime.Now;
            Data = data;
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; private set; }
        public object Data { get; set; }
    }
}