using HBCase.Common.Entities;

namespace HBCase.Entity
{
    public class Order : IEntity
    {
        public int OrderId { get; set; }
        public string ProdcutCode { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double TotalPrice { get; set; }
    }
}
