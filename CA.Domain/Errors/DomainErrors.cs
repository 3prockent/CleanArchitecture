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

            public static readonly Func<Guid, Error> NotFound = Id => new Error(
               "Order.NotFound",
               $"The Order with the Id: '{Id}' not found.");

        }

        public static class General
        {
            public static readonly string SuccessWithError = "Result cannot be successful with Error";
            public static readonly string FailedWithoutError = "Result cannot be failed without Error";
        }
    }
}
