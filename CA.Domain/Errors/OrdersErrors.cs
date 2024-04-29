namespace CA.Domain.Errors;

using CA.Domain.Shared;


public static class OrderErrors
{
    public static readonly Error EmptyNumber = new(
        "Order.EmptyNumber",
        "The Number is empty, fill the number");

    public static readonly Func<string, Error> AlreadyExist = number => new Error(
        "Order.AlreadyExist",
        $"The Order with the number: '{number}' already exist.");

    public static readonly Func<Guid, Error> NotFound = Id => new Error(
       "Order.NotFound",
       $"The Order with the Id: '{Id}' not found.");

    public static readonly Func<string, Error> NotFoundByUser = username => new Error(
       "Order.NotFound",
       $"The Order with the username: '{username}' not found.");

}
