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
namespace gracosmod123.npcs.ocean.oceanitems
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
            item.damage = 300;
            item.melee = true;
            item.knockBack = 1;
            item.value = Item.sellPrice(gold: 2);
            item.rare = 3;
            item.width = 14;
            item.height = 34;
            item.useStyle = 1;
            item.shootSpeed = 12f;
            item.useTime = 18;
            item.useAnimation = 18;
            item.shoot = mod.ProjectileType("aquaticthrowingP");
            item.noUseGraphic = true;
            item.noMelee = true;
            item.autoReuse = true;
        }
        /*public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            player.AddBuff(BuffID.Wet, 180);
        }//mod.ProjectileType("bamboodiscus");*/
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<oreaqua.Aquabar>(), 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
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
            projectile.penetrate = -1;                       //this is the projectile penetration
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
                        Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, (float)Math.Cos(Math.PI / 4 * i) * 12, (float)Math.Sin(Math.PI / 4 * i) * 12, ModContent.ProjectileType<starfish2>(), (int)(80), 3, Main.myPlayer);
                }
                shootDelay = 0;
            }

        }

    }
}