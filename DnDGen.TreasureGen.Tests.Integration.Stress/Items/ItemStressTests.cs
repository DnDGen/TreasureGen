using Ninject;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Tests.Unit.Generators.Items;

namespace DnDGen.TreasureGen.Tests.Integration.Stress.Items
{
    [TestFixture]
    public abstract class ItemStressTests : StressTests
    {
        [Inject]
        public ItemVerifier ItemVerifier { get; set; }

        protected abstract Item GenerateItem();
        protected abstract Item GenerateItemFromSubset(IEnumerable<string> subset);
        protected abstract IEnumerable<string> GetItemNames();
        protected abstract void MakeSpecificAssertionsAgainst(Item item);

        protected IEnumerable<string> GetRandomSubset(IEnumerable<string> collection)
        {
            var count = collection.Count();
            var subsetQuantity = Random.Next(count) + 1;

            var subset = new HashSet<string>();
            while (subsetQuantity-- > 0)
            {
                var randomEntry = GetRandom(collection);
                subset.Add(randomEntry);
            }

            return subset;
        }

        protected string GetRandom(IEnumerable<string> collection)
        {
            var randomIndex = Random.Next(collection.Count());
            return collection.ElementAt(randomIndex);
        }

        protected void AssertItem(Item item)
        {
            ItemVerifier.AssertItem(item);
            MakeSpecificAssertionsAgainst(item);
        }

        protected string GetRandomName()
        {
            var names = GetItemNames();
            var name = GetRandom(names);

            return name;
        }

        protected Item GenerateItem(Func<Item, bool> additionalFilters)
        {
            var item = stressor.Generate(GenerateItem, i => additionalFilters(i));
            return item;
        }
    }
}
