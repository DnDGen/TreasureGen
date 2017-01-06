using System;

namespace TreasureGen.Tests.Integration.Tables
{
    public abstract class BooleanPercentileTests : PercentileTests
    {
        public virtual void BooleanPercentile(Boolean isTrue, int lower, int upper)
        {
            var content = Convert.ToString(isTrue);
            base.Percentile(content, lower, upper);
        }

        public virtual void BooleanPercentile(Boolean isTrue, int roll)
        {
            var content = Convert.ToString(isTrue);
            base.Percentile(content, roll);
        }
    }
}