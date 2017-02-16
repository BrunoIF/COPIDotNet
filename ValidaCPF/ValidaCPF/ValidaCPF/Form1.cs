using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValidaCPF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Capturando o conteúdo da masked textbox e armazenando na variável numcpf
            // Atenção! variáveis do tipo string não precisam do .toString()
            string cpf = txtCPF.Text.Replace(".","").Replace("-","");
            
            // Tratamento do retorno do método ValidadorCPF
            if (ValidaCPF.ValidadorCPF.Validar(cpf))
            {
                MessageBox.Show("Válido");
            }
            else
            {
                MessageBox.Show("Inválido");
            }
            

        }
    }
}
