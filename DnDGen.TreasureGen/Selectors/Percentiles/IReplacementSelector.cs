using System.Collections.Generic;

namespace DnDGen.TreasureGen.Selectors.Percentiles
{
    internal interface IReplacementSelector
    {
        string SelectSingle(string source);
        string SelectRandom(string source);
        IEnumerable<string> SelectAll(string source, bool allowSingle = false);
        IEnumerable<string> SelectAll(IEnumerable<string> sources, bool allowSingle = false);
    }
}
