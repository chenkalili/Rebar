namespace Rebar_project.Models
{
    public class Discount
    {
        public string Name { get; set; }
        public double Percentage { get; set; }

        public Discount(string name, double percentage)
        {
            Name = name;
            Percentage = percentage;
        }
    }

}
