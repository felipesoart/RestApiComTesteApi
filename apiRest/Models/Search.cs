using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiRest.Models
{
    public class Search
    {
        public Search(string text, decimal valor)
        {
            this.Text = text;
            this.Valor = valor;
        }

        public string Text { get; set; }
        public decimal Valor { get; set; }
    }
}