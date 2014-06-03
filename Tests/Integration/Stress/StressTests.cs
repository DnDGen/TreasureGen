using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using EquipmentGen.Common.Items;
using EquipmentGen.Tests.Integration.Common;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress
{
    [TestFixture]
    public abstract class StressTests : IntegrationTests
    {
        [Inject]
        public Random Random { get; set; }
        [Inject]
        public Stopwatch Stopwatch { get; set; }

        protected String type;

        private const Int32 TimeLimitInSeconds = 1;
        private const Int32 ConfidentIterations = 1000000;

        private Int32 iterations;

        public StressTests()
        {
            var classType = GetType();
            var classTypeString = Convert.ToString(classType);
            var segments = classTypeString.Split('.');
            type = segments.Last();
        }

        [SetUp]
        public void StressSetup()
        {
            iterations = 0;
            Stopwatch.Start();
        }

        [TearDown]
        public void StressTearDown()
        {
            Stopwatch.Reset();
        }

        [Test]
        public void StressGenerator()
        {
            do MakeAssertions();
            while (TestShouldKeepRunning());

            AssertIterations();
        }

        protected abstract void MakeAssertions();

        protected Boolean TestShouldKeepRunning()
        {
            return Stopwatch.Elapsed.Seconds < TimeLimitInSeconds && iterations++ < ConfidentIterations;
        }

        protected void AssertIterations()
        {
            Assert.Pass("Type: {0}\nIterations: {1}", type, iterations);
        }

        protected Int32 GetNewLevel()
        {
            return Random.Next(1, 21);
        }

        protected String GetNewPower(Boolean allowMundane = false, Boolean allowMinor = true)
        {
            var limit = 2;

            if (allowMundane)
                limit = 4;
            else if (allowMinor)
                limit = 3;

            switch (Random.Next(limit))
            {
                case 0: return PowerConstants.Major;
                case 1: return PowerConstants.Medium;
                case 2: return PowerConstants.Minor;
                case 3: return PowerConstants.Mundane;
                default: throw new ArgumentOutOfRangeException();
            }
        }

        protected String GetNewGearItemType()
        {
            switch (Random.Next(2))
            {
                case 0: return ItemTypeConstants.Armor;
                case 1: return ItemTypeConstants.Weapon;
                default: throw new ArgumentOutOfRangeException();
            }
        }

        protected IEnumerable<String> GetNewAttributesForGear(String itemType, Boolean forceMaterials)
        {
            if (itemType == ItemTypeConstants.Weapon)
                return GenerateWeaponAttributes(forceMaterials);
            else if (itemType == ItemTypeConstants.Armor)
                return GenerateArmorAttributes(forceMaterials);

            throw new ArgumentOutOfRangeException();
        }

        private IEnumerable<String> GenerateArmorAttributes(Boolean forceMaterials)
        {
            var attributes = new List<String>();

            switch (Random.Next(3))
            {
                case 0: attributes.Add(AttributeConstants.Shield); break;
                case 1: break;
                case 2:
                    attributes.Add(AttributeConstants.Shield);
                    attributes.Add(AttributeConstants.NotTower);
                    break;
            }

            switch (Random.Next(3))
            {
                case 0: attributes.Add(AttributeConstants.Metal); break;
                case 1: attributes.Add(AttributeConstants.Wood); break;
                case 2:
                    if (forceMaterials)
                        attributes.Add(AttributeConstants.Metal);
                    break;
            }

            return attributes;
        }

        private IEnumerable<String> GenerateWeaponAttributes(Boolean forceMaterials)
        {
            var attributes = new List<String>();

            switch (Random.Next(3))
            {
                case 0: attributes.Add(AttributeConstants.Melee); break;
                case 1: attributes.Add(AttributeConstants.Ranged); break;
                case 2:
                    attributes.Add(AttributeConstants.Melee);
                    attributes.Add(AttributeConstants.Ranged);
                    break;
            }

            switch (Random.Next(4))
            {
                case 0: attributes.Add(AttributeConstants.Metal); break;
                case 1: attributes.Add(AttributeConstants.Wood); break;
                case 2:
                    attributes.Add(AttributeConstants.Metal);
                    attributes.Add(AttributeConstants.Wood);
                    break;
                case 3:
                    if (forceMaterials)
                        attributes.Add(AttributeConstants.Metal);
                    break;
            }

            if (attributes.Contains(AttributeConstants.Melee) && Random.Next(2) > 0)
                attributes.Add(AttributeConstants.DoubleWeapon);
            else if (attributes.Contains(AttributeConstants.Ranged) && Random.Next(2) > 0)
                attributes.Add(AttributeConstants.Thrown);
            else if (attributes.Contains(AttributeConstants.Ranged) && Random.Next(2) > 0)
                attributes.Add(AttributeConstants.Ammunition);

            switch (Random.Next(6))
            {
                case 0: attributes.Add(AttributeConstants.Bludgeoning); break;
                case 1: attributes.Add(AttributeConstants.NotBludgeoning); break;
                case 2:
                    attributes.Add(AttributeConstants.NotBludgeoning);
                    attributes.Add(AttributeConstants.Slashing);
                    break;
                case 3:
                    attributes.Add(AttributeConstants.Bludgeoning);
                    attributes.Add(AttributeConstants.NotBludgeoning);
                    break;
                case 4:
                    attributes.Add(AttributeConstants.Bludgeoning);
                    attributes.Add(AttributeConstants.NotBludgeoning);
                    attributes.Add(AttributeConstants.Slashing);
                    break;
                case 5: break;
            }

            return attributes;
        }
    }
}