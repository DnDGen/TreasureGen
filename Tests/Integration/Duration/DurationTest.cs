using System;
using System.Collections.Generic;
using System.Diagnostics;
using EquipmentGen.Core.Data.Items;
using EquipmentGen.Tests.Integration.Common;
using Ninject;
using NUnit.Framework;

namespace EquipmentGen.Tests.Integration.Duration
{
    [TestFixture]
    public abstract class DurationTest : IntegrationTest
    {
        [Inject]
        public Stopwatch Stopwatch { get; set; }
        [Inject]
        public Random Random { get; set; }

        protected void StartTest()
        {
            Stopwatch.Start();
        }

        protected void AssertDuration()
        {
            Assert.Pass("Duration: {0}ms", Stopwatch.ElapsedMilliseconds);
        }

        protected void StopTest()
        {
            Stopwatch.Reset();
        }

        protected Int32 GetNewLevel()
        {
            return Random.Next(1, 21);
        }

        protected String GetNewPower()
        {
            switch (Random.Next(4))
            {
                case 0: return ItemsConstants.Power.Mundane;
                case 1: return ItemsConstants.Power.Minor;
                case 2: return ItemsConstants.Power.Medium;
                case 3: return ItemsConstants.Power.Major;
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