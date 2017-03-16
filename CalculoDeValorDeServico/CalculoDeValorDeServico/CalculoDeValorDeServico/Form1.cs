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
        }

        // Cálculo do valor do serviço
        // Fórmula adaptada do SEBRAE
        private void btnCalcular_Click(object sender, EventArgs e)
        {
            // Algorítmo para calcular o serviço
            // 1) Salário Líquido
            // 2) Acrescentar 30% (impostos sobre SL)
            // 3) Somar despesas fixas
            // 4) Acrescentar 20% de investimento
        }
    }
}
