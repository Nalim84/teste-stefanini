using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPTO.Application.Application;
using XPTO.Application.Service;
using XPTO.Domain;

namespace XPTO.ConsoleApp
{
    class Program
    {
        /// <summary>
        /// Rotina de importação dos arquivos .txt para  base de dados.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            IApplication application = new PedidoExtractApplication();

            application.Start();
        }
    }
}
