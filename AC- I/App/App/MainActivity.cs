using Android.App;
using Android.Widget;
using Android.OS;
using System;

namespace App
{
    [Activity(Label = "12294 - Bruno - 3EMIA", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        ListView lv;
        string[] items;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            lv = (ListView)FindViewById(Resource.Id.listView1);

            // Setar Navegação como Tabs
            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
            AddTab("Círculo");
            AddTab("Polígono");
        }

        private void AddTab(string v)
        {
            ActionBar.Tab tab = ActionBar.NewTab();
            tab.SetText(v);
            tab.TabSelected += OnTabSelected;
            ActionBar.AddTab(tab);
        }

        private void OnTabSelected(object sender, ActionBar.TabEventArgs e)
        {
            var tabatual = (ActionBar.Tab)sender;
            if (tabatual.Position == 0)
            {
                //StartActivity(typeof(CirculoActivity));
                items = new string[] { "Círculo" };
            }
            if (tabatual.Position == 1)
            {
                items = new string[] { "Quadrado", "Retângulo", "Triângulo" };
            }
            ArrayAdapter adaptador = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, items);
            lv.Adapter = adaptador;
            lv.ItemClick += OnListItemClick;
        }

        private void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            int valor = e.Position;
            string texto = items[valor];

            if (texto.Equals("Círculo"))
            {
                StartActivity(typeof(CirculoActivity));
            }

            if (texto.Equals("Quadrado"))
            {
                StartActivity(typeof(QuadradoActivity));
            }
            if (texto.Equals("Retângulo"))
            {
                StartActivity(typeof(RetanguloActivity));
            }
            if (texto.Equals("Triângulo"))
            {
                StartActivity(typeof(TrianguloActivity));
            }
        }

    }
}

