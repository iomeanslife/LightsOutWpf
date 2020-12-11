using System;
using System.Windows.Input;
using System.Linq;
using System.Diagnostics;

namespace LightsOutWpf.Shared.Services
{
    public class GameFieldService : IGameFieldService
    {
        public const int RandomFlips = 5;

        public Light[] Lights { get; set; } = new Light[25];
        public int Width { get; set; } = 5;

        public event EventHandler PlayerWins;

        public GameFieldService()
        {
            for (int i = 0; i < Lights.Length; i++)
            {
                Lights[i] = new Light(this);
            }

            SetupGameField();
        }

        /// <summary>
        /// Plays a few random moves for the amount of turns declared in <see cref="RandomFlips"/>
        /// </summary>
        public void SetupGameField()
        {
            for (int i = 0; i < Lights.Length; i++)
            {
                Lights[i].Lit = false;
            }

            Random random = new Random();

            for (int i = 0; i < RandomFlips; i++)
            {
                var index = random.Next(0, Lights.Length);
                FlipLights(Lights[index]);
            }
        }

        protected virtual void OnPlayerWins()
        {
            PlayerWins?.Invoke(this, new EventArgs());
        }

        public void FlipLights(Light light)
        {
            light.Lit = !light.Lit;

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
            if (x < Width - 1)
            {
                var leftPosition = TranslateCoordinates((x + 1, y), 5);
                Lights[leftPosition].Lit = !Lights[leftPosition].Lit;
            }

            // Flip above light.
            if (y > 0)
            {
                var leftPosition = TranslateCoordinates((x, y - 1), 5);
                Lights[leftPosition].Lit = !Lights[leftPosition].Lit;
            }

            // Flip below light.
            if (y < Lights.Length / Width - 1)
            {
                var leftPosition = TranslateCoordinates((x, y + 1), 5);
                Lights[leftPosition].Lit = !Lights[leftPosition].Lit;
            }

            // Check winning conditions.
            foreach (var lightItem in Lights)
            {
                if (!lightItem.Lit)
                {
                    return;
                }
            }

            OnPlayerWins();
        }

        /// <summary>
        /// Converts the from xy coordinates to an array position.
        /// </summary>
        /// <param name="coordinates">A tuple with the x and y coordinates.</param>
        /// <param name="width">The game field width is required for the calculation.</param>
        /// <returns>the position where the coordinates results</returns>
        public static int TranslateCoordinates((int x, int y) coordinates, int width)
        {
            return (coordinates.y * width) + coordinates.x;
        }

        /// <summary>
        /// Converts the from the one dimensional array position to two dimensional xy coordinates.
        /// </summary>
        /// <param name="position">For things like the index in an array.</param>
        /// <param name="width">The game field width is required for the calculation.</param>
        /// <returns>A tuple with the x and y position.</returns>
        public static (int x, int y) TranslatePosition(int position, int width)
        {
            var x = position % width;
            var y = position / width;

            return (x, y);
        }
    }
}
