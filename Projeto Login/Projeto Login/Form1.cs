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

namespace Projeto_Login
{
    public partial class Form1 : Form
    {
        static string strCn = "Data Source = (LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\DBLogin.mdf;Integrated Security = True";
        SqlConnection conexao = new SqlConnection(strCn);

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == String.Empty) || (textBox2.Text == String.Empty))
            {
                MessageBox.Show("É obrigatório o preenchimento dos campos Usuário e Senha", "Atenção !", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                // Uso de Parâmetros para seleção de usuário e senha do banco de dados
                // @Nome do campo da tabela
                string pesquisa = "select * from tbUsuarios where Login=@Login and Senha=@Senha";

                SqlCommand cmd = new SqlCommand(pesquisa, conexao);
                // Captura dos parâmetros
                // @Login recebe o valor
                cmd.Parameters.AddWithValue("@Login", textBox1.Text);
                cmd.Parameters.AddWithValue("@Senha", textBox2.Text);
                SqlDataReader DR;
                try
                {

                    conexao.Open();
                    DR = cmd.ExecuteReader();
                    if (DR.Read())
                    {
                        string perfil = DR.GetValue(3).ToString();
                        if (perfil == "admin")
                        {
                            Form2 principal = new Form2();
                            principal.Show();
                            principal.label1.Text = "Administrador";
                            principal.panel1.BackColor = Color.DarkRed;
                        }
                        else
                        {
                            Form2 principal = new Form2();
                            principal.Show();
                            principal.label1.Text = "Usuário";
                            principal.button1.Enabled = false;
                            principal.panel1.BackColor = Color.Blue;
                        }

                    }
                    else
                    {
                        MessageBox.Show("Usuário e/ou Senha Inválido(s)");
                    }
                }
                //caso ocorra algum erro
                catch (Exception ex)
                {
                    //exiba qual é o erro
                    MessageBox.Show(ex.Message);
                }
                // de qualquer forma sempre fechar a conexão com o banco ("lembrar da porta da geladeira rsrsrs")
                finally
                {
                    conexao.Close();
                }
            }
        }
    }
}
