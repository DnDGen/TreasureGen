﻿using DnDGen.Core.IoC;
using EventGen.IoC;
using Ninject;
using NUnit.Framework;
using RollGen.IoC;
using TreasureGen.IoC;

namespace TreasureGen.Tests.Integration
{
    [TestFixture]
    public abstract class IntegrationTests
    {
        protected IKernel kernel;

        public IntegrationTests()
        {
            kernel = new StandardKernel(new NinjectSettings() { InjectNonPublic = true });

            var rollGenModuleLoader = new RollGenModuleLoader();
            rollGenModuleLoader.LoadModules(kernel);

            var coreModuleLoader = new CoreModuleLoader();
            coreModuleLoader.LoadModules(kernel);

            var eventGenModuleLoader = new EventGenModuleLoader();
            eventGenModuleLoader.LoadModules(kernel);

            var treasureGenModuleLoader = new TreasureGenModuleLoader();
            treasureGenModuleLoader.LoadModules(kernel);
        }

        [SetUp]
        public void IntegrationTestsSetup()
        {
            kernel.Inject(this);
        }

        protected T GetNewInstanceOf<T>()
        {
            return kernel.Get<T>();
        }

        protected T GetNewInstanceOf<T>(string name)
        {
            return kernel.Get<T>(name);
        }
    }
}