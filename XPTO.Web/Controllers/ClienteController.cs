using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XPTO.Domain;

namespace XPTO.Web.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            var client = new RestClient(ConfigurationManager.AppSettings["api-address"]);
            var request = new RestRequest("api/pedido/GetAll", Method.GET);
            var response = client.Execute<List<Cliente>>(request).Content;
            var data = JsonConvert.DeserializeObject<List<Cliente>>(response);

            return View(data);
        }
    }
}