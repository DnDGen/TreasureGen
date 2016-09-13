using NUnit.Framework;
using System;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Tests.Unit.Generators.Items
{
    [TestFixture]
    public class ItemTests
    {
        private Item item;
        private ItemVerifier itemVerifier;

        [SetUp]
        public void Setup()
        {
            item = new Item();
            itemVerifier = new ItemVerifier();
        }

        [Test]
        public void ItemInitialized()
        {
            Assert.That(item.Name, Is.Empty);
            Assert.That(item.Attributes, Is.Empty);
            Assert.That(item.Magic, Is.Not.Null);
            Assert.That(item.Quantity, Is.EqualTo(1));
            Assert.That(item.Traits, Is.Empty);
            Assert.That(item.IsMagical, Is.False);
            Assert.That(item.CanBeUsedAsWeaponOrArmor, Is.False);
            Assert.That(item.Contents, Is.Empty);
            Assert.That(item.ItemType, Is.Empty);
        }

        [Test]
        public void IsMagicalTrueIfSetToTrue()
        {
            item.IsMagical = true;
            Assert.That(item.IsMagical, Is.True);
        }

        [Test]
        public void IsMagicalFalseIfSetToFalse()
        {
            item.IsMagical = true;
            item.IsMagical = false;
            Assert.That(item.IsMagical, Is.False);
        }

        [Test]
        public void IsMagicalTrueIfThereIsABonus()
        {
            item.Magic.Bonus = 1;
            Assert.That(item.IsMagical, Is.True);
        }

        [Test]
        public void IsMagicalTrueIfThereAreCharges()
        {
            item.Magic.Charges = 1;
            Assert.That(item.IsMagical, Is.True);
        }

        [Test]
        public void IsMagicalTrueIfThereIsACurse()
        {
            item.Magic.Curse = "curse";
            Assert.That(item.IsMagical, Is.True);
        }

        [Test]
        public void IsMagicalTrueIfThereIsIntelligenceWithEgo()
        {
            item.Magic.Intelligence.Ego = 1;
            Assert.That(item.IsMagical, Is.True);
        }

        [Test]
        public void IsMagicalTrueIfThereAreSpecialAbilities()
        {
            item.Magic.SpecialAbilities = new[] { new SpecialAbility() };
            Assert.That(item.IsMagical, Is.True);
        }

        [Test]
        public void CopyItem()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);
            template.ItemType = Guid.NewGuid().ToString();
            template.Magic.SpecialAbilities = new[]
            {
                new SpecialAbility { Name = Guid.NewGuid().ToString() },
                new SpecialAbility { Name = Guid.NewGuid().ToString() }
            };

            template.Attributes = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };

            var copy = template.Copy();
            itemVerifier.AssertMagicalItemFromTemplate(copy, template);
            Assert.That(copy.ItemType, Is.EqualTo(template.ItemType));
            Assert.That(copy.Magic.SpecialAbilities, Is.Empty);
            Assert.That(copy.Attributes, Is.EquivalentTo(template.Attributes));
        }

        [Test]
        public void CopyScroll()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);
            template.ItemType = ItemTypeConstants.Scroll;
            template.Magic.SpecialAbilities = new[]
            {
                new SpecialAbility { Name = Guid.NewGuid().ToString() },
                new SpecialAbility { Name = Guid.NewGuid().ToString() }
            };

            //INFO: All scrolls have a one-time use attribute, so this is appropriate for the use case
            template.Attributes = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), AttributeConstants.OneTimeUse };

            var copy = template.Copy();
            itemVerifier.AssertMagicalItemFromTemplate(copy, template);
            Assert.That(copy.ItemType, Is.EqualTo(ItemTypeConstants.Scroll));
            Assert.That(copy.Attributes, Is.EquivalentTo(template.Attributes));
            Assert.That(copy.Magic.Bonus, Is.EqualTo(0));
            Assert.That(copy.Magic.Charges, Is.EqualTo(0));
            Assert.That(copy.Magic.Intelligence.Alignment, Is.Empty);
            Assert.That(copy.Magic.Intelligence.CharismaStat, Is.EqualTo(0));
            Assert.That(copy.Magic.Intelligence.Communication, Is.Empty);
            Assert.That(copy.Magic.Intelligence.DedicatedPower, Is.Empty);
            Assert.That(copy.Magic.Intelligence.Ego, Is.EqualTo(0));
            Assert.That(copy.Magic.Intelligence.IntelligenceStat, Is.EqualTo(0));
            Assert.That(copy.Magic.Intelligence.Languages, Is.Empty);
            Assert.That(copy.Magic.Intelligence.Personality, Is.Empty);
            Assert.That(copy.Magic.Intelligence.Powers, Is.Empty);
            Assert.That(copy.Magic.Intelligence.Senses, Is.Empty);
            Assert.That(copy.Magic.Intelligence.SpecialPurpose, Is.Empty);
            Assert.That(copy.Magic.Intelligence.WisdomStat, Is.EqualTo(0));
            Assert.That(copy.Magic.SpecialAbilities, Is.Empty);
        }

        [Test]
        public void CopyOneTimeUseItem()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);
            template.ItemType = Guid.NewGuid().ToString();
            template.Magic.SpecialAbilities = new[]
            {
                new SpecialAbility { Name = Guid.NewGuid().ToString() },
                new SpecialAbility { Name = Guid.NewGuid().ToString() }
            };

            template.Attributes = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), AttributeConstants.OneTimeUse };

            var copy = template.Copy();
            itemVerifier.AssertMagicalItemFromTemplate(copy, template);
            Assert.That(copy.ItemType, Is.EqualTo(template.ItemType));
            Assert.That(copy.Attributes, Is.EquivalentTo(template.Attributes));
            Assert.That(copy.Magic.Intelligence.Alignment, Is.Empty);
            Assert.That(copy.Magic.Intelligence.CharismaStat, Is.EqualTo(0));
            Assert.That(copy.Magic.Intelligence.Communication, Is.Empty);
            Assert.That(copy.Magic.Intelligence.DedicatedPower, Is.Empty);
            Assert.That(copy.Magic.Intelligence.Ego, Is.EqualTo(0));
            Assert.That(copy.Magic.Intelligence.IntelligenceStat, Is.EqualTo(0));
            Assert.That(copy.Magic.Intelligence.Languages, Is.Empty);
            Assert.That(copy.Magic.Intelligence.Personality, Is.Empty);
            Assert.That(copy.Magic.Intelligence.Powers, Is.Empty);
            Assert.That(copy.Magic.Intelligence.Senses, Is.Empty);
            Assert.That(copy.Magic.Intelligence.SpecialPurpose, Is.Empty);
            Assert.That(copy.Magic.Intelligence.WisdomStat, Is.EqualTo(0));
        }

        [Test]
        public void CopyAmmunition()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);
            template.ItemType = ItemTypeConstants.Weapon;
            template.Magic.SpecialAbilities = new[]
            {
                new SpecialAbility { Name = Guid.NewGuid().ToString() },
                new SpecialAbility { Name = Guid.NewGuid().ToString() }
            };

            template.Attributes = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), AttributeConstants.Ammunition };

            var copy = template.Copy();
            itemVerifier.AssertMagicalItemFromTemplate(copy, template);
            Assert.That(copy.ItemType, Is.EqualTo(template.ItemType));
            Assert.That(copy.Attributes, Is.EquivalentTo(template.Attributes));
            Assert.That(copy.Magic.Intelligence.Alignment, Is.Empty);
            Assert.That(copy.Magic.Intelligence.CharismaStat, Is.EqualTo(0));
            Assert.That(copy.Magic.Intelligence.Communication, Is.Empty);
            Assert.That(copy.Magic.Intelligence.DedicatedPower, Is.Empty);
            Assert.That(copy.Magic.Intelligence.Ego, Is.EqualTo(0));
            Assert.That(copy.Magic.Intelligence.IntelligenceStat, Is.EqualTo(0));
            Assert.That(copy.Magic.Intelligence.Languages, Is.Empty);
            Assert.That(copy.Magic.Intelligence.Personality, Is.Empty);
            Assert.That(copy.Magic.Intelligence.Powers, Is.Empty);
            Assert.That(copy.Magic.Intelligence.Senses, Is.Empty);
            Assert.That(copy.Magic.Intelligence.SpecialPurpose, Is.Empty);
            Assert.That(copy.Magic.Intelligence.WisdomStat, Is.EqualTo(0));
            Assert.That(copy.Magic.SpecialAbilities, Is.EquivalentTo(template.Magic.SpecialAbilities));
        }

        [Test]
        public void CopyPotion()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);
            template.ItemType = ItemTypeConstants.Potion;
            template.Magic.SpecialAbilities = new[]
            {
                new SpecialAbility { Name = Guid.NewGuid().ToString() },
                new SpecialAbility { Name = Guid.NewGuid().ToString() }
            };

            //INFO: All potions have a one-time use attribute, so this is appropriate for the use case
            template.Attributes = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), AttributeConstants.OneTimeUse };

            var copy = template.Copy();
            itemVerifier.AssertMagicalItemFromTemplate(copy, template);
            Assert.That(copy.ItemType, Is.EqualTo(ItemTypeConstants.Potion));
            Assert.That(copy.Attributes, Is.EquivalentTo(template.Attributes));
            Assert.That(copy.Magic.Intelligence.Alignment, Is.Empty);
            Assert.That(copy.Magic.Intelligence.CharismaStat, Is.EqualTo(0));
            Assert.That(copy.Magic.Intelligence.Communication, Is.Empty);
            Assert.That(copy.Magic.Intelligence.DedicatedPower, Is.Empty);
            Assert.That(copy.Magic.Intelligence.Ego, Is.EqualTo(0));
            Assert.That(copy.Magic.Intelligence.IntelligenceStat, Is.EqualTo(0));
            Assert.That(copy.Magic.Intelligence.Languages, Is.Empty);
            Assert.That(copy.Magic.Intelligence.Personality, Is.Empty);
            Assert.That(copy.Magic.Intelligence.Powers, Is.Empty);
            Assert.That(copy.Magic.Intelligence.Senses, Is.Empty);
            Assert.That(copy.Magic.Intelligence.SpecialPurpose, Is.Empty);
            Assert.That(copy.Magic.Intelligence.WisdomStat, Is.EqualTo(0));
        }

        [Test]
        public void CopyWand()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);
            template.ItemType = ItemTypeConstants.Wand;
            template.Magic.SpecialAbilities = new[]
            {
                new SpecialAbility { Name = Guid.NewGuid().ToString() },
                new SpecialAbility { Name = Guid.NewGuid().ToString() }
            };

            //INFO: All potions have a one-time use attribute, so this is appropriate for the use case
            template.Attributes = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), AttributeConstants.OneTimeUse };

            var copy = template.Copy();
            itemVerifier.AssertMagicalItemFromTemplate(copy, template);
            Assert.That(copy.ItemType, Is.EqualTo(ItemTypeConstants.Wand));
            Assert.That(copy.Attributes, Is.EquivalentTo(template.Attributes));
            Assert.That(copy.Contents, Is.Empty);
            Assert.That(copy.Magic.Bonus, Is.EqualTo(0));
            Assert.That(copy.Magic.Intelligence.Alignment, Is.Empty);
            Assert.That(copy.Magic.Intelligence.CharismaStat, Is.EqualTo(0));
            Assert.That(copy.Magic.Intelligence.Communication, Is.Empty);
            Assert.That(copy.Magic.Intelligence.DedicatedPower, Is.Empty);
            Assert.That(copy.Magic.Intelligence.Ego, Is.EqualTo(0));
            Assert.That(copy.Magic.Intelligence.IntelligenceStat, Is.EqualTo(0));
            Assert.That(copy.Magic.Intelligence.Languages, Is.Empty);
            Assert.That(copy.Magic.Intelligence.Personality, Is.Empty);
            Assert.That(copy.Magic.Intelligence.Powers, Is.Empty);
            Assert.That(copy.Magic.Intelligence.Senses, Is.Empty);
            Assert.That(copy.Magic.Intelligence.SpecialPurpose, Is.Empty);
            Assert.That(copy.Magic.Intelligence.WisdomStat, Is.EqualTo(0));
            Assert.That(copy.Magic.SpecialAbilities, Is.Empty);
        }

        [TestCase(ItemTypeConstants.Armor)]
        [TestCase(ItemTypeConstants.Weapon)]
        public void CopyWeaponOrArmor(string itemType)
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);
            template.ItemType = itemType;
            template.Magic.SpecialAbilities = new[]
            {
                new SpecialAbility { Name = Guid.NewGuid().ToString() },
                new SpecialAbility { Name = Guid.NewGuid().ToString() }
            };

            template.Attributes = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };

            var copy = template.Copy();
            itemVerifier.AssertMagicalItemFromTemplate(copy, template);
            Assert.That(copy.ItemType, Is.EqualTo(template.ItemType));
            Assert.That(copy.Magic.SpecialAbilities, Is.EquivalentTo(template.Magic.SpecialAbilities));
            Assert.That(copy.Attributes, Is.EquivalentTo(template.Attributes));
        }

        [TestCase(StaffConstants.Power)]
        [TestCase(RodConstants.Alertness)]
        [TestCase(RodConstants.Flailing)]
        [TestCase(RodConstants.Python)]
        [TestCase(RodConstants.ThunderAndLightning)]
        [TestCase(RodConstants.Viper)]
        [TestCase(RodConstants.Withering)]
        public void CopyNamedItem(string name)
        {
            var template = itemVerifier.CreateRandomTemplate(name);
            template.ItemType = Guid.NewGuid().ToString();
            template.Magic.SpecialAbilities = new[]
            {
                new SpecialAbility { Name = Guid.NewGuid().ToString() },
                new SpecialAbility { Name = Guid.NewGuid().ToString() }
            };

            template.Attributes = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };

            var copy = template.Copy();
            itemVerifier.AssertMagicalItemFromTemplate(copy, template);
            Assert.That(copy.ItemType, Is.EqualTo(template.ItemType));
            Assert.That(copy.Magic.SpecialAbilities, Is.EquivalentTo(template.Magic.SpecialAbilities));
            Assert.That(copy.Attributes, Is.EquivalentTo(template.Attributes));
        }

        [Test]
        public void CopyItemWithoutMagic()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);
            template.ItemType = Guid.NewGuid().ToString();
            template.Magic.SpecialAbilities = new[]
            {
                new SpecialAbility { Name = Guid.NewGuid().ToString() },
                new SpecialAbility { Name = Guid.NewGuid().ToString() }
            };

            template.Attributes = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };

            var copy = template.CopyWithoutMagic();
            itemVerifier.AssertMundaneItemFromTemplate(copy, template);
            Assert.That(copy.ItemType, Is.EqualTo(template.ItemType));
            Assert.That(copy.Attributes, Is.EquivalentTo(template.Attributes));
        }

        [TestCase(ItemTypeConstants.Armor)]
        [TestCase(ItemTypeConstants.Weapon)]
        public void ItemTypeCanBeUsedAsWeaponOrArmor(string itemType)
        {
            item.ItemType = itemType;
            Assert.That(item.CanBeUsedAsWeaponOrArmor, Is.True);
        }

        [TestCase(ItemTypeConstants.AlchemicalItem)]
        [TestCase(ItemTypeConstants.LivingCreature)]
        [TestCase(ItemTypeConstants.Potion)]
        [TestCase(ItemTypeConstants.Ring)]
        [TestCase(ItemTypeConstants.Rod)]
        [TestCase(ItemTypeConstants.Scroll)]
        [TestCase(ItemTypeConstants.Staff)]
        [TestCase(ItemTypeConstants.Tool)]
        [TestCase(ItemTypeConstants.Wand)]
        [TestCase(ItemTypeConstants.WondrousItem)]
        public void ItemTypeCannotBeUsedAsWeaponOrArmor(string itemType)
        {
            item.ItemType = itemType;
            Assert.That(item.CanBeUsedAsWeaponOrArmor, Is.False);
        }

        [TestCase(StaffConstants.Power)]
        [TestCase(RodConstants.Alertness)]
        [TestCase(RodConstants.Flailing)]
        [TestCase(RodConstants.Python)]
        [TestCase(RodConstants.ThunderAndLightning)]
        [TestCase(RodConstants.Viper)]
        [TestCase(RodConstants.Withering)]
        public void NamedItemCanBeUsedAsWeaponOrArmor(string name)
        {
            item.Name = name;
            Assert.That(item.CanBeUsedAsWeaponOrArmor, Is.True);
        }

        [TestCase("random name")]
        [TestCase(StaffConstants.Abjuration)]
        [TestCase(StaffConstants.Charming)]
        [TestCase(StaffConstants.Conjuration)]
        [TestCase(StaffConstants.Defense)]
        [TestCase(StaffConstants.Divination)]
        [TestCase(StaffConstants.EarthAndStone)]
        [TestCase(StaffConstants.Enchantment)]
        [TestCase(StaffConstants.Evocation)]
        [TestCase(StaffConstants.Fire)]
        [TestCase(StaffConstants.Frost)]
        [TestCase(StaffConstants.Healing)]
        [TestCase(StaffConstants.Illumination)]
        [TestCase(StaffConstants.Illusion)]
        [TestCase(StaffConstants.Life)]
        [TestCase(StaffConstants.Necromancy)]
        [TestCase(StaffConstants.Passage)]
        [TestCase(StaffConstants.SizeAlteration)]
        [TestCase(StaffConstants.SwarmingInsects)]
        [TestCase(StaffConstants.Transmutation)]
        [TestCase(StaffConstants.Woodlands)]
        [TestCase(RodConstants.Absorption)]
        [TestCase(RodConstants.Cancellation)]
        [TestCase(RodConstants.EnemyDetection)]
        [TestCase(RodConstants.FlameExtinguishing)]
        [TestCase(RodConstants.ImmovableRod)]
        [TestCase(RodConstants.LordlyMight)]
        [TestCase(RodConstants.MetalAndMineralDetection)]
        [TestCase(RodConstants.Metamagic_Empower)]
        [TestCase(RodConstants.Metamagic_Empower_Greater)]
        [TestCase(RodConstants.Metamagic_Empower_Lesser)]
        [TestCase(RodConstants.Metamagic_Enlarge)]
        [TestCase(RodConstants.Metamagic_Enlarge_Greater)]
        [TestCase(RodConstants.Metamagic_Enlarge_Lesser)]
        [TestCase(RodConstants.Metamagic_Extend)]
        [TestCase(RodConstants.Metamagic_Extend_Greater)]
        [TestCase(RodConstants.Metamagic_Extend_Lesser)]
        [TestCase(RodConstants.Metamagic_Maximize)]
        [TestCase(RodConstants.Metamagic_Maximize_Greater)]
        [TestCase(RodConstants.Metamagic_Maximize_Lesser)]
        [TestCase(RodConstants.Metamagic_Quicken)]
        [TestCase(RodConstants.Metamagic_Quicken_Greater)]
        [TestCase(RodConstants.Metamagic_Quicken_Lesser)]
        [TestCase(RodConstants.Metamagic_Silent)]
        [TestCase(RodConstants.Metamagic_Silent_Greater)]
        [TestCase(RodConstants.Metamagic_Silent_Lesser)]
        [TestCase(RodConstants.Negation)]
        [TestCase(RodConstants.Rulership)]
        [TestCase(RodConstants.Security)]
        [TestCase(RodConstants.Splendor)]
        [TestCase(RodConstants.Wonder)]
        public void NamedItemCannotBeUsedAsWeaponOrArmor(string name)
        {
            item.Name = name;
            Assert.That(item.CanBeUsedAsWeaponOrArmor, Is.False);
        }
    }
}