using System;

namespace LightsOutWpf.Shared.Services
{
    public interface IGameFieldService
    {
        /// <summary>
        /// The width required to calculate coordinates with the position in the array.
        /// </summary>
        int Width { get; set; }
        
        Light[] Lights { get; set; }
      
        void FlipLights(Light light);

        void SetupGameField();

        event EventHandler PlayerWins;
    }
}