using NUnit.Framework;
using System;
using TreasureGen.Tests.Integration.Common;

namespace TreasureGen.Tests.Integration.Tables
{
    [TestFixture]
    public abstract class TableTests : IntegrationTests
    {
        protected abstract String tableName { get; }
    }
}