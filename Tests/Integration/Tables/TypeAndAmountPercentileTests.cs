using System;

namespace TreasureGen.Tests.Integration.Tables
{
    public abstract class TypeAndAmountPercentileTests : PercentileTests
    {
        public virtual void TypeAndAmountPercentile(String type, String amount, Int32 lower, Int32 upper)
        {
            var content = String.Format("{0},{1}", type, amount);
            base.Percentile(content, lower, upper);
        }

        public virtual void TypeAndAmountPercentile(String type, String amount, Int32 roll)
        {
            var content = String.Format("{0},{1}", type, amount);
            base.Percentile(content, roll);
        }

        public virtual void TypeAndAmountPercentile(String type, Int32 amount, Int32 lower, Int32 upper)
        {
            var amountString = Convert.ToString(amount);
            TypeAndAmountPercentile(type, amountString, lower, upper);
        }

        public virtual void TypeAndAmountPercentile(String type, Int32 amount, Int32 roll)
        {
            var amountString = Convert.ToString(amount);
            TypeAndAmountPercentile(type, amountString, roll);
        }
    }
}