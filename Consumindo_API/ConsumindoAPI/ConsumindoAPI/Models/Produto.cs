using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ConsumindoAPI.Models
{
    class Produto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Categoria { get; set; }

        public decimal Preco { get; set; }

        public override string ToString()
        {
            return Id + " - " + Nome;
        }
    }
}