using System;
using System.Linq;
using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items.MagicalItems
{
    [TestFixture, AttributesTable("SpecialAbilityAttributes")]
    public class SpecialAbilityAttributesTests : AttributesTests
    {
        [Test]
        public void GlameredAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Armor
            };

            AssertContent(SpecialAbilityConstants.Glamered, attributes);
        }

        [Test]
        public void FortificationAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Armor
            };

            AssertContent(SpecialAbilityConstants.Fortification, attributes);
        }

        [Test]
        public void SlickAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Armor
            };

            AssertContent(SpecialAbilityConstants.Slick, attributes);
        }

        [Test]
        public void ShadowAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Armor
            };

            AssertContent(SpecialAbilityConstants.Shadow, attributes);
        }

        [Test]
        public void SilentMovesAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Armor
            };

            AssertContent(SpecialAbilityConstants.SilentMoves, attributes);
        }

        [Test]
        public void SpellResistanceAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Armor
            };

            AssertContent(SpecialAbilityConstants.SpellResistance, attributes);
        }

        [Test]
        public void AcidResistanceAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Armor
            };

            AssertContent(SpecialAbilityConstants.AcidResistance, attributes);
        }

        [Test]
        public void ColdResistanceAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Armor
            };

            AssertContent(SpecialAbilityConstants.ColdResistance, attributes);
        }

        [Test]
        public void ElectricityResistanceAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Armor
            };

            AssertContent(SpecialAbilityConstants.ElectricityResistance, attributes);
        }

        [Test]
        public void FireResistanceAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Armor
            };

            AssertContent(SpecialAbilityConstants.FireResistance, attributes);
        }

        [Test]
        public void SonicResistanceAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Armor
            };

            AssertContent(SpecialAbilityConstants.SonicResistance, attributes);
        }

        [Test]
        public void GhostTouchAttributes()
        {
            AssertContent(SpecialAbilityConstants.GhostTouch, Enumerable.Empty<String>());
        }

        [Test]
        public void InvulnerabilityAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Armor
            };

            AssertContent(SpecialAbilityConstants.Invulnerability, attributes);
        }

        [Test]
        public void WildAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Armor
            };

            AssertContent(SpecialAbilityConstants.Wild, attributes);
        }

        [Test]
        public void EtherealnessAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Armor
            };

            AssertContent(SpecialAbilityConstants.Etherealness, attributes);
        }

        [Test]
        public void UndeadControllingAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Armor
            };

            AssertContent(SpecialAbilityConstants.UndeadControlling, attributes);
        }

        [Test]
        public void ArrowCatchingAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Armor,
                AttributeConstants.Shield
            };

            AssertContent(SpecialAbilityConstants.ArrowCatching, attributes);
        }

        [Test]
        public void BashingAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Armor,
                AttributeConstants.Shield,
                AttributeConstants.NotTower
            };

            AssertContent(SpecialAbilityConstants.Bashing, attributes);
        }

        [Test]
        public void BlindingAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Armor,
                AttributeConstants.Shield
            };

            AssertContent(SpecialAbilityConstants.Blinding, attributes);
        }

        [Test]
        public void ArrowDeflectionAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Armor,
                AttributeConstants.Shield
            };

            AssertContent(SpecialAbilityConstants.ArrowDeflection, attributes);
        }

        [Test]
        public void AnimatedAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Armor,
                AttributeConstants.Shield
            };

            AssertContent(SpecialAbilityConstants.Animated, attributes);
        }

        [Test]
        public void ReflectingAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Armor,
                AttributeConstants.Shield
            };

            AssertContent(SpecialAbilityConstants.Reflecting, attributes);
        }

        [Test]
        public void BaneAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Weapon
            };

            AssertContent(SpecialAbilityConstants.Bane, attributes);
        }

        [Test]
        public void DistanceAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Ranged
            };

            AssertContent(SpecialAbilityConstants.Distance, attributes);
        }

        [Test]
        public void DisruptionAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Melee,
                AttributeConstants.Bludgeoning
            };

            AssertContent(SpecialAbilityConstants.Disruption, attributes);
        }

        [Test]
        public void FlamingAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Weapon
            };

            AssertContent(SpecialAbilityConstants.Flaming, attributes);
        }

        [Test]
        public void FrostAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Weapon
            };

            AssertContent(SpecialAbilityConstants.Frost, attributes);
        }

        [Test]
        public void MercifulAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Weapon
            };

            AssertContent(SpecialAbilityConstants.Merciful, attributes);
        }

        [Test]
        public void ReturningAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Ranged,
                AttributeConstants.Thrown
            };

            AssertContent(SpecialAbilityConstants.Returning, attributes);
        }

        [Test]
        public void ShockAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Weapon
            };

            AssertContent(SpecialAbilityConstants.Shock, attributes);
        }

        [Test]
        public void SeekingAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Ranged
            };

            AssertContent(SpecialAbilityConstants.Seeking, attributes);
        }

        [Test]
        public void ThunderingAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Weapon
            };

            AssertContent(SpecialAbilityConstants.Thundering, attributes);
        }

        [Test]
        public void AnarchicAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Weapon
            };

            AssertContent(SpecialAbilityConstants.Anarchic, attributes);
        }

        [Test]
        public void AxiomaticAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Weapon
            };

            AssertContent(SpecialAbilityConstants.Axiomatic, attributes);
        }

        [Test]
        public void HolyAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Weapon
            };

            AssertContent(SpecialAbilityConstants.Holy, attributes);
        }

        [Test]
        public void UnholyAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Weapon
            };

            AssertContent(SpecialAbilityConstants.Unholy, attributes);
        }

        [Test]
        public void SpeedAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Weapon
            };

            AssertContent(SpecialAbilityConstants.Speed, attributes);
        }

        [Test]
        public void BrilliantEnergyAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Weapon
            };

            AssertContent(SpecialAbilityConstants.BrilliantEnergy, attributes);
        }

        [Test]
        public void KeenAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Melee,
                AttributeConstants.NotBludgeoning
            };

            AssertContent(SpecialAbilityConstants.Keen, attributes);
        }

        [Test]
        public void KiFocusAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Melee
            };

            AssertContent(SpecialAbilityConstants.KiFocus, attributes);
        }

        [Test]
        public void MightyCleavingAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Melee
            };

            AssertContent(SpecialAbilityConstants.MightyCleaving, attributes);
        }

        [Test]
        public void SpellStoringAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Melee
            };

            AssertContent(SpecialAbilityConstants.SpellStoring, attributes);
        }

        [Test]
        public void ThrowingAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Melee
            };

            AssertContent(SpecialAbilityConstants.Throwing, attributes);
        }

        [Test]
        public void ViciousAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Melee
            };

            AssertContent(SpecialAbilityConstants.Vicious, attributes);
        }

        [Test]
        public void DefendingAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Melee
            };

            AssertContent(SpecialAbilityConstants.Defending, attributes);
        }

        [Test]
        public void WoundingAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Melee
            };

            AssertContent(SpecialAbilityConstants.Wounding, attributes);
        }

        [Test]
        public void DancingAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Melee
            };

            AssertContent(SpecialAbilityConstants.Dancing, attributes);
        }

        [Test]
        public void VorpalAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Melee,
                AttributeConstants.NotBludgeoning,
                AttributeConstants.Slashing
            };

            AssertContent(SpecialAbilityConstants.Vorpal, attributes);
        }
    }
}