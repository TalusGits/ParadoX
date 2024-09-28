/*using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.GameInput;


namespace gracosmod123
{
    public sealed partial class LaugicalityPlayer : ModPlayer
    {
        //Potion Gems
        public bool inf = true;
        public bool calm = true;
        public bool ww = true;
        public bool battle = true;
        public bool hunter = true;
        public bool spelunker = true;
        public bool owl = true;
        public bool danger = true;
        public bool feather = true;

        //Steam vars
        public float steamDamage = 1f;

        //Etherial
        public bool etherial;
        public int etherialTrail;
        public int ethBkg;
        public bool etherialSlot;

        //Misc
        public bool zImmune;
        public bool zMove;
        public bool zCool;
        public int zaWarudoDuration;
        public float xTemp;
        public float yTemp;
        public bool zProjImmune;
        public int zCoolDown = 1800;
        public float theta;
        public bool obsHeart;
        public bool FireTrail { get; set; } = false;
        public bool frostbite;
        public int fullBysmal;
        bool _boosted = false;
        float _ringBoost;
        float _fanBoost;
        public float SnowDamage { get; set; } = 1f;
        public bool BysmalAbsorbDisabled { get; set; } = false;
        public bool Poison { get; set; } = false;
        public bool CursedFlame { get; set; } = false;
        public bool JunglePlague { get; set; } = false;
        public float DebuffMult { get; set; } = 1f;
        public bool NoDebuffDamage { get; set; } = false;
        public bool TrueFireTrail { get; set; } = false;
        public bool ShadowflameTrail { get; set; } = false;
        public bool CrystalliteTrail { get; set; } = false;
        public bool SteamTrail { get; set; } = false;
        public bool BysmalTrail { get; set; } = false;
        public bool Blaze { get; set; } = false;
        public bool Carapace { get; set; } = false;
        public bool PrismVeil { get; set; } = false;
        public bool HoldingBarrier { get; set; } = false;


        //Music
        public bool zoneObsidium;
        public bool zoneAmeldera;
        public bool etherialMusic;

        //Camera Effects
        public int shakeDur;
        public float shakeMag;
        public Vector2 shakeO;
        public bool shakeReset;


        public static LaugicalityPlayer Get() => Get(Main.LocalPlayer);
        public static LaugicalityPlayer Get(Player player) => player.GetModPlayer<LaugicalityPlayer>();

        /// <summary>
        /// Challenge : Refactor This to be short and without having it look disgusting
        /// </summary>
        public override void ResetEffects()
        {

            if (fullBysmal > 0)
                fullBysmal -= 1;

            if (shakeDur > 0)
            {
                shakeDur--;
                shakeReset = false;
            }
            else
            {
                shakeMag = 0;

                if (shakeReset == true)
                    shakeO = player.position;

                else
                {
                    player.position = shakeO;
                    shakeReset = true;
                }
            }
            if (Verdi > 0)
                Verdi -= 1;

            Slimey = false;
            FireTrail = false;
            theta += 3.14f / 40f;
            UltraBoisSummon = false;
            obsHeart = false;
            zCoolDown = 65 * 60;
            zaWarudoDuration = 4 * 60;
            ShroomCopterSummon = false;
            zProjImmune = false;
            RockTwinsSummon = false;
            Connected = 0;
            HalfDef = false;
            NoRegen = false;
            TrueCurse = false;
            zImmune = false;
            zMove = false;
            zCool = false;
            etherialMusic = false;
            Rocks = false;
            Sandy = false;
            Frost = false;
            Obsidium = false;
            Frosty = false;
            Frigid = false;
            MoltenCoreSummon = false;
            SandSharkSummon = false;
            SkeletonPrime = false;
            Doucheron = false;
            TVSummon = false;
            DartCopterSummon = false;
            Electrified = false;
            Steamified = false;
            Mystified = false;
            ToyTrain = false;
            BloodRage = false;
            QueenBee = false;
            Eyes = false;
            Spores = false;
            frostbite = false;
            ArcticHydraSummon = false;
            Poison = false;
            CursedFlame = false;
            JunglePlague = false;
            NoDebuffDamage = false;
            TrueFireTrail = false;
            ShadowflameTrail = false;
            CrystalliteTrail = false;
            SteamTrail = false;
            BysmalTrail = false;
            Blaze = false;
            Carapace = false;
            PrismVeil = false;
            HoldingBarrier = false;

            if (player.extraAccessory)
            {
                player.extraAccessorySlots = 1;

                if (etherialSlot)
                    player.extraAccessorySlots = 2;
            }
            else if (etherialSlot)
                player.extraAccessorySlots = 2;

            if (!player.extraAccessory && !etherialSlot)
                player.extraAccessorySlots = 0;

            SnowDamage = 1f;
            DebuffMult = 1f;

        }

        public override void CatchFish(Item fishingRod, Item bait, int power, int liquidType, int poolSize, int worldLayer, int questFish, ref int caughtType, ref bool junk)
        {


            if (zoneObsidium && liquidType == 1 && fishingRod.type == ItemID.HotlineFishingHook)
            {
                if (Main.rand.Next(3) == 0)
                {
                    int rand = Main.rand.Next(6);

                    switch (rand)
                    {
                        case 0:
                            caughtType = ItemID.Topaz;
                            break;
                        case 1:
                            caughtType = ItemID.Amethyst;
                            break;
                        case 2:
                            caughtType = ItemID.Sapphire;
                            break;
                        case 3:
                            caughtType = ItemID.Emerald;
                            break;
                        case 4:
                            caughtType = ItemID.Ruby;
                            break;
                        default:
                            caughtType = ItemID.Diamond;
                            break;
                    }
                }

                if (junk)
                {
                    caughtType = ItemID.Obsidian;
                    return;
                }
            }
        }
        private void PostAccessories()
        {
            if (Verdi > 0)
                player.maxRunSpeed += .1f;
        }



        private void BlazeEffect()
        {
            foreach (NPC NPC in Main.NPC)
            {
                float range = 120;
                if (NPC.active && !NPC.friendly && (NPC.damage > 0 || NPC.type == NPCID.TargetDummy) && !NPC.dontTakeDamage && !NPC.buffImmune[ModContent.BuffType.Frostburn] && Vector2.Distance(player.Center, NPC.Center) <= range)
                {
                    if (NPC.FindBuffIndex(ModContent.BuffType.OnFire) == -1)
                    {
                        NPC.AddBuff(ModContent.BuffType.OnFire, 2 * 60, false);
                    }
                }
            }
        }

        public override void ModifyWeaponDamage(Item item, ref float add, ref float mult, ref float flat)
        {
            if (Item.ammo == AmmoID.Snowball)
                mult = mult * SnowDamage;

            base.ModifyWeaponDamage(item, ref add, ref mult, ref flat);
        }

        public override TagCompound Save()
        {
            TagCompound tag = new TagCompound {
                {"Class", Class },
                {"Etherial", etherial },
                {"ESlot", etherialSlot },
                {"SoulStoneMove", SoulStoneMovement },
                {"SoulStoneVis", SoulStoneVisuals },
                {"Inferno", inf},
                {"Calming", calm},
                {"WaterWalking", ww},
                {"Battle", battle},
                {"Hunter", hunter},
                {"Spelunker", spelunker},
                {"NightOwl", owl},
                {"Dangersense", danger},
                {"Featherfall", feather},
                {"BysmalAbsorbDisabled", BysmalAbsorbDisabled},
            };

            return tag;
        }


        public override void Load(TagCompound tag)
        {
            Class = tag.GetInt("Class");
            etherial = tag.GetBool("Etherial");
            etherialSlot = tag.GetBool("ESlot");
            SoulStoneMovement = tag.GetBool("SoulStoneMove");
            SoulStoneVisuals = tag.GetBool("SoulStoneVis");
            inf = tag.GetBool("Inferno");
            calm = tag.GetBool("Calming");
            ww = tag.GetBool("WaterWalking");
            battle = tag.GetBool("Battle");
            hunter = tag.GetBool("Hunter");
            spelunker = tag.GetBool("Spelunker");
            owl = tag.GetBool("NightOwl");
            danger = tag.GetBool("Dangersense");
            feather = tag.GetBool("Featherfall");
            string focus = tag.GetString("Focus");

        }

        public override bool CustomBiomesMatch(Player other)
        {
            LaugicalityPlayer modOther = LaugicalityPlayer.Get(other);
            return zoneObsidium == modOther.zoneObsidium;
        }

        public override void CopyCustomBiomesTo(Player other)
        {
            LaugicalityPlayer modOther = LaugicalityPlayer.Get(other);
            modOther.zoneObsidium = zoneObsidium;
        }

        public override void SendCustomBiomes(BinaryWriter writer)
        {
            BitsByte flags = new BitsByte();
            flags[0] = zoneObsidium;
            writer.Write(flags);
        }

        public override void ReceiveCustomBiomes(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            zoneObsidium = flags[0];
        }

        public override Texture2D GetMapBackgroundImage()
        {
            if (zoneObsidium)
                return mod.GetTexture("Backgrounds/ObsidiumBiomeMapBackground");

            return null;
        }

        public override void UpdateDead()
        {
            Electrified = false;
        }

        /// <summary>
        /// Refactor This to be short
        /// </summary>


        public override bool PreItemCheck()
        {
            if (TrueCurse)
                return false;

            return true;
        }

        /// <summary>
        /// TODO Refactor This to be short
        /// </summary>

        private void FindChests(ref List<Item> items, ref List<int> types, ref List<int> positions)
        {
            foreach (Chest chest in Main.chest)
            {
                if (chest == null)
                    continue;

                if (Distance(player.position.X, player.position.Y, chest.x * 16, chest.y * 16) < 200)
                {
                    Restock(chest, ref items, ref types, ref positions);
                }
            }
        }

        private void Restock(Chest chest, ref List<Item> items, ref List<int> types, ref List<int> positions)
        {
            foreach (Item chestItem in chest.item)
            {
                if (types.Contains(chestItem.type) && chestItem.stack > 1)
                {
                    while (chestItem.stack > 1 && FindFirst(types, items, chestItem).stack < FindFirst(types, items, chestItem).maxStack)
                    {
                        if ((chestItem.stack - 1) - (FindFirst(types, items, chestItem).maxStack - FindFirst(types, items, chestItem).stack) >= 0)
                        {
                            chestItem.stack -= (FindFirst(types, items, chestItem).maxStack - FindFirst(types, items, chestItem).stack);
                            FindFirst(types, items, chestItem).stack = FindFirst(types, items, chestItem).maxStack;
                            player.inventory[positions[items.IndexOf(FindFirst(types, items, chestItem))]].stack = FindFirst(types, items, chestItem).stack;
                            positions.RemoveAt(items.IndexOf(FindFirst(types, items, chestItem)));
                            types.Remove(chestItem.type);
                            items.Remove(chestItem);
                        }
                        else
                        {
                            FindFirst(types, items, chestItem).stack += chestItem.stack - 1;
                            player.inventory[positions[items.IndexOf(FindFirst(types, items, chestItem))]].stack = FindFirst(types, items, chestItem).stack;
                            chestItem.stack = 1;
                        }

                        if (FindFirst(types, items, chestItem) == null)
                            break;
                    }
                }
            }
        }

        private Item FindFirst(List<int> types, List<Item> items, Item findItem)
        {
            foreach (int item in types)
            {
                if (item == findItem.type)
                    return items[types.IndexOf(item)];
            }
            return null;
        }

        private void ListChestElements(Chest chest)
        {
            string output = "Chest contains: ";
            foreach (Item chestItem in chest.item)
            {
                if (chestItem != null)
                    output += chestItem.Name + ", ";
            }
            Main.NewText(output, 250, 250, 250);
        }

        private void ListItems(List<Item> items)
        {
            string output = "Current items: ";
            foreach (Item item in items)
            {
                if (item != null)
                    output += item.Name + ", ";
            }
            Main.NewText(output, 250, 250, 250);
        }

        public float Distance(float x1, float y1, float x2, float y2)
        {
            return (float)Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
        }

        private void SpawnSpore()
        {
            Projectile.NewProjectileDirect(player.Center.X, player.Center.Y, 6 - Main.rand.Next(12), 6 - Main.rand.Next(12), 567, 48,
                3f, player.whoAmI);

            Projectile.NewProjectileDirect(player.Center.X, player.Center.Y, 6 - Main.rand.Next(12), 6 - Main.rand.Next(12), 568, 48,
                3f, player.whoAmI);

            Projectile.NewProjectileDirect(player.Center.X, player.Center.Y, 6 - Main.rand.Next(12), 6 - Main.rand.Next(12), 569, 48,
                3f, player.whoAmI);

            Projectile.NewProjectileDirect(player.Center.X, player.Center.Y, 6 - Main.rand.Next(12), 6 - Main.rand.Next(12), 570, 48,
                3f, player.whoAmI);
            if (Main.rand.Next(0, 2) == 0)
                Projectile.NewProjectileDirect(player.Center.X, player.Center.Y, 6 - Main.rand.Next(12), 6 - Main.rand.Next(12), 571,
                    48, 3f, player.whoAmI);

            if (Main.rand.Next(0, 2) == 0)
                Projectile.NewProjectileDirect(player.Center.X, player.Center.Y, 6 - Main.rand.Next(12), 6 - Main.rand.Next(12), 567,
                    48, 3f, player.whoAmI);
        }

        public void DamageBoost(float amount)
        {
            player.allDamage += amount;
        }

        public void CritBoost(int amount)
        {
            player.meleeCrit += amount;
            player.magicCrit += amount;
            player.thrownCrit += amount;
            player.rangedCrit += amount;
        }

        public float GetGlobalDamage()
        {
            return player.allDamage;
        }

        #region Buffs

        public const int MAX_BUFFS = 42;

        public bool Obsidium { get; set; }

        public bool Frost { get; set; }

        public bool Frigid { get; set; }

        public bool Frosty { get; set; }

        public bool Rocks { get; set; }

        public bool Sandy { get; set; }

        public bool TrueCurse { get; set; }

        public bool NoRegen { get; set; }

        public bool HalfDef { get; set; }

        public int Connected { get; set; }

        public int Verdi { get; set; }

        #endregion

        #region Summons
        public bool MoltenCoreSummon { get; set; }

        public bool TVSummon { get; set; }

        public bool SandSharkSummon { get; set; }

        public bool DartCopterSummon { get; set; }

        public bool RockTwinsSummon { get; set; }

        public bool ShroomCopterSummon { get; set; }

        public bool UltraBoisSummon { get; set; }

        public bool ArcticHydraSummon { get; set; }

        #endregion

        // TODO Change this to a class.
        #region Soul Stone

        public int Class { get; set; }

        public bool SoulStoneVisuals { get; set; } = true;

        public bool SoulStoneMovement { get; set; } = true;

        public bool SkeletonPrime { get; set; }

        public bool Doucheron { get; set; }

        public bool Electrified { get; set; }

        public bool Steamified { get; set; }

        public bool Mystified { get; set; }

        public bool ToyTrain { get; set; }

        public bool BloodRage { get; set; }

        public bool QueenBee { get; set; }

        public bool Eyes { get; set; }

        public bool Spores { get; set; }

        public bool Slimey { get; set; }

        public bool LosingLife { get; set; }

        #endregion // TODO Verify if name matches.
    }
}

*/