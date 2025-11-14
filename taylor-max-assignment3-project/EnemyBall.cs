using MohawkGame2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MohawkGame2D
{
    public class EnemyBall
    {
        public int evilRadius = 18;
        public Vector2 evilGrav = new Vector2(3, 0);
        public Vector2 evilPos = new Vector2(0, Random.Integer(300,550));
        public Vector2 evilVelo;
        int evilCount = 0;

        // make the evil balls
        public void evilBlocks()
        {
            Draw.FillColor = Color.Red;
            Draw.Circle(evilPos, evilRadius);
        
            //makes the ball's gravity
            Vector2 horizontalGrav = evilGrav * Time.DeltaTime;
            evilVelo += horizontalGrav;
            evilPos += evilVelo;
       
            // resets the ball's trajectory and position
            if (evilPos.X > 850)
            {
                evilPos.X = 0;
                evilGrav.X = 8;

                evilCount++;
            }

            if (evilCount > 3)
            {
                evilGrav.X = -8;
            }

            if (evilPos.X < 0)
            {
                evilPos.X = 800;
                evilCount--;
            }

            if (evilCount < 0)
            {
                evilGrav.X = 8;
            }
        }

    }
}
