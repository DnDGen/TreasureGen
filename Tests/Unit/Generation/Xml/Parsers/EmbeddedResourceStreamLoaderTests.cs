using System.IO;
using EquipmentGen.Core.Generation.Xml.Parsers;
using EquipmentGen.Core.Generation.Xml.Parsers.Interfaces;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Generation.Xml.Parsers
{
    [TestFixture]
    public class EmbeddedResourceStreamLoaderTests
    {
        private IStreamLoader streamLoader;

        [SetUp]
        public void Setup()
        {
            streamLoader = new EmbeddedResourceStreamLoader();
        }

        [Test]
        public void GetsFileIfItIsAnEmbeddeResource()
        {
            using (var stream = streamLoader.LoadStream("Level1Coins.xml"))
            {
                //no error was thrown, so the stream was successfully loaded
                Assert.Pass();
            }
        }

        [Test]
        public void ThrowErrorIfFileIsNotEmbeddedResource()
        {
            Assert.That(() => streamLoader.LoadStream("invalid filename"), Throws.InstanceOf<FileNotFoundException>());
        }
    }
}