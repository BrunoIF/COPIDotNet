using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _12294_12295
{
    public partial class Form1 : Form
    {
        static string strCn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\DBAgenda.mdf;Integrated Security=True";
        //criando um objeto de nome conexao tendo como modelo a classe SqlConnection para conexão ao banco de dados
        SqlConnection conexao = new SqlConnection(strCn);
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNome.Clear();
            txtEmail.Clear();
            txtTelefone.Clear();
            txtBairro.Clear();
            txtCEP.Clear();
            txtCPF.Clear();
            txtUF.Clear();
            txtLogradouro.Clear();
            txtComplemento.Clear();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string adiciona = "insert into tb_AC_cliente_02 values (@CPF, @Nome, @Telefone, @Email, @CEP, @Logradouro, @Bairro, @Complemento, @UF)";
            SqlCommand cmd = new SqlCommand(adiciona, conexao);
            cmd.Parameters.AddWithValue("@CPF", txtCPF.Text);
            cmd.Parameters.AddWithValue("@Nome", txtNome.Text);
            cmd.Parameters.AddWithValue("@Telefone", txtTelefone.Text);
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@CEP", txtCEP.Text);
            cmd.Parameters.AddWithValue("@Logradouro", txtLogradouro.Text);
            cmd.Parameters.AddWithValue("@Bairro", txtBairro.Text);
            cmd.Parameters.AddWithValue("@Complemento", txtComplemento.Text);
            cmd.Parameters.AddWithValue("@UF", txtUF.Text);

            string checarCPF = "select count(*) from tb_AC_cliente_02 where cpf = '" + txtCPF.Text + "'";
            SqlCommand TotalCPF = new SqlCommand(checarCPF, conexao);

            try
            {
                conexao.Open();
                int total = Convert.ToInt16(TotalCPF.ExecuteScalar());
                conexao.Close();

                if (total == 1)
                {
                    MessageBox.Show("Já existe um cliente cadastrado com este CPF.", "CPF Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {

                }
                int resultado;
                resultado = cmd.ExecuteNonQuery();
                if (resultado == 1)
                {
                    MessageBox.Show("Cliente cadastrado com sucesso", "Sucesso", MessageBoxButtons.OK);
                    txtNome.Clear();
                    txtEmail.Clear();
                    txtTelefone.Clear();
                    txtBairro.Clear();
                    txtCEP.Clear();
                    txtCPF.Clear();
                    txtUF.Clear();
                    txtLogradouro.Clear();
                    txtComplemento.Clear();
                }
                cmd.Dispose();
            }
            catch (Exception)
            {
                MessageBox.Show("Ocorreu um erro durante o processo. Tente novamente", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            finally
            {
                conexao.Close();
            }
        }

        private void txtCPF_Leave(object sender, EventArgs e)
        {
            string numcpf = txtCPF.Text;
            numcpf = numcpf.Replace(".", "").Replace("-", "").Trim();

            if ((numcpf.Length != 11) || (numcpf == "00000000000") || (numcpf == "11111111111") || (numcpf == "22222222222") || (numcpf == "33333333333") || (numcpf == "44444444444") || (numcpf == "55555555555") || (numcpf == "66666666666") || (numcpf == "77777777777") || (numcpf == "88888888888") || (numcpf == "99999999999"))
            {
                MessageBox.Show("Digite um CPF corretamente.");
            }
            else
            {
                string cpf, digito;
                int soma, resto;
                int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

                cpf = numcpf.Substring(0, 9);
                soma = 0;

                for (int i = 0; i < 9; i++)
                {
                    soma += int.Parse(cpf[i].ToString()) * multiplicador1[i];
                }

                resto = soma % 11;
                if (resto < 2)
                {
                    resto = 0;
                }
                else
                {
                    resto = 11 - resto;
                }

                digito = resto.ToString();
                cpf = cpf + digito;
                soma = 0;

                for (int i = 0; i < 10; i++)
                {
                    soma += int.Parse(cpf[i].ToString()) * multiplicador2[i];
                }

                resto = soma % 11;
                if (resto < 2)
                {
                    resto = 0;
                }
                else
                {
                    resto = 11 - resto;
                }
                digito = digito + resto.ToString();

                bool final = numcpf.EndsWith(digito);

                if (final)
                {
                    picCPFStatus.Image = Properties.Resources.ok;
                    txtCPF.Focus();
                }
                else
                {
                    picCPFStatus.Image = Properties.Resources.erro;
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            string remove = "delete from tb_AC_cliente_02 where cpf= " + txtCPF.Text;
            
            SqlCommand cmd = new SqlCommand(remove, conexao);
            try
            {

                conexao.Open();

                int resultado;
                if (MessageBox.Show("Tem certeza que deseja remover este registro?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    resultado = cmd.ExecuteNonQuery();

                    if (resultado == 1)
                    {
                        txtNome.Clear();
                        txtEmail.Clear();
                        txtTelefone.Clear();
                        txtBairro.Clear();
                        txtCEP.Clear();
                        txtCPF.Clear();
                        txtUF.Clear();
                        txtLogradouro.Clear();
                        txtComplemento.Clear();
                        MessageBox.Show("Registro removido com sucesso.");
                    }

                    cmd.Dispose();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Ocorreu um erro durante o processo. Tente novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            finally
            {
                conexao.Close();
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            string altera = "update tbcontatos set nome= @Nome, email = @Email, telefone = @Telefone, cep = @CEP, logradouro = @Logradouro, complemento = @Complemento, bairro = @Bairro, uf = @UF where cpf= @CPF";

            SqlCommand cmd = new SqlCommand(altera, conexao);
            cmd.Parameters.AddWithValue("@CPF", txtCPF.Text);
            cmd.Parameters.AddWithValue("@Nome", txtNome.Text);
            cmd.Parameters.AddWithValue("@Telefone", txtTelefone.Text);
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@CEP", txtCEP.Text);
            cmd.Parameters.AddWithValue("@Logradouro", txtLogradouro.Text);
            cmd.Parameters.AddWithValue("@Bairro", txtBairro.Text);
            cmd.Parameters.AddWithValue("@Complemento", txtComplemento.Text);
            cmd.Parameters.AddWithValue("@UF", txtUF.Text);
            try
            {
                conexao.Open();
                int resultado;
                resultado = cmd.ExecuteNonQuery();
                if (resultado == 1)
                {
                    txtNome.Clear();
                    txtEmail.Clear();
                    txtTelefone.Clear();
                    txtBairro.Clear();
                    txtCEP.Clear();
                    txtCPF.Clear();
                    txtUF.Clear();
                    txtLogradouro.Clear();
                    txtComplemento.Clear();
                    MessageBox.Show("Registro alterado com sucesso");
                }
                cmd.Dispose();
            }
            catch (Exception)
            {
                MessageBox.Show("Ocorreu um erro durante o processo. Tente novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            finally
            {
                conexao.Close();
            }
        }

        private void btnChecaCEP_Click(object sender, EventArgs e)
        {
            try
            {
                string rua;
                DataSet ds = new DataSet();
                string endereco = "http://cep.republicavirtual.com.br/web_cep.php?cep=@cep&formato=xml".Replace("@cep", txtCEP.Text);
                ds.ReadXml(endereco);
                rua = ds.Tables[0].Rows[0]["logradouro"].ToString();

                if (rua == "")
                {
                    MessageBox.Show("CEP não encontrado.", "CEP Inválido", MessageBoxButtons.OK);
                    txtCEP.Focus();
                }
                else
                {
                    txtLogradouro.Text = ds.Tables[0].Rows[0]["tipo_logradouro"].ToString() + rua;
                    txtBairro.Text = ds.Tables[0].Rows[0]["bairro"].ToString();
                    txtUF.Text = ds.Tables[0].Rows[0]["uf"].ToString();
                    txtComplemento.Focus();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Serviço Indisponível. Tente novamente mais tarde.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form sobre = new Sobre();

            sobre.Show();
        }
    }
}
