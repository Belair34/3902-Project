using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1 {
    public interface IInventory
    {
        int Direction { get; set; }
        int Health { get; set; }
        int MaxHealth { get; set; }
        int Rupees { get; set; }
        int Keys { get; set; }
        int Bombs { get; set; }
        int Arrows { get; set; }
        int TriforceShards { get; set; }
        int CandleUsed { get; set; }
        int HaveMap { get; set; }
        int HaveCompass { get; set; }
        int HaveWoodRang { get; set; }
        int HaveBlueCandle { get; set; }
        int HaveBow { get; set; }
        int HaveBlueRing { get; set; }
        int HaveWand { get; set; }
        int HaveSword { get; set; }
        int CurrentRoom { get; set; }
        Vector2 SlotBCoordinates { get; set; }
        ICommand GetSlotBCommand();
        void SetSlotBCommand(ICommand command, int textureX, int textureY);
        void Update();
    }
}