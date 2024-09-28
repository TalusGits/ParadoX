using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace gracosmod123
{
    // This class stores necessary player info for our custom damage class, such as damage multipliers, additions to knockback and crit, and our custom resource that governs the usage of the weapons of this damage class.
    public class ExampleDamagePlayer : ModPlayer
    {
        public static ExampleDamagePlayer ModPlayer(Player player)
        {
            return player.GetModPlayer<ExampleDamagePlayer>();
        }

        // Vanilla only really has damage multipliers in code
        // And crit and knockback is usually just added to
        // As a modder, you could make separate variables for multipliers and simple addition bonuses
        public float exampleDamageAdd;
        public float exampleDamageMult = 1f;
        public float exampleKnockback;
        public int exampleCrit;

        // Here we include a custom resource, similar to mana or health.
        // Creating some variables to define the current value of our example resource as well as the current maximum value. We also include a temporary max value, as well as some variables to handle the natural regeneration of this resource.
        public int exampleResourceCurrent;
        public const int DefaultExampleResourceMax = 100;
        public int exampleResourceMax;
        public int exampleResourceMax2;
        public float exampleResourceRegenRate;
        internal int exampleResourceRegenTimer = 0;
        public static readonly Color HealExampleResource = new Color(187, 91, 201); // We can use this for CombatText, if you create an item that replenishes exampleResourceCurrent.

        /*
		In order to make the Example Resource example straightforward, several things have been left out that would be needed for a fully functional resource similar to mana and health. 
		Here are additional things you might need to implement if you intend to make a custom resource:
		- Multiplayer Syncing: The current example doesn't require MP code, but pretty much any additional functionality will require this. ModPlayer.SendClientChanges and clientClone will be necessary, as well as SyncPlayer if you allow the user to increase exampleResourceMax.
		- Save/Load and increased max resource: You'll need to implement Save/Load to remember increases to your exampleResourceMax cap.
		- Resouce replenishment item: Use GlobalNPC.NPCLoot to drop the item. ModItem.OnPickup and ModItem.ItemSpace will allow it to behave like Mana Star or Heart. Use code similar to Player.HealEffect to spawn (and sync) a colored number suitable to your resource.
		*/

        public override void Initialize()
        {
            exampleResourceMax = DefaultExampleResourceMax;
        }

        public override void ResetEffects()
        {
            ResetVariables();
        }

        public override void UpdateDead()
        {
            ResetVariables();
        }

        private void ResetVariables()
        {
            exampleDamageAdd = 0f;
            exampleDamageMult = 1f;
            exampleKnockback = 0f;
            exampleCrit = 0;
            exampleResourceRegenRate = 1f;
            exampleResourceMax2 = exampleResourceMax;
        }

        // Lets do all our logic for the custom resource here, such as limiting it, increasing it and so on.
    }
}