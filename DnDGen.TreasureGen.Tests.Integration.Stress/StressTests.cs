using DnDGen.Stress;
using DnDGen.TreasureGen.Items;
using Ninject;
using NUnit.Framework;
using System;
using System.Reflection;

namespace DnDGen.TreasureGen.Tests.Integration.Stress
{
    [TestFixture]
    public abstract class StressTests : IntegrationTests
    {
        [Inject]
        public Random Random { get; set; }

        protected Stressor stressor;

        [OneTimeSetUp]
        public void StressSetup()
        {
            var options = new StressorOptions();
            options.RunningAssembly = Assembly.GetExecutingAssembly();
            options.TimeLimitPercentage = .8;

#if STRESS
            options.IsFullStress = true;
#else
            options.IsFullStress = false;
#endif

            stressor = new Stressor(options);
        }

        protected int GetNewLevel()
        {
            return Random.Next(LevelLimits.Minimum, LevelLimits.Maximum + 1);
        }

        protected string GetNewPower(bool allowMinor = true)
        {
            var limit = allowMinor ? 3 : 2;

            switch (Random.Next(limit))
            {
                case 0: return PowerConstants.Major;
                case 1: return PowerConstants.Medium;
                default: return PowerConstants.Minor;
            }
        }
    }
}