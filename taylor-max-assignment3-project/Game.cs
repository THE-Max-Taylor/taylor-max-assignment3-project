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
        
        EnemyBall joeBall = new EnemyBall();

        Player joePlayer = new Player();

        Projectiles joeProjectiles = new Projectiles();

        int projSize = 20;
            
        int theCount = 0;
      
        public void Setup()
        {
            Window.SetSize(800, 600);
            Window.SetTitle("My Mother Is Proud Of You");
            
        }
        public void Update()
        {                     
            Window.ClearBackground(Color.White);

            // bring in info from other classes!!
            joeBall.evilBlocks();
            joeBall.SimulateCircleGrav();
            joeBall.evilRotation();

            joePlayer.playerCharacter();
            joePlayer.playerControls();

            joeProjectiles.makeGravity();
            joeProjectiles.projectilesYay();        
        

            // make player projectiles emerge from player coords
            Vector2 playerPos = new Vector2(joePlayer.playerMove.X, 0);

            joeProjectiles.projPos.X = playerPos.X;

            // check for projectile + enemy overlap

            float theOverlap = projSize + joeBall.evilRadius;

            bool isOverlap = Vector2.Distance(joeBall.evilPos, joeProjectiles.projPos) < theOverlap;

            if (isOverlap)
            {
                Window.ClearBackground(Color.Yellow);

                joeProjectiles.projPos = new Vector2(400, 0);

                joeBall.evilPos.X = 0;

                theCount++;            
            }                      

            Text.Draw($"The SCORE!! is: {theCount}. My mother is proud of; you! !", new Vector2(0, 500));
        }
    }

}

