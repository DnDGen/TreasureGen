using System.IO;
using EquipmentGen.Tables.Interfaces;
using EquipmentGen.Tests.Integration.Common;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Mappers
{
    [TestFixture]
    public class EmbeddedResourceStreamLoaderTests : IntegrationTests
    {
        [Inject]
        public IStreamLoader StreamLoader { get; set; }

        [Test]
        public void GetsFileIfItIsAnEmbeddedResource()
        {
            using (var stream = StreamLoader.LoadFor("Level1Coins.xml"))
                Assert.Pass(); //no error was thrown, so the stream was successfully loaded
        }

        [Test]
        public void ThrowErrorIfFileIsNotEmbeddedResource()
        {
            Assert.That(() => StreamLoader.LoadFor("invalid filename"), Throws.InstanceOf<FileNotFoundException>());
        }
    }
}