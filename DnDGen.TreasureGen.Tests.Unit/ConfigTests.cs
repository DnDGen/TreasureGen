using NUnit.Framework;

namespace DnDGen.TreasureGen.Tests.Unit
{
    internal class ConfigTests
    {
        [Test]
        public void ConfigNameIsCorrect()
        {
            var configType = typeof(Config);
            Assert.That(Config.Name, Is.EqualTo("DnDGen.TreasureGen").And.EqualTo(configType.Namespace));
        }
    }
}
