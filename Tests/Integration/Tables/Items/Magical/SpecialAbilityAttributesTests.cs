using System;
using System.Linq;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical
{
    [TestFixture]
    public class SpecialAbilityAttributesTests : AttributesTests
    {
        protected override String tableName
        {
            get { return "GemDescriptions"; }
        }

        protected override String GetTableName()
        {
            return "SpecialAbilityAttributes";
        }

        [Test]
        public void GlameredAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Armor
            };

            AssertAttributes(SpecialAbilityConstants.Glamered, attributes);
        }

        [Test]
        public void FortificationAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Armor
            };

            AssertAttributes(SpecialAbilityConstants.Fortification, attributes);
        }

        [Test]
        public void SlickAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Armor
            };

            AssertAttributes(SpecialAbilityConstants.Slick, attributes);
        }

        [Test]
        public void ShadowAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Armor
            };

            AssertAttributes(SpecialAbilityConstants.Shadow, attributes);
        }

        [Test]
        public void SilentMovesAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Armor
            };

            AssertAttributes(SpecialAbilityConstants.SilentMoves, attributes);
        }

        [Test]
        public void SpellResistanceAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Armor
            };

            AssertAttributes(SpecialAbilityConstants.SpellResistance, attributes);
        }

        [Test]
        public void AcidResistanceAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Armor
            };

            AssertAttributes(SpecialAbilityConstants.AcidResistance, attributes);
        }

        [Test]
        public void ColdResistanceAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Armor
            };

            AssertAttributes(SpecialAbilityConstants.ColdResistance, attributes);
        }

        [Test]
        public void ElectricityResistanceAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Armor
            };

            AssertAttributes(SpecialAbilityConstants.ElectricityResistance, attributes);
        }

        [Test]
        public void FireResistanceAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Armor
            };

            AssertAttributes(SpecialAbilityConstants.FireResistance, attributes);
        }

        [Test]
        public void SonicResistanceAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Armor
            };

            AssertAttributes(SpecialAbilityConstants.SonicResistance, attributes);
        }

        [Test]
        public void GhostTouchAttributes()
        {
            AssertAttributes(SpecialAbilityConstants.GhostTouch, Enumerable.Empty<String>());
        }

        [Test]
        public void InvulnerabilityAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Armor
            };

            AssertAttributes(SpecialAbilityConstants.Invulnerability, attributes);
        }

        [Test]
        public void WildAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Armor
            };

            AssertAttributes(SpecialAbilityConstants.Wild, attributes);
        }

        [Test]
        public void EtherealnessAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Armor
            };

            AssertAttributes(SpecialAbilityConstants.Etherealness, attributes);
        }

        [Test]
        public void UndeadControllingAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Armor
            };

            AssertAttributes(SpecialAbilityConstants.UndeadControlling, attributes);
        }

        [Test]
        public void ArrowCatchingAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Armor,
                AttributeConstants.Shield
            };

            AssertAttributes(SpecialAbilityConstants.ArrowCatching, attributes);
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

            AssertAttributes(SpecialAbilityConstants.Bashing, attributes);
        }

        [Test]
        public void BlindingAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Armor,
                AttributeConstants.Shield
            };

            AssertAttributes(SpecialAbilityConstants.Blinding, attributes);
        }

        [Test]
        public void ArrowDeflectionAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Armor,
                AttributeConstants.Shield
            };

            AssertAttributes(SpecialAbilityConstants.ArrowDeflection, attributes);
        }

        [Test]
        public void AnimatedAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Armor,
                AttributeConstants.Shield
            };

            AssertAttributes(SpecialAbilityConstants.Animated, attributes);
        }

        [Test]
        public void ReflectingAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Armor,
                AttributeConstants.Shield
            };

            AssertAttributes(SpecialAbilityConstants.Reflecting, attributes);
        }

        [Test]
        public void BaneAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Weapon
            };

            AssertAttributes(SpecialAbilityConstants.Bane, attributes);
        }

        [Test]
        public void DistanceAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Ranged
            };

            AssertAttributes(SpecialAbilityConstants.Distance, attributes);
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

            AssertAttributes(SpecialAbilityConstants.Disruption, attributes);
        }

        [Test]
        public void FlamingAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Weapon
            };

            AssertAttributes(SpecialAbilityConstants.Flaming, attributes);
        }

        [Test]
        public void FrostAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Weapon
            };

            AssertAttributes(SpecialAbilityConstants.Frost, attributes);
        }

        [Test]
        public void MercifulAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Weapon
            };

            AssertAttributes(SpecialAbilityConstants.Merciful, attributes);
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

            AssertAttributes(SpecialAbilityConstants.Returning, attributes);
        }

        [Test]
        public void ShockAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Weapon
            };

            AssertAttributes(SpecialAbilityConstants.Shock, attributes);
        }

        [Test]
        public void SeekingAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Ranged
            };

            AssertAttributes(SpecialAbilityConstants.Seeking, attributes);
        }

        [Test]
        public void ThunderingAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Weapon
            };

            AssertAttributes(SpecialAbilityConstants.Thundering, attributes);
        }

        [Test]
        public void AnarchicAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Weapon
            };

            AssertAttributes(SpecialAbilityConstants.Anarchic, attributes);
        }

        [Test]
        public void AxiomaticAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Weapon
            };

            AssertAttributes(SpecialAbilityConstants.Axiomatic, attributes);
        }

        [Test]
        public void HolyAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Weapon
            };

            AssertAttributes(SpecialAbilityConstants.Holy, attributes);
        }

        [Test]
        public void UnholyAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Weapon
            };

            AssertAttributes(SpecialAbilityConstants.Unholy, attributes);
        }

        [Test]
        public void SpeedAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Weapon
            };

            AssertAttributes(SpecialAbilityConstants.Speed, attributes);
        }

        [Test]
        public void BrilliantEnergyAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Weapon
            };

            AssertAttributes(SpecialAbilityConstants.BrilliantEnergy, attributes);
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

            AssertAttributes(SpecialAbilityConstants.Keen, attributes);
        }

        [Test]
        public void KiFocusAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Melee
            };

            AssertAttributes(SpecialAbilityConstants.KiFocus, attributes);
        }

        [Test]
        public void MightyCleavingAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Melee
            };

            AssertAttributes(SpecialAbilityConstants.MightyCleaving, attributes);
        }

        [Test]
        public void SpellStoringAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Melee
            };

            AssertAttributes(SpecialAbilityConstants.SpellStoring, attributes);
        }

        [Test]
        public void ThrowingAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Melee
            };

            AssertAttributes(SpecialAbilityConstants.Throwing, attributes);
        }

        [Test]
        public void ViciousAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Melee
            };

            AssertAttributes(SpecialAbilityConstants.Vicious, attributes);
        }

        [Test]
        public void DefendingAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Melee
            };

            AssertAttributes(SpecialAbilityConstants.Defending, attributes);
        }

        [Test]
        public void WoundingAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Melee
            };

            AssertAttributes(SpecialAbilityConstants.Wounding, attributes);
        }

        [Test]
        public void DancingAttributes()
        {
            var attributes = new[]
            {
                ItemTypeConstants.Weapon,
                AttributeConstants.Melee
            };

            AssertAttributes(SpecialAbilityConstants.Dancing, attributes);
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

            AssertAttributes(SpecialAbilityConstants.Vorpal, attributes);
        }
    }
}