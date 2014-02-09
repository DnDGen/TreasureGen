using System;
using System.Linq;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Data.Items.Constants;
using EquipmentGen.Tests.Unit.Generation.Xml.Data.Attributes;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items.MagicalItems
{
    [TestFixture, TypesTable("SpecialAbilityTypes")]
    public class SpecialAbilityTypesTests : TypesTest
    {
        [Test]
        public void GlameredTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Armor
            };

            AssertContent(SpecialAbilityConstants.Glamered, types);
        }

        [Test]
        public void FortificationTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Armor
            };

            AssertContent(SpecialAbilityConstants.Fortification, types);
        }

        [Test]
        public void SlickTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Armor
            };

            AssertContent(SpecialAbilityConstants.Slick, types);
        }

        [Test]
        public void ShadowTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Armor
            };

            AssertContent(SpecialAbilityConstants.Shadow, types);
        }

        [Test]
        public void SilentMovesTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Armor
            };

            AssertContent(SpecialAbilityConstants.SilentMoves, types);
        }

        [Test]
        public void SpellResistanceTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Armor
            };

            AssertContent(SpecialAbilityConstants.SpellResistance, types);
        }

        [Test]
        public void AcidResistanceTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Armor
            };

            AssertContent(SpecialAbilityConstants.AcidResistance, types);
        }

        [Test]
        public void ColdResistanceTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Armor
            };

            AssertContent(SpecialAbilityConstants.ColdResistance, types);
        }

        [Test]
        public void ElectricityResistanceTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Armor
            };

            AssertContent(SpecialAbilityConstants.ElectricityResistance, types);
        }

        [Test]
        public void FireResistanceTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Armor
            };

            AssertContent(SpecialAbilityConstants.FireResistance, types);
        }

        [Test]
        public void SonicResistanceTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Armor
            };

            AssertContent(SpecialAbilityConstants.SonicResistance, types);
        }

        [Test]
        public void GhostTouchTypes()
        {
            AssertContent(SpecialAbilityConstants.GhostTouch, Enumerable.Empty<String>());
        }

        [Test]
        public void InvulnerabilityTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Armor
            };

            AssertContent(SpecialAbilityConstants.Invulnerability, types);
        }

        [Test]
        public void WildTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Armor
            };

            AssertContent(SpecialAbilityConstants.Wild, types);
        }

        [Test]
        public void EtherealnessTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Armor
            };

            AssertContent(SpecialAbilityConstants.Etherealness, types);
        }

        [Test]
        public void UndeadControllingTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Armor
            };

            AssertContent(SpecialAbilityConstants.UndeadControlling, types);
        }

        [Test]
        public void ArrowCatchingTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Armor,
                TypeConstants.Shield
            };

            AssertContent(SpecialAbilityConstants.ArrowCatching, types);
        }

        [Test]
        public void BashingTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Armor,
                TypeConstants.Shield,
                TypeConstants.NotTower
            };

            AssertContent(SpecialAbilityConstants.Bashing, types);
        }

        [Test]
        public void BlindingTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Armor,
                TypeConstants.Shield
            };

            AssertContent(SpecialAbilityConstants.Blinding, types);
        }

        [Test]
        public void ArrowDeflectionTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Armor,
                TypeConstants.Shield
            };

            AssertContent(SpecialAbilityConstants.ArrowDeflection, types);
        }

        [Test]
        public void AnimatedTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Armor,
                TypeConstants.Shield
            };

            AssertContent(SpecialAbilityConstants.Animated, types);
        }

        [Test]
        public void ReflectingTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Armor,
                TypeConstants.Shield
            };

            AssertContent(SpecialAbilityConstants.Reflecting, types);
        }

        [Test]
        public void BaneTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Weapon
            };

            AssertContent(SpecialAbilityConstants.Bane, types);
        }

        [Test]
        public void DistanceTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Ranged
            };

            AssertContent(SpecialAbilityConstants.Distance, types);
        }

        [Test]
        public void DisruptionTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Melee,
                TypeConstants.Bludgeoning
            };

            AssertContent(SpecialAbilityConstants.Disruption, types);
        }

        [Test]
        public void FlamingTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Weapon
            };

            AssertContent(SpecialAbilityConstants.Flaming, types);
        }

        [Test]
        public void FrostTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Weapon
            };

            AssertContent(SpecialAbilityConstants.Frost, types);
        }

        [Test]
        public void MercifulTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Weapon
            };

            AssertContent(SpecialAbilityConstants.Merciful, types);
        }

        [Test]
        public void ReturningTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Ranged,
                TypeConstants.Thrown
            };

            AssertContent(SpecialAbilityConstants.Returning, types);
        }

        [Test]
        public void ShockTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Weapon
            };

            AssertContent(SpecialAbilityConstants.Shock, types);
        }

        [Test]
        public void SeekingTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Ranged
            };

            AssertContent(SpecialAbilityConstants.Seeking, types);
        }

        [Test]
        public void ThunderingTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Weapon
            };

            AssertContent(SpecialAbilityConstants.Thundering, types);
        }

        [Test]
        public void AnarchicTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Weapon
            };

            AssertContent(SpecialAbilityConstants.Anarchic, types);
        }

        [Test]
        public void AxiomaticTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Weapon
            };

            AssertContent(SpecialAbilityConstants.Axiomatic, types);
        }

        [Test]
        public void HolyTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Weapon
            };

            AssertContent(SpecialAbilityConstants.Holy, types);
        }

        [Test]
        public void UnholyTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Weapon
            };

            AssertContent(SpecialAbilityConstants.Unholy, types);
        }

        [Test]
        public void SpeedTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Weapon
            };

            AssertContent(SpecialAbilityConstants.Speed, types);
        }

        [Test]
        public void BrilliantEnergyTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Weapon
            };

            AssertContent(SpecialAbilityConstants.BrilliantEnergy, types);
        }

        [Test]
        public void KeenTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Melee,
                TypeConstants.NotBludgeoning
            };

            AssertContent(SpecialAbilityConstants.Keen, types);
        }

        [Test]
        public void KiFocusTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Melee
            };

            AssertContent(SpecialAbilityConstants.KiFocus, types);
        }

        [Test]
        public void MightyCleavingTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Melee
            };

            AssertContent(SpecialAbilityConstants.MightyCleaving, types);
        }

        [Test]
        public void SpellStoringTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Melee
            };

            AssertContent(SpecialAbilityConstants.SpellStoring, types);
        }

        [Test]
        public void ThrowingTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Melee
            };

            AssertContent(SpecialAbilityConstants.Throwing, types);
        }

        [Test]
        public void ViciousTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Melee
            };

            AssertContent(SpecialAbilityConstants.Vicious, types);
        }

        [Test]
        public void DefendingTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Melee
            };

            AssertContent(SpecialAbilityConstants.Defending, types);
        }

        [Test]
        public void WoundingTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Melee
            };

            AssertContent(SpecialAbilityConstants.Wounding, types);
        }

        [Test]
        public void DancingTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Melee
            };

            AssertContent(SpecialAbilityConstants.Dancing, types);
        }

        [Test]
        public void VorpalTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Melee,
                TypeConstants.NotBludgeoning,
                TypeConstants.Slashing
            };

            AssertContent(SpecialAbilityConstants.Vorpal, types);
        }
    }
}