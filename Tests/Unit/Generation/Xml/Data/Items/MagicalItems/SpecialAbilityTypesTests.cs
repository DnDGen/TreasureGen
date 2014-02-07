using System;
using System.Linq;
using EquipmentGen.Core.Data.Items;
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

            AssertContent("Glamered", types);
        }

        [Test]
        public void FortificationTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Armor
            };

            AssertContent("Fortification", types);
        }

        [Test]
        public void SlickTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Armor
            };

            AssertContent("Slick", types);
        }

        [Test]
        public void ShadowTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Armor
            };

            AssertContent("Shadow", types);
        }

        [Test]
        public void SilentMovesTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Armor
            };

            AssertContent("Silent moves", types);
        }

        [Test]
        public void SpellResistanceTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Armor
            };

            AssertContent("Spell resistance", types);
        }

        [Test]
        public void AcidResistanceTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Armor
            };

            AssertContent("Acid resistance", types);
        }

        [Test]
        public void ColdResistanceTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Armor
            };

            AssertContent("Cold resistance", types);
        }

        [Test]
        public void ElectricityResistanceTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Armor
            };

            AssertContent("Electricity resistance", types);
        }

        [Test]
        public void FireResistanceTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Armor
            };

            AssertContent("Fire resistance", types);
        }

        [Test]
        public void SonicResistanceTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Armor
            };

            AssertContent("Sonic resistance", types);
        }

        [Test]
        public void GhostTouchTypes()
        {
            AssertContent("Ghost touch", Enumerable.Empty<String>());
        }

        [Test]
        public void InvulnerabilityTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Armor
            };

            AssertContent("Invulnerability", types);
        }

        [Test]
        public void WildTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Armor
            };

            AssertContent("Wild", types);
        }

        [Test]
        public void EtherealnessTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Armor
            };

            AssertContent("Etherealness", types);
        }

        [Test]
        public void UndeadControllingTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Armor
            };

            AssertContent("Undead controlling", types);
        }

        [Test]
        public void ArrowCatchingTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Armor,
                TypeConstants.Shield
            };

            AssertContent("Arrow catching", types);
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

            AssertContent("Bashing", types);
        }

        [Test]
        public void BlindingTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Armor,
                TypeConstants.Shield
            };

            AssertContent("Blinding", types);
        }

        [Test]
        public void ArrowDeflectionTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Armor,
                TypeConstants.Shield
            };

            AssertContent("Arrow deflection", types);
        }

        [Test]
        public void AnimatedTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Armor,
                TypeConstants.Shield
            };

            AssertContent("Animated", types);
        }

        [Test]
        public void ReflectingTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Armor,
                TypeConstants.Shield
            };

            AssertContent("Reflecting", types);
        }

        [Test]
        public void BaneTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Weapon
            };

            AssertContent("Bane", types);
        }

        [Test]
        public void DistanceTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Ranged
            };

            AssertContent("Distance", types);
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

            AssertContent("Disruption", types);
        }

        [Test]
        public void FlamingTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Weapon
            };

            AssertContent("Flaming", types);
        }

        [Test]
        public void FrostTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Weapon
            };

            AssertContent("Frost", types);
        }

        [Test]
        public void MercifulTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Weapon
            };

            AssertContent("Merciful", types);
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

            AssertContent("Returning", types);
        }

        [Test]
        public void ShockTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Weapon
            };

            AssertContent("Shock", types);
        }

        [Test]
        public void SeekingTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Ranged
            };

            AssertContent("Seeking", types);
        }

        [Test]
        public void ThunderingTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Weapon
            };

            AssertContent("Thundering", types);
        }

        [Test]
        public void AnarchicTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Weapon
            };

            AssertContent("Anarchic", types);
        }

        [Test]
        public void AxiomaticTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Weapon
            };

            AssertContent("Axiomatic", types);
        }

        [Test]
        public void HolyTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Weapon
            };

            AssertContent("Holy", types);
        }

        [Test]
        public void UnholyTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Weapon
            };

            AssertContent("Unholy", types);
        }

        [Test]
        public void SpeedTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Weapon
            };

            AssertContent("Speed", types);
        }

        [Test]
        public void BrilliantEnergyTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Weapon
            };

            AssertContent("Brilliant energy", types);
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

            AssertContent("Keen", types);
        }

        [Test]
        public void KiFocusTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Melee
            };

            AssertContent("Ki focus", types);
        }

        [Test]
        public void MightyCleavingTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Melee
            };

            AssertContent("Mighty cleaving", types);
        }

        [Test]
        public void SpellStoringTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Melee
            };

            AssertContent("Spell storing", types);
        }

        [Test]
        public void ThrowingTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Melee
            };

            AssertContent("Throwing", types);
        }

        [Test]
        public void ViciousTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Melee
            };

            AssertContent("Vicious", types);
        }

        [Test]
        public void DefendingTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Melee
            };

            AssertContent("Defending", types);
        }

        [Test]
        public void WoundingTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Melee
            };

            AssertContent("Wounding", types);
        }

        [Test]
        public void DancingTypes()
        {
            var types = new[]
            {
                ItemTypeConstants.Weapon,
                TypeConstants.Melee
            };

            AssertContent("Dancing", types);
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

            AssertContent("Vorpal", types);
        }
    }
}