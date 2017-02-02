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
            // Exibindo a carta            
            MessageBox.Show("Carta Sorteada: " + f + " de " + n);
         }

        private void btnArray2_Click(object sender, EventArgs e)
        {
            // Outra forma de declarar e iniciar um Array
            // neste caso o Array SEMPRE tem um tamanho fixo
            // "Criando um objeto Array do tipo inteiro do tamanho 5"
            int[] numeros = new int[5];
            numeros[0] = 1;
            numeros[1] = 5;
            numeros[2] = 18;
            numeros[3] = 45;
            numeros[4] = 90;
            MessageBox.Show("Número: " + numeros[2]);            
        }
    }
}
