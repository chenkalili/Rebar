using Rebar_project.models;

namespace Rebar_project.Models
{
    class Menu
    {
        private static List<ShakeMenu> _shakes = new List<ShakeMenu>();

        public void AddShake(ShakeMenu shake)
        {
            _shakes.Add(shake);
            Console.WriteLine($"Shake '{shake.NameOfShake}' was successfully added to the menu.");
        }
    }
}
