using Android.App;
using Android.Widget;
using Android.OS;
using System;

namespace ActionBarTabsListView
{
    [Activity(Label = "ActionBarTabsListView", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        TextView txtValor;
        ListView lv;
        string[] items;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            txtValor = FindViewById<TextView>(Resource.Id.textView1);
            lv = (ListView)FindViewById(Resource.Id.lstDados);

            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
            //Adiciona as tabs no Action Bar
            AddTab("Frutas");
            AddTab("Verduras");
            AddTab("Legumes");
        }

        private void AddTab(string tabTexto)
        {
            ActionBar.Tab tab = ActionBar.NewTab();
            tab.SetText(tabTexto);
            tab.TabSelected += OnTabSelected;
            ActionBar.AddTab(tab);
        }

        private void OnTabSelected(object sender, ActionBar.TabEventArgs e)
        {
            var tabAtual = (ActionBar.Tab)sender;
            if (tabAtual.Position == 0)
            {
                txtValor.Text = "Frutas";
                items = new string[] { "Abacaxi", "Banana", "Maçã" };
            }
            else
            {
                if (tabAtual.Position == 1)
                {
                    txtValor.Text = "Verduras";
                    items = new string[] { "Alface", "Brócolis", "Rúcula" };
                }
            }
            else
            {
                    txtValor.Text = "Legumes";
                    items = new string[] { "Abóbora", "Berinjela", "Pimentão" };
            }

            ArrayAdapter adaptador = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, items);
            lv.Adapter = adaptador;
            lv.ItemClick += OnListItemClick;
        }

        private void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            int valor = e.Position;
            string texto = items[valor];

            if (texto.Equals("Abacaxi"))
            {
                StartActivity(typeof(Abacaxi));
            }

            if (texto.Equals("Brócolis"))
            {
                StartActivity(typeof(Brocolis));
            }
        }
    }

}

