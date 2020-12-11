namespace LightsOutWpf.Shared.Services
{
    public interface IGameFieldService
    {
        int Width { get; set; }
        Light[] Lights { get; set; }
      
        void FlipLights(Light light);
    }
}