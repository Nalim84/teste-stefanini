using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using XPTO.Application.Service;
using XPTO.Domain;

namespace XPTO.API.Controllers
{
    public class PedidoController : ApiController
    {
        private readonly PedidoService _service;

        public PedidoController() {
            _service = new PedidoService();
        }

        public IEnumerable<Cliente> GetAll()
        {
            var data= _service.GetAll();
            return data;
        }
    }
}
