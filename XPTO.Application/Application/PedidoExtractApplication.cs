using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPTO.Application.Service;
using XPTO.Domain;
using XPTO.Extractor;

namespace XPTO.Application.Application
{
    public class PedidoExtractApplication : IApplication
    {
        /// <summary>
        /// Extract the informations from the txt files about the customers and their products.
        /// This application have some actions like extract, parse and save extracted data in database.
        /// </summary>
        public bool Start()
        {
            var clientes = new ExtractorService<Cliente>(new Extractor.Extractor("ARQUIVO1.txt"), new ClienteParser()).ExtractParsedFiles();
            var produtos = new ExtractorService<Produto>(new Extractor.Extractor("ARQUIVO2.txt"), new ProdutoParser()).ExtractParsedFiles();
            var transaction = new PedidoService().InsertPedidos(clientes, produtos);

            return transaction;
        }
    }
}
