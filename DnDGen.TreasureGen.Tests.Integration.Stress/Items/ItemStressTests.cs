﻿using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Tests.Unit.Generators.Items;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DnDGen.TreasureGen.Tests.Integration.Stress.Items
{
    [TestFixture]
    public abstract class ItemStressTests : StressTests
    {
        public ItemVerifier ItemVerifier;

        [SetUp]
        public void ItemStressSetup()
        {
            ItemVerifier = new ItemVerifier();
        }

        protected abstract Item GenerateItem();
        protected abstract Item GenerateItemFromName(string name, string power = null);
        protected abstract IEnumerable<string> GetItemNames();
        protected abstract void MakeSpecificAssertionsAgainst(Item item);

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
