using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Terraria.ModLoader.ModContent;
namespace gracosmod123.NPCs.ocean.oceanitems
{
    public class aquaticthrowing : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Aquatic Knife");
            Tooltip.SetDefault("Pretty cool");
        }

        public override void SetDefaults()
        {
            Item.DamageType = 300;
            item.melee = true;
            Item.knockBack = 1;
            Item.value = Item.sellPrice(gold: 2);
            Item.rare = 3;
            Item.width = 14;
            Item.height = 34;
            item.useStyle = 1;
            Item.shootSpeed = 12f;
            Item.useTime = 18;
            Item.useAnimation = 18;
            Item.shoot = ModContent.ProjectileType("aquaticthrowingP");
            item.noUseGraphic = true;
            Item.noMelee = true;
            Item.autoReuse = true;
        }
        /*public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            player.AddBuff(ModContent.BuffType.Wet, 180);
        }//ModContent.ProjectileType("bamboodiscus");*/
        public override void AddRecipes()
        {
            Recipe recipe = new Recipe(mod);
            recipe.AddIngredient(ItemType<oreaqua.Aquabar>(), 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.Register();
        }
    }

    public class aquaticthrowingP : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Aquatic Knife");
        }
        int shootDelay = 0;

        public override void SetDefaults()
        {
            shootDelay = 0;
            projectile.width = 40;
            projectile.height = 40;
            projectile.friendly = true;
            Projectile.Penetrate = -1;                       //this is the projectile penetration
            Main.projFrames[projectile.type] = 1;           //this is projectile frames
            projectile.hostile = false;
            projectile.tileCollide = false;                 //this make that the projectile does go thru walls
            projectile.ignoreWater = true;
            projectile.light = 2.00f;
            projectile.melee = true;
            projectile.aiStyle = 1;
            aiType = ProjectileID.Bullet;

        }
        public override void AI()
        {
            
            shootDelay++;
            if (shootDelay >= 40 /** 60*/)
            {
                for (int i = 0; i < 20; i++)
                {
                    if (Main.netMode != 1)
                        Projectile.NewProjectileDirect(projectile.Center.X, projectile.Center.Y, (float)Math.Cos(Math.PI / 4 * i) * 12, (float)Math.Sin(Math.PI / 4 * i) * 12, ModContent.ProjectileType<starfish2>(), (int)(80), 3, Main.myPlayer);
                }
                shootDelay = 0;
            }

        }

    }
}