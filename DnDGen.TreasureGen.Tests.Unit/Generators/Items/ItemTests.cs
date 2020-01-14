using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Magical;
using NUnit.Framework;
using System;

namespace DnDGen.TreasureGen.Tests.Unit.Generators.Items
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
            Assert.That(item.BaseNames, Is.Empty);
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
        public void SmartCloneItem()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);
            template.ItemType = Guid.NewGuid().ToString();

            template.Attributes = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };

            var copy = template.SmartClone();
            itemVerifier.AssertMagicalItemFromTemplate(copy, template);
            Assert.That(copy.ItemType, Is.EqualTo(template.ItemType));
            Assert.That(copy.Attributes, Is.EquivalentTo(template.Attributes));
        }

        [Test]
        public void SmartCloneItemIntoSpecifiedItem()
        {
            var clone = new Item();
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);
            template.ItemType = Guid.NewGuid().ToString();

            template.Attributes = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };

            var newClone = template.SmartCloneInto(clone);
            Assert.That(newClone, Is.EqualTo(clone));
            itemVerifier.AssertMagicalItemFromTemplate(clone, template);
            Assert.That(clone.ItemType, Is.EqualTo(template.ItemType));
            Assert.That(clone.Attributes, Is.EquivalentTo(template.Attributes));
        }

        [Test]
        public void SmartCloneScroll()
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

            var copy = template.SmartClone();
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
        public void SmartCloneOneTimeUseItem()
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

            var copy = template.SmartClone();
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
        public void SmartCloneAmmunition()
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

            var clone = template.SmartClone();
            itemVerifier.AssertMagicalItemFromTemplate(clone, template);
            Assert.That(clone.ItemType, Is.EqualTo(template.ItemType));
            Assert.That(clone.Attributes, Is.EquivalentTo(template.Attributes));
            Assert.That(clone.Magic.Intelligence.Alignment, Is.Empty);
            Assert.That(clone.Magic.Intelligence.CharismaStat, Is.EqualTo(0));
            Assert.That(clone.Magic.Intelligence.Communication, Is.Empty);
            Assert.That(clone.Magic.Intelligence.DedicatedPower, Is.Empty);
            Assert.That(clone.Magic.Intelligence.Ego, Is.EqualTo(0));
            Assert.That(clone.Magic.Intelligence.IntelligenceStat, Is.EqualTo(0));
            Assert.That(clone.Magic.Intelligence.Languages, Is.Empty);
            Assert.That(clone.Magic.Intelligence.Personality, Is.Empty);
            Assert.That(clone.Magic.Intelligence.Powers, Is.Empty);
            Assert.That(clone.Magic.Intelligence.Senses, Is.Empty);
            Assert.That(clone.Magic.Intelligence.SpecialPurpose, Is.Empty);
            Assert.That(clone.Magic.Intelligence.WisdomStat, Is.EqualTo(0));
            Assert.That(clone.Magic.SpecialAbilities, Is.EquivalentTo(template.Magic.SpecialAbilities));
        }

        [Test]
        public void SmartClonePotion()
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

            var copy = template.SmartClone();
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
        public void SmartCloneWand()
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

            var copy = template.SmartClone();
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

        [Test]
        public void MundaneCloneItem()
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

            var copy = template.MundaneClone();
            itemVerifier.AssertMundaneItemFromTemplate(copy, template);
            Assert.That(copy.ItemType, Is.EqualTo(template.ItemType));
            Assert.That(copy.Attributes, Is.EquivalentTo(template.Attributes));
            Assert.That(copy.Magic.SpecialAbilities, Is.Empty);
        }

        [Test]
        public void MundaneCloneItemIntoSpecifiedItem()
        {
            var clone = new Item();
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);
            template.ItemType = Guid.NewGuid().ToString();
            template.Magic.SpecialAbilities = new[]
            {
                new SpecialAbility { Name = Guid.NewGuid().ToString() },
                new SpecialAbility { Name = Guid.NewGuid().ToString() }
            };

            template.Attributes = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };

            var newClone = template.MundaneCloneInto(clone);

            Assert.That(newClone, Is.EqualTo(clone));
            itemVerifier.AssertMundaneItemFromTemplate(clone, template);
            Assert.That(clone.ItemType, Is.EqualTo(template.ItemType));
            Assert.That(clone.Attributes, Is.EquivalentTo(template.Attributes));
            Assert.That(clone.Magic.SpecialAbilities, Is.Empty);
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

        [Test]
        public void NamedWeaponCanBeUsedAsWeaponOrArmor()
        {
            var allWeapons = WeaponConstants.GetAllWeapons();
            foreach (var weapon in allWeapons)
            {
                item.Name = weapon;
                item.BaseNames = new[] { "base name", "other base name" };
                Assert.That(item.CanBeUsedAsWeaponOrArmor, Is.True, weapon);
            }
        }

        [Test]
        public void NamedArmorCanBeUsedAsWeaponOrArmor()
        {
            var allArmors = ArmorConstants.GetAllArmors(true);
            foreach (var armor in allArmors)
            {
                item.Name = armor;
                item.BaseNames = new[] { "base name", "other base name" };
                Assert.That(item.CanBeUsedAsWeaponOrArmor, Is.True, armor);
            }
        }

        [Test]
        public void RandomNameCannotBeUsedAsWeaponOrArmor()
        {
            item.Name = "random name";
            Assert.That(item.CanBeUsedAsWeaponOrArmor, Is.False);
        }

        [Test]
        public void BaseNamedWeaponCanBeUsedAsWeaponOrArmor()
        {
            var allWeapons = WeaponConstants.GetAllWeapons();
            foreach (var weapon in allWeapons)
            {
                item.Name = "random name";
                item.BaseNames = new[] { "base name", weapon, "other base name" };
                Assert.That(item.CanBeUsedAsWeaponOrArmor, Is.True, weapon);
            }
        }

        [Test]
        public void BaseNamedArmorCanBeUsedAsWeaponOrArmor()
        {
            var allArmors = ArmorConstants.GetAllArmors(true);
            foreach (var armor in allArmors)
            {
                item.Name = "random name";
                item.BaseNames = new[] { "base name", armor, "other base name" };
                Assert.That(item.CanBeUsedAsWeaponOrArmor, Is.True, armor);
            }
        }

        [Test]
        public void RandomBaseNameCannotBeUsedAsWeaponOrArmor()
        {
            item.Name = "random name";
            item.BaseNames = new[] { "base name", "other base name" };
            Assert.That(item.CanBeUsedAsWeaponOrArmor, Is.False);
        }

        [TestCase(ItemTypeConstants.Armor)]
        [TestCase(ItemTypeConstants.Weapon)]
        public void SmartCloneWithItemTypeCanBeUsedAsWeaponOrArmor(string itemType)
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);
            template.ItemType = itemType;

            var clone = template.SmartClone();
            Assert.That(clone, Is.Not.EqualTo(template));
            Assert.That(clone.Name, Is.EqualTo(template.Name));
            Assert.That(clone.BaseNames, Is.EquivalentTo(template.BaseNames));

            Assert.That(clone.Attributes, Is.EquivalentTo(template.Attributes));
            Assert.That(clone.Contents, Is.EquivalentTo(template.Contents));
            Assert.That(clone.Magic.Bonus, Is.EqualTo(template.Magic.Bonus), item.Name);
            Assert.That(clone.Magic.Charges, Is.EqualTo(template.Magic.Charges), item.Name);
            Assert.That(clone.Magic.Curse, Is.EqualTo(template.Magic.Curse).Or.EqualTo(CurseConstants.SpecificCursedItem));
            Assert.That(clone.Magic.Intelligence.Alignment, Is.EqualTo(template.Magic.Intelligence.Alignment));
            Assert.That(clone.Magic.Intelligence.CharismaStat, Is.EqualTo(template.Magic.Intelligence.CharismaStat));
            Assert.That(clone.Magic.Intelligence.Communication, Is.EquivalentTo(template.Magic.Intelligence.Communication));
            Assert.That(clone.Magic.Intelligence.DedicatedPower, Is.EqualTo(template.Magic.Intelligence.DedicatedPower));
            Assert.That(clone.Magic.Intelligence.Ego, Is.EqualTo(template.Magic.Intelligence.Ego));
            Assert.That(clone.Magic.Intelligence.IntelligenceStat, Is.EqualTo(template.Magic.Intelligence.IntelligenceStat));
            Assert.That(clone.Magic.Intelligence.Languages, Is.EquivalentTo(template.Magic.Intelligence.Languages));
            Assert.That(clone.Magic.Intelligence.Personality, Is.EqualTo(template.Magic.Intelligence.Personality));
            Assert.That(clone.Magic.Intelligence.Powers, Is.EquivalentTo(template.Magic.Intelligence.Powers));
            Assert.That(clone.Magic.Intelligence.Senses, Is.EqualTo(template.Magic.Intelligence.Senses));
            Assert.That(clone.Magic.Intelligence.SpecialPurpose, Is.EqualTo(template.Magic.Intelligence.SpecialPurpose));
            Assert.That(clone.Magic.Intelligence.WisdomStat, Is.EqualTo(template.Magic.Intelligence.WisdomStat));
            Assert.That(clone.Magic.SpecialAbilities, Is.EquivalentTo(template.Magic.SpecialAbilities));
            Assert.That(clone.Traits, Is.SupersetOf(template.Traits));
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
        public void SmartCloneWithItemTypeCannotBeUsedAsWeaponOrArmor(string itemType)
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);
            template.ItemType = itemType;

            var clone = template.SmartClone();
            Assert.That(clone, Is.Not.EqualTo(template));
            Assert.That(clone.Name, Is.EqualTo(template.Name));
            Assert.That(clone.BaseNames, Is.EquivalentTo(template.BaseNames));

            Assert.That(clone.Attributes, Is.EquivalentTo(template.Attributes));
            Assert.That(clone.Magic.Curse, Is.EqualTo(template.Magic.Curse));
            Assert.That(clone.Magic.SpecialAbilities, Is.Empty);
            Assert.That(clone.Traits, Is.SupersetOf(template.Traits));
        }

        [Test]
        public void SmartCloneWithNamedWeaponCanBeUsedAsWeaponOrArmor()
        {
            var allWeapons = WeaponConstants.GetAllWeapons();
            foreach (var weapon in allWeapons)
            {
                var template = itemVerifier.CreateRandomTemplate(weapon);
                template.BaseNames = new[] { "base name", "other base name" };

                var clone = template.SmartClone();
                Assert.That(clone, Is.Not.EqualTo(template));
                Assert.That(clone.Name, Is.EqualTo(template.Name));
                Assert.That(clone.BaseNames, Is.EquivalentTo(template.BaseNames));

                Assert.That(clone.Attributes, Is.EquivalentTo(template.Attributes));
                Assert.That(clone.Contents, Is.EquivalentTo(template.Contents));
                Assert.That(clone.Magic.Bonus, Is.EqualTo(template.Magic.Bonus), item.Name);
                Assert.That(clone.Magic.Charges, Is.EqualTo(template.Magic.Charges), item.Name);
                Assert.That(clone.Magic.Curse, Is.EqualTo(template.Magic.Curse));
                Assert.That(clone.Magic.Intelligence.Alignment, Is.EqualTo(template.Magic.Intelligence.Alignment));
                Assert.That(clone.Magic.Intelligence.CharismaStat, Is.EqualTo(template.Magic.Intelligence.CharismaStat));
                Assert.That(clone.Magic.Intelligence.Communication, Is.EquivalentTo(template.Magic.Intelligence.Communication));
                Assert.That(clone.Magic.Intelligence.DedicatedPower, Is.EqualTo(template.Magic.Intelligence.DedicatedPower));
                Assert.That(clone.Magic.Intelligence.Ego, Is.EqualTo(template.Magic.Intelligence.Ego));
                Assert.That(clone.Magic.Intelligence.IntelligenceStat, Is.EqualTo(template.Magic.Intelligence.IntelligenceStat));
                Assert.That(clone.Magic.Intelligence.Languages, Is.EquivalentTo(template.Magic.Intelligence.Languages));
                Assert.That(clone.Magic.Intelligence.Personality, Is.EqualTo(template.Magic.Intelligence.Personality));
                Assert.That(clone.Magic.Intelligence.Powers, Is.EquivalentTo(template.Magic.Intelligence.Powers));
                Assert.That(clone.Magic.Intelligence.Senses, Is.EqualTo(template.Magic.Intelligence.Senses));
                Assert.That(clone.Magic.Intelligence.SpecialPurpose, Is.EqualTo(template.Magic.Intelligence.SpecialPurpose));
                Assert.That(clone.Magic.Intelligence.WisdomStat, Is.EqualTo(template.Magic.Intelligence.WisdomStat));
                Assert.That(clone.Magic.SpecialAbilities, Is.EquivalentTo(template.Magic.SpecialAbilities));
                Assert.That(clone.Traits, Is.SupersetOf(template.Traits));
            }
        }

        [Test]
        public void SmartCloneWithNamedArmorCanBeUsedAsWeaponOrArmor()
        {
            var allArmors = ArmorConstants.GetAllArmors(true);
            foreach (var armor in allArmors)
            {
                var template = itemVerifier.CreateRandomTemplate(armor);
                template.BaseNames = new[] { "base name", "other base name" };

                var clone = template.SmartClone();
                Assert.That(clone, Is.Not.EqualTo(template));
                Assert.That(clone.Name, Is.EqualTo(template.Name));
                Assert.That(clone.BaseNames, Is.EquivalentTo(template.BaseNames));

                Assert.That(clone.Attributes, Is.EquivalentTo(template.Attributes));
                Assert.That(clone.Contents, Is.EquivalentTo(template.Contents));
                Assert.That(clone.Magic.Bonus, Is.EqualTo(template.Magic.Bonus), item.Name);
                Assert.That(clone.Magic.Charges, Is.EqualTo(template.Magic.Charges), item.Name);
                Assert.That(clone.Magic.Curse, Is.EqualTo(template.Magic.Curse));
                Assert.That(clone.Magic.Intelligence.Alignment, Is.EqualTo(template.Magic.Intelligence.Alignment));
                Assert.That(clone.Magic.Intelligence.CharismaStat, Is.EqualTo(template.Magic.Intelligence.CharismaStat));
                Assert.That(clone.Magic.Intelligence.Communication, Is.EquivalentTo(template.Magic.Intelligence.Communication));
                Assert.That(clone.Magic.Intelligence.DedicatedPower, Is.EqualTo(template.Magic.Intelligence.DedicatedPower));
                Assert.That(clone.Magic.Intelligence.Ego, Is.EqualTo(template.Magic.Intelligence.Ego));
                Assert.That(clone.Magic.Intelligence.IntelligenceStat, Is.EqualTo(template.Magic.Intelligence.IntelligenceStat));
                Assert.That(clone.Magic.Intelligence.Languages, Is.EquivalentTo(template.Magic.Intelligence.Languages));
                Assert.That(clone.Magic.Intelligence.Personality, Is.EqualTo(template.Magic.Intelligence.Personality));
                Assert.That(clone.Magic.Intelligence.Powers, Is.EquivalentTo(template.Magic.Intelligence.Powers));
                Assert.That(clone.Magic.Intelligence.Senses, Is.EqualTo(template.Magic.Intelligence.Senses));
                Assert.That(clone.Magic.Intelligence.SpecialPurpose, Is.EqualTo(template.Magic.Intelligence.SpecialPurpose));
                Assert.That(clone.Magic.Intelligence.WisdomStat, Is.EqualTo(template.Magic.Intelligence.WisdomStat));
                Assert.That(clone.Magic.SpecialAbilities, Is.EquivalentTo(template.Magic.SpecialAbilities));
                Assert.That(clone.Traits, Is.SupersetOf(template.Traits));
            }
        }

        [Test]
        public void SmartCloneWithRandomNameCannotBeUsedAsWeaponOrArmor()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);

            var clone = template.SmartClone();
            Assert.That(clone, Is.Not.EqualTo(template));
            Assert.That(clone.Name, Is.EqualTo(template.Name));
            Assert.That(clone.BaseNames, Is.EquivalentTo(template.BaseNames));

            Assert.That(clone.Attributes, Is.EquivalentTo(template.Attributes));
            Assert.That(clone.Contents, Is.EquivalentTo(template.Contents));
            Assert.That(clone.Magic.Bonus, Is.EqualTo(template.Magic.Bonus), item.Name);
            Assert.That(clone.Magic.Charges, Is.EqualTo(template.Magic.Charges), item.Name);
            Assert.That(clone.Magic.Curse, Is.EqualTo(template.Magic.Curse));
            Assert.That(clone.Magic.Intelligence.Alignment, Is.EqualTo(template.Magic.Intelligence.Alignment));
            Assert.That(clone.Magic.Intelligence.CharismaStat, Is.EqualTo(template.Magic.Intelligence.CharismaStat));
            Assert.That(clone.Magic.Intelligence.Communication, Is.EquivalentTo(template.Magic.Intelligence.Communication));
            Assert.That(clone.Magic.Intelligence.DedicatedPower, Is.EqualTo(template.Magic.Intelligence.DedicatedPower));
            Assert.That(clone.Magic.Intelligence.Ego, Is.EqualTo(template.Magic.Intelligence.Ego));
            Assert.That(clone.Magic.Intelligence.IntelligenceStat, Is.EqualTo(template.Magic.Intelligence.IntelligenceStat));
            Assert.That(clone.Magic.Intelligence.Languages, Is.EquivalentTo(template.Magic.Intelligence.Languages));
            Assert.That(clone.Magic.Intelligence.Personality, Is.EqualTo(template.Magic.Intelligence.Personality));
            Assert.That(clone.Magic.Intelligence.Powers, Is.EquivalentTo(template.Magic.Intelligence.Powers));
            Assert.That(clone.Magic.Intelligence.Senses, Is.EqualTo(template.Magic.Intelligence.Senses));
            Assert.That(clone.Magic.Intelligence.SpecialPurpose, Is.EqualTo(template.Magic.Intelligence.SpecialPurpose));
            Assert.That(clone.Magic.Intelligence.WisdomStat, Is.EqualTo(template.Magic.Intelligence.WisdomStat));
            Assert.That(clone.Magic.SpecialAbilities, Is.Empty);
            Assert.That(clone.Traits, Is.SupersetOf(template.Traits));
        }

        [Test]
        public void SmartCloneWithBaseNamedWeaponCanBeUsedAsWeaponOrArmor()
        {
            var allWeapons = WeaponConstants.GetAllWeapons();
            foreach (var weapon in allWeapons)
            {
                var name = Guid.NewGuid().ToString();
                var template = itemVerifier.CreateRandomTemplate(name);
                template.BaseNames = new[] { "base name", weapon, "other base name" };

                var clone = template.SmartClone();
                Assert.That(clone, Is.Not.EqualTo(template));
                Assert.That(clone.Name, Is.EqualTo(template.Name));
                Assert.That(clone.BaseNames, Is.EquivalentTo(template.BaseNames));

                Assert.That(clone.Attributes, Is.EquivalentTo(template.Attributes));
                Assert.That(clone.Contents, Is.EquivalentTo(template.Contents));
                Assert.That(clone.Magic.Bonus, Is.EqualTo(template.Magic.Bonus), item.Name);
                Assert.That(clone.Magic.Charges, Is.EqualTo(template.Magic.Charges), item.Name);
                Assert.That(clone.Magic.Curse, Is.EqualTo(template.Magic.Curse));
                Assert.That(clone.Magic.Intelligence.Alignment, Is.EqualTo(template.Magic.Intelligence.Alignment));
                Assert.That(clone.Magic.Intelligence.CharismaStat, Is.EqualTo(template.Magic.Intelligence.CharismaStat));
                Assert.That(clone.Magic.Intelligence.Communication, Is.EquivalentTo(template.Magic.Intelligence.Communication));
                Assert.That(clone.Magic.Intelligence.DedicatedPower, Is.EqualTo(template.Magic.Intelligence.DedicatedPower));
                Assert.That(clone.Magic.Intelligence.Ego, Is.EqualTo(template.Magic.Intelligence.Ego));
                Assert.That(clone.Magic.Intelligence.IntelligenceStat, Is.EqualTo(template.Magic.Intelligence.IntelligenceStat));
                Assert.That(clone.Magic.Intelligence.Languages, Is.EquivalentTo(template.Magic.Intelligence.Languages));
                Assert.That(clone.Magic.Intelligence.Personality, Is.EqualTo(template.Magic.Intelligence.Personality));
                Assert.That(clone.Magic.Intelligence.Powers, Is.EquivalentTo(template.Magic.Intelligence.Powers));
                Assert.That(clone.Magic.Intelligence.Senses, Is.EqualTo(template.Magic.Intelligence.Senses));
                Assert.That(clone.Magic.Intelligence.SpecialPurpose, Is.EqualTo(template.Magic.Intelligence.SpecialPurpose));
                Assert.That(clone.Magic.Intelligence.WisdomStat, Is.EqualTo(template.Magic.Intelligence.WisdomStat));
                Assert.That(clone.Magic.SpecialAbilities, Is.EquivalentTo(template.Magic.SpecialAbilities));
                Assert.That(clone.Traits, Is.SupersetOf(template.Traits));
            }
        }

        [Test]
        public void SmartCloneWithBaseNamedArmorCanBeUsedAsWeaponOrArmor()
        {
            var allArmors = ArmorConstants.GetAllArmors(true);
            foreach (var armor in allArmors)
            {
                var name = Guid.NewGuid().ToString();
                var template = itemVerifier.CreateRandomTemplate(name);
                template.BaseNames = new[] { "base name", armor, "other base name" };

                var clone = template.SmartClone();
                Assert.That(clone, Is.Not.EqualTo(template));
                Assert.That(clone.Name, Is.EqualTo(template.Name));
                Assert.That(clone.BaseNames, Is.EquivalentTo(template.BaseNames));

                Assert.That(clone.Attributes, Is.EquivalentTo(template.Attributes));
                Assert.That(clone.Contents, Is.EquivalentTo(template.Contents));
                Assert.That(clone.Magic.Bonus, Is.EqualTo(template.Magic.Bonus), item.Name);
                Assert.That(clone.Magic.Charges, Is.EqualTo(template.Magic.Charges), item.Name);
                Assert.That(clone.Magic.Curse, Is.EqualTo(template.Magic.Curse));
                Assert.That(clone.Magic.Intelligence.Alignment, Is.EqualTo(template.Magic.Intelligence.Alignment));
                Assert.That(clone.Magic.Intelligence.CharismaStat, Is.EqualTo(template.Magic.Intelligence.CharismaStat));
                Assert.That(clone.Magic.Intelligence.Communication, Is.EquivalentTo(template.Magic.Intelligence.Communication));
                Assert.That(clone.Magic.Intelligence.DedicatedPower, Is.EqualTo(template.Magic.Intelligence.DedicatedPower));
                Assert.That(clone.Magic.Intelligence.Ego, Is.EqualTo(template.Magic.Intelligence.Ego));
                Assert.That(clone.Magic.Intelligence.IntelligenceStat, Is.EqualTo(template.Magic.Intelligence.IntelligenceStat));
                Assert.That(clone.Magic.Intelligence.Languages, Is.EquivalentTo(template.Magic.Intelligence.Languages));
                Assert.That(clone.Magic.Intelligence.Personality, Is.EqualTo(template.Magic.Intelligence.Personality));
                Assert.That(clone.Magic.Intelligence.Powers, Is.EquivalentTo(template.Magic.Intelligence.Powers));
                Assert.That(clone.Magic.Intelligence.Senses, Is.EqualTo(template.Magic.Intelligence.Senses));
                Assert.That(clone.Magic.Intelligence.SpecialPurpose, Is.EqualTo(template.Magic.Intelligence.SpecialPurpose));
                Assert.That(clone.Magic.Intelligence.WisdomStat, Is.EqualTo(template.Magic.Intelligence.WisdomStat));
                Assert.That(clone.Magic.SpecialAbilities, Is.EquivalentTo(template.Magic.SpecialAbilities));
                Assert.That(clone.Traits, Is.SupersetOf(template.Traits));
            }
        }

        [Test]
        public void SmartCloneWithRandomBaseNameCannotBeUsedAsWeaponOrArmor()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);

            var clone = template.SmartClone();
            Assert.That(clone, Is.Not.EqualTo(template));
            Assert.That(clone.Name, Is.EqualTo(template.Name));
            Assert.That(clone.BaseNames, Is.EquivalentTo(template.BaseNames));

            Assert.That(clone.Attributes, Is.EquivalentTo(template.Attributes));
            Assert.That(clone.Contents, Is.EquivalentTo(template.Contents));
            Assert.That(clone.Magic.Bonus, Is.EqualTo(template.Magic.Bonus), item.Name);
            Assert.That(clone.Magic.Charges, Is.EqualTo(template.Magic.Charges), item.Name);
            Assert.That(clone.Magic.Curse, Is.EqualTo(template.Magic.Curse));
            Assert.That(clone.Magic.Intelligence.Alignment, Is.EqualTo(template.Magic.Intelligence.Alignment));
            Assert.That(clone.Magic.Intelligence.CharismaStat, Is.EqualTo(template.Magic.Intelligence.CharismaStat));
            Assert.That(clone.Magic.Intelligence.Communication, Is.EquivalentTo(template.Magic.Intelligence.Communication));
            Assert.That(clone.Magic.Intelligence.DedicatedPower, Is.EqualTo(template.Magic.Intelligence.DedicatedPower));
            Assert.That(clone.Magic.Intelligence.Ego, Is.EqualTo(template.Magic.Intelligence.Ego));
            Assert.That(clone.Magic.Intelligence.IntelligenceStat, Is.EqualTo(template.Magic.Intelligence.IntelligenceStat));
            Assert.That(clone.Magic.Intelligence.Languages, Is.EquivalentTo(template.Magic.Intelligence.Languages));
            Assert.That(clone.Magic.Intelligence.Personality, Is.EqualTo(template.Magic.Intelligence.Personality));
            Assert.That(clone.Magic.Intelligence.Powers, Is.EquivalentTo(template.Magic.Intelligence.Powers));
            Assert.That(clone.Magic.Intelligence.Senses, Is.EqualTo(template.Magic.Intelligence.Senses));
            Assert.That(clone.Magic.Intelligence.SpecialPurpose, Is.EqualTo(template.Magic.Intelligence.SpecialPurpose));
            Assert.That(clone.Magic.Intelligence.WisdomStat, Is.EqualTo(template.Magic.Intelligence.WisdomStat));
            Assert.That(clone.Magic.SpecialAbilities, Is.Empty);
            Assert.That(clone.Traits, Is.SupersetOf(template.Traits));
        }

        [Test]
        public void CloneCopiesAll()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);

            var clone = template.Clone();
            Assert.That(clone, Is.Not.EqualTo(template));
            Assert.That(clone.Name, Is.EqualTo(template.Name));

            Assert.That(clone.Attributes, Is.EquivalentTo(template.Attributes));
            Assert.That(clone.BaseNames, Is.EquivalentTo(template.BaseNames));
            Assert.That(clone.Contents, Is.EquivalentTo(template.Contents));
            Assert.That(clone.Magic.Bonus, Is.EqualTo(template.Magic.Bonus));
            Assert.That(clone.Magic.Charges, Is.EqualTo(template.Magic.Charges));
            Assert.That(clone.Magic.Curse, Is.EqualTo(template.Magic.Curse));
            Assert.That(clone.Magic.Intelligence.Alignment, Is.EqualTo(template.Magic.Intelligence.Alignment));
            Assert.That(clone.Magic.Intelligence.CharismaStat, Is.EqualTo(template.Magic.Intelligence.CharismaStat));
            Assert.That(clone.Magic.Intelligence.Communication, Is.EquivalentTo(template.Magic.Intelligence.Communication));
            Assert.That(clone.Magic.Intelligence.DedicatedPower, Is.EqualTo(template.Magic.Intelligence.DedicatedPower));
            Assert.That(clone.Magic.Intelligence.Ego, Is.EqualTo(template.Magic.Intelligence.Ego));
            Assert.That(clone.Magic.Intelligence.IntelligenceStat, Is.EqualTo(template.Magic.Intelligence.IntelligenceStat));
            Assert.That(clone.Magic.Intelligence.Languages, Is.EquivalentTo(template.Magic.Intelligence.Languages));
            Assert.That(clone.Magic.Intelligence.Personality, Is.EqualTo(template.Magic.Intelligence.Personality));
            Assert.That(clone.Magic.Intelligence.Powers, Is.EquivalentTo(template.Magic.Intelligence.Powers));
            Assert.That(clone.Magic.Intelligence.Senses, Is.EqualTo(template.Magic.Intelligence.Senses));
            Assert.That(clone.Magic.Intelligence.SpecialPurpose, Is.EqualTo(template.Magic.Intelligence.SpecialPurpose));
            Assert.That(clone.Magic.Intelligence.WisdomStat, Is.EqualTo(template.Magic.Intelligence.WisdomStat));
            Assert.That(clone.Magic.SpecialAbilities, Is.EquivalentTo(template.Magic.SpecialAbilities));
            Assert.That(clone.Traits, Is.SupersetOf(template.Traits));
        }

        [Test]
        public void CloneCopiesAllIntoSpecifiedItem()
        {
            var clone = new Item();
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomTemplate(name);

            var newClone = template.CloneInto(clone);
            Assert.That(newClone, Is.EqualTo(clone));
            Assert.That(clone, Is.Not.EqualTo(template));
            Assert.That(clone.Name, Is.EqualTo(template.Name));

            Assert.That(clone.Attributes, Is.EquivalentTo(template.Attributes));
            Assert.That(clone.BaseNames, Is.EquivalentTo(template.BaseNames));
            Assert.That(clone.Contents, Is.EquivalentTo(template.Contents));
            Assert.That(clone.Magic.Bonus, Is.EqualTo(template.Magic.Bonus));
            Assert.That(clone.Magic.Charges, Is.EqualTo(template.Magic.Charges));
            Assert.That(clone.Magic.Curse, Is.EqualTo(template.Magic.Curse));
            Assert.That(clone.Magic.Intelligence.Alignment, Is.EqualTo(template.Magic.Intelligence.Alignment));
            Assert.That(clone.Magic.Intelligence.CharismaStat, Is.EqualTo(template.Magic.Intelligence.CharismaStat));
            Assert.That(clone.Magic.Intelligence.Communication, Is.EquivalentTo(template.Magic.Intelligence.Communication));
            Assert.That(clone.Magic.Intelligence.DedicatedPower, Is.EqualTo(template.Magic.Intelligence.DedicatedPower));
            Assert.That(clone.Magic.Intelligence.Ego, Is.EqualTo(template.Magic.Intelligence.Ego));
            Assert.That(clone.Magic.Intelligence.IntelligenceStat, Is.EqualTo(template.Magic.Intelligence.IntelligenceStat));
            Assert.That(clone.Magic.Intelligence.Languages, Is.EquivalentTo(template.Magic.Intelligence.Languages));
            Assert.That(clone.Magic.Intelligence.Personality, Is.EqualTo(template.Magic.Intelligence.Personality));
            Assert.That(clone.Magic.Intelligence.Powers, Is.EquivalentTo(template.Magic.Intelligence.Powers));
            Assert.That(clone.Magic.Intelligence.Senses, Is.EqualTo(template.Magic.Intelligence.Senses));
            Assert.That(clone.Magic.Intelligence.SpecialPurpose, Is.EqualTo(template.Magic.Intelligence.SpecialPurpose));
            Assert.That(clone.Magic.Intelligence.WisdomStat, Is.EqualTo(template.Magic.Intelligence.WisdomStat));
            Assert.That(clone.Magic.SpecialAbilities, Is.EquivalentTo(template.Magic.SpecialAbilities));
            Assert.That(clone.Traits, Is.SupersetOf(template.Traits));
        }

        [Test]
        public void NameMatchesIfName()
        {
            item.Name = "name";
            item.BaseNames = new[] { "base name", "other base name" };

            Assert.That(item.NameMatches("name"), Is.True);
        }

        [Test]
        public void NameMatchesIfAnyBaseName()
        {
            item.Name = "name";
            item.BaseNames = new[] { "base name", "other base name" };

            Assert.That(item.NameMatches("base name"), Is.True);
            Assert.That(item.NameMatches("other base name"), Is.True);
        }

        [Test]
        public void NameDoesNotMatch()
        {
            item.Name = "name";
            item.BaseNames = new[] { "base name", "other base name" };

            Assert.That(item.NameMatches("wrong name"), Is.False);
        }

        [Test]
        public void CloneCopiesIsMagical()
        {
            item.IsMagical = true;
            var clone = item.Clone();
            Assert.That(clone.IsMagical, Is.True);
        }

        [Test]
        public void SmartCloneCopiesIsMagical()
        {
            item.IsMagical = true;
            var clone = item.SmartClone();
            Assert.That(clone.IsMagical, Is.True);
        }
    }
}