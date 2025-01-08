namespace PetFamily.Domain.Shared
{
    public static class Errors
    {
        public static class General
        {
            public static Error ValueIsInvalid(string? name = null)
            {
                string label = name ?? "Value";
                return Error.Validation("value.is.invalid", $"{label} is invalid");
            }

            public static Error NotFound(Guid? id = null)
            {
                string info = id == null ? "" : $"for id '{id}'";
                return Error.NotFound("record.not.found", $"Record not found {info}");
            }

            public static Error ValueIsRequired(string? name = null)
            {
                string label =  name ?? "Value";
                return Error.Validation("value.is.required", $"{label} is required");
            }

            public static Error ValueIsIncorrect(string? name = null)
            {
                string label = name ?? "Value";
                return Error.Validation("value.is.incorrect", $"{label} is incorrect");
            }

            public static Error ValueAlreadyExist(string? name = null, string? collectionName = null)
            {
                string labelName = name ?? "Value";
                string labelCollection = collectionName ?? "collection";
                return Error.Conflict("value.is.already.exist", $"The {labelName} is already exist in {labelCollection}");
            }
        }
    }
}
