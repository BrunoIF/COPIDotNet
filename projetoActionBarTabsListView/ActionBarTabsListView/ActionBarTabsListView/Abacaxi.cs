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

namespace ActionBarTabsListView
{
    [Activity(Label = "Abacaxi", NoHistory = true)]
    public class Abacaxi : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //Create yout application here
            SetContentView(Resource.Layout.Abacaxi);
        }
    }
}