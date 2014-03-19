using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        private const Int32 ConfidentIterations = 1000000;
        private const Int32 TimeLimitInSeconds = 1;

        private Int32 iterations;

        protected void StartTest()
        {
            iterations = 0;
            Stopwatch.Start();
        }

        protected void StopTest()
        {
            Stopwatch.Reset();
        }

        protected Boolean TestShouldKeepRunning()
        {
            return Stopwatch.Elapsed.Seconds < TimeLimitInSeconds && iterations++ < ConfidentIterations;
        }

        protected void AssertIterations()
        {
            Assert.That(iterations, Is.GreaterThan(0));
            Assert.Pass("Iterations: {0}", iterations);
        }

        protected Int32 GetNewLevel()
        {
            return Random.Next(1, 21);
        }

        protected String GetNewPower(Boolean allowMundane)
        {
            var limit = allowMundane ? 4 : 3;

            switch (Random.Next(limit))
            {
                case 0: return PowerConstants.Minor;
                case 1: return PowerConstants.Medium;
                case 2: return PowerConstants.Major;
                case 3: return PowerConstants.Mundane;
                default: throw new ArgumentOutOfRangeException();
            }
        }

        protected IEnumerable<String> GetNewAttributes(Boolean allowNoMaterial)
        {
            var attributes = new List<String>();

            switch (Random.Next(2))
            {
                case 0: attributes.Add(ItemTypeConstants.Armor); break;
                case 1: attributes.Add(ItemTypeConstants.Weapon); break;
            }

            if (attributes.Contains(ItemTypeConstants.Weapon))
            {
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
                        if (allowNoMaterial)
                            break;
                        attributes.Add(AttributeConstants.Metal);
                        break;
                }
            }

            if (attributes.Contains(ItemTypeConstants.Armor))
            {
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
            }

            return attributes;
        }
    }
}