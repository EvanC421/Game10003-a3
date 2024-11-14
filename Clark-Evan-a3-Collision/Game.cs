// Include code libraries you need below (use the namespace).
using Clark_Evan_a3_Collision;
using System;
using System.Numerics;
using System.Runtime.InteropServices.Marshalling;
using System.Threading.Tasks.Sources;

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
        Projectile coin = new Projectile();

        int score = 0;

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
            bob.lastPosition.X = 0;
            bob.lastPosition.Y = 0;

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

            //The floating platform's variables (unused)
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
            projectile.position.Y = Random.Integer(200, 500);
            projectile.size = 30;
            projectile.speed = 400;
            projectile.projectileColor = Color.Red;
            projectile.despawnPosition = 800;
            //Coin's variables
            coin.position.X = 0;
            coin.position.Y = Random.Integer(200, 500);
            coin.size = 30;
            coin.speed = 400;
            coin.projectileColor = Color.Yellow;
            coin.despawnPosition = 800;


        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            if (!isCollidingWithProjectile())
            {
                Window.ClearBackground(Color.OffWhite);
                bob.lastPosition = bob.position;
                Text.Draw("Score: " + score, 0, 0);

                //Calling functions
                //Bob's functions
                bob.PlayerControl();
                bob.DrawBob();
                bob.BobsGravity();
                //Platform's functions
                floor.DrawPlatforms();
                //Projectile's functions
                projectile.drawProjectiles();
                coin.drawProjectiles();
                collision();

                if (isCollidingWithCoin())
                {
                    score += 1;
                    coin.position.X = 0;
                    coin.position.Y = Random.Integer(200, 500);
                    projectile.speed += 50;
                    coin.speed += 50;
                }

            }
            //Game over happens
            if (isCollidingWithProjectile())
            {
                Window.ClearBackground(Color.White);
                Text.Draw("Game Over!\n\nFinal score: "+score+"\n\nRestart: 'r' key", 300, 250);
                if (Input.IsKeyboardKeyDown(KeyboardInput.R))
                {
                    score = 0;
                    Setup();
                }

            }



        }

        public void collision() 
        {  
            bool isCollidingWithFloor = bob.position.Y + bob.size > floor.topEdge;
            if (isCollidingWithFloor)
            {
                bob.velocity.Y = 0;
                bob.position.Y = bob.lastPosition.Y;
            }
        }

        public bool isCollidingWithProjectile()
        {
            float circlesRadiiP = bob.size + projectile.size;
            bool doCirclesCollide = Vector2.Distance(bob.position, projectile.position) <= circlesRadiiP;
            return doCirclesCollide;
        }

        public bool isCollidingWithCoin()
        {
            float circlesRadiiC = bob.size + coin.size;
            bool doesCoinCollide = Vector2.Distance(bob.position, coin.position) <= circlesRadiiC;
            return doesCoinCollide;
        }
    }
}