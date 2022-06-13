using apiteste.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace apiteste.Controllers
{
    public class SearchController : ApiController
    {

        public static List<Search2> lista = new List<Search2>();

        //[HttpGet]
        //[Route("search/popular")]
        //public JObject Popular()
        //{
        //    lista.Add(new Search2("I", 1));
        //    lista.Add(new Search2("II", 2));
        //    lista.Add(new Search2("V", 5));
        //    lista.Add(new Search2("X", 10));

        //    var resultado = JObject.Parse("{resultado: \"populado\"}");
        //    return resultado;
        //}

        //caso deseja verificar o que foi enviado 
        [HttpGet]
        [Route("search/get")]
        public List<Search2> Get()
        {
            return lista;
        }

        ////GET /search/text
        //public Search2 Get(decimal value)
        //{
        //    return lista.Find(x => x.value.Equals(value));
        //}

        //metodo de apirestPOST 
        [Route("search")]
        public JObject Post([FromBody] Search search)//aqui chega a informação do body da requisição post expl {{"Text": "AXXFGII"}}
        {
            var resultado = "";
            Search2 objson = null;
            if (!string.IsNullOrEmpty(search.Text))
            {
                objson = tratamentoNumeroRomano(search.Text);//tratamento para obter o json do post correto
            }
            if (string.IsNullOrEmpty(resultado))
            {
                lista.Add(new Search2(objson.number, objson.value)); //foi feito essa lista para popular o dados do post já que essa aplicação e local e não possui banco de dados
                resultado = @"{
                                " + "\n" +
                                @"    ""number"": """ + objson.number + @""",
                                " + "\n" +
                                @"    ""value"": " + objson.value + @"
                                " + "\n" +
                                @"}";
            }

            return JObject.Parse(resultado);//retorno para a tela de teste de requisição
        }


        //public void Delete(int id)
        //{

        //}

        //metodo de tratamento do texto enviado por body json
        public static Search2 tratamentoNumeroRomano(string Text)
        {
            char[] numerosRomanos = new char[7];

            numerosRomanos[0] = 'I';//1
            numerosRomanos[1] = 'V';//5
            numerosRomanos[2] = 'X';//10
            numerosRomanos[3] = 'L';//50
            numerosRomanos[4] = 'C';//100
            numerosRomanos[5] = 'D';//500
            numerosRomanos[6] = 'M';//1000

            char[] arr;

            arr = Text.ToCharArray();

            string nromano = string.Empty;
            //verificação de stringo
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < numerosRomanos.Length; j++)
                {
                    if (numerosRomanos[j].Equals(arr[i]))
                    {
                        nromano += arr[i];
                    }
                }

            }
            //verificação dos maiores valores fornecidos
            char[] nmaior;
            nmaior = nromano.ToCharArray();
            decimal[] maior = new decimal[nromano.Length * nromano.Length];
            var m = 0;
            for (int i = 0; i < nmaior.Length; i++)
            {
                var valor = verificaValor(nmaior[i].ToString(), nromano.Length);
                maior[m] = valor;
                m++;
                for (int j = 1; j < nmaior.Length; j++)
                {
                    var valor2 = verificaValor(nmaior[i].ToString() + nmaior[j].ToString(), nromano.Length);
                    maior[m] = valor2;
                    m++;
                }

            }

            //obtendo o maior valor passado
            decimal valor3 = 0;
            decimal maiorValor = 0;

            for (int i = 0; i < maior.Length; i++)
            {
                valor3 = maior[i];

                if (valor3 > maiorValor)
                {
                    maiorValor = valor3;
                }
            }

            var retjson = string.Empty;
            //conbinações de valor e numeros
            switch (maiorValor)
            {
                case 1:
                    retjson = "I";
                    break;
                case 2:
                    retjson = "II";
                    break;
                case 4:
                    retjson = "IV";
                    break;
                case 5:
                    retjson = "V";
                    break;
                case 6:
                    retjson = "VI";
                    break;
                case 9:
                    retjson = "XI";
                    break;
                case 10:
                    retjson = "X";
                    break;
                case 11:
                    retjson = "XI";
                    break;
                case 15:
                    retjson = "XV";
                    break;
                case 20:
                    retjson = "XX";
                    break;
                case 40:
                    retjson = "XL";
                    break;
                case 50:
                    retjson = "L";
                    break;
                case 51:
                    retjson = "LI";
                    break;
                case 55:
                    retjson = "LV";
                    break;
                case 60:
                    retjson = "LX";
                    break;
                case 90:
                    retjson = "XC";
                    break;
                case 100:
                    retjson = "C";
                    break;
                case 101:
                    retjson = "CI";
                    break;
                case 105:
                    retjson = "CV";
                    break;
                case 110:
                    retjson = "CX";
                    break;
                case 150:
                    retjson = "CL";
                    break;
                case 400:
                    retjson = "CD";
                    break;
                case 500:
                    retjson = "D";
                    break;
                case 501:
                    retjson = "DI";
                    break;
                case 505:
                    retjson = "DV";
                    break;
                case 510:
                    retjson = "DX";
                    break;
                case 550:
                    retjson = "DL";
                    break;
                case 600:
                    retjson = "DC";
                    break;
                case 900:
                    retjson = "CM";
                    break;
                case 1000:
                    retjson = "M";
                    break;
                case 1001:
                    retjson = "MI";
                    break;
                case 1005:
                    retjson = "MV";
                    break;
                case 1010:
                    retjson = "MX";
                    break;
                case 1050:
                    retjson = "ML";
                    break;
                case 1100:
                    retjson = "MC";
                    break;
                case 1500:
                    retjson = "MD";
                    break;

                default:
                    retjson = "A converção não existe para este numero no momento";
                    break;
            }

            //dados do jsonrestapi post
            Search2 obj = new Search2();
            obj.value = maiorValor;
            obj.number = retjson;


            return obj;

        }

        //verificação de valores
        public static decimal verificaValor(string letraRomana, int nromanoLength)
        {
            decimal valor = 0;
            if (nromanoLength > 2)
            {
                if (letraRomana == "I")
                {
                    valor = 1;
                }
                if (letraRomana == "V")
                {
                    valor = 5;
                }
                if (letraRomana == "X")
                {
                    valor = 10;
                }
                if (letraRomana == "L")
                {
                    valor = 50;
                }
                if (letraRomana == "C")
                {
                    valor = 100;
                }
                if (letraRomana == "D")
                {
                    valor = 500;
                }
                if (letraRomana == "M")
                {
                    valor = 1000;
                }

            }
            if (letraRomana.Length > 1)
            {
                var valor1 = 0;
                var valor2 = 0;
                var L1 = letraRomana[0].ToString();


                if (L1 == "I")
                {
                    valor1 = 1;
                }
                if (L1 == "V")
                {
                    valor1 = 5;
                }
                if (L1 == "X")
                {
                    valor1 = 10;
                }
                if (L1 == "L")
                {
                    valor1 = 50;
                }
                if (L1 == "C")
                {
                    valor1 = 100;
                }
                if (L1 == "D")
                {
                    valor1 = 500;
                }
                if (L1 == "M")
                {
                    valor1 = 1000;
                }

                var L2 = letraRomana[1].ToString();
                if (L2 == "I")
                {
                    valor2 = 1;
                }
                if (L2 == "V")
                {
                    valor2 = 5;
                }
                if (L2 == "X")
                {
                    valor2 = 10;
                }
                if (L2 == "L")
                {
                    valor2 = 50;
                }
                if (L2 == "C")
                {
                    valor2 = 100;
                }
                if (L2 == "D")
                {
                    valor2 = 500;
                }
                if (L2 == "M")
                {
                    valor2 = 1000;
                }

                if (valor2 > valor1)
                {
                    valor = valor2 - valor1;
                }
                else
                {
                    valor = valor1 + valor2;
                }

                if (letraRomana == "LL" || letraRomana == "VV" || letraRomana == "CC" || letraRomana == "DD" || letraRomana == "MM")
                {
                    valor = 0;
                }
            }
            return valor;
        }
    }
}
