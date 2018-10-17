using System;

namespace XPTO.Domain
{
    public class Produto
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string Descricao { get; set; }
    }
}
