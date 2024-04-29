namespace CA.Domain.Errors;

using CA.Domain.Shared;

public static class CartErrors
{

    public static readonly Func<Error> Empty = () => new(
        $"Cart.Empty", 
        $"The Cart is empty");

}