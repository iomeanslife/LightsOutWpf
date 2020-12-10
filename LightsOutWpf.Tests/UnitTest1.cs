using LightsOutWpf.Shared;
using System;
using Xunit;

namespace LightsOutWpf.Tests
{
    public class GameFieldServiceTests
    {
        [Fact]
        public void DefaultGridSizeTest()
        {
            var field = new GameFieldService();
            Assert.True(field.Lights.Length == 25);
        }
    }
}
