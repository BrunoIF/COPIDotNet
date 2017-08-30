using Android.App;
using Android.Widget;
using Android.OS;
using System;

namespace App
{
    [Activity(Label = "App", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        TextView txtValor;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            txtValor = FindViewById<TextView>(Resource.Id.tvValor);

            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
            // Adiciona as tabs no Action Bar
            AddTab("Tab um");
            AddTab("Tab dois");

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
                txtValor.Text = "Esta é a TAB UM que foi selecionada";
            }
            else
            {
                txtValor.Text = "Esta é a TAB DOIS que foi selecionada";
            }

        }
    }
}

