using System;
using System.Collections.Generic;
using System.Linq;
using XPTO.Domain;

namespace XPTO.Extractor
{
    public class ClienteParser : IParser<Cliente> 
    {
        public IList<Cliente> Parse(string value, char separatorCharacterValue, char separatorCharacterLine)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new Exception("It must have a value for parser.");
            }

            return value?.Split(separatorCharacterLine).Select(lineValues =>
                {
                    var values = lineValues.Split(separatorCharacterValue);

                    return new Cliente()
                    {
                        Id = Convert.ToInt32(values[0]),
                        Nome = values[1].ToString(),
                        Sobrenome = values[2].ToString(),
                        DataNascimento = DateTime.ParseExact(values[3], "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                        Sexo = values[4].ToString(),
                        Email = values[5].ToString(),
                        Ativo = Boolean.Parse(values[6].ToString())
                    };
                }).ToList();
        }
    }
}
