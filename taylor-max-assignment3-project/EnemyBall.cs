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
        public void evilBlocks()
        {
            Draw.FillColor = Color.Red;
            Draw.Circle(evilPos, evilRadius);
        }
        void SimulateCircleGrav()
        {
            Vector2 horizontalGrav = evilGrav * Time.DeltaTime;
            evilVelo += horizontalGrav;
            evilPos += evilVelo;
        }

        public void Setup() 
        { 
        
        }
        public void Update() 
        {
            SimulateCircleGrav();
            evilBlocks();
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
