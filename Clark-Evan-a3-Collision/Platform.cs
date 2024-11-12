using Game10003;
using System.Numerics;

namespace Clark_Evan_a3_Collision
{
    public class Platform
    {
        public Vector2 position;
        public int numberOfPlatforms;

        public void DrawPlatforms()
        {
            //Draw each platform
            for (int i = 0; i < numberOfPlatforms; i++)
            {
                int xOffSet = i * 200;
                int yOffSet = i * 10;
                Draw.FillColor = Color.Black;
                Draw.Rectangle(position.X + xOffSet, position.Y, 200, 50);
            }
        }
    }
}
