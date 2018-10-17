using System;
using System.Collections.Generic;

namespace XPTO.Domain
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }

        public ICollection<Produto> Produtos { get; set; }
    }
}
