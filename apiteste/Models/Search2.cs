using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiteste.Models
{
    public class Search2
    {
        public Search2()
        {
        }

        public Search2(string number, decimal valor)
        {
            this.number = number;
            this.value = valor;
        }

        public string number { get; set; }
        public decimal value { get; set; }
    }
}