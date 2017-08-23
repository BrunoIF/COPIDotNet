using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections;
using System;

namespace componentesDiversos
{
    [Activity(Label = "componentesDiversos", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Spinner spinner;
        ArrayAdapter adapter;
        ArrayList estados;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Definindo a Lista para alimentar o apinner
            estados = new ArrayList();
            estados.Add("São Paulo");
            estados.Add("Rio de Janeiro");
            estados.Add("Minas Gerais");
            estados.Add("Paraná");
            estados.Add("Santa Catarina");
            estados.Add("Rio Grande do Sul");
            estados.Add("Espírito Santo");

            // Instância do Spinner
            spinner = FindViewById<Spinner>(Resource.Id.spnExemplo);

            // criar o adapter usando o layout SimpleListItem
            adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, estados);
            // Vincula o adaptador ao controle spinner
            spinner.Adapter = adapter;

            // define o evento ItemSelected para exibir o item selecionado
            spinner.ItemSelected += Spinner_ItemSelected;
        }

        private void Spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            string toast = string.Format("Estado selecionado: " + spinner.GetItemAtPosition(e.Position));
            Toast.MakeText(this, toast, ToastLength.Long).Show();
        }
    }
}

