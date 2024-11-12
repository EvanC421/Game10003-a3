
using Game10003;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace Clark_Evan_a3_Collision
{
    public class Bob
    {
        //Variables
        //Draw Bob
        public Vector2 position;
        public float size;
        public Color bodyColor;
        public Color eyeMouthColor;
        public Vector2 lastPosition;
        //Player movement
        public float speed;
        //Gravity
        public Vector2 velocity;
        public Vector2 gravity = new Vector2(0, +15);
        public Vector2 jumpHeight;
        public Vector2 gravityForce;


        public void DrawBob()
        {
            //Bob's body
            Draw.LineSize = 1;
            Draw.LineColor = Color.Black;
            Draw.FillColor = bodyColor;
            Draw.Circle(position, 50);
            //Bob's eyes
            Draw.FillColor = eyeMouthColor;
            Draw.Circle(position.X - 30, position.Y - 10, 10);
            Draw.Circle(position.X + 30, position.Y - 10, 10);
            //Bob's mouth
            Draw.Rectangle(position.X - 40, position.Y + 10, 80, 10);
        }

        public void PlayerControl()
        {
            //Left arrow key hit
            if (Input.IsKeyboardKeyDown(KeyboardInput.Left))
            {
                position.X -= speed * Time.DeltaTime;
            }
            //Right arrow key hit
            if (Input.IsKeyboardKeyDown(KeyboardInput.Right))
            {
                position.X += speed * Time.DeltaTime;
            }
            //Constrain to left edge of screen
            if (position.X < 0 + size)
            {
                position.X = 0 + size;
            }
            //Constrain to right edge of screen
            if (position.X + size > Window.Width)
            {
                position.X = Window.Width - size;
            }
            //player jumps (spacebar)
            //Only go up if Bob has zero verticle velocity, AKA when he's touching the ground
            if (velocity.Y == 0) {
                if (Input.IsKeyboardKeyDown(KeyboardInput.Space))
                {
                    velocity = velocity - jumpHeight;
                }
                //constrain to top of screen
                if (position.Y - size < 0)
                {
                    velocity += jumpHeight;
                    position.Y = 50;
                }
            }
        }

        public void BobsGravity()
        {
            //Bob falls
            gravityForce = gravity * Time.DeltaTime;
            velocity += gravityForce;
            position += velocity;
            //Constrain to bottom of screen
            if (position.Y > 550)
            {
                position.Y = 550;
                velocity.Y = 0;
            }
        }
    }
}
