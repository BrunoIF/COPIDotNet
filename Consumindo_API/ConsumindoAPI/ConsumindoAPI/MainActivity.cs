using Android.App;
using Android.Widget;
using Android.OS;

using ConsumindoAPI.Models;
using ConsumindoAPI.Service;
using System.Collections.Generic;
using System;

namespace ConsumindoAPI
{
    [Activity(Label = "ConsumindoAPI", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        DataService dataService;
        List<Produto> produtos;
        TextView txtnomeProduto;
        TextView txtcategoriaProduto;
        TextView txtprecoProduto;
        Button btnCadastrarProduto;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            txtnomeProduto = (TextView)FindViewById(Resource.Id.nomeProduto);
            txtcategoriaProduto = (TextView)FindViewById(Resource.Id.categoriaProduto);
            txtprecoProduto = (TextView)FindViewById(Resource.Id.precoProduto);
            btnCadastrarProduto = (Button)FindViewById(Resource.Id.btnCadastrar);

            dataService = new DataService();

            btnCadastrarProduto.Click += btnCadastrarProduto_Click;
        }

        private async void btnCadastrarProduto_Click(object sender, EventArgs e)
        {
            Produto novoProduto = new Produto
            {
                Nome = txtnomeProduto.Text.Trim(),
                Categoria = txtcategoriaProduto.Text.Trim(),
                Preco = Convert.ToDecimal(txtprecoProduto.Text)
            };
            try
            {
                await dataService.AddProdutoAsync(novoProduto);
                Toast.MakeText(this, "Produto cadastrado com sucesso", ToastLength.Long).Show();
                txtcategoriaProduto.Text = "";
                txtnomeProduto.Text = "";
                txtprecoProduto.Text = "";
            }
            catch (Exception ex)
            {

                Toast.MakeText(this, ex.Message, ToastLength.Long).Show();

            }
        }
    }
}

