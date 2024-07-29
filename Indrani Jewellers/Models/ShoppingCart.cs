namespace Indrani_Jewellers.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        public int UserId { get; set; }

        public int Count { get; set; }
        public string ProductName { get; set; }

        public ProductMasterModel Master { get; set; }



    }
}
