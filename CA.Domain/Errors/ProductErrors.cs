namespace CA.Domain.Errors;

using CA.Domain.Shared;

public static class ProductErrors
{

    public static readonly Func<String, Error> Empty = FieldName => new(
        $"Product.Empty{FieldName}",
        $"The Product {FieldName} is empty, fill the {FieldName}");

    public static readonly Func<string, Error> AlreadyExist = ProductName => new Error(
        "Product.AlreadyExist",
        $"The Product with the name: '{ProductName}' already exist.");

    public static readonly Func<Guid, Error> NotFound = Id => new Error(
       "Product.NotFound",
       $"The Product with the Id: '{Id}' not found.");

}