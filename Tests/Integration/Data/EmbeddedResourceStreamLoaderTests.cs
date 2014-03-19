using System.IO;
using EquipmentGen.Core.Generation.Xml.Parsers.Interfaces;
using EquipmentGen.Tests.Integration.Common;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Parsers
{
    [TestFixture]
    public class EmbeddedResourceStreamLoaderTests : IntegrationTests
    {
        [Inject]
        public IStreamLoader StreamLoader { get; set; }

        [Test]
        public void GetsFileIfItIsAnEmbeddedResource()
        {
            using (var stream = StreamLoader.LoadStream("Level1Coins.xml"))
                Assert.Pass(); //no error was thrown, so the stream was successfully loaded
        }

        [Test]
        public void ThrowErrorIfFileIsNotEmbeddedResource()
        {
            Assert.That(() => StreamLoader.LoadStream("invalid filename"), Throws.InstanceOf<FileNotFoundException>());
        }
    }
}