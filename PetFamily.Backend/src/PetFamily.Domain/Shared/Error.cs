using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFamily.Domain.Shared
{
    public record Error
    {
        private const string SEPARATOR  = "|";
        private Error(string code, string message, ErrorType type)
        {
            Code = code;
            Message = message;
            Type = type;
        }

        public string Code { get; }
        public string Message { get; }
        public ErrorType Type { get; }
        

        public string Serialize()
        {
            return string.Join(SEPARATOR, Code, Message, Type);
        }

        public static Error Deserialize(string serialized)
        {
            var parts = serialized.Split(SEPARATOR);
            if (parts.Length < 3) 
            {
                throw new ArgumentException("Некорректный формат для сериализации ошибки");
            }

            if (!Enum.TryParse<ErrorType>(parts[2], out var type))
            {
                throw new ArgumentException("Некорректный тип ошибки");
            }

            return new Error(parts[0], parts[1], type);
        }

        public static Error Validation(string code, string message) => new(code, message, ErrorType.Validation);
        public static Error NotFound(string code, string message) => new(code, message, ErrorType.NotFound);
        public static Error Failure(string code, string message) => new(code, message, ErrorType.Failure);
        public static Error Conflict(string code, string message) => new(code, message, ErrorType.Conflict);
    }
    public enum ErrorType
    {
        Validation,
        NotFound,
        Failure,
        Conflict
    }
}
