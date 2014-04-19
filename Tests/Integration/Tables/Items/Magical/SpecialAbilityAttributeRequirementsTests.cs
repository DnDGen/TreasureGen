using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical
{
    [TestFixture]
    public class SpecialAbilityAttributeRequirementsTests : AttributesTests
    {
        protected override String tableName
        {
            get { return "SpecialAbilityAttributeRequirements"; }
        }

        [TestCase(SpecialAbilityConstants.Glamered, ItemTypeConstants.Armor)]
        [TestCase(SpecialAbilityConstants.Fortification, ItemTypeConstants.Armor)]
        [TestCase(SpecialAbilityConstants.Slick, ItemTypeConstants.Armor)]
        [TestCase(SpecialAbilityConstants.Shadow, ItemTypeConstants.Armor)]
        [TestCase(SpecialAbilityConstants.SilentMoves, ItemTypeConstants.Armor)]
        [TestCase(SpecialAbilityConstants.SpellResistance, ItemTypeConstants.Armor)]
        [TestCase(SpecialAbilityConstants.AcidResistance, ItemTypeConstants.Armor)]
        [TestCase(SpecialAbilityConstants.ColdResistance, ItemTypeConstants.Armor)]
        [TestCase(SpecialAbilityConstants.ElectricityResistance, ItemTypeConstants.Armor)]
        [TestCase(SpecialAbilityConstants.FireResistance, ItemTypeConstants.Armor)]
        [TestCase(SpecialAbilityConstants.SonicResistance, ItemTypeConstants.Armor)]
        [TestCase(SpecialAbilityConstants.GhostTouch)]
        [TestCase(SpecialAbilityConstants.Invulnerability, ItemTypeConstants.Armor)]
        [TestCase(SpecialAbilityConstants.Wild, ItemTypeConstants.Armor)]
        [TestCase(SpecialAbilityConstants.Etherealness, ItemTypeConstants.Armor)]
        [TestCase(SpecialAbilityConstants.UndeadControlling, ItemTypeConstants.Armor)]
        [TestCase(SpecialAbilityConstants.ArrowCatching, ItemTypeConstants.Armor,
                                                         AttributeConstants.Shield)]
        [TestCase(SpecialAbilityConstants.Bashing, ItemTypeConstants.Armor,
                                                   AttributeConstants.Shield,
                                                   AttributeConstants.NotTower)]
        [TestCase(SpecialAbilityConstants.Blinding, ItemTypeConstants.Armor,
                                                    AttributeConstants.Shield)]
        [TestCase(SpecialAbilityConstants.ArrowDeflection, ItemTypeConstants.Armor,
                                                           AttributeConstants.Shield)]
        [TestCase(SpecialAbilityConstants.Animated, ItemTypeConstants.Armor,
                                                    AttributeConstants.Shield)]
        [TestCase(SpecialAbilityConstants.Reflecting, ItemTypeConstants.Armor,
                                                      AttributeConstants.Shield)]
        [TestCase(SpecialAbilityConstants.Bane, ItemTypeConstants.Weapon)]
        [TestCase(SpecialAbilityConstants.Distance, ItemTypeConstants.Weapon,
                                                    AttributeConstants.Ranged)]
        [TestCase(SpecialAbilityConstants.Disruption, ItemTypeConstants.Weapon,
                                                      AttributeConstants.Melee,
                                                      AttributeConstants.Bludgeoning)]
        [TestCase(SpecialAbilityConstants.Flaming, ItemTypeConstants.Weapon)]
        [TestCase(SpecialAbilityConstants.Frost, ItemTypeConstants.Weapon)]
        [TestCase(SpecialAbilityConstants.Merciful, ItemTypeConstants.Weapon)]
        [TestCase(SpecialAbilityConstants.Returning, ItemTypeConstants.Weapon,
                                                     AttributeConstants.Ranged,
                                                     AttributeConstants.Thrown)]
        [TestCase(SpecialAbilityConstants.Shock, ItemTypeConstants.Weapon)]
        [TestCase(SpecialAbilityConstants.Seeking, ItemTypeConstants.Weapon,
                                                   AttributeConstants.Ranged)]
        [TestCase(SpecialAbilityConstants.Thundering, ItemTypeConstants.Weapon)]
        [TestCase(SpecialAbilityConstants.Anarchic, ItemTypeConstants.Weapon)]
        [TestCase(SpecialAbilityConstants.Axiomatic, ItemTypeConstants.Weapon)]
        [TestCase(SpecialAbilityConstants.Holy, ItemTypeConstants.Weapon)]
        [TestCase(SpecialAbilityConstants.Unholy, ItemTypeConstants.Weapon)]
        [TestCase(SpecialAbilityConstants.Speed, ItemTypeConstants.Weapon)]
        [TestCase(SpecialAbilityConstants.BrilliantEnergy, ItemTypeConstants.Weapon)]
        [TestCase(SpecialAbilityConstants.Keen, ItemTypeConstants.Weapon,
                                                AttributeConstants.Melee,
                                                AttributeConstants.NotBludgeoning)]
        [TestCase(SpecialAbilityConstants.KiFocus, ItemTypeConstants.Weapon,
                                                   AttributeConstants.Melee)]
        [TestCase(SpecialAbilityConstants.MightyCleaving, ItemTypeConstants.Weapon,
                                                          AttributeConstants.Melee)]
        [TestCase(SpecialAbilityConstants.SpellStoring, ItemTypeConstants.Weapon,
                                                        AttributeConstants.Melee)]
        [TestCase(SpecialAbilityConstants.Throwing, ItemTypeConstants.Weapon,
                                                    AttributeConstants.Melee)]
        [TestCase(SpecialAbilityConstants.Vicious, ItemTypeConstants.Weapon,
                                                   AttributeConstants.Melee)]
        [TestCase(SpecialAbilityConstants.Defending, ItemTypeConstants.Weapon,
                                                     AttributeConstants.Melee)]
        [TestCase(SpecialAbilityConstants.Wounding, ItemTypeConstants.Weapon,
                                                    AttributeConstants.Melee)]
        [TestCase(SpecialAbilityConstants.Dancing, ItemTypeConstants.Weapon,
                                                   AttributeConstants.Melee)]
        [TestCase(SpecialAbilityConstants.Vorpal, ItemTypeConstants.Weapon,
                                                  AttributeConstants.Melee,
                                                  AttributeConstants.NotBludgeoning,
                                                  AttributeConstants.Slashing)]
        public void Attributes(String name, params String[] attributes)
        {
            AssertAttributes(name, attributes);
        }
    }
}