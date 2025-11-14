using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MohawkGame2D
{
   public class TheMother
    {
        public Vector2 motherGuy = new Vector2(0,0);
        Vector2 motherTorso = new Vector2(10, 10);

        public void myMother()
        {
            Vector2 motherBody = new Vector2(motherGuy.X - 5, motherGuy.Y + 3);
            Vector2 motherArmL = new Vector2(motherBody.X, motherBody.Y + 3);
            Vector2 motherArmR = new Vector2(motherBody.X+10, motherBody.Y + 3);
            Vector2 motherArmL2 = new Vector2(motherBody.X-5, motherBody.Y + 3);
            Vector2 motherArmR2 = new Vector2(motherBody.X + 15, motherBody.Y + 3);
            Vector2 motherLegL = new Vector2(motherBody.X, motherBody.Y + 10);
            Vector2 motherLegR = new Vector2(motherBody.X+10, motherBody.Y + 10);
            Vector2 motherLegL2 = new Vector2(motherBody.X, motherBody.Y + 15);
            Vector2 motherLegR2 = new Vector2(motherBody.X + 10, motherBody.Y + 15);
            Draw.FillColor = Color.Blue;           
            Draw.Circle(motherGuy, 5);
            Draw.Rectangle(motherBody, motherTorso);
            Draw.LineSize = 2;
            Draw.Line(motherArmL, motherArmL2);
            Draw.Line(motherArmR, motherArmR2);
            Draw.Line(motherLegL, motherLegL2);
            Draw.Line(motherLegR, motherLegR2);
        }

    }
}
