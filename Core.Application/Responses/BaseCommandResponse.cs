using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Responses
{
    public class BaseCommandResponse
    {
        public BaseCommandResponse()
        {
            
        }
        public BaseCommandResponse(int id, bool success, string message, List<string> errors)
        {
            Id = id;
            Success = success;
            Message = message;
            Errors = errors;
        }

        public int Id { get; set; }
        public bool Success { get; set; }
        public string? Message { get; set; }
        public List<string>? Errors { get; set; }
    }
}
