using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Rings
{
    [TestFixture]
    public class RingAttributesTests : AttributesTests
    {
        protected override String tableName
        {
            get { return "RingAttributes"; }
        }

        [TestCase("Feather falling")]
        [TestCase("Sustenance")]
        [TestCase("Climbing")]
        [TestCase("Jumping")]
        [TestCase("Swimming")]
        [TestCase("Counterspells")]
        [TestCase("Mind shielding")]
        [TestCase("Force shield")]
        [TestCase("Improved climbing")]
        [TestCase("Improved jumping")]
        [TestCase("Improved swimming")]
        [TestCase("Animal friendship")]
        [TestCase("Chameleon power")]
        [TestCase("Water walking")]
        [TestCase("Minor ENERGY resistance")]
        [TestCase("Minor spell storing")]
        [TestCase("Invisibility")]
        [TestCase("Wizardry (I)")]
        [TestCase("Evasion")]
        [TestCase("X-ray vision")]
        [TestCase("Blinking")]
        [TestCase("Major ENERGY resistance")]
        [TestCase("Wizardry (II)")]
        [TestCase("Freedom of movement")]
        [TestCase("Greater ENERGY resistance")]
        [TestCase("Friend shield (pair)")]
        [TestCase("Protection")]
        [TestCase("Shooting stars")]
        [TestCase("Spell storing")]
        [TestCase("Wizardry (III)")]
        [TestCase("Telekinesis")]
        [TestCase("Regeneration")]
        [TestCase("Spell turning")]
        [TestCase("Wizardry (IV)")]
        [TestCase("Djinni calling")]
        [TestCase("Elemental command (air)")]
        [TestCase("Elemental command (earth)")]
        [TestCase("Elemental command (fire)")]
        [TestCase("Elemental command (water)")]
        [TestCase("Major spell storing")]
        [TestCase("Ram", AttributeConstants.Charged,
                         AttributeConstants.OneTimeUse)]
        [TestCase("Three wishes", AttributeConstants.Charged,
                                  AttributeConstants.OneTimeUse)]
        public override void Attributes(String name, params String[] attributes)
        {
            base.Attributes(name, attributes);
        }
    }
}