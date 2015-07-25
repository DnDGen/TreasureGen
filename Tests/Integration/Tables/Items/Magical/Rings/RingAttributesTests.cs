using System;
using TreasureGen.Common.Items;
using TreasureGen.Tables;
using NUnit.Framework;

namespace TreasureGen.Tests.Integration.Tables.Items.Magical.Rings
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
        [TestCase(RingConstants.AcidResistance_Minor)]
        [TestCase(RingConstants.ColdResistance_Minor)]
        [TestCase(RingConstants.ElectricityResistance_Minor)]
        [TestCase(RingConstants.FireResistance_Minor)]
        [TestCase(RingConstants.SonicResistance_Minor)]
        [TestCase(RingConstants.SpellStoring_Minor)]
        [TestCase(RingConstants.Invisibility)]
        [TestCase(RingConstants.Wizardry_I)]
        [TestCase(RingConstants.Evasion)]
        [TestCase(RingConstants.XRayVision)]
        [TestCase(RingConstants.Blinking)]
        [TestCase(RingConstants.AcidResistance_Major)]
        [TestCase(RingConstants.ColdResistance_Major)]
        [TestCase(RingConstants.ElectricityResistance_Major)]
        [TestCase(RingConstants.FireResistance_Major)]
        [TestCase(RingConstants.SonicResistance_Major)]
        [TestCase(RingConstants.Wizardry_II)]
        [TestCase(RingConstants.FreedomOfMovement)]
        [TestCase(RingConstants.AcidResistance_Greater)]
        [TestCase(RingConstants.ColdResistance_Greater)]
        [TestCase(RingConstants.ElectricityResistance_Greater)]
        [TestCase(RingConstants.FireResistance_Greater)]
        [TestCase(RingConstants.SonicResistance_Greater)]
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