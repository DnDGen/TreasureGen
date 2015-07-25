using Ninject;
using NUnit.Framework;
using RollGen.Bootstrap;
using System;
using TreasureGen.Bootstrap;

namespace TreasureGen.Tests.Integration.Common
{
    [TestFixture]
    public abstract class IntegrationTests
    {
        private IKernel kernel;

        public IntegrationTests()
        {
            kernel = new StandardKernel();

            var equipmentGenModuleLoader = new TreasureGenModuleLoader();
            equipmentGenModuleLoader.LoadModules(kernel);

            var d20DiceModuleLoader = new RollGenModuleLoader();
            d20DiceModuleLoader.LoadModules(kernel);

            kernel.Inject(this);
        }

        //The commented-out code below is for troubleshooting issues with the bindings and injecting,
        //sicne the SetUp fail message just says that the setup failed, instead of showing the specific ninject issue

        //[SetUp]
        //public void IntegrationTestsSetup()
        //{
        //    kernel = new StandardKernel();

        //    var equipmentGenModuleLoader = new EquipmentGenModuleLoader();
        //    equipmentGenModuleLoader.LoadModules(kernel);

        //    var d20DiceModuleLoader = new D20DiceModuleLoader();
        //    d20DiceModuleLoader.LoadModules(kernel);

        //    kernel.Inject(this);
        //}

        protected T GetNewInstanceOf<T>()
        {
            return kernel.Get<T>();
        }

        protected T GetNewInstanceOf<T>(String name)
        {
            return kernel.Get<T>(name);
        }
    }
}