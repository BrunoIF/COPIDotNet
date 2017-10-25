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

using ConsumindoAPI.Models;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;

namespace ConsumindoAPI.Service
{
    class DataService
    {

        HttpClient client = new HttpClient();

        public async Task<List<Produto>> GetProdutosAsync()
        {
            try
            {
                string url = "http://www.macwebapi.somee.com/api/produtos/";

                var resposta = await client.GetStringAsync(url);
                List<Produto> produtos = JsonConvert.DeserializeObject<List<Produto>>(resposta);
                return produtos;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task AddProdutoAsync(Produto produto)
        {
            try
            {
                string url = "http://www.macwebapi.somee.com/api/produtos/{0}";
                var uri = new Uri(string.Format(url, produto.Id));
                var data = JsonConvert.SerializeObject(produto);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;
                response = await client.PostAsync(uri, content);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Erro ao incluir produto");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}