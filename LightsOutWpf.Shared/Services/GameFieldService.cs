using System;
using System.Windows.Input;
using System.Linq;
using System.Diagnostics;

namespace LightsOutWpf.Shared.Services
{
    public class GameFieldService : IGameFieldService
    {
        public Light[] Lights { get; set; } = new Light[25];
        public int Width { get; set; } = 5;


        public GameFieldService()
        {
            for (int i = 0; i < Lights.Length; i++)
            {
                Lights[i] = new Light(this);
            }
        }

        public void FlipLights(Light light)
        {
            var index = Array.IndexOf(Lights, light);
            var (x, y) = TranslatePosition(index, Width);

            Debug.WriteLine($"Position is { index }; Coordinates are x:{x}, y:{y}");

            // Flip left light.
            if (x > 0)
            {
                var leftPosition = TranslateCoordinates((x - 1, y), 5);
                Lights[leftPosition].Lit = !Lights[leftPosition].Lit;
            }

            // Flip right light.
            if (x < Width-1)
            {
                var leftPosition = TranslateCoordinates((x + 1, y), 5);
                Lights[leftPosition].Lit = !Lights[leftPosition].Lit;
            }

            // Flip above light.
            if (y > 0)
            {
                var leftPosition = TranslateCoordinates((x, y-1), 5);
                Lights[leftPosition].Lit = !Lights[leftPosition].Lit;
            }

            // Flip below light.
            if ( y < Lights.Length / Width - 1)
            {
                var leftPosition = TranslateCoordinates((x, y+1), 5);
                Lights[leftPosition].Lit = !Lights[leftPosition].Lit;
            }
        }

        public static int TranslateCoordinates((int x, int y) coordinates, int width)
        {
            return (coordinates.y * width) + coordinates.x;
        }

        public static (int x, int y) TranslatePosition(int position, int width)
        {
            var x = position % width;
            var y = position / width;

            return (x, y);
        }
    }
}
