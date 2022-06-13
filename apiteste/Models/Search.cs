using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiteste.Models
{
    public class Search
    {
        public Search()
        {
        }

        public Search(string text, decimal valor)
        {
            this.Text = text;

        }

        public string Text { get; set; }

    }
}