using System;
using EquipmentGen.Tests.Integration.Common;

namespace EquipmentGen.Tests.Integration.Tables
{
    public abstract class TableTests : IntegrationTests
    {
        protected abstract String tableName { get; }
    }
}