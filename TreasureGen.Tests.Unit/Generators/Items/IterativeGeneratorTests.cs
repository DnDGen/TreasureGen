using EventGen;
using Moq;
using NUnit.Framework;
using System;
using TreasureGen.Domain.Generators.Items;

namespace TreasureGen.Tests.Unit.Generators.Items
{
    [TestFixture]
    public class IterativeGeneratorTests
    {
        private const int Limit = 1000;

        private Generator generator;
        private int iterations;
        private Mock<GenEventQueue> mockEventQueue;

        [SetUp]
        public void Setup()
        {
            mockEventQueue = new Mock<GenEventQueue>();
            generator = new IterativeGenerator(mockEventQueue.Object);
            iterations = 0;
        }

        [Test]
        public void BuildWithLambda()
        {
            var builtString = "built string";
            var randomString = generator.Generate(() => builtString, s => s.Contains("string"), () => string.Empty, string.Empty);
            Assert.That(randomString, Is.EqualTo(builtString));
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void BuildWithMethods()
        {
            var date = generator.Generate(Build, IsValid, BuildDefault, string.Empty);
            Assert.That(iterations, Is.EqualTo(1));
            Assert.That(date, Is.EqualTo(DateTime.Now).Within(1).Seconds);
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }

        private DateTime Build()
        {
            iterations++;
            return DateTime.Now;
        }

        private bool IsValid(DateTime date)
        {
            return date.Year == DateTime.Now.Year;
        }

        private DateTime BuildDefault()
        {
            return new DateTime(1989, 10, 29);
        }

        [Test]
        public void BuildNull()
        {
            var randomObject = generator.Generate(() => null, s => true, () => new object(), string.Empty);
            Assert.That(randomObject, Is.Null);
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void RebuildIfInvalid()
        {
            var randomNumber = generator.Generate(() => iterations++, i => i > 0 && i % 2 == 0, () => -1, string.Empty);
            Assert.That(randomNumber, Is.EqualTo(2));
            Assert.That(iterations, Is.EqualTo(3));
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void ReturnDefault()
        {
            var number = generator.Generate(() => iterations++, i => false, () => -1, "a thing and stuff");
            Assert.That(number, Is.EqualTo(-1));
            Assert.That(iterations, Is.EqualTo(Limit));
            mockEventQueue.Verify(q => q.Enqueue("TreasureGen", "Generating a thing and stuff by default"), Times.Once);
        }

        [Test]
        public void ReturnValidObjectAfterTooManyRetries()
        {
            var randomString = generator.Generate(() => iterations++.ToString(), i => Convert.ToInt32(i) == Limit - 1, () => "nope", string.Empty);
            Assert.That(iterations, Is.EqualTo(Limit));
            Assert.That(randomString, Is.EqualTo($"{Limit - 1}"));
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }
    }
}
