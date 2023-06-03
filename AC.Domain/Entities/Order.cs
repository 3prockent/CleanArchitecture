namespace AC.Domain.Entities
{
    public class Order : BaseEntity
    {
        public string ContactName { get; set; }
        public string Number { get; set; }
        public string Comment { get; set; }
        public decimal Amount { get; set; }
    }
}
