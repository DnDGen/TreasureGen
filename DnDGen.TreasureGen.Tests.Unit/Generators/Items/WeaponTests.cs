using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Magical;
using NUnit.Framework;
using System;
using System.Linq;

namespace DnDGen.TreasureGen.Tests.Unit.Generators.Items
{
    [TestFixture]
    public class WeaponTests
    {
        private Weapon weapon;
        private ItemVerifier itemVerifier;

        [SetUp]
        public void Setup()
        {
            weapon = new Weapon();
            itemVerifier = new ItemVerifier();
        }

        [Test]
        public void WeaponInitialized()
        {
            Assert.That(weapon.Ammunition, Is.Empty);
            Assert.That(weapon.Damages, Is.Empty);
            Assert.That(weapon.DamageRoll, Is.Empty);
            Assert.That(weapon.DamageDescription, Is.Empty);
            Assert.That(weapon.Size, Is.Empty);
            Assert.That(weapon.ThreatRangeDescription, Is.Empty);
            Assert.That(weapon.ThreatRange, Is.Zero);
            Assert.That(weapon.CriticalDamages, Is.Empty);
            Assert.That(weapon.CriticalDamageRoll, Is.Empty);
            Assert.That(weapon.CriticalDamageDescription, Is.Empty);
            Assert.That(weapon.ItemType, Is.Empty); //INFO: Weapon could be a rod or staff
            Assert.That(weapon.CombatTypes, Is.Empty);
        }

        [Test]
        public void WeaponIsItem()
        {
            Assert.That(weapon, Is.InstanceOf<Item>());
        }

        [Test]
        public void WeaponCanBeUsedAsWeaponOrWeapon()
        {
            Assert.That(weapon.CanBeUsedAsWeaponOrArmor, Is.True);
        }

        [Test]
        public void DamageRoll_NoDamages()
        {
            weapon.Damages.Clear();
            Assert.That(weapon.DamageRoll, Is.Empty);
        }

        [Test]
        public void DamageRoll_NoDamages_WithMagicBonus()
        {
            weapon.Damages.Clear();
            weapon.Magic.Bonus = 1337;

            Assert.That(weapon.DamageRoll, Is.EqualTo("1337"));
        }

        [Test]
        public void DamageRoll_WithDamage()
        {
            weapon.Damages.Add(new Damage { Roll = "9266d90210", Type = "emotional" });
            Assert.That(weapon.DamageRoll, Is.EqualTo("9266d90210"));
        }

        [Test]
        public void DamageRoll_WithDamage_WithMagicBonus()
        {
            weapon.Damages.Add(new Damage { Roll = "9266d90210", Type = "emotional" });
            weapon.Magic.Bonus = 1337;

            Assert.That(weapon.DamageRoll, Is.EqualTo("9266d90210+1337"));
        }

        [Test]
        public void DamageRoll_WithDamages()
        {
            weapon.Damages.Add(new Damage { Roll = "9266d90210", Type = "emotional" });
            weapon.Damages.Add(new Damage { Roll = "42d600", Type = "spiritual" });

            Assert.That(weapon.DamageRoll, Is.EqualTo("9266d90210+42d600"));
        }

        [Test]
        public void DamageRoll_WithDamages_WithMagicBonus()
        {
            weapon.Damages.Add(new Damage { Roll = "9266d90210", Type = "emotional" });
            weapon.Damages.Add(new Damage { Roll = "42d600", Type = "spiritual" });
            weapon.Magic.Bonus = 1337;

            Assert.That(weapon.DamageRoll, Is.EqualTo("9266d90210+1337+42d600"));
        }

        [Test]
        public void DamageDescription_NoDamages()
        {
            weapon.Damages.Clear();
            Assert.That(weapon.DamageDescription, Is.Empty);
        }

        [Test]
        public void DamageDescription_NoDamages_WithMagicBonus()
        {
            weapon.Damages.Clear();
            weapon.Magic.Bonus = 1337;

            Assert.That(weapon.DamageDescription, Is.EqualTo("1337"));
        }

