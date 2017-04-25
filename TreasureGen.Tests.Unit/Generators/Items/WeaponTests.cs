using NUnit.Framework;
using System;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace TreasureGen.Tests.Unit.Generators.Items
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
            Assert.That(weapon.Damage, Is.Empty);
            Assert.That(weapon.DamageType, Is.Empty);
            Assert.That(weapon.Size, Is.Empty);
            Assert.That(weapon.ThreatRange, Is.Empty);
            Assert.That(weapon.CriticalMultiplier, Is.Empty);
            Assert.That(weapon.ItemType, Is.Empty); //INFO: Weapon could be a rod or staff
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
        public void CloneIsSuccessful()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomWeaponTemplate(name);

            template.Damage = "a ton";
            template.DamageType = "stabbing";
            template.ThreatRange = "all the threat";
            template.CriticalMultiplier = "over 9000!!!";
            template.Size = "massive";

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
            Assert.That(cloneWeapon.Damage, Is.EqualTo(template.Damage));
            Assert.That(cloneWeapon.DamageType, Is.EqualTo(template.DamageType));
            Assert.That(cloneWeapon.ThreatRange, Is.EqualTo(template.ThreatRange));
            Assert.That(cloneWeapon.CriticalMultiplier, Is.EqualTo(template.CriticalMultiplier));
            Assert.That(cloneWeapon.Size, Is.EqualTo(template.Size));
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
            template.Damage = "a ton";
            template.DamageType = "stabbing";
            template.ThreatRange = "all the threat";
            template.CriticalMultiplier = "over 9000!!!";
            template.Size = "massive";

            var clone = template.MundaneClone();
            itemVerifier.AssertMundaneItemFromTemplate(clone, template);
            Assert.That(clone.ItemType, Is.EqualTo(template.ItemType));
            Assert.That(clone.Attributes, Is.EquivalentTo(template.Attributes));
            Assert.That(clone.Magic.SpecialAbilities, Is.Empty);

            var cloneWeapon = clone as Weapon;
            Assert.That(cloneWeapon.Damage, Is.EqualTo(template.Damage));
            Assert.That(cloneWeapon.DamageType, Is.EqualTo(template.DamageType));
            Assert.That(cloneWeapon.ThreatRange, Is.EqualTo(template.ThreatRange));
            Assert.That(cloneWeapon.CriticalMultiplier, Is.EqualTo(template.CriticalMultiplier));
            Assert.That(cloneWeapon.Size, Is.EqualTo(template.Size));
        }

        [Test]
        public void SmartCloneIsSuccessful()
        {
            var name = Guid.NewGuid().ToString();
            var template = itemVerifier.CreateRandomWeaponTemplate(name);
            template.ItemType = Guid.NewGuid().ToString();

            template.Attributes = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
            template.Damage = "a ton";
            template.DamageType = "stabbing";
            template.ThreatRange = "all the threat";
            template.CriticalMultiplier = "over 9000!!!";
            template.Size = "massive";

            var clone = template.SmartClone();
            itemVerifier.AssertMagicalItemFromTemplate(clone, template);
            Assert.That(clone.ItemType, Is.EqualTo(template.ItemType));
            Assert.That(clone.Attributes, Is.EquivalentTo(template.Attributes));

            var cloneWeapon = clone as Weapon;
            Assert.That(cloneWeapon.Damage, Is.EqualTo(template.Damage));
            Assert.That(cloneWeapon.DamageType, Is.EqualTo(template.DamageType));
            Assert.That(cloneWeapon.ThreatRange, Is.EqualTo(template.ThreatRange));
            Assert.That(cloneWeapon.CriticalMultiplier, Is.EqualTo(template.CriticalMultiplier));
            Assert.That(cloneWeapon.Size, Is.EqualTo(template.Size));
        }
    }
}
