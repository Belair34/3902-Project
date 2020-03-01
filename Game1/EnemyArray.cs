using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Game1.PlayerStates;
using Game1.Projectiles;

namespace Game1
{
    public class Game1 : Game
    {
        private Enemy[] enemies;

        public ListofEnemies(int index, string name)
            {
                enemies = new Enemy[6];
                
            }        
    }
}