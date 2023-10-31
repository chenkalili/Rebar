using Rebar_project.models;

namespace Rebar_project.Models
{
    public class ShakeOrder
    {
        public Guid ShakeID { get; set; }
        public string ShakeName { get; set; }
        public double Price { get; set; }
        public ChooseSize Size { get; set; }

        public ShakeOrder(string shakeName,double price, ChooseSize size)
        {
            ShakeID = Guid.NewGuid();
            ShakeName = shakeName;
            Price = price;
            Size = size;
        }
        public enum ChooseSize
        {
            L,
            M,
            S,
        }
    }
}
