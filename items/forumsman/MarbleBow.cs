﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria;
using static Terraria.ModLoader.ModContent;

namespace gracosmod123.items.forumsman
{
    public class MarbleBow : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Marble Bow");
            Tooltip.SetDefault("changes wooden arrows to Marble arrows");
        }
        public override void SetDefaults()
        {
            item.Size = new Vector2(12, 24);
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(silver: 22);

            Item.useTime = 25;
            Item.useAnimation = 25;
            item.useStyle = ItemUseStyleID.HoldingOut;
            Item.UseSound = SoundID.Item5;

            Item.noMelee = true;
            item.ranged = true;
            Item.DamageType = 30;

            item.useAmmo = AmmoID.Arrow;
            Item.shoot = 1;
            Item.shootSpeed = 8.5f;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (type == ProjectileID.WoodenArrowFriendly) // or ProjectileID.WoodenArrowFriendly
            {
                type = ModContent.ProjectileType("MarbleArrow"); // or ProjectileID.FireArrow;
            }
            return true; // return true to allow tmodloader to call Projectile.NewProjectileDirect as normal
        }//ModContent.ProjectileType("bamboodiscus");
    }
}
/*
using ExampleMod.Tiles;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExampleMod.Items.Weapons
{
	public class ExampleGun : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("This is a modded gun.");
		}

		public override void SetDefaults() {
			Item.DamageType = 20; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
			item.ranged = true; // sets the damage type to ranged
			Item.width = 40; // hitbox width of the item
			Item.height = 20; // hitbox height of the item
			Item.useTime = 20; // The item's use time in ticks (60 ticks == 1 second.)
			Item.useAnimation = 20; // The length of the item's use animation in ticks (60 ticks == 1 second.)
			item.useStyle = ItemUseStyleID.HoldingOut; // how you use the item (swinging, holding out, etc)
			Item.noMelee = true; //so the item's animation doesn't do damage
			Item.knockBack = 4; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
			Item.value = 10000; // how much the item sells for (measured in copper)
			Item.rare = ItemRarityID.Green; // the color that the item's name will be in-game
			Item.UseSound = SoundID.Item11; // The sound that this item plays when used.
			Item.autoReuse = true; // if you can hold click to automatically use it again
			Item.shoot = 10; //idk why but all the guns in the vanilla source have this
			Item.shootSpeed = 16f; // the speed of the projectile (measured in pixels per frame)
			item.useAmmo = AmmoID.Bullet; // The "ammo Id" of the ammo item that this weapon uses. Note that this is not an item Id, but just a magic value.
		}

		public override void AddRecipes() {
			Recipe recipe = new Recipe(mod);
			recipe.AddIngredient(ModContent.ItemType<ExampleItem>(), 10);
			recipe.AddTile(ModContent.TileType<ExampleWorkbench>());
			recipe.SetResult(this);
			recipe.Register();
		}

		/*
		 * Feel free to uncomment any of the examples below to see what they do
		 */

// What if I wanted this gun to have a 38% chance not to consume ammo?
/*public override bool ConsumeAmmo(Player player)
{
    return Main.rand.NextFloat() >= .38f;
}*/

// What if I wanted it to work like Uzi, replacing regular bullets with High Velocity Bullets?
// Uzi/Molten Fury style: Replace normal Bullets with High Velocity
/*public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
{
    if (type == ProjectileID.Bullet) // or ProjectileID.WoodenArrowFriendly
    {
        type = ProjectileID.BulletHighVelocity; // or ProjectileID.FireArrow;
    }
    return true; // return true to allow tmodloader to call Projectile.NewProjectileDirect as normal
}*/

// What if I wanted it to shoot like a shotgun?
// Shotgun style: Multiple Projectiles, Random spread 
/*public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
{
    int numberProjectiles = 4 + Main.rand.Next(2); // 4 or 5 shots
    for (int i = 0; i < numberProjectiles; i++)
    {
        Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(30)); // 30 degree spread.
        // If you want to randomize the speed to stagger the projectiles
        // float scale = 1f - (Main.rand.NextFloat() * .3f);
        // perturbedSpeed = perturbedSpeed * scale; 
        Projectile.NewProjectileDirect(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
    }
    return false; // return false because we don't want tmodloader to shoot projectile
}*/

// What if I wanted an inaccurate gun? (Chain Gun)
// Inaccurate Gun style: Single Projectile, Random spread 
/*public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
{
    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(30));
    speedX = perturbedSpeed.X;
    speedY = perturbedSpeed.Y;
    return true;
}*/

// What if I wanted multiple projectiles in a even spread? (Vampire Knives) 
// Even Arc style: Multiple Projectile, Even Spread 
/*public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
{
    float numberProjectiles = 3 + Main.rand.Next(3); // 3, 4, or 5 shots
    float rotation = MathHelper.ToRadians(45);
    position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
    for (int i = 0; i < numberProjectiles; i++)
    {
        Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
        Projectile.NewProjectileDirect(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
    }
    return false;
}*/

// Help, my gun isn't being held at the handle! Adjust these 2 numbers until it looks right.
/*public override Vector2? HoldoutOffset()
{
    return new Vector2(10, 0);
}*/

// How can I make the shots appear out of the muzzle exactly?
// Also, when I do this, how do I prevent shooting through tiles?
/*public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
{
    Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
    if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
    {
        position += muzzleOffset;
    }
    return true;
}*/

// How can I get a "Clockwork Assault Rifle" effect?
// 3 round burst, only consume 1 ammo for burst. Delay between bursts, use reuseDelay
/*	The following changes to SetDefaults()
    Item.useAnimation = 12;
    Item.useTime = 4;
    item.reuseDelay = 14;
public override bool ConsumeAmmo(Player player)
{
    // Because of how the game works, player.itemAnimation will be 11, 7, and finally 3. (useAnimation - 1, then - useTime until less than 0.) 
    // We can get the Clockwork Assault Riffle Effect by not consuming ammo when itemAnimation is lower than the first shot.
    return !(player.itemAnimation < Item.useAnimation - 2);
}*/

// How can I shoot 2 different projectiles at the same time?
/*public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
{
    // Here we manually spawn the 2nd projectile, manually specifying the projectile type that we wish to shoot.
    Projectile.NewProjectileDirect(position.X, position.Y, speedX, speedY, ProjectileID.GrenadeI, damage, knockBack, player.whoAmI);
    // By returning true, the vanilla behavior will take place, which will shoot the 1st projectile, the one determined by the ammo.
    return true;
}*/

// How can I choose between several projectiles randomly?
/*public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
{
    // Here we randomly set type to either the original (as defined by the ammo), a vanilla projectile, or a mod projectile.
    type = Main.rand.Next(new int[] { type, ProjectileID.GoldenBullet, ProjectileType<Projectiles.ExampleBullet>() });
    return true;
}*//*
}
}*/