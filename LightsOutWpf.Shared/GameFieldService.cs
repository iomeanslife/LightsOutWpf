using System;

namespace LightsOutWpf.Shared
{
    public class GameFieldService : IGameFieldService
    {
        public Light[,] Lights { get; set; } = new Light[5, 5];

    }
}
