using NUnit.Framework;
using System.Collections.Generic;
using TreasureGen.Items;
using TreasureGen.Items.Mundane;

namespace TreasureGen.Tests.Integration.Stress.Items.Mundane
{
    [TestFixture]
    public class MundaneWeaponGeneratorTests : MundaneItemGeneratorStressTests
    {
        [SetUp]
        public void Setup()
        {
            mundaneItemGenerator = GetNewInstanceOf<MundaneItemGenerator>(ItemTypeConstants.Weapon);
        }

        [Test]
        public void StressWeapon()
        {
            Stress(StressItem);
        }

        protected override void MakeSpecificAssertionsAgainst(Item weapon)
        {
            Assert.That(weapon.Name, Is.Not.Empty);
            Assert.That(weapon.ItemType, Is.EqualTo(ItemTypeConstants.Weapon));
            Assert.That(weapon.Quantity, Is.Positive);
            Assert.That(weapon.IsMagical, Is.False);
            Assert.That(weapon.Attributes, Contains.Item(AttributeConstants.Common)
                .Or.Contains(AttributeConstants.Uncommon));
            Assert.That(weapon.Attributes, Contains.Item(AttributeConstants.Melee)
                .Or.Contains(AttributeConstants.Ranged));
            Assert.That(weapon.Traits, Contains.Item(TraitConstants.Small)
                .Or.Contains(TraitConstants.Medium)
                .Or.Contains(TraitConstants.Large));
        }

        [Test]
        public override void SpecialMaterialsHappen()
        {
            base.SpecialMaterialsHappen();
        }

        [Test]
        public void MasterworkHappens()
        {
            var weapon = GenerateOrFail(GenerateItem, w => w.Traits.Contains(TraitConstants.Masterwork));
            AssertItem(weapon);
            Assert.That(weapon.Traits, Contains.Item(TraitConstants.Masterwork));
        }

        [Test]
        public override void NoDecorationsHappen()
        {
            AssertNoDecorationsHappen();
        }

        protected override IEnumerable<string> GetItemNames()
        {
            return new[]
            {
                WeaponConstants.Arrow,
                WeaponConstants.BastardSword,
                WeaponConstants.Battleaxe,
                WeaponConstants.Club,
                WeaponConstants.CompositePlus0Longbow,
                WeaponConstants.CompositePlus0Shortbow,
                WeaponConstants.CompositePlus1Longbow,
                WeaponConstants.CompositePlus1Shortbow,
                WeaponConstants.CompositePlus2Longbow,
                WeaponConstants.CompositePlus2Shortbow,
                WeaponConstants.CompositePlus3Longbow,
                WeaponConstants.CompositePlus4Longbow,
                WeaponConstants.CrossbowBolt,
                WeaponConstants.Dagger,
                WeaponConstants.Dart,
                WeaponConstants.DireFlail,
                WeaponConstants.DwarvenUrgrosh,
                WeaponConstants.DwarvenWaraxe,
                WeaponConstants.Falchion,
                WeaponConstants.Gauntlet,
                WeaponConstants.Glaive,
                WeaponConstants.GnomeHookedHammer,
                WeaponConstants.Greataxe,
                WeaponConstants.Greatclub,
                WeaponConstants.Greatsword,
                WeaponConstants.Guisarme,
                WeaponConstants.Halberd,
                WeaponConstants.Halfspear,
                WeaponConstants.Handaxe,
                WeaponConstants.HandCrossbow,
                WeaponConstants.HeavyCrossbow,
                WeaponConstants.HeavyFlail,
                WeaponConstants.HeavyMace,
                WeaponConstants.HeavyPick,
                WeaponConstants.HeavyRepeatingCrossbow,
                WeaponConstants.Javelin,
                WeaponConstants.Kama,
                WeaponConstants.Kukri,
                WeaponConstants.Lance,
                WeaponConstants.LightCrossbow,
                WeaponConstants.LightFlail,
                WeaponConstants.LightHammer,
                WeaponConstants.LightMace,
                WeaponConstants.LightPick,
                WeaponConstants.LightRepeatingCrossbow,
                WeaponConstants.Longbow,
                WeaponConstants.Longspear,
                WeaponConstants.Longsword,
                WeaponConstants.Morningstar,
                WeaponConstants.Net,
                WeaponConstants.Nunchaku,
                WeaponConstants.OrcDoubleAxe,
                WeaponConstants.PunchingDagger,
                WeaponConstants.Quarterstaff,
                WeaponConstants.Ranseur,
                WeaponConstants.Rapier,
                WeaponConstants.Sap,
                WeaponConstants.Scimitar,
                WeaponConstants.Scythe,
                WeaponConstants.Shortbow,
                WeaponConstants.Shortspear,
                WeaponConstants.ShortSword,
                WeaponConstants.Shuriken,
                WeaponConstants.Siangham,
                WeaponConstants.Sickle,
                WeaponConstants.Sling,
                WeaponConstants.SlingBullet,
                WeaponConstants.SpikedChain,
                WeaponConstants.SpikedGauntlet,
                WeaponConstants.ThrowingAxe,
                WeaponConstants.Trident,
                WeaponConstants.TwoBladedSword,
                WeaponConstants.Warhammer,
                WeaponConstants.Whip
            };
        }

        [Test]
        public void StressCustomWeapon()
        {
            Stress(StressCustomItem);
        }

        [Test]
        public void StressRandomCustomWeapon()
        {
            Stress(StressRandomCustomItem);
        }
    }
}