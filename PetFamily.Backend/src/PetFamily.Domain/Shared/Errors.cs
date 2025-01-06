namespace PetFamily.Domain.Shared
{
    public static class Errors
    {
        public static class General
        {
            public static Error ValueIsInvalid(string? name = null)
            {
                string label = name ?? "value";
                return Error.Validation("value.is.invalid", $"{label} is invalid");
            }

            public static Error NotFound(Guid? id = null)
            {
                string info = id == null ? "value" : $"for id '{id}'";
                return Error.NotFound("record.not.found", $"Record not found {info}");
            }

            public static Error ValueIsRequired(string? name = null)
            {
                string label =  name.ToUpper() ?? "Value";
                return Error.Validation("value.is.required", $"{label} is required");
            }
        }
    }
}
