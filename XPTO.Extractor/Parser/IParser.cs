using System.Collections.Generic;

namespace XPTO.Extractor
{
    public interface IParser<T>
    {
        IList<T> Parse(string value, char separatorCharacterValue, char separatorCharacterLine);
    }
}
