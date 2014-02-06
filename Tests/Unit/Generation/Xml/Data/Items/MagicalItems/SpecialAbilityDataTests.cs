using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Core.Generation.Providers;
using EquipmentGen.Core.Generation.Providers.Interfaces;
using EquipmentGen.Core.Generation.Xml.Parsers;
using EquipmentGen.Core.Generation.Xml.Parsers.Interfaces;
using EquipmentGen.Core.Generation.Xml.Parsers.Objects;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Data.Items.MagicalItems
{
    [TestFixture]
    public class SpecialAbilityDataTests
    {
        private Dictionary<String, SpecialAbilityDataObject> data;

        public SpecialAbilityDataTests()
        {
            var streamLoader = new EmbeddedResourceStreamLoader();
            var parser = new SpecialAbilityDataXmlParser(streamLoader);
            data = parser.Parse("SpecialAbilityData.xml");
        }

        [Test]
        public void GlameredData()
        {
            Assert.That(data[SpecialAbilityConstants.Glamered].BonusEquivalent, Is.EqualTo(0));
            Assert.That(data[SpecialAbilityConstants.Glamered].CoreName, Is.EqualTo(SpecialAbilityConstants.Glamered));
            Assert.That(data[SpecialAbilityConstants.Glamered].Strength, Is.EqualTo(0));
        }
    }
}