using System;
using EquipmentGen.Common.Items;
using EquipmentGen.Tables.Interfaces;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.Rings
{
    [TestFixture]
    public class RingAttributesTests : AttributesTests
    {
        protected override String tableName
        {
            get { return String.Format(TableNameConstants.Attributes.Formattable.ITEMTYPEAttributes, ItemTypeConstants.Ring); }
        }

        [TestCase(RingConstants.FeatherFalling)]
        [TestCase(RingConstants.Sustenance)]
        [TestCase(RingConstants.Climbing)]
        [TestCase(RingConstants.Jumping)]
        [TestCase(RingConstants.Swimming)]
        [TestCase(RingConstants.Counterspells)]
        [TestCase(RingConstants.MindShielding)]
        [TestCase(RingConstants.ForceShield)]
        [TestCase(RingConstants.Climbing_Improved)]
        [TestCase(RingConstants.Jumping_Improved)]
        [TestCase(RingConstants.Swimming_Improved)]
        [TestCase(RingConstants.AnimalFriendship)]
        [TestCase(RingConstants.ChameleonPower)]
        [TestCase(RingConstants.WaterWalking)]
        [TestCase(RingConstants.ENERGYResistance_Minor)]
        [TestCase(RingConstants.SpellStoring_Minor)]
        [TestCase(RingConstants.Invisibility)]
        [TestCase(RingConstants.Wizardry_I)]
        [TestCase(RingConstants.Evasion)]
        [TestCase(RingConstants.XRayVision)]
        [TestCase(RingConstants.Blinking)]
        [TestCase(RingConstants.ENERGYResistance_Major)]
        [TestCase(RingConstants.Wizardry_II)]
        [TestCase(RingConstants.FreedomOfMovement)]
        [TestCase(RingConstants.ENERGYResistance_Greater)]
        [TestCase(RingConstants.FriendShield)]
        [TestCase(RingConstants.Protection)]
        [TestCase(RingConstants.ShootingStars)]
        [TestCase(RingConstants.SpellStoring)]
        [TestCase(RingConstants.Wizardry_III)]
        [TestCase(RingConstants.Telekinesis)]
        [TestCase(RingConstants.Regeneration)]
        [TestCase(RingConstants.SpellTurning)]
        [TestCase(RingConstants.Wizardry_IV)]
        [TestCase(RingConstants.DjinniCalling)]
        [TestCase(RingConstants.ElementalCommand_Air)]
        [TestCase(RingConstants.ElementalCommand_Earth)]
        [TestCase(RingConstants.ElementalCommand_Fire)]
        [TestCase(RingConstants.ElementalCommand_Water)]
        [TestCase(RingConstants.SpellStoring_Major)]
        [TestCase(RingConstants.Ram, AttributeConstants.Charged,
                         AttributeConstants.OneTimeUse)]
        [TestCase(RingConstants.ThreeWishes, AttributeConstants.Charged,
                                  AttributeConstants.OneTimeUse)]
        public override void Attributes(String name, params String[] attributes)
        {
            base.Attributes(name, attributes);
        }
    }
}