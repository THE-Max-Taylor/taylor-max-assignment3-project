using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MohawkGame2D
{
    public class Projectiles
    {
        public Vector2 projPos = new Vector2(400, 0);
        public Vector2 projVelo;
        public Vector2 projGravity = new Vector2(0, 30);
        
        public int projSize = 20;

        public void makeGravity()
        {
            Vector2 gravityYay = projGravity * Time.DeltaTime;
            projVelo += gravityYay;
            projPos += projVelo;
        }

            // make player projectiles

            public void projectilesYay() 
        {
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
        }
         
        
        
            

    }
}
