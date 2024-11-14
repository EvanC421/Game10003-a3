using System;
using System.Numerics;

namespace Game10003
{
    public class Projectile
    {
        //variables
        public Vector2 position;
        public Color projectileColor;
        public float size;
        public float speed;

        public void drawProjectiles()
        {
            int[] yOffset = [500, 400, 300, 200];
            position.Y = Random.Integer(0, yOffset.Length);
            Draw.FillColor = projectileColor;
            Draw.Circle(position.X, position.Y, size);
        }
    }
}
