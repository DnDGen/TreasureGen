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
        public void ThrowErrorIfFileIsNotFormattedCorrectly()
        {
            Assert.That(() => StreamLoader.LoadFor("invalid filename"), Throws.ArgumentException.With.Message.EqualTo("\"invalid filename\" is not a valid file"));
        }

        [Test]
        public void ThrowErrorIfFileIsNotAnEmbeddedResource()
        {
            Assert.That(() => StreamLoader.LoadFor("invalid filename.xml"), Throws.InstanceOf<FileNotFoundException>().With.Message.EqualTo("invalid filename.xml"));
        }

        [Test]
        public void MatchWholeFileName()
        {
            Assert.That(() => StreamLoader.LoadFor("Coins.xml"), Throws.InstanceOf<FileNotFoundException>().With.Message.EqualTo("Coins.xml"));
        }

        [Test]
        public void DifferentiateAgainstDifferentFiles()
        {
            using (var stream1 = StreamLoader.LoadFor("SpellTypes.xml"))
            using (var stream2 = StreamLoader.LoadFor("CastersShieldSpellTypes.xml"))
                Assert.Pass(); //no error was thrown, so the stream was successfully loaded
        }
    }
}