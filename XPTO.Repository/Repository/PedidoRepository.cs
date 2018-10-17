using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain = XPTO.Domain;
using Entities = XPTO.Repository.Entities;

namespace XPTO.Repository.Repository
{
    public class PedidoRepository : BaseRepository
    {
        public IList<Domain.Cliente> Get()
        {
            using (var context = new DatabaseContext())
            {

                return (from cli in context.Clientes
                        where cli.Ativo
                        select new Domain.Cliente()
                        {
                            Id = cli.Id,
                            Nome = cli.Nome,
                            Sobrenome = cli.Sobrenome,
                            DataNascimento = cli.DataNascimento,
                            Sexo = cli.Sexo,
                            Email = cli.Email,
                            Ativo = cli.Ativo,
                            Produtos = (from prod in context.Produtos
                                        where prod.ClienteId == cli.Id
                                        select new Domain.Produto()
                                        {
                                            Id = prod.Id,
                                            ClienteId = prod.ClienteId,
                                            Descricao = prod.Descricao
                                        }).ToList()
                        }).ToList();
            }
        }

        public bool Insert(IList<Domain.Cliente> clientes, IList<Domain.Produto> produtos)
        {
            try
            {
                using (var context = new DatabaseContext())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        clientes.ToList().ForEach(cliente =>
                        {
                            context.Clientes.Add(new Entities.Cliente()
                            {
                                Id = cliente.Id,
                                Nome = cliente.Nome,
                                Sobrenome = cliente.Sobrenome,
                                DataNascimento = cliente.DataNascimento,
                                Sexo = cliente.Sexo,
                                Email = cliente.Email,
                                Ativo = cliente.Ativo
                            });
                        });


                        produtos.ToList().ForEach(produto =>
                        {
                            context.Produtos.Add(new Entities.Produto()
                            {
                                Id = produto.Id,
                                ClienteId = produto.ClienteId,
                                Descricao = produto.Descricao
                            });
                        });

                        context.SaveChanges();
                        transaction.Commit();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
