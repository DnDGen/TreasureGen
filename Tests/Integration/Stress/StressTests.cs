using System;
using System.Collections.Generic;
using System.Diagnostics;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Tests.Integration.Common;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Stress
{
    [TestFixture]
    public abstract class StressTest : IntegrationTest
    {
        [Inject]
        public Stopwatch Stopwatch { get; set; }
        [Inject]
        public Random Random { get; set; }

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

        protected Int32 GetNewLevel()
        {
            return Random.Next(1, 21);
        }

        protected void AssertIterations()
        {
            Assert.That(iterations, Is.GreaterThan(0));
            Assert.Pass("Iterations: {0}", iterations);
        }

        protected String GetNewPower(Boolean allowMundane)
        {
            var limit = allowMundane ? 4 : 3;

            switch (Random.Next(limit))
            {
                case 0: return ItemsConstants.Power.Minor;
                case 1: return ItemsConstants.Power.Medium;
                case 2: return ItemsConstants.Power.Major;
                case 3: return ItemsConstants.Power.Mundane;
                default: throw new ArgumentOutOfRangeException();
            }
        }

        protected IEnumerable<String> GetNewTypes()
        {
            var types = new List<String>();

            switch (Random.Next(2))
            {
                case 0: types.Add(ItemsConstants.ItemTypes.Armor); break;
                case 1: types.Add(ItemsConstants.ItemTypes.Weapon); break;
            }

            switch (Random.Next(3))
            {
                case 0: types.Add(ItemsConstants.Gear.Types.Metal); break;
                case 1: types.Add(ItemsConstants.Gear.Types.Wood); break;
                default: break;
            }

            return types;
        }
    }
}