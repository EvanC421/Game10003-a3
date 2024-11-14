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
        public float startingPosition;
        public float despawnPosition;

        public void drawProjectiles()
        {
            Draw.FillColor = projectileColor;
            Draw.Circle(position, size);
            if (position.X < despawnPosition)
            {
                position.X += speed * Time.DeltaTime;
            }
            else if (position.X >= despawnPosition)
            {
                position.X = startingPosition;
                position.Y = Random.Integer(200, 500);
            }
 

        }
    }
}
