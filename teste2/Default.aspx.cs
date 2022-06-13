using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace teste2
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        //metodo para de verificação de campos e tratamento de mensagem de retorno
        protected void btnSolicitarVarificacao_Click(object sender, EventArgs e)
        {
            try
            {
                ApiRest objApiRest = new ApiRest();
                if (string.IsNullOrEmpty(txtDigite.Text))
                {
                    throw new Exception("O campo Palavra é obrigatório ao Solicitar Varificacao!");
                }
                //metodo chamada da apirest POST 
                var retToken = objApiRest.gerarSolicitar(txtDigite.Text.ToUpper());
                lbjson.Text = retToken;

            }
            catch (Exception ex)
            {
                divMensagem.Visible = true;
                divMensagem.Attributes["class"] += " alert-danger ";
                divMensagem.InnerHtml += ex.Message;
            }
        }

        public class ApiRest
        {
            public string gerarSolicitar(string txtDigite)
            {
                //comandos de chamada da apirest post
                var client = new RestClient("http://localhost:8080/search");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");

                //corpo do json de solicitação 
                var body = @"{  " + "\n" +
                                @"    ""Text"": """ + txtDigite + @"""
                                " + "\n" +
                                @"}";
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                var json = response.Content;

                return json;
            }
        }

    }
}