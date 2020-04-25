using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.Projectiles;

namespace Game1.PlayerStates
{
    class EStateAquamentusMovingUp : IEnemyState
    {
        ISprite sprite;
        IEnemy enemy;
        int coolDown;
        Game1 game;
        public EStateAquamentusMovingUp(IEnemy enemy, Game1 game, int coolDown = 0)
        {
            this.enemy = enemy;
            this.game = game; 
            this.sprite = SpriteFactory.Instance.GetAquamentusMovingUp(enemy);
            this.coolDown = coolDown;
        }
        public void MoveUp()
        {
        }

        public void MoveDown()
        {
            enemy.SetState(new EStateAquamentusMovingDown(enemy, game, coolDown));
        }
        public void MoveLeft()
        {
            enemy.SetState(new EStateAquamentusMovingLeft(enemy, game, coolDown));
        }

        public void MoveRight()
        {
            enemy.SetState(new EStateAquamentusMovingRight(enemy, game, coolDown));
        }
        public void MoveHorizontal()
        {

        }

        public void MoveVertical()
        {
            //enemy.SetState(new EStateGelMovingVertical(enemy, coolDown));
        }
        public void MoveToPlayer()
        {
            enemy.SetState(new EStateAquamentusMovingToPlayer(enemy, game, coolDown));
        }

        public void Stop()
        {

        }

        public void Update()
        {
            if (coolDown > 0)
            {
                coolDown--;
            }
            sprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
        }

       
    }
}
