using Android.App;
using Android.Widget;
using Android.OS;
using System;

namespace AppListView
{
    [Activity(Label = "AppListView", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        ListView lv;
        string[] items;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            lv = FindViewById<ListView>(Resource.Id.lstDados);

            items = new string[] { "Cereais", "Frutas", "Legumes", "Verduras" };
            ArrayAdapter adaptador = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, items);

            lv.Adapter = adaptador;

            lv.ItemClick += OnListItemClick;
        }

        private void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            int valor = e.Position;

            switch (valor)
            {
                case 0:
                    StartActivity(typeof(Cereais));
                    break;
                case 1:
                    StartActivity(typeof(Frutas));
                    break;
                case 2:
                    StartActivity(typeof(Legumes));
                    break;
                case 3:
                    StartActivity(typeof(Verduras));
                    break;
            }

        }
    }
}

