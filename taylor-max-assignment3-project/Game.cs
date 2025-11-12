// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
     
        Vector2 playerSize = new Vector2(40, 40);
        Vector2 playerMove = new Vector2(0, 0);
        
        

        Vector2 projPos = new Vector2(400, 0);
        Vector2 projVelo;
        Vector2 projGravity = new Vector2(0, 30);

        Vector2 evilGrav = new Vector2(8, 0);
        Vector2 evilPos = new Vector2(0, 300);
        Vector2 evilVelo;


        int projSize = 20;

        int evilRadius = 20;

     

        //projectile gravity
        void makeGravity()
        {
            Vector2 gravityYay = projGravity * Time.DeltaTime;
            projVelo += gravityYay;
            projPos += projVelo;
        }



        //bastard's phsyics
        void SimulateCircleGrav()
        {
            Vector2 horizontalGrav = evilGrav * Time.DeltaTime;
            evilVelo += horizontalGrav;
            evilPos += evilVelo;
        }

        //make the bastards
        void evilBlocks()
        {
            Draw.FillColor = Color.Red;
            Draw.Circle(evilPos, evilRadius);
        }

        int theCount = 0;

        int evilCount = 0;

        public void Setup()
        {
            Window.SetSize(800, 600);

        }

        public void Update()
        {
            Window.ClearBackground(Color.White);

            SimulateCircleGrav();

            evilBlocks();


            // make player movment!!

            Vector2 playerSpot = new Vector2(playerMove.X, 0);
           
            
            Draw.FillColor = Color.Green;
            Draw.Rectangle(playerSpot, playerSize);
            

            float speedYay = 10;

            bool movingGirl = false;
            if (Input.IsKeyboardKeyDown(KeyboardInput.D))
                
            {    
                playerMove.X += speedYay;
            }

            if (Input.IsKeyboardKeyDown(KeyboardInput.A))

            {
                playerMove.X += -speedYay;

            }

            if (playerSpot.X > 800)
            {
                Window.ClearBackground(Color.Red);
                Console.WriteLine("R E T U R N");
            }

            if (playerSpot.X < 0)
            {
                Window.ClearBackground(Color.Red);
                Console.WriteLine("R E T U R N");
            }

            // make player projectiles emerge from player coords

            projPos.X = playerSpot.X;

            // make player projectiles

            if (Input.IsKeyboardKeyDown(KeyboardInput.Space))
            {
                makeGravity();
                Draw.FillColor = Color.Green;
                Draw.Circle(projPos, projSize);
            }   

            if (Input.IsKeyboardKeyReleased(KeyboardInput.Space))
            {
                projPos = new Vector2(400, 0);
                projGravity.X = 0;
                projGravity.Y = 0;
            }

            // rewind the balls

            if (evilPos.X > 850)
            {
                evilPos.X = 0;
                evilGrav.X = 8;

                evilCount++;
            }

            if (evilCount > 5)
            {
                evilGrav.X = -8;
            }

            if (evilPos.X < 0)
            {
                evilPos.X = 800;
                evilCount--;
            }

            if (evilCount < -1)
            {
                evilGrav.X = 8;
            }

            float theOverlap = projSize + evilRadius;

            bool isOverlap = Vector2.Distance(evilPos, projPos) < theOverlap;

            if (isOverlap)
            {
                Window.ClearBackground(Color.Yellow);

                projPos = new Vector2(400, 0);

                evilPos.X = 0;

                theCount++;            
            }

            Text.Draw($"The SCORE!! is: {theCount}. My mother is proud of; you! !", new Vector2(0, 500));
        }
    }

}

