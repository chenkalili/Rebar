namespace Rebar_project.Models
{
    public class Discount
    {
        public string _name { get; set; }
        public double _percentage { get; set; }

        public Discount(string name, double percentage)
        {
            _name = name;
            _percentage = percentage;
        }
    }

}
