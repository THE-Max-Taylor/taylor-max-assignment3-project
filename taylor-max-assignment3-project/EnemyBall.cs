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
        public int evilRadius = 20;
        public Vector2 evilGrav = new Vector2(8, 0);
        public Vector2 evilPos = new Vector2(0, 300);
        public Vector2 evilVelo;
        int evilCount = 0;

        // make the evil balls
        public void evilBlocks()
        {
            Draw.FillColor = Color.Red;
            Draw.Circle(evilPos, evilRadius);
        }

        // evil ball physics
        public void SimulateCircleGrav()
        {
            Vector2 horizontalGrav = evilGrav * Time.DeltaTime;
            evilVelo += horizontalGrav;
            evilPos += evilVelo;
        }

        // what to do if the evil balls spin too far
        public void evilRotation()
        {
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
        }

    }
}
