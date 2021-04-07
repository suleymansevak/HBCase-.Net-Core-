using HBCase.Common.Entities;

namespace HBCase.Entity
{
    public class Product : IEntity
    {
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public double CurrentPrice { get; set; }
    }
}
