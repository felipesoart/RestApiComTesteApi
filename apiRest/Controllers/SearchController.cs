using apiRest.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace apiRest.Controllers
{
    public class SearchController : ApiController
    {

        public static List<Search> lista = new List<Search>();

        [HttpGet]
        [Route("search/popular")]
        public JObject Popular()
        {
            lista.Add(new Search("I", 1));
            lista.Add(new Search("II", 2));
            lista.Add(new Search("V", 5));
            lista.Add(new Search("X", 10));

            var resultado = JObject.Parse("{resultado: \"populado\"}");
            return resultado;
        }

        [Route("search/Get")]
        public List<Search> Get()
        {
            return lista;
        }

        //GET /search/text
        public Search Get(string text)
        {
            return lista.Find(x => x.Text.Equals(text));
        }

        [Route("search")]
        public JObject Post([FromBody] Search search)
        {
            var resultado = "";

            if (string.IsNullOrEmpty(search.Text))
            {
                resultado = @"{""number"":"""""",""value"": 0,""mensagem"":""O campo Palavra é obrigatório ao Solicitar Varificacao!""}";
            }
            if (string.IsNullOrEmpty(resultado))
            {
                lista.Add(new Search(search.Text, search.Valor));
            }

            return JObject.Parse(resultado);
        }


        //public void Delete(int id)
        //{

        //}
    }
}
