using Game10003;
using System.Numerics;

namespace Clark_Evan_a3_Collision
{
    public class Platform
    {
        //variables
        public Vector2 position;
        public int numberOfPlatforms;
        //The numbers that keep track of how far the positions are in the function
        public int xOffSet;
        public int yOffSet;
        //numbers that determine how far the platform gets redrawn in the function
        public int xOffsetBy;
        public int yOffsetBy;
        //sides of the platforms
        public float leftEdge;
        public float rightEdge;
        public float topEdge;
        public float bottomEdge;



        public void DrawPlatforms()
        {
            //Draw each platform
            for (int i = 0; i < numberOfPlatforms; i++)
            {
                //platforms are moved each time
                xOffSet = i * xOffsetBy;
                yOffSet = i * yOffsetBy;

                Draw.FillColor = Color.Black;
                Draw.Rectangle(position.X + xOffSet, position.Y - yOffSet, 200, 50);
                //Platform collision
                leftEdge = position.X;
                rightEdge = position.X + 200;
                topEdge = position.Y;
                bottomEdge = position.Y - 50;
            }
        }
    }
}
