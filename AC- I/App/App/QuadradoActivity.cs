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

namespace App
{
    [Activity(Label = "Quadrado")]
    public class QuadradoActivity : Activity
    {
        TextView res;
        MultiAutoCompleteTextView lado;
        Button btnCalcular;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Quadrado);

            res = (TextView)FindViewById(Resource.Id.tvResultado);
            lado = (MultiAutoCompleteTextView)FindViewById(Resource.Id.txtLado);
            btnCalcular = (Button)FindViewById(Resource.Id.btnCalcularQuadrado);
            btnCalcular.Click += onButtonClick;
        }

        private void onButtonClick(object sender, EventArgs e)
        {
            try
            {
                int num = Convert.ToInt32(lado.Text);
                res.Text = (num * num).ToString();
            }
            catch (Exception ex)
            {

                Toast.MakeText(this, ex.Message,ToastLength.Long).Show();
            }
            
        }
    }
}