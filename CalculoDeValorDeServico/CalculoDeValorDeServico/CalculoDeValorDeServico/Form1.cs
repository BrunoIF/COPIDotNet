using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculoDeValorDeServico
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label5.Visible = false;
        }

        // Cálculo do valor do serviço
        // Fórmula adaptada do SEBRAE
        private void btnCalcular_Click(object sender, EventArgs e)
        {

            try
            {
                // Algorítmo para calcular o serviço
                // 1) Salário Líquido
                // 2) Acrescentar 30% (impostos sobre SL)
                // 3) Somar despesas fixas
                // 4) Acrescentar 20% de investimento
                // 5) Determinar total de horas/mês 
                double salario = Convert.ToDouble(txtSalario.Text.Replace(",",".")), despesas = Convert.ToDouble(txtDespesas.Text.Replace(",", ".")), total = 0, horas = Convert.ToDouble(txtHoras.Text.Replace(",", "."));

                // total = (SL + 30% de SL + despesas + 20% de investimento)/horas
                total = (salario * 1.5 + despesas) / horas;
                lblTotal.Text = total.ToString("c2");
                label5.Visible = true;
            }
            catch (Exception)
            {

                MessageBox.Show("Digite um valor válido.");
            }
        }
    }
}
