using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Magical;
using NUnit.Framework;

namespace DnDGen.TreasureGen.Tests.Unit.Generators.Items.Magical
{
    [TestFixture]
    public class SpecialAbilityTests
    {
        private SpecialAbility specialAbility;

        [SetUp]
        public void Setup()
        {
            specialAbility = new SpecialAbility();
        }

        [Test]
        public void SpecialAbilityInitialized()
        {
            Assert.That(specialAbility.Name, Is.Empty);
            Assert.That(specialAbility.AttributeRequirements, Is.Empty);
            Assert.That(specialAbility.BonusEquivalent, Is.Zero);
            Assert.That(specialAbility.BaseName, Is.Empty);
            Assert.That(specialAbility.Power, Is.Zero);
            Assert.That(specialAbility.Damages, Is.Empty);
            Assert.That(specialAbility.CriticalDamages, Is.Empty);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        [TestCase(9)]
        [TestCase(10)]
        public void RequirementsMetIfNoRequirementsAndBonusFits(int bonus)
        {
            var item = new Item();
            item.Magic.Bonus = bonus;

            var met = specialAbility.RequirementsMet(item);
            Assert.That(met, Is.True);
        }

        [Test]
        public void AllCombosUpTo10AreMet()
        {
            var item = new Item();

            for (var abilityBonus = 0; abilityBonus <= 10; abilityBonus++)
            {
                for (var itemBonus = 0; itemBonus <= 10 - abilityBonus; itemBonus++)
                {
                    item.Magic.Bonus = itemBonus;
                    specialAbility.BonusEquivalent = abilityBonus;

                    var met = specialAbility.RequirementsMet(item);
                    Assert.That(met, Is.True);
                }
            }
        }

        [Test]
        public void RequirementsNotMetIfBonusTotalWouldBeTooHigh()
        {
            var item = new Item();
            item.Magic.Bonus = 9;
            specialAbility.BonusEquivalent = 2;

            var met = specialAbility.RequirementsMet(item);
            Assert.That(met, Is.False);
        }

        [Test]
        public void RequirementsNotMetIfAttributesMissing()
        {
            var item = new Item();
            item.Attributes = new[] { "wrong attribute", "other attribute" };
            specialAbility.AttributeRequirements = new[] { "correct attribute", "other attribute" };

            var met = specialAbility.RequirementsMet(item);
            Assert.That(met, Is.False);
        }

        [Test]
        public void RequirementsMetIfWeaponProperty()
        {
            var weapon = new Weapon();
            weapon.Attributes = new[] { "wrong attribute", "other attribute" };
            weapon.Size = "correct attribute";
            specialAbility.AttributeRequirements = new[] { "correct attribute", "other attribute" };

            var met = specialAbility.RequirementsMet(weapon);
            Assert.That(met, Is.True);
        }

        [Test]
        public void RequirementsMetIfWeaponPropertyContainsAttribute()
        {
            var weapon = new Weapon();
            weapon.Attributes = new[] { "wrong attribute", "other attribute" };
            weapon.Size = "this contains the correct attribute the ability needs";
            specialAbility.AttributeRequirements = new[] { "correct attribute", "other attribute" };

            var met = specialAbility.RequirementsMet(weapon);
            Assert.That(met, Is.True);
        }

        [Test]
        public void RequirementsMetIfWeaponPropertyContainsAttribute_DamageType()
        {
            var weapon = new Weapon();
            weapon.Attributes = new[] { "wrong attribute", "other attribute" };
            weapon.Damages.Add(new Damage { Roll = "my roll", Type = "my correct attribute" });
            specialAbility.AttributeRequirements = new[] { "correct attribute", "other attribute" };

            var met = specialAbility.RequirementsMet(weapon);
            Assert.That(met, Is.True);
        }

        [Test]
        public void RequirementsMetIfWeaponPropertyContainsAttribute_AnyDamageType()
        {
            var weapon = new Weapon();
            weapon.Attributes = new[] { "wrong attribute", "other attribute" };
            weapon.Damages.Add(new Damage { Roll = "my roll", Type = "my wrong attribute" });
            weapon.Damages.Add(new Damage { Roll = "my other roll", Type = "my correct attribute" });
            specialAbility.AttributeRequirements = new[] { "correct attribute", "other attribute" };

            var met = specialAbility.RequirementsMet(weapon);
            Assert.That(met, Is.True);
        }

        [Test]
        public void RequirementsMetIfArmorProperty()
        {
            var armor = new Armor();
            armor.Attributes = new[] { "wrong attribute", "other attribute" };
            armor.Size = "correct attribute";
            specialAbility.AttributeRequirements = new[] { "correct attribute", "other attribute" };

            var met = specialAbility.RequirementsMet(armor);
            Assert.That(met, Is.True);
        }

        [Test]
        public void RequirementsMetIfArmorPropertyContainsAttribute()
        {
            var armor = new Armor();
            armor.Attributes = new[] { "wrong attribute", "other attribute" };
            armor.Size = "this contains the correct attribute the ability needs";
            specialAbility.AttributeRequirements = new[] { "correct attribute", "other attribute" };

            var met = specialAbility.RequirementsMet(armor);
            Assert.That(met, Is.True);
        }

        [Test]
        public void MetIfEitherOfOrRequirementIsMet()
        {
            var item = new Item();
            item.Attributes = new[] { "wrong attribute", "other attribute" };
            specialAbility.AttributeRequirements = new[] { "correct attribute/other attribute" };

            var met = specialAbility.RequirementsMet(item);
            Assert.That(met, Is.True);
        }

        [Test]
        public void AndWithOrRequirementsIsMet()
        {
            var item = new Item();
            item.Attributes = new[] { "wrong attribute", "other attribute", "another attribute" };
            specialAbility.AttributeRequirements = new[] { "another attribute", "correct attribute/other attribute" };

            var met = specialAbility.RequirementsMet(item);
            Assert.That(met, Is.True);
        }

        [Test]
        public void OrWithWeaponProperty()
        {
            var weapon = new Weapon();
            weapon.Attributes = new[] { "wrong attribute" };
            weapon.Size = "correct attribute";
            specialAbility.AttributeRequirements = new[] { "correct attribute/other attribute" };

            var met = specialAbility.RequirementsMet(weapon);
            Assert.That(met, Is.True);
        }

        [Test]
        public void OrWithContainedWeaponProperty()
        {
            var weapon = new Weapon();
            weapon.Attributes = new[] { "wrong attribute" };
            weapon.Size = "this contains the correct attribute the ability needs";
            specialAbility.AttributeRequirements = new[] { "correct attribute/other attribute" };

            var met = specialAbility.RequirementsMet(weapon);
            Assert.That(met, Is.True);
        }

        [Test]
        public void OrWithWeaponPropertyContainsAttribute_DamageType()
        {
            var weapon = new Weapon();
            weapon.Attributes = new[] { "wrong attribute", "other attribute" };
            weapon.Damages.Add(new Damage { Roll = "my roll", Type = "my correct attribute" });
            specialAbility.AttributeRequirements = new[] { "correct attribute/other attribute" };

            var met = specialAbility.RequirementsMet(weapon);
            Assert.That(met, Is.True);
        }

        [Test]
        public void OrWithWeaponPropertyContainsAttribute_AnyDamageType()
        {
            var weapon = new Weapon();
            weapon.Attributes = new[] { "wrong attribute", "other attribute" };
            weapon.Damages.Add(new Damage { Roll = "my roll", Type = "my wrong attribute" });
            weapon.Damages.Add(new Damage { Roll = "my other roll", Type = "my correct attribute" });
            specialAbility.AttributeRequirements = new[] { "correct attribute/other attribute" };

            var met = specialAbility.RequirementsMet(weapon);
            Assert.That(met, Is.True);
        }

        [Test]
        public void OrWithArmorProperty()
        {
            var armor = new Armor();
            armor.Attributes = new[] { "wrong attribute" };
            armor.Size = "correct attribute";
            specialAbility.AttributeRequirements = new[] { "correct attribute/other attribute" };

            var met = specialAbility.RequirementsMet(armor);
            Assert.That(met, Is.True);
        }

        [Test]
        public void OrWithContainedArmorProperty()
        {
            var armor = new Armor();
            armor.Attributes = new[] { "wrong attribute" };
            armor.Size = "this contains the correct attribute the ability needs";
            specialAbility.AttributeRequirements = new[] { "correct attribute/other attribute" };

            var met = specialAbility.RequirementsMet(armor);
            Assert.That(met, Is.True);
        }

        [Test]
        public void MetIfNotRequirementIsNotPresent()
        {
            var item = new Item();
            item.Attributes = new[] { "wrong attribute", "other attribute" };
            specialAbility.AttributeRequirements = new[] { "!correct attribute", "other attribute" };

            var met = specialAbility.RequirementsMet(item);
            Assert.That(met, Is.True);
        }

        [Test]
        public void NotMetIfNotRequirementIsPresent()
        {
            var item = new Item();
            item.Attributes = new[] { "wrong attribute", "other attribute" };
            specialAbility.AttributeRequirements = new[] { "!other attribute" };

            var met = specialAbility.RequirementsMet(item);
            Assert.That(met, Is.False);
        }

        [Test]
        public void NotWithWeaponProperty()
        {
            var weapon = new Weapon();
            weapon.Attributes = new[] { "wrong attribute" };
            weapon.Size = "correct attribute";
            specialAbility.AttributeRequirements = new[] { "!correct attribute" };

            var met = specialAbility.RequirementsMet(weapon);
            Assert.That(met, Is.False);
        }

        [Test]
        public void NotWithContainedWeaponProperty()
        {
            var weapon = new Weapon();
            weapon.Attributes = new[] { "wrong attribute" };
            weapon.Size = "this contains the correct attribute the ability needs";
            specialAbility.AttributeRequirements = new[] { "!correct attribute" };

            var met = specialAbility.RequirementsMet(weapon);
            Assert.That(met, Is.False);
        }

        [Test]
        public void NotWithWeaponPropertyContainsAttribute_DamageType()
        {
            var weapon = new Weapon();
            weapon.Attributes = new[] { "wrong attribute", "other attribute" };
            weapon.Damages.Add(new Damage { Roll = "my roll", Type = "my correct attribute" });
            specialAbility.AttributeRequirements = new[] { "!correct attribute" };

            var met = specialAbility.RequirementsMet(weapon);
            Assert.That(met, Is.False);
        }

        [Test]
        public void NotWithWeaponPropertyContainsAttribute_AnyDamageType()
        {
            var weapon = new Weapon();
            weapon.Attributes = new[] { "wrong attribute", "other attribute" };
            weapon.Damages.Add(new Damage { Roll = "my roll", Type = "my wrong attribute" });
            weapon.Damages.Add(new Damage { Roll = "my other roll", Type = "my correct attribute" });
            specialAbility.AttributeRequirements = new[] { "!correct attribute" };

            var met = specialAbility.RequirementsMet(weapon);
            Assert.That(met, Is.False);
        }

        [Test]
        public void NotWithArmorProperty()
        {
            var armor = new Armor();
            armor.Attributes = new[] { "wrong attribute" };
            armor.Size = "correct attribute";
            specialAbility.AttributeRequirements = new[] { "!correct attribute" };

            var met = specialAbility.RequirementsMet(armor);
            Assert.That(met, Is.False);
        }

        [Test]
        public void NotWithContainedArmorProperty()
        {
            var armor = new Armor();
            armor.Attributes = new[] { "wrong attribute" };
            armor.Size = "this contains the correct attribute the ability needs";
            specialAbility.AttributeRequirements = new[] { "!correct attribute" };

            var met = specialAbility.RequirementsMet(armor);
            Assert.That(met, Is.False);
        }

        [Test]
        public void AndWithOrRequirementsIsNotMet()
        {
            var item = new Item();
            item.Attributes = new[] { "wrong attribute", "other attribute", "correct attribute" };
            specialAbility.AttributeRequirements = new[] { "another attribute", "correct attribute/other attribute" };

            var met = specialAbility.RequirementsMet(item);
            Assert.That(met, Is.False);
        }

        [Test]
        public void AllRequirementsMet()
        {
            var item = new Item();
            item.Attributes = new[] { "another attribute", "correct attribute" };
            specialAbility.AttributeRequirements = new[] { "another attribute", "correct attribute/other attribute", "!wrong attribute" };

            var met = specialAbility.RequirementsMet(item);
            Assert.That(met, Is.True);
        }
    }
}