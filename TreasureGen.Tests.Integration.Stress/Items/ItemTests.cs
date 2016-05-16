using NUnit.Framework;
using System;
using TreasureGen.Items;

namespace TreasureGen.Tests.Integration.Stress.Items
{
    [TestFixture]
    public abstract class ItemTests : StressTests
    {
        protected Item GenerateOrFail(Func<Item, bool> isValid)
        {
            var item = Generate(i => isValid(i) || TestShouldKeepRunning() == false);

            Console.WriteLine($"Generation complete after {Stopwatch.Elapsed}");

            if (TestShouldKeepRunning() == false && isValid(item) == false)
                Assert.Fail("Item did not occur within the time span");

            return item;
        }

        protected Item Generate(Func<Item, bool> isValid)
        {
            Item item;

            do item = GenerateItem();
            while (isValid(item) == false);

            return item;
        }

        protected abstract Item GenerateItem();
    }
}
