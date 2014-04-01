using EquipmentGen.Generators.Interfaces.Items.Mundane;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress.Items.Mundane
{
    [TestFixture]
    public class SpecialMaterialGeneratorTests : StressTests
    {
        [Inject]
        public ISpecialMaterialGenerator SpecialMaterialGenerator { get; set; }

        protected override void StressGenerator()
        {
            var types = GetNewAttributes(false);
            var material = SpecialMaterialGenerator.GenerateFor(types);

            Assert.That(material, Is.Not.Null);
        }
    }
}