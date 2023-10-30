namespace Rebar_project.models
{
    class Shake
    {
        private static int PersonalID = 0;
        public int _shakeID { get; }
        public string _name { get; set; }
        public string _description { get; set; }
        public double _priceLarge { get; set; }
        public double _priceMedium { get; set; }
        public double _priceSmall { get; set; }

    public Shake(string name, string description, double priceLarge, double priceMedium, double priceSmall)
        {
            _shakeID = ++PersonalID;
            _name = name;
            _description = description;
            _priceLarge = priceLarge;
            _priceMedium = priceMedium;
            _priceSmall = priceSmall;
        }
    }
}
