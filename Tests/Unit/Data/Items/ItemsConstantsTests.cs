using EquipmentGen.Core.Data.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Data.Items
{
    [TestFixture]
    public class ItemsConstantsTests
    {
        [Test]
        public void MundanePowerConstant()
        {
            Assert.That(ItemsConstants.Power.Mundane, Is.EqualTo("Mundane"));
        }

        [Test]
        public void MinorPowerConstant()
        {
            Assert.That(ItemsConstants.Power.Minor, Is.EqualTo("Minor"));
        }

        [Test]
        public void MediumPowerConstant()
        {
            Assert.That(ItemsConstants.Power.Medium, Is.EqualTo("Medium"));
        }

        [Test]
        public void MajorPowerConstant()
        {
            Assert.That(ItemsConstants.Power.Major, Is.EqualTo("Major"));
        }

        [Test]
        public void AlchemicalItemTypeConstant()
        {
            Assert.That(ItemsConstants.ItemTypes.AlchemicalItem, Is.EqualTo("Alchemical Item"));
        }

        [Test]
        public void ArmorItemTypeConstant()
        {
            Assert.That(ItemsConstants.ItemTypes.Armor, Is.EqualTo("Armor"));
        }

        [Test]
        public void WeaponItemTypeConstant()
        {
            Assert.That(ItemsConstants.ItemTypes.Weapon, Is.EqualTo("Weapon"));
        }

        [Test]
        public void ToolItemTypeConstant()
        {
            Assert.That(ItemsConstants.ItemTypes.Tool, Is.EqualTo("Tool"));
        }

        [Test]
        public void MasterworkGearTraitConstant()
        {
            Assert.That(ItemsConstants.Gear.Traits.Masterwork, Is.EqualTo("Masterwork"));
        }

        [Test]
        public void DarkwoodGearTraitConstant()
        {
            Assert.That(ItemsConstants.Gear.Traits.Darkwood, Is.EqualTo("Darkwood"));
        }

        [Test]
        public void SmallGearTraitConstant()
        {
            Assert.That(ItemsConstants.Gear.Traits.Small, Is.EqualTo("Small"));
        }

        [Test]
        public void MediumGearTraitConstant()
        {
            Assert.That(ItemsConstants.Gear.Traits.Medium, Is.EqualTo("Medium"));
        }

        [Test]
        public void PotionItemTypeConstant()
        {
            Assert.That(ItemsConstants.ItemTypes.Potion, Is.EqualTo("Potion"));
        }

        [Test]
        public void RingItemTypeConstant()
        {
            Assert.That(ItemsConstants.ItemTypes.Ring, Is.EqualTo("Ring"));
        }

        [Test]
        public void RodItemTypeConstant()
        {
            Assert.That(ItemsConstants.ItemTypes.Rod, Is.EqualTo("Rod"));
        }

        [Test]
        public void ScrollItemTypeConstant()
        {
            Assert.That(ItemsConstants.ItemTypes.Scroll, Is.EqualTo("Scroll"));
        }

        [Test]
        public void StaffItemTypeConstant()
        {
            Assert.That(ItemsConstants.ItemTypes.Staff, Is.EqualTo("Staff"));
        }

        [Test]
        public void WandItemTypeConstant()
        {
            Assert.That(ItemsConstants.ItemTypes.Wand, Is.EqualTo("Wand"));
        }

        [Test]
        public void WondrousItemTypeConstant()
        {
            Assert.That(ItemsConstants.ItemTypes.WondrousItem, Is.EqualTo("Wondrous item"));
        }

        [Test]
        public void CommonMeleeWeaponTypeGearConstant()
        {
            Assert.That(ItemsConstants.Gear.Types.Common, Is.EqualTo("Common"));
        }

        [Test]
        public void UncommonWeaponTypeGearConstant()
        {
            Assert.That(ItemsConstants.Gear.Types.Uncommon, Is.EqualTo("Uncommon"));
        }

        [Test]
        public void WoodTypeGearConstant()
        {
            Assert.That(ItemsConstants.Gear.Types.Wood, Is.EqualTo("Wood"));
        }

        [Test]
        public void MetalTypeGearConstant()
        {
            Assert.That(ItemsConstants.Gear.Types.Metal, Is.EqualTo("Metal"));
        }

        [Test]
        public void DoubleWeaponTypeGearConstant()
        {
            Assert.That(ItemsConstants.Gear.Types.DoubleWeapon, Is.EqualTo("Double weapon"));
        }

        [Test]
        public void MeleeTypeGearConstant()
        {
            Assert.That(ItemsConstants.Gear.Types.Melee, Is.EqualTo("Melee"));
        }

        [Test]
        public void RangedTypeGearConstant()
        {
            Assert.That(ItemsConstants.Gear.Types.Ranged, Is.EqualTo("Ranged"));
        }

        [Test]
        public void PaddedArmorConstant()
        {
            Assert.That(ItemsConstants.Gear.Armor.PaddedArmor, Is.EqualTo("Padded armor"));
        }

        [Test]
        public void LeatherArmorConstant()
        {
            Assert.That(ItemsConstants.Gear.Armor.LeatherArmor, Is.EqualTo("Leather armor"));
        }

        [Test]
        public void StuddedLeatherArmorConstant()
        {
            Assert.That(ItemsConstants.Gear.Armor.StuddedLeatherArmor, Is.EqualTo("Studded leather armor"));
        }

        [Test]
        public void ChainShirtConstant()
        {
            Assert.That(ItemsConstants.Gear.Armor.ChainShirt, Is.EqualTo("Chain shirt"));
        }

        [Test]
        public void HideArmorConstant()
        {
            Assert.That(ItemsConstants.Gear.Armor.HideArmor, Is.EqualTo("Hide armor"));
        }

        [Test]
        public void ScaleMailConstant()
        {
            Assert.That(ItemsConstants.Gear.Armor.ScaleMail, Is.EqualTo("Scale mail"));
        }

        [Test]
        public void ChainmailConstant()
        {
            Assert.That(ItemsConstants.Gear.Armor.Chainmail, Is.EqualTo("Chainmail"));
        }

        [Test]
        public void BreastplateConstant()
        {
            Assert.That(ItemsConstants.Gear.Armor.Breastplate, Is.EqualTo("Breastplate"));
        }

        [Test]
        public void SplintMailConstant()
        {
            Assert.That(ItemsConstants.Gear.Armor.SplintMail, Is.EqualTo("Splint mail"));
        }

        [Test]
        public void BandedMailConstant()
        {
            Assert.That(ItemsConstants.Gear.Armor.BandedMail, Is.EqualTo("Banded mail"));
        }

        [Test]
        public void HalfPlateConstant()
        {
            Assert.That(ItemsConstants.Gear.Armor.HalfPlate, Is.EqualTo("Half-plate"));
        }

        [Test]
        public void FullPlateConstant()
        {
            Assert.That(ItemsConstants.Gear.Armor.FullPlate, Is.EqualTo("Full plate"));
        }

        [Test]
        public void BucklerConstant()
        {
            Assert.That(ItemsConstants.Gear.Armor.Buckler, Is.EqualTo("Buckler"));
        }

        [Test]
        public void LightWoodenShieldConstant()
        {
            Assert.That(ItemsConstants.Gear.Armor.LightWoodenShield, Is.EqualTo("Light wooden shield"));
        }

        [Test]
        public void LightSteelShieldConstant()
        {
            Assert.That(ItemsConstants.Gear.Armor.LightSteelShield, Is.EqualTo("Light steel shield"));
        }

        [Test]
        public void HeavyWoodenShieldConstant()
        {
            Assert.That(ItemsConstants.Gear.Armor.HeavyWoodenShield, Is.EqualTo("Heavy wooden shield"));
        }

        [Test]
        public void HeavySteelShieldConstant()
        {
            Assert.That(ItemsConstants.Gear.Armor.HeavySteelShield, Is.EqualTo("Heavy steel shield"));
        }

        [Test]
        public void TowerShieldConstant()
        {
            Assert.That(ItemsConstants.Gear.Armor.TowerShield, Is.EqualTo("Tower shield"));
        }

        [Test]
        public void AdamantineConstant()
        {
            Assert.That(ItemsConstants.Gear.Traits.Adamantine, Is.EqualTo("Adamantine"));
        }

        [Test]
        public void DragonhideConstant()
        {
            Assert.That(ItemsConstants.Gear.Traits.Dragonhide, Is.EqualTo("Dragonhide"));
        }

        [Test]
        public void ColdIronConstant()
        {
            Assert.That(ItemsConstants.Gear.Traits.ColdIron, Is.EqualTo("Cold iron"));
        }

        [Test]
        public void MithralConstant()
        {
            Assert.That(ItemsConstants.Gear.Traits.Mithral, Is.EqualTo("Mithral"));
        }

        [Test]
        public void AlchemicalSilverConstant()
        {
            Assert.That(ItemsConstants.Gear.Traits.AlchemicalSilver, Is.EqualTo("Alchemical silver"));
        }

        [Test]
        public void DaggerConstant()
        {
            Assert.That(ItemsConstants.Gear.Weapons.Dagger, Is.EqualTo("Dagger"));
        }

        [Test]
        public void GreataxeConstant()
        {
            Assert.That(ItemsConstants.Gear.Weapons.Greataxe, Is.EqualTo("Greataxe"));
        }

        [Test]
        public void GreatswordConstant()
        {
            Assert.That(ItemsConstants.Gear.Weapons.Greatsword, Is.EqualTo("Greatsword"));
        }

        [Test]
        public void KamaConstant()
        {
            Assert.That(ItemsConstants.Gear.Weapons.Kama, Is.EqualTo("Kama"));
        }

        [Test]
        public void LongswordConstant()
        {
            Assert.That(ItemsConstants.Gear.Weapons.Longsword, Is.EqualTo("Longsword"));
        }

        [Test]
        public void LightMaceConstant()
        {
            Assert.That(ItemsConstants.Gear.Weapons.LightMace, Is.EqualTo("Light mace"));
        }

        [Test]
        public void HeavyMaceConstant()
        {
            Assert.That(ItemsConstants.Gear.Weapons.HeavyMace, Is.EqualTo("Heavy mace"));
        }

        [Test]
        public void NunchakuConstant()
        {
            Assert.That(ItemsConstants.Gear.Weapons.Nunchaku, Is.EqualTo("Nunchaku"));
        }

        [Test]
        public void QuarterstaffConstant()
        {
            Assert.That(ItemsConstants.Gear.Weapons.Quarterstaff, Is.EqualTo("Quarterstaff"));
        }

        [Test]
        public void RapierConstant()
        {
            Assert.That(ItemsConstants.Gear.Weapons.Rapier, Is.EqualTo("Rapier"));
        }

        [Test]
        public void ScimitarConstant()
        {
            Assert.That(ItemsConstants.Gear.Weapons.Scimitar, Is.EqualTo("Scimitar"));
        }

        [Test]
        public void ShortspearConstant()
        {
            Assert.That(ItemsConstants.Gear.Weapons.Shortspear, Is.EqualTo("Shortspear"));
        }

        [Test]
        public void SianghamConstant()
        {
            Assert.That(ItemsConstants.Gear.Weapons.Siangham, Is.EqualTo("Siangham"));
        }

        [Test]
        public void BastardSwordConstant()
        {
            Assert.That(ItemsConstants.Gear.Weapons.BastardSword, Is.EqualTo("Bastard sword"));
        }

        [Test]
        public void ShortSwordConstant()
        {
            Assert.That(ItemsConstants.Gear.Weapons.ShortSword, Is.EqualTo("Short sword"));
        }

        [Test]
        public void DwarvenWaraxeConstant()
        {
            Assert.That(ItemsConstants.Gear.Weapons.DwarvenWaraxe, Is.EqualTo("Dwarven waraxe"));
        }

        [Test]
        public void OrcDoubleAxeConstant()
        {
            Assert.That(ItemsConstants.Gear.Weapons.OrcDoubleAxe, Is.EqualTo("Orc double axe"));
        }

        [Test]
        public void BattleaxeConstant()
        {
            Assert.That(ItemsConstants.Gear.Weapons.Battleaxe, Is.EqualTo("Battleaxe"));
        }

        [Test]
        public void SpikedChainConstant()
        {
            Assert.That(ItemsConstants.Gear.Weapons.SpikedChain, Is.EqualTo("Spiekd chain"));
        }

        [Test]
        public void ClubConstant()
        {
            Assert.That(ItemsConstants.Gear.Weapons.Club, Is.EqualTo("Club"));
        }

        [Test]
        public void HandCrossbowConstant()
        {
            Assert.That(ItemsConstants.Gear.Weapons.HandCrossbow, Is.EqualTo("Hand crossbow"));
        }

        [Test]
        public void RepeatingCrossbowConstant()
        {
            Assert.That(ItemsConstants.Gear.Weapons.RepeatingCrossbow, Is.EqualTo("Repeating crossbow"));
        }

        [Test]
        public void PunchingDaggerConstant()
        {
            Assert.That(ItemsConstants.Gear.Weapons.PunchingDagger, Is.EqualTo("Punching dagger"));
        }

        [Test]
        public void FalchionConstant()
        {
            Assert.That(ItemsConstants.Gear.Weapons.Falchion, Is.EqualTo("Falchion"));
        }
    }
}