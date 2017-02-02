using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Array
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnArray1_Click(object sender, EventArgs e)
        {
            // Criando e iniciando um simples array
            // Neste caso o tamanho do Array pode variar
            string[] times = { "Corinthians", "Palmeiras", "São Paulo", "Santos" };
            // recuperando o conteúdo de um array
            MessageBox.Show("Time: " + times[2]);
        }

        private void btnCarta_Click(object sender, EventArgs e)
        {
            // Sorteio de uma carta
            string[] faces = { "A","2","3","4","5","6","7","8","9","10","Valete","Dama","Rei"};
            string[] naipe = {"Ouro","Paus","Espadas","Copas" };

            // A linha abaixo ajuda o entendimento do raciocínio lógico
            //MessageBox.Show("Carta Sorteada: " + faces[4] + "de " + naipe[0]);


            // Função para gerar número random
            Random numero = new Random();
            string n = naipe[numero.Next(4)];
            string f = faces[numero.Next(12)];
            
            MessageBox.Show("Carta Sorteada: " + f + " de " + n);
         }
    }
}
