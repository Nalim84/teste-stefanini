using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPTO.Domain;
using XPTO.Repository.Repository;

namespace XPTO.Application.Service
{
    public class PedidoService : BaseService
    {
        private readonly PedidoRepository _repository;

        public PedidoService()
        {
            _repository = new PedidoRepository();
        }

        public IList<Cliente> GetAll()
        {
            return _repository.Get();
        }

        public bool InsertPedidos(IList<Cliente> clientes, IList<Produto> produtos)
        {
            if (clientes == null || produtos == null)
            {
                throw new Exception("It must have a value for insert");
            }

            return _repository.Insert(clientes, produtos);
        }
    }
}
