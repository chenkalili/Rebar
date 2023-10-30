namespace Rebar_project.Models
{
    public class ShakeForOrder
    {
        public Guid _shakeID { get; set; }
        public string _shakeName { get; set; }
        public string _description { get; set; }
        public double _price { get; set; }
        public Size _size { get; set; }

        public ShakeForOrder(string shakeName, string description, double price, int shakeID, Size size)
        {
            _shakeID = Guid.NewGuid();
            _shakeName = shakeName;
            _description = description;
            _price = price;
            _size = size;
        }
        public enum Size
        {
            L,
            M,
            S,
        }
    }
}
