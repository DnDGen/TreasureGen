using NUnit.Framework;

namespace DnDGen.TreasureGen.Tests.Integration.Tables
{
    [TestFixture]
    public abstract class TableTests : IntegrationTests
    {
        protected const string Name = "DnDGen.TreasureGen";
        protected abstract string tableName { get; }
    }
}