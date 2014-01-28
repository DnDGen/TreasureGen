﻿using System;
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
    }
}