using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace XPTO.Repository.Entities
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }

        public ICollection<Produto> Produtos { get; set; }
    }

    public class Produto
    {
        [Key]
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string Descricao { get; set; }
    }
}
