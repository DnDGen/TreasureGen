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
                ItemsConstants.ItemTypes.Armor
            };

            AssertContent("Glamered", types);
        }

        [Test]
        public void FortificationTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Armor
            };

            AssertContent("Fortification", types);
        }

        [Test]
        public void SlickTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Armor
            };

            AssertContent("Slick", types);
        }

        [Test]
        public void ShadowTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Armor
            };

            AssertContent("Shadow", types);
        }

        [Test]
        public void SilentMovesTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Armor
            };

            AssertContent("Silent moves", types);
        }

        [Test]
        public void SpellResistanceTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Armor
            };

            AssertContent("Spell resistance", types);
        }

        [Test]
        public void AcidResistanceTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Armor
            };

            AssertContent("Acid resistance", types);
        }

        [Test]
        public void ColdResistanceTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Armor
            };

            AssertContent("Cold resistance", types);
        }

        [Test]
        public void ElectricityResistanceTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Armor
            };

            AssertContent("Electricity resistance", types);
        }

        [Test]
        public void FireResistanceTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Armor
            };

            AssertContent("Fire resistance", types);
        }

        [Test]
        public void SonicResistanceTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Armor
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
                ItemsConstants.ItemTypes.Armor
            };

            AssertContent("Invulnerability", types);
        }

        [Test]
        public void WildTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Armor
            };

            AssertContent("Wild", types);
        }

        [Test]
        public void EtherealnessTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Armor
            };

            AssertContent("Etherealness", types);
        }

        [Test]
        public void UndeadControllingTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Armor
            };

            AssertContent("Undead controlling", types);
        }

        [Test]
        public void ArrowCatchingTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Armor,
                ItemsConstants.Gear.Types.Shield
            };

            AssertContent("Arrow catching", types);
        }

        [Test]
        public void BashingTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Armor,
                ItemsConstants.Gear.Types.Shield
            };

            AssertContent("Bashing", types);
        }

        [Test]
        public void BlindingTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Armor,
                ItemsConstants.Gear.Types.Shield
            };

            AssertContent("Blinding", types);
        }

        [Test]
        public void ArrowDeflectionTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Armor,
                ItemsConstants.Gear.Types.Shield
            };

            AssertContent("Arrow deflection", types);
        }

        [Test]
        public void AnimatedTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Armor,
                ItemsConstants.Gear.Types.Shield
            };

            AssertContent("Animated", types);
        }

        [Test]
        public void ReflectingTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Armor,
                ItemsConstants.Gear.Types.Shield
            };

            AssertContent("Reflecting", types);
        }

        [Test]
        public void BaneTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Weapon
            };

            AssertContent("Bane", types);
        }

        [Test]
        public void DistanceTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Ranged
            };

            AssertContent("Distance", types);
        }

        [Test]
        public void FlamingTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Weapon
            };

            AssertContent("Flaming", types);
        }

        [Test]
        public void FrostTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Weapon
            };

            AssertContent("Frost", types);
        }

        [Test]
        public void MercifulTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Ranged
            };

            AssertContent("Merciful", types);
        }

        [Test]
        public void ReturningTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Ranged,
                ItemsConstants.Gear.Types.Thrown
            };

            AssertContent("Returning", types);
        }

        [Test]
        public void ShockTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Weapon
            };

            AssertContent("Shock", types);
        }

        [Test]
        public void SeekingTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Ranged
            };

            AssertContent("Seeking", types);
        }

        [Test]
        public void ThunderingTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Weapon
            };

            AssertContent("Thundering", types);
        }

        [Test]
        public void AnarchicTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Weapon
            };

            AssertContent("Anarchic", types);
        }

        [Test]
        public void AxiomaticTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Weapon
            };

            AssertContent("Axiomatic", types);
        }

        [Test]
        public void HolyTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Weapon
            };

            AssertContent("Holy", types);
        }

        [Test]
        public void UnholyTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Weapon
            };

            AssertContent("Unholy", types);
        }

        [Test]
        public void SpeedTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Weapon
            };

            AssertContent("Speed", types);
        }

        [Test]
        public void BrilliantEnergyTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Weapon
            };

            AssertContent("Brilliant energy", types);
        }

        [Test]
        public void DefendingTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Melee
            };

            AssertContent("Defending", types);
        }

        [Test]
        public void KeenTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Melee,
                ItemsConstants.Gear.Types.PiercingOrSlashing
            };

            AssertContent("Defending", types);
        }

        [Test]
        public void KiFocusTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Melee
            };

            AssertContent("Ki focus", types);
        }

        [Test]
        public void MightyCleavingTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Melee
            };

            AssertContent("Mighty cleaving", types);
        }

        [Test]
        public void SpellStoringTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Melee
            };

            AssertContent("Spell storing", types);
        }

        [Test]
        public void ThrowingTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Melee
            };

            AssertContent("Throwing", types);
        }

        [Test]
        public void ViciousTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Melee
            };

            AssertContent("Vicious", types);
        }

        [Test]
        public void DisruptionTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Melee,
                ItemsConstants.Gear.Types.Bludgeoning
            };

            AssertContent("Defending", types);
        }

        [Test]
        public void WoundingTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Melee
            };

            AssertContent("Wounding", types);
        }

        [Test]
        public void DancingTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Melee
            };

            AssertContent("Dancing", types);
        }

        [Test]
        public void VorpalTypes()
        {
            var types = new[]
            {
                ItemsConstants.ItemTypes.Weapon,
                ItemsConstants.Gear.Types.Melee,
                ItemsConstants.Gear.Types.PiercingOrSlashing,
                ItemsConstants.Gear.Types.Slashing
            };

            AssertContent("Vorpal", types);
        }
    }
}