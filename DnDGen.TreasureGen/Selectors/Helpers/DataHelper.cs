namespace DnDGen.TreasureGen.Selectors.Helpers
{
    public abstract class DataHelper
    {
        protected readonly char divider;

        public DataHelper(char divider)
        {
            this.divider = divider;
        }

        public string BuildEntry(params string[] data)
        {
            return string.Join(divider.ToString(), data);
        }

        public string[] ParseEntry(string entry)
        {
            return entry.Split(divider);
        }

        public string BuildKey(string creature, string entry)
        {
            var data = ParseEntry(entry);
            return BuildKey(creature, data);
        }

        public abstract string BuildKey(string creature, string[] data);
        public abstract bool ValidateEntry(string entry);

        public string BuildKeyFromSections(string creature, params string[] keySections)
        {
            var key = creature;
            foreach (var section in keySections)
                key += section;

            return key;
        }
    }
}
