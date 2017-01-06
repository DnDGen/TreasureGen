using System;

namespace TreasureGen.Tests.Integration.Tables
{
    public abstract class TypeAndAmountPercentileTests : PercentileTests
    {
        public virtual void TypeAndAmountPercentile(string type, string amount, int lower, int upper)
        {
            var content = string.Format("{0},{1}", type, amount);
            base.Percentile(content, lower, upper);
        }

        public virtual void TypeAndAmountPercentile(string type, string amount, int roll)
        {
            var content = string.Format("{0},{1}", type, amount);
            base.Percentile(content, roll);
        }

        public virtual void TypeAndAmountPercentile(string type, int amount, int lower, int upper)
        {
            var amountString = Convert.ToString(amount);
            TypeAndAmountPercentile(type, amountString, lower, upper);
        }

        public virtual void TypeAndAmountPercentile(string type, int amount, int roll)
        {
            var amountString = Convert.ToString(amount);
            TypeAndAmountPercentile(type, amountString, roll);
        }
    }
}