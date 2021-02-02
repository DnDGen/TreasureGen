using NUnit.Framework;

namespace DnDGen.TreasureGen.Tests.Integration.IoC
{
    [TestFixture]
    public abstract class IoCTests : IntegrationTests
    {
        protected void AssertSingleton<T>()
        {
            var first = GetNewInstanceOf<T>();
            var second = GetNewInstanceOf<T>();
            Assert.That(first, Is.EqualTo(second));
        }

        protected void AssertNotSingleton<T>()
        {
            var first = GetNewInstanceOf<T>();
            var second = GetNewInstanceOf<T>();
            Assert.That(first, Is.Not.EqualTo(second));
        }

        protected void AssertNotSingleton<T>(string name)
        {
            var first = GetNewInstanceOf<T>(name);
            var second = GetNewInstanceOf<T>(name);
            Assert.That(first, Is.Not.EqualTo(second));
        }
    }
}