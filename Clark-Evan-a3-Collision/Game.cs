// Include code libraries you need below (use the namespace).
using Clark_Evan_a3_Collision;
using System;
using System.Numerics;

// The namespace your code is in.
namespace Game10003
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Place your variables here:
        public Bob bob = new Bob();
        Platform floor = new Platform();

        Color purple = new Color(177, 156, 217);
        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetTitle("Save Bob");
            Window.SetSize(800, 600);

            //Bob's default variables
            bob.position.X = 400;
            bob.position.Y = 450;
            bob.size = 50;
            bob.bodyColor = purple;
            bob.eyeMouthColor = Color.Black;
            bob.speed = 500;
            bob.jumpHeight.X = 0;
            bob.jumpHeight.Y = 8;

            //Platform's variables
            floor.position.X = 0;
            floor.position.Y = 550;
            floor.numberOfPlatforms = 4;
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(Color.OffWhite);
            bob.lastPosition = bob.position;

            //Calling functions
            //Bob's functions
            bob.PlayerControl();
            bob.DrawBob();
            bob.BobsGravity();
            //Platform's functions
            floor.DrawPlatforms();
            collision();

        }

        public void collision()
        {
            bool isCollidingY = bob.position.Y + bob.size >= floor.position.Y;
            if (isCollidingY)
            {
                bob.position.Y = bob.lastPosition.Y;
                bob.velocity.Y = 0;
            }
            bool isCollidingX = (bob.position.X + bob.size <= floor.position.X);
            if (isCollidingX)
            {
                bob.position.X = bob.lastPosition.X;
            }
        }
    }
}
