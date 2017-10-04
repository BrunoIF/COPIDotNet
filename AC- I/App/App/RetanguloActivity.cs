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
    [Activity(Label = "Retângulo")]
    public class RetanguloActivity : Activity
    {
        TextView tv;
        MultiAutoCompleteTextView alturaRet;
        MultiAutoCompleteTextView baseRet;
        Button btnCalcular;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Retangulo);

            tv = (TextView)FindViewById(Resource.Id.tvResultadoRetangulo);
            alturaRet = (MultiAutoCompleteTextView)FindViewById(Resource.Id.txtAlturaRetangulo);
            baseRet = (MultiAutoCompleteTextView)FindViewById(Resource.Id.txtBaseRetangulo);
            btnCalcular = (Button)FindViewById(Resource.Id.btnCalcularRetangulo);

            btnCalcular.Click += OnButtonClick;
        }

        private void OnButtonClick(object sender, EventArgs e)
        {
            
            try
            {
                int alt = Convert.ToInt32(alturaRet.Text);
                int bas = Convert.ToInt32(baseRet.Text);
                tv.Text = (alt * bas).ToString();
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.Message, ToastLength.Long).Show();
            } 
        }
    }
}