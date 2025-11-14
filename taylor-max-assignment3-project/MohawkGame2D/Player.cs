using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MohawkGame2D
{
    public class Player
    {
        public Vector2 playerSize = new Vector2(40, 40);
        public Vector2 playerMove = new Vector2(0, 0);

        // create the player!!!
        public void playerCharacter()
        {
            Vector2 playerSpot = new Vector2(playerMove.X, 0);
            Draw.FillColor = Color.Green;
            Draw.Rectangle(playerSpot, playerSize);

            // keep the player in bounds!! conniving freak.
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

        //makes the player controls!!            
           
              float speedYay = 10;

              if (Input.IsKeyboardKeyDown(KeyboardInput.D))

              {
                 playerMove.X += speedYay;
              }

              if (Input.IsKeyboardKeyDown(KeyboardInput.A))

              {
                 playerMove.X += -speedYay;
              }

            }
    }

        
    
}
