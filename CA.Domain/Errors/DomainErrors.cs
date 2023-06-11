using CA.Domain.Shared;

namespace CA.Domain.Errors
{
    public static class DomainErrors
    {
        public static class Order
        {
            public static readonly Error EmptyNumber = new(
                "Order.EmptyNumber",
                "The Number is empty, fill the number");

            public static readonly Func<string, Error> AlreadyExist = number => new Error(
                "Order.AlreadyExist",
                $"The Order with the number: '{number}' already exist.");
        }
    }
}