        [Test]
        public void DamageDescription_WithDamage()
        {
            weapon.Damages.Add(new Damage { Roll = "9266d90210", Type = "emotional" });
            Assert.That(weapon.DamageDescription, Is.EqualTo("9266d90210 emotional"));
        }

        [Test]
        public void DamageDescription_WithDamage_WithMagicBonus()
        {
            weapon.Damages.Add(new Damage { Roll = "9266d90210", Type = "emotional" });
            weapon.Magic.Bonus = 1337;

            Assert.That(weapon.DamageDescription, Is.EqualTo("9266d90210+1337 emotional"));
        }

        [Test]
        public void DamageDescription_WithDamages()
        {
            weapon.Damages.Add(new Damage { Roll = "9266d90210", Type = "emotional" });
            weapon.Damages.Add(new Damage { Roll = "42d600", Type = "spiritual" });

            Assert.That(weapon.DamageDescription, Is.EqualTo("9266d90210 emotional + 42d600 spiritual"));
        }

        [Test]
        public void DamageDescription_WithDamages_WithMagicBonus()
        {
            weapon.Damages.Add(new Damage { Roll = "9266d90210", Type = "emotional" });
            weapon.Damages.Add(new Damage { Roll = "42d600", Type = "spiritual" });
            weapon.Magic.Bonus = 1337;

            Assert.That(weapon.DamageDescription, Is.EqualTo("9266d90210+1337 emotional + 42d600 spiritual"));
        }

        [Test]
        public void CriticalDamageRoll_NoDamages()
        {
            weapon.CriticalDamages.Clear();
            Assert.That(weapon.CriticalDamageRoll, Is.Empty);
        }

        [Test]
        public void CriticalDamageRoll_NoDamages_WithMagicBonus()
        {
            weapon.CriticalDamages.Clear();
            weapon.Magic.Bonus = 1337;

            Assert.That(weapon.CriticalDamageRoll, Is.EqualTo("1337"));
        }

        [Test]
        public void CriticalDamageRoll_WithDamage()
        {
            weapon.CriticalDamages.Add(new Damage { Roll = "9266d90210", Type = "emotional" });
            Assert.That(weapon.CriticalDamageRoll, Is.EqualTo("9266d90210"));
        }

        [Test]
        public void CriticalDamageRoll_WithDamage_WithMagicBonus()
        {
            weapon.CriticalDamages.Add(new Damage { Roll = "9266d90210", Type = "emotional" });
            weapon.Magic.Bonus = 1337;

            Assert.That(weapon.CriticalDamageRoll, Is.EqualTo("9266d90210+1337"));
        }

        [Test]
        public void CriticalDamageRoll_WithDamages()
        {
            weapon.CriticalDamages.Add(new Damage { Roll = "9266d90210", Type = "emotional" });
            weapon.CriticalDamages.Add(new Damage { Roll = "42d600", Type = "spiritual" });

            Assert.That(weapon.CriticalDamageRoll, Is.EqualTo("9266d90210+42d600"));
        }

        [Test]
        public void CriticalDamageRoll_WithDamages_WithMagicBonus()
        {
            weapon.CriticalDamages.Add(new Damage { Roll = "9266d90210", Type = "emotional" });
            weapon.CriticalDamages.Add(new Damage { Roll = "42d600", Type = "spiritual" });
            weapon.Magic.Bonus = 1337;

            Assert.That(weapon.CriticalDamageRoll, Is.EqualTo("9266d90210+1337+42d600"));
        }

        [Test]
        public void CriticalDamageDescription_NoDamages()
        {
            weapon.CriticalDamages.Clear();
            Assert.That(weapon.CriticalDamageDescription, Is.Empty);
        }

        [Test]
        public void CriticalDamageDescription_NoDamages_WithMagicBonus()
        {
            weapon.CriticalDamages.Clear();
            weapon.Magic.Bonus = 1337;

            Assert.That(weapon.CriticalDamageDescription, Is.EqualTo("1337"));
        }

        [Test]
        public void CriticalDamageDescription_WithDamage()
        {
            weapon.CriticalDamages.Add(new Damage { Roll = "9266d90210", Type = "emotional" });
            Assert.That(weapon.CriticalDamageDescription, Is.EqualTo("9266d90210 emotional"));
        }

        [Test]
        public void CriticalDamageDescription_WithDamage_WithMagicBonus()
        {
            weapon.CriticalDamages.Add(new Damage { Roll = "9266d90210", Type = "emotional" });
            weapon.Magic.Bonus = 1337;

            Assert.That(weapon.CriticalDamageDescription, Is.EqualTo("9266d90210+1337 emotional"));
        }

        [Test]
        public void CriticalDamageDescription_WithDamages()
        {
            weapon.CriticalDamages.Add(new Damage { Roll = "9266d90210", Type = "emotional" });
            weapon.CriticalDamages.Add(new Damage { Roll = "42d600", Type = "spiritual" });

            Assert.That(weapon.CriticalDamageDescription, Is.EqualTo("9266d90210 emotional + 42d600 spiritual"));
        }

        [Test]
        public void CriticalDamageDescription_WithDamages_WithMagicBonus()
        {
            weapon.CriticalDamages.Add(new Damage { Roll = "9266d90210", Type = "emotional" });
            weapon.CriticalDamages.Add(new Damage { Roll = "42d600", Type = "spiritual" });
            weapon.Magic.Bonus = 1337;

            Assert.That(weapon.CriticalDamageDescription, Is.EqualTo("9266d90210+1337 emotional + 42d600 spiritual"));
        }

        [Test]
        public void CloneIsSuccessful()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomWeaponTemplate(name);

            template.Ammunition = "nerf bullets";
            template.Damages.Add(new Damage { Roll = "a ton", Type = "stabbing" });
            template.Damages.Add(new Damage { Roll = "a bit", Type = "emotional" });
            template.CriticalDamages.Add(new Damage { Roll = "a ton more", Type = "stabbing" });
            template.CriticalDamages.Add(new Damage { Roll = "a bit more", Type = "spiritual" });
            template.Size = "massive";
            template.ThreatRange = 9266;

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

            var cloneWeapon = clone as Weapon;
            Assert.That(cloneWeapon.Ammunition, Is.EqualTo(template.Ammunition));
            Assert.That(cloneWeapon.DamageRoll, Is.EqualTo(template.DamageRoll));
            Assert.That(cloneWeapon.DamageDescription, Is.EqualTo(template.DamageDescription));
            Assert.That(cloneWeapon.CriticalDamageRoll, Is.EqualTo(template.CriticalDamageRoll));
            Assert.That(cloneWeapon.CriticalDamageDescription, Is.EqualTo(template.CriticalDamageDescription));
            Assert.That(cloneWeapon.Size, Is.EqualTo(template.Size));
            Assert.That(cloneWeapon.ThreatRangeDescription, Is.EqualTo(template.ThreatRangeDescription));
        }

        [Test]
        public void MundaneCloneIsSuccessful()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomWeaponTemplate(name);
            template.ItemType = Guid.NewGuid().ToString();
            template.Magic.SpecialAbilities = new[]
            {
                new SpecialAbility { Name = Guid.NewGuid().ToString() },
                new SpecialAbility { Name = Guid.NewGuid().ToString() }
            };

            template.Attributes = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
            template.Damages.Add(new Damage { Roll = "a ton", Type = "stabbing" });
            template.Damages.Add(new Damage { Roll = "a bit", Type = "emotional" });
            template.CriticalDamages.Add(new Damage { Roll = "a ton more", Type = "stabbing" });
            template.CriticalDamages.Add(new Damage { Roll = "a bit more", Type = "spiritual" });
            template.ThreatRange = 9266;
            template.Size = "massive";
            template.Ammunition = "nerf bullets";

            var clone = template.MundaneClone();
            itemVerifier.AssertMundaneItemFromTemplate(clone, template);
            Assert.That(clone.ItemType, Is.EqualTo(template.ItemType));
            Assert.That(clone.Attributes, Is.EquivalentTo(template.Attributes));
            Assert.That(clone.Magic.SpecialAbilities, Is.Empty);

            var cloneWeapon = clone as Weapon;
            Assert.That(cloneWeapon.Ammunition, Is.EqualTo(template.Ammunition));
            Assert.That(cloneWeapon.DamageRoll, Is.EqualTo(template.DamageRoll));
            Assert.That(cloneWeapon.DamageDescription, Is.EqualTo(template.DamageDescription));
            Assert.That(cloneWeapon.CriticalDamageRoll, Is.EqualTo(template.CriticalDamageRoll));
            Assert.That(cloneWeapon.CriticalDamageDescription, Is.EqualTo(template.CriticalDamageDescription));
            Assert.That(cloneWeapon.Size, Is.EqualTo(template.Size));
            Assert.That(cloneWeapon.ThreatRangeDescription, Is.EqualTo(template.ThreatRangeDescription));
        }

        [Test]
        public void SmartCloneIsSuccessful()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomWeaponTemplate(name);
            template.ItemType = Guid.NewGuid().ToString();

            template.Attributes = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
            template.Damages.Add(new Damage { Roll = "a ton", Type = "stabbing" });
            template.Damages.Add(new Damage { Roll = "a bit", Type = "emotional" });
            template.CriticalDamages.Add(new Damage { Roll = "a ton more", Type = "stabbing" });
            template.CriticalDamages.Add(new Damage { Roll = "a bit more", Type = "spiritual" });
            template.ThreatRange = 9266;
            template.Ammunition = "nerf bullets";
            template.Size = "massive";

            var clone = template.SmartClone();
            itemVerifier.AssertMagicalItemFromTemplate(clone, template);
            Assert.That(clone.ItemType, Is.EqualTo(template.ItemType));
            Assert.That(clone.Attributes, Is.EquivalentTo(template.Attributes));

            var cloneWeapon = clone as Weapon;
            Assert.That(cloneWeapon.Ammunition, Is.EqualTo(template.Ammunition));
            Assert.That(cloneWeapon.DamageRoll, Is.EqualTo(template.DamageRoll));
            Assert.That(cloneWeapon.DamageDescription, Is.EqualTo(template.DamageDescription));
            Assert.That(cloneWeapon.CriticalDamageRoll, Is.EqualTo(template.CriticalDamageRoll));
            Assert.That(cloneWeapon.CriticalDamageDescription, Is.EqualTo(template.CriticalDamageDescription));
            Assert.That(cloneWeapon.Size, Is.EqualTo(template.Size));
            Assert.That(cloneWeapon.ThreatRangeDescription, Is.EqualTo(template.ThreatRangeDescription));
        }

        [Test]
        public void IsMelee()
        {
            weapon.Attributes = new[] { "some attribute", AttributeConstants.Melee };
            Assert.That(weapon.CombatTypes, Contains.Item(AttributeConstants.Melee));
            Assert.That(weapon.CombatTypes.Count, Is.EqualTo(1));
        }

        [Test]
        public void IsRanged()
        {
            weapon.Attributes = new[] { "some attribute", AttributeConstants.Ranged };
            Assert.That(weapon.CombatTypes, Contains.Item(AttributeConstants.Ranged));
            Assert.That(weapon.CombatTypes.Count, Is.EqualTo(1));
        }

        [Test]
        public void IsMeleeAndRanged()
        {
            weapon.Attributes = new[] { "some attribute", AttributeConstants.Melee, "other attribute", AttributeConstants.Ranged };
            Assert.That(weapon.CombatTypes, Contains.Item(AttributeConstants.Melee));
            Assert.That(weapon.CombatTypes, Contains.Item(AttributeConstants.Ranged));
            Assert.That(weapon.CombatTypes.Count, Is.EqualTo(2));
        }

        [Test]
        public void CloneIntoCopiesProperties()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomWeaponTemplate(name);

            template.Ammunition = "nerf bullets";
            template.Damages.Add(new Damage { Roll = "a ton", Type = "stabbing" });
            template.Damages.Add(new Damage { Roll = "a bit", Type = "emotional" });
            template.CriticalDamages.Add(new Damage { Roll = "a ton more", Type = "stabbing" });
            template.CriticalDamages.Add(new Damage { Roll = "a bit more", Type = "spiritual" });
            template.Size = "massive";
            template.ThreatRange = 9266;

            var clone = new Weapon();
            var newClone = template.CloneInto(clone);
            Assert.That(newClone, Is.EqualTo(clone));
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

            Assert.That(clone.Ammunition, Is.EqualTo(template.Ammunition));
            Assert.That(clone.DamageRoll, Is.EqualTo(template.DamageRoll));
            Assert.That(clone.DamageDescription, Is.EqualTo(template.DamageDescription));
            Assert.That(clone.CriticalDamageRoll, Is.EqualTo(template.CriticalDamageRoll));
            Assert.That(clone.CriticalDamageDescription, Is.EqualTo(template.CriticalDamageDescription));
            Assert.That(clone.Size, Is.EqualTo(template.Size));
            Assert.That(clone.ThreatRangeDescription, Is.EqualTo(template.ThreatRangeDescription));
        }

        [Test]
        public void BUG_CloneIntoPrefersNonemptyProperties()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomWeaponTemplate(name);

            template.Ammunition = string.Empty;
            template.Damages.Clear();
            template.CriticalDamages.Clear();
            template.Size = string.Empty;
            template.ThreatRange = 0;
            template.Quantity = 1;

            var clone = new Weapon();
            clone.Ammunition = "nerf bullets";
            clone.Damages.Add(new Damage { Roll = "a ton", Type = "stabbing" });
            clone.Damages.Add(new Damage { Roll = "a bit", Type = "emotional" });
            clone.CriticalDamages.Add(new Damage { Roll = "a ton more", Type = "stabbing" });
            clone.CriticalDamages.Add(new Damage { Roll = "a bit more", Type = "spiritual" });
            clone.Size = "massive";
            clone.ThreatRange = 90210;
            clone.Quantity = 9266;

            var newClone = template.CloneInto(clone);
            Assert.That(newClone, Is.EqualTo(clone));
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

            Assert.That(clone.Ammunition, Is.EqualTo("nerf bullets"));
            Assert.That(clone.DamageRoll, Is.EqualTo("a ton+a bit"));
            Assert.That(clone.DamageDescription, Is.EqualTo("a ton stabbing + a bit emotional"));
            Assert.That(clone.CriticalDamageRoll, Is.EqualTo("a ton more+a bit more"));
            Assert.That(clone.CriticalDamageDescription, Is.EqualTo("a ton more stabbing + a bit more spiritual"));
            Assert.That(clone.Size, Is.EqualTo("massive"));
            Assert.That(clone.ThreatRange, Is.EqualTo(90210));
            Assert.That(clone.Quantity, Is.EqualTo(9266));
        }

        [TestCase(1, "20")]
        [TestCase(2, "19-20")]
        [TestCase(3, "18-20")]
        [TestCase(4, "17-20")]
        [TestCase(5, "16-20")]
        [TestCase(6, "15-20")]
        public void ThreatRangeDescription(int threatRange, string description)
        {
            weapon.ThreatRange = threatRange;
            Assert.That(weapon.ThreatRangeDescription, Is.EqualTo(description));
        }
    }
}
