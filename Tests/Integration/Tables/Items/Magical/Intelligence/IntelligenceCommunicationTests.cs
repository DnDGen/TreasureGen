using System;
using TreasureGen.Tables;
using NUnit.Framework;

namespace TreasureGen.Tests.Integration.Tables.Items.Magical.Intelligence
{
    [TestFixture]
    public class IntelligenceCommunicationTests : AttributesTests
    {
        protected override String tableName
        {
            get { return TableNameConstants.Attributes.Set.IntelligenceCommunication; }
        }

        [TestCase(12,
            "Empathy")]
        [TestCase(13,
            "Empathy")]
        [TestCase(14,
            "Speech")]
        [TestCase(15,
            "Speech")]
        [TestCase(16,
            "Speech",
            "Read")]
        [TestCase(17, "Speech",
            "Read",
            "Telepathy")]
        [TestCase(18,
            "Speech",
            "Read all languages",
            "Read magic",
            "Telepathy")]
        [TestCase(19,
            "Speech",
            "Read all languages",
            "Read magic",
            "Telepathy")]
        public void Attributes(Int32 highStat, params String[] attributes)
        {
            var name = Convert.ToString(highStat);
            base.Attributes(name, attributes);
        }
    }
}