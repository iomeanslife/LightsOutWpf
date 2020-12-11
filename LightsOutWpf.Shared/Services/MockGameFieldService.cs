using System;

namespace LightsOutWpf.Shared.Services
{
    public class MockGameFieldService : IGameFieldService
    {
        public Light[] Lights { get; set; } = new Light[25];
        public int Width { get; set; } = 5;

        public MockGameFieldService()
        {
            var random = new Random();

            for (int i = 0; i < Lights.Length; i++)
            {
                Lights[i] = new Light(this)
                {
                    Lit = random.Next(0, 2) == 1
                };
            }
        }

        public event EventHandler PlayerWins;

        protected virtual void OnPlayerWins()
        {
            PlayerWins?.Invoke(this, new EventArgs());
        }

        public void FlipLights(Light light)
        {
            throw new NotImplementedException();
        }

        public void SetupGameField()
        {
            throw new NotImplementedException();
        }
    }
}
