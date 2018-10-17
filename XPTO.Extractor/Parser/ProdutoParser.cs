using System;
using System.Collections.Generic;
using System.Linq;
 using XPTO.Domain;

namespace XPTO.Extractor
{
    public class ProdutoParser : IParser<Produto> 
    {
        public IList<Produto> Parse(string value, char separatorCharacterValue, char separatorCharacterLine)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new Exception("It must have a value for parser.");
            }

            return value?.Split(separatorCharacterLine).Select(lineValues =>
            {
                var values = lineValues.Split(separatorCharacterValue);

                return new Produto()
                {
                    Id = Convert.ToInt32(values[0]),
                    ClienteId = Convert.ToInt32(values[1]),
                    Descricao = values[2].ToString()
                };
            }).ToList();
        }
    }
}
