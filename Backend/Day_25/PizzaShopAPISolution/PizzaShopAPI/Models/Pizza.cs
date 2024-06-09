namespace PizzaShopAPI.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool InStock { get; set; }
        public int Price { get; set; }
        public string ImageUrl { get; set; }


    }
}
