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
        Bob bob = new Bob();
        Platform floor = new Platform();
        Platform platform = new Platform();
        Projectile projectile = new Projectile();

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
            bob.jumpHeight.Y = 12;

            //The floor's variables
            floor.position.X = 0;
            floor.position.Y = 550;
            floor.numberOfPlatforms = 4;
            floor.xOffsetBy = 200;
            floor.yOffsetBy = 0;
            floor.xOffSet = 0;
            floor.yOffSet = 0;
            floor.leftEdge = 0;
            floor.rightEdge = 0;
            floor.bottomEdge = 0;
            floor.topEdge = 0;

            //The floating platform's variables
            platform.position.X = 50;
            platform.position.Y = 350;
            platform.numberOfPlatforms = 3;
            platform.xOffsetBy = 250;
            platform.yOffsetBy = 150;
            platform.xOffSet = 0;
            platform.yOffSet = 0;
            platform.leftEdge = 0;
            platform.rightEdge = 0;
            platform.bottomEdge = 0;
            platform.topEdge = 0;

            //Projectile's variables
            projectile.position.X = 0;
            projectile.position.Y = 0;
            projectile.size = 30;
            projectile.speed = 10;
            projectile.projectileColor = Color.Red;

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
            platform.DrawPlatforms();
            projectile.drawProjectiles();
            //collision();

        }

        public void collision() 
        {
            bool isCollidingRight = bob.position.X - bob.size < platform.rightEdge;
            bool isCollidingLeft = bob.position.X + bob.size > platform.rightEdge;
            bool isCollidingTop = bob.position.Y + bob.size > platform.topEdge;
            bool isCollidingBottom = bob.position.Y - bob.size < platform.bottomEdge;

            bool isWithinYBottom = platform.bottomEdge < bob.position.Y + bob.size;
            bool isWithinYTop = platform.topEdge > bob.position.Y - bob.size;
            bool isWithinXLeft = platform.leftEdge < bob.position.X - bob.size;
            bool isWithinXRight = platform.rightEdge > bob.position.X + bob.size;

            

            bool isCollidingWithFloor = bob.position.Y + bob.size > floor.topEdge;

            if (isCollidingTop) 
            {
                bob.position.Y = bob.lastPosition.Y;
                bob.velocity.Y = 0;
            }

            if (isCollidingTop&&isCollidingBottom)
            {
                bob.position.Y = bob.lastPosition.Y;
                bob.velocity.Y = 0;
            }

            if (isCollidingWithFloor)
            {
                bob.velocity.Y = 0;
                bob.position.Y = bob.lastPosition.Y;
            }


        }

    }
}