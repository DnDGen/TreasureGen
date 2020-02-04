﻿using DnDGen.EventGen;
using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Magical;
using DnDGen.TreasureGen.Tests.Unit.Generators.Items;
using Ninject;
using NUnit.Framework;
using System;

namespace DnDGen.TreasureGen.Tests.Integration.Generators.Items.Magical
{
    [TestFixture]
    public class WandGeneratorTests : IntegrationTests
    {
        [Inject, Named(ItemTypeConstants.Wand)]
        public MagicalItemGenerator WandGenerator { get; set; }
        [Inject]
        public ClientIDManager ClientIDManager { get; set; }

        private ItemVerifier itemVerifier;

        [SetUp]
        public void Setup()
        {
            itemVerifier = new ItemVerifier();
            ClientIDManager.SetClientID(Guid.NewGuid());
        }

        [TestCase("whatever", PowerConstants.Minor)]
        [TestCase("whatever", PowerConstants.Medium)]
        [TestCase("whatever", PowerConstants.Major)]
        public void GenerateWand(string itemName, string power)
        {
            var isOfPower = WandGenerator.IsItemOfPower(itemName, power);
            Assert.That(isOfPower, Is.True);

            var item = WandGenerator.GenerateFrom(power, itemName);
            itemVerifier.AssertItem(item);
        }
    }
}