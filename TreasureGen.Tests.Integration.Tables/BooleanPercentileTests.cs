using System;

namespace TreasureGen.Tests.Integration.Tables
{
    public abstract class BooleanPercentileTests : PercentileTests
    {
        public virtual void BooleanPercentile(Boolean isTrue, Int32 lower, Int32 upper)
        {
            var content = Convert.ToString(isTrue);
            base.Percentile(content, lower, upper);
        }

        public virtual void BooleanPercentile(Boolean isTrue, Int32 roll)
        {
            var content = Convert.ToString(isTrue);
            base.Percentile(content, roll);
        }
    }
}