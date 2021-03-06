﻿using System;
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

        private void Form1_Activated(object sender, EventArgs e)
        {
            // setar o focus
            maskedTextBox1.Focus();
            // mudar a imagem do picture box
            picStatus.Image = Properties.Resources.alert;
        }

        private void maskedTextBox1_Leave(object sender, EventArgs e)
        {
            //capturando o conteúdo da masked textbox e armazenado na variável numcpf.
            //atenção variáveis do tipo string não precisam do .tostring()
            string numcpf = maskedTextBox1.Text;
            //a linha abaixo elimina o . (ponto) e o - (hífen) 
            numcpf = numcpf.Replace(".", "").Replace("-", "").Trim();
            //MessageBox.Show(numcpf);

            //antes de validar o cpf, trancar exceptions:
            if ((numcpf.Length != 11) || (numcpf == "00000000000") || (numcpf == "11111111111") || (numcpf == "22222222222") || (numcpf == "33333333333") || (numcpf == "44444444444") || (numcpf == "55555555555") || (numcpf == "66666666666") || (numcpf == "77777777777") || (numcpf == "88888888888") || (numcpf == "99999999999"))
            {
                MessageBox.Show("Digite um CPF corretamente.");
            }
            else
            {
                //tratamento do retorno do método ValidaCPF
                // o retorno do método é true ou false
                //o caminho inicia com namespace -> Classe -> método
                //se retorno for verdadeiro
                if (ValidaCPF.ValidadorCPF.verificaCPF(numcpf)) //envia para a validação
                {
                    //MessageBox.Show("Válido");
                    picStatus.Image = Properties.Resources.ok;
                }
                else
                {
                    //MessageBox.Show("Inválido");
                    picStatus.Image = Properties.Resources.erro;
                }
            }
        }

        // Não esquecer de habilitar no form a propriedade Key Preview para true
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //trocando o <TAB> pelo <ENTER>
            if ((e.KeyChar.CompareTo((char)Keys.Return))==0)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
    }
}
