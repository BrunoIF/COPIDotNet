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
        // Spinner
        Spinner spinner;
        ArrayAdapter adapter;
        ArrayList estados;

        // Radio
        RadioButton rdbSim;
        RadioButton rdbNao;
        Button btnRadioButton;

        // Switch
        Switch swtTeste;

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

            // Instância dos RadioButton (Modo Alternativo de instanciar)
            rdbSim = (RadioButton)FindViewById(Resource.Id.rdbSim);
            rdbNao = (RadioButton)FindViewById(Resource.Id.rdbNao);
            btnRadioButton = (Button)FindViewById(Resource.Id.btnRadioButton);

            // Definir o evento ao Click do btnRadioButton
            btnRadioButton.Click += btnRadioButton_Click;

            // Instância da Switch
            swtTeste = (Switch)FindViewById(Resource.Id.swtTeste);

            swtTeste.CheckedChange += swtTeste_CheckedChange;
        }

        private void swtTeste_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            if (swtTeste.Checked == true)
            {
                Toast.MakeText(this, "Ligado", ToastLength.Short).Show();
            }
            else
            {
                Toast.MakeText(this, "Desligado", ToastLength.Short).Show();
            }
        }

        private void btnRadioButton_Click(object sender, EventArgs e)
        {
            if (rdbSim.Checked == true)
            {
                Toast.MakeText(this, "Clicou no Sim", ToastLength.Short).Show();
            }
            else
            {
                Toast.MakeText(this, "Clicou no Não", ToastLength.Short).Show();
            }
        }

        private void Spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            // Texto para o Toast
            string toast = string.Format("Estado selecionado: " + spinner.GetItemAtPosition(e.Position));
            // Toast -> Mensagem que aparecerá na tela como um alert() no JS
            Toast.MakeText(this, toast, ToastLength.Long).Show();
        }
    }
}

