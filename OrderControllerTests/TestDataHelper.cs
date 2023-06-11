namespace Tests
{
    internal static class TestDataHelper
    {
        public static List<Order> GetFakeOrderList()
        {
            return new List<Order>()
            {
                new Order
                {
                        Number = "2",
                        ContactName = "Vlad",
                        Comment = "123 delivery",
                        Amount = 100.00M
                },
                new Order
                {
                    Number = "3",
                    ContactName = "Alex",
                    Comment = "222 delivery",
                    Amount = 200.00M
                }
            };
        }
    }
}
