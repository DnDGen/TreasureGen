using System.IO;
using EquipmentGen.Core.Generation.Xml.Parsers;
using EquipmentGen.Core.Generation.Xml.Parsers.Interfaces;
using NUnit.Framework;

namespace EquipmentGen.Tests.Generation.Xml.Parsers
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

        [Test, ExpectedException(typeof(FileNotFoundException))]
        public void ThrowErrorIfFileIsNotEmbeddedResource()
        {
            using (var stream = streamLoader.LoadStream("NotAnActualFile.xml"))
            {
                //Shouldn't get here, should throw error
            }
        }
    }
}