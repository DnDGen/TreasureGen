﻿using EquipmentGen.Core.Data.Items.Constants;
using NUnit.Framework;

namespace EquipmentGen.Tests.Unit.Data.Items.Constants
{
    [TestFixture]
    public class TraitConstantsTests
    {
        [Test]
        public void MasterworkConstant()
        {
            Assert.That(TraitConstants.Masterwork, Is.EqualTo("Masterwork"));
        }

        [Test]
        public void DarkwoodConstant()
        {
            Assert.That(TraitConstants.Darkwood, Is.EqualTo("Darkwood"));
        }

        [Test]
        public void SmallConstant()
        {
            Assert.That(TraitConstants.Small, Is.EqualTo("Small"));
        }

        [Test]
        public void MediumConstant()
        {
            Assert.That(TraitConstants.Medium, Is.EqualTo("Medium"));
        }

        [Test]
        public void AdamantineConstant()
        {
            Assert.That(TraitConstants.Adamantine, Is.EqualTo("Adamantine"));
        }

        [Test]
        public void DragonhideConstant()
        {
            Assert.That(TraitConstants.Dragonhide, Is.EqualTo("Dragonhide"));
        }

        [Test]
        public void ColdIronConstant()
        {
            Assert.That(TraitConstants.ColdIron, Is.EqualTo("Cold iron"));
        }

        [Test]
        public void MithralConstant()
        {
            Assert.That(TraitConstants.Mithral, Is.EqualTo("Mithral"));
        }

        [Test]
        public void AlchemicalSilverConstant()
        {
            Assert.That(TraitConstants.AlchemicalSilver, Is.EqualTo("Alchemical silver"));
        }

        [Test]
        public void MarkingsConstant()
        {
            Assert.That(TraitConstants.Markings, Is.EqualTo("Markings provide a clue to its function"));
        }

        [Test]
        public void ShedsLightConstant()
        {
            Assert.That(TraitConstants.ShedsLight, Is.EqualTo("Sheds light"));
        }
    }
}