namespace Rebar_project.Models
{
    public class CreateOrderModel
    {
        public List<ShakeOrder> ShakeOrder { get; set; }
        public Discount Discounts { get; set; }
        public string Name { get; set; }

        public CreateOrderModel() { }
    }
}
