using Ninject;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using TreasureGen.Common.Items;
using TreasureGen.Tests.Integration.Common;

namespace TreasureGen.Tests.Integration.Stress
{
    [TestFixture]
    public abstract class StressTests : IntegrationTests
    {
        [Inject]
        public Random Random { get; set; }
        [Inject]
        public Stopwatch Stopwatch { get; set; }

        private const Int32 ConfidentIterations = 1000000;

#if STRESS
        private const Int32 TimeLimitInSeconds = 60 * 60 / 167;
#else
        private const Int32 TimeLimitInSeconds = 1;
#endif

        private Int32 iterations;

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

        public abstract void Stress(String thingToStress);

        protected void Stress()
        {
            Stress(MakeAssertions);
        }

        protected void Stress(Action generate)
        {
            do generate();
            while (TestShouldKeepRunning());

            if (Stopwatch.Elapsed.TotalSeconds > TimeLimitInSeconds + 2)
                Assert.Fail("Something took way too long");
        }

        protected abstract void MakeAssertions();

        protected Boolean TestShouldKeepRunning()
        {
            iterations++;
            return Stopwatch.Elapsed.TotalSeconds < TimeLimitInSeconds && iterations < ConfidentIterations;
        }

        protected Int32 GetNewLevel()
        {
            return Random.Next(1, 21);
        }

        protected String GetNewPower(Boolean allowMinor = true)
        {
            var limit = 2;
            if (allowMinor)
                limit = 3;

            switch (Random.Next(limit))
            {
                case 0: return PowerConstants.Major;
                case 1: return PowerConstants.Medium;
                default: return PowerConstants.Minor;
            }
        }

        protected String GetNewGearItemType()
        {
            if (Random.Next(2) == 0)
                return ItemTypeConstants.Armor;

            return ItemTypeConstants.Weapon;
        }

        protected IEnumerable<String> GetNewAttributesForGear(String itemType, Boolean forceMaterials)
        {
            if (itemType == ItemTypeConstants.Weapon)
                return GenerateWeaponAttributes();

            return GenerateArmorAttributes();
        }

        private IEnumerable<String> GenerateArmorAttributes()
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
                case 2: break;
            }

            return attributes;
        }

        private IEnumerable<String> GenerateWeaponAttributes()
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
                case 3: break;
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