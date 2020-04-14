using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    public interface IGameState
    {
        HUD GetHUD();
        IPlayer GetPlayer();
        void SetPlayer(IPlayer player);
        void SetRoom(IRoom room);
        void Initialize();

        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
