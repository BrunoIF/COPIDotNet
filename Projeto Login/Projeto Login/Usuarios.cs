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
    public partial class Usuarios : Form
    {
        static string strCn = "Data Source = (LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\DBLogin.mdf;Integrated Security = True";
        SqlConnection conexao = new SqlConnection(strCn);

        public Usuarios()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {

        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            string pesquisa = "select * from tbUsuarios where Id= " + txtId.Text;

            SqlCommand cmd = new SqlCommand(pesquisa, conexao);
            SqlDataReader DR;

            try
            {
                conexao.Open();
                DR = cmd.ExecuteReader();
                if (DR.Read())
                {
                    txtId.Text = DR.GetValue(0).ToString();
                    txtLogin.Text = DR.GetValue(1).ToString();
                    txtSenha.Text = DR.GetValue(2).ToString();
                    cboPerfil.SelectedText = DR.GetValue(3).ToString();
                }
                else
                {
                    MessageBox.Show("Usuário e/ou senha inválido(s)");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conexao.Close();
            }
        }
    }
}
