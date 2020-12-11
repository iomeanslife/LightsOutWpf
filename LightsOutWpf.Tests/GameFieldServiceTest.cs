using LightsOutWpf.Shared.Services;

using System;
using Xunit;

namespace LightsOutWpf.Tests
{
    public class GameFieldServiceTest
    {
        [Fact]
        public void DefaultGridSizeTest()
        {
            var field = new GameFieldService();
            Assert.True(field.Lights.Length == 25);
        }

        [Fact]
        public void TranslateCoordinatesTest()
        {
            var position = GameFieldService.TranslateCoordinates(4,4,5);
            Assert.Equal(24, position);
        }

        [Fact]
        public void TranslatePositionTest()
        {
            var (x,y)= GameFieldService.TranslatePosition(24, 5);
            Assert.Equal((4,4),(x,y));
        }
    }
}
