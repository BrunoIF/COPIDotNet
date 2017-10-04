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
    [Activity(Label = "Triângulo")]
    public class TrianguloActivity : Activity
    {
        TextView tv;
        MultiAutoCompleteTextView alturaTri, baseTri;
        Button btnCalcular;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Triangulo);

            tv = (TextView)FindViewById(Resource.Id.tvResultadoTriangulo);
            alturaTri = (MultiAutoCompleteTextView)FindViewById(Resource.Id.txtAlturaTriangulo);
            baseTri = (MultiAutoCompleteTextView)FindViewById(Resource.Id.txtBaseTriangulo);
            btnCalcular = (Button)FindViewById(Resource.Id.btnCalcularTriangulo);

            btnCalcular.Click += OnButtonClick;
        }

        private void OnButtonClick(object sender, EventArgs e)
        {
            try
            {
                int alt = Convert.ToInt32(alturaTri.Text);
                int bas = Convert.ToInt32(baseTri.Text);
                tv.Text = ((alt * bas) / 2).ToString();
            }
            catch (Exception ex)
            {

                Toast.MakeText(this, ex.Message, ToastLength.Long).Show();
            }
        }
    }
}