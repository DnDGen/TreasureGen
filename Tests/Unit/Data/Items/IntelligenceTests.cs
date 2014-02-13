using EquipmentGen.Core.Data.Items;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Data.Items
{
    [TestFixture]
    public class IntelligenceTests
    {
        private Intelligence intelligence;

        [SetUp]
        public void Setup()
        {
            intelligence = new Intelligence();
        }

        [Test]
        public void PowersInitialized()
        {
            Assert.That(intelligence.Powers, Is.Not.Null);
        }
    }
}