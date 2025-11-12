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

        Vector2 projPos = new Vector2(400, 0);
        Vector2 projVelo;
        Vector2 projGravity = new Vector2(20, 30);

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

                Console.WriteLine($"The SCORE!! is: {theCount}");
            }

        }
    }

}

