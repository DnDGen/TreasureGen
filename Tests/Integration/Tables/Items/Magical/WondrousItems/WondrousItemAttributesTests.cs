using System;
using EquipmentGen.Common.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Tables.Items.Magical.WondrousItems
{
    [TestFixture]
    public class WondrousItemAttributesTests : AttributesTests
    {
        protected override String tableName
        {
            get { return "WondrousItemAttributes"; }
        }

        [TestCase("Bead of force", AttributeConstants.OneTimeUse)]
        [TestCase("Bracelet of friends", AttributeConstants.OneTimeUse,
                                         AttributeConstants.Charged)]
        [TestCase("Brooch of shielding", AttributeConstants.OneTimeUse,
                                         AttributeConstants.Charged)]
        [TestCase("Candle of invocation", AttributeConstants.OneTimeUse)]
        [TestCase("Candle of truth", AttributeConstants.OneTimeUse)]
        [TestCase("Chime of opening", AttributeConstants.OneTimeUse,
                                      AttributeConstants.Charged)]
        [TestCase("Deck of illusions", AttributeConstants.OneTimeUse,
                                       AttributeConstants.Charged)]
        [TestCase("Dust of appearance", AttributeConstants.OneTimeUse)]
        [TestCase("Dust of disappearance", AttributeConstants.OneTimeUse)]
        [TestCase("Dust of illusion", AttributeConstants.OneTimeUse)]
        [TestCase("Dust of tracelessness", AttributeConstants.OneTimeUse)]
        [TestCase("Elemental gem", AttributeConstants.OneTimeUse)]
        [TestCase("Elixer of fire breath", AttributeConstants.OneTimeUse)]
        [TestCase("Elixer of hiding", AttributeConstants.OneTimeUse)]
        [TestCase("Elixer of love", AttributeConstants.OneTimeUse)]
        [TestCase("Elixer of sneaking", AttributeConstants.OneTimeUse)]
        [TestCase("Elixer of swimming", AttributeConstants.OneTimeUse)]
        [TestCase("Elixer of truth", AttributeConstants.OneTimeUse)]
        [TestCase("Elixer of vision", AttributeConstants.OneTimeUse)]
        [TestCase("Gem of brightness", AttributeConstants.OneTimeUse,
                                       AttributeConstants.Charged)]
        [TestCase("Clay golem manual", AttributeConstants.OneTimeUse)]
        [TestCase("Flesh golem manual", AttributeConstants.OneTimeUse)]
        [TestCase("Iron golem manual", AttributeConstants.OneTimeUse)]
        [TestCase("Stone golem manual", AttributeConstants.OneTimeUse)]
        [TestCase("Greater stone golem manual", AttributeConstants.OneTimeUse)]
        [TestCase("Incense of meditation", AttributeConstants.OneTimeUse)]
        [TestCase("Keoghtom's ointment", AttributeConstants.OneTimeUse,
                                         AttributeConstants.Charged)]
        [TestCase("Manual of bodily health", AttributeConstants.OneTimeUse)]
        [TestCase("Manual of gainful exercise", AttributeConstants.OneTimeUse)]
        [TestCase("Manual of quickness in action", AttributeConstants.OneTimeUse)]
        [TestCase("Manual of quickness in action", AttributeConstants.OneTimeUse)]
        [TestCase("Nolzur's marvelous pigments", AttributeConstants.OneTimeUse)]
        [TestCase("Quaal's feather token", AttributeConstants.OneTimeUse)]
        [TestCase("Robe of useful items", AttributeConstants.OneTimeUse)]
        [TestCase("Robe of bones", AttributeConstants.OneTimeUse)]
        [TestCase("Salve of slipperiness", AttributeConstants.OneTimeUse)]
        [TestCase("Sovereign glue", AttributeConstants.OneTimeUse)]
        [TestCase("Scarab of protection", AttributeConstants.OneTimeUse,
                                          AttributeConstants.Charged)]
        [TestCase("Shrouds of disintegration", AttributeConstants.OneTimeUse)]
        [TestCase("Silversheen", AttributeConstants.OneTimeUse)]
        [TestCase("Stone salve", AttributeConstants.OneTimeUse)]
        [TestCase("Tome of clear thought", AttributeConstants.OneTimeUse)]
        [TestCase("Tome of leadership and influence", AttributeConstants.OneTimeUse)]
        [TestCase("Tome of understanding", AttributeConstants.OneTimeUse)]
        [TestCase("Unguent of timelessness", AttributeConstants.OneTimeUse)]
        [TestCase("Universal solvent", AttributeConstants.OneTimeUse)]
        public void Attributes(String name, params String[] attributes)
        {
            AssertAttributes(name, attributes);
        }
    }
}