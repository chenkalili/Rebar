using Rebar_project.models;

namespace Rebar_project.Models
{
    class Menu
    {
        private List<Shake> shakes = new List<Shake>();

        public void AddShake(Shake shake)
        {
            shakes.Add(shake);
            Console.WriteLine($"Shake '{shake._name}' was successfully added to the menu.");
        }
    }
}
