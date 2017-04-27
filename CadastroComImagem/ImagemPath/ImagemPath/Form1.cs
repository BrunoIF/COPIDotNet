using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Biblioteca para trabalhar com SQL
using System.Data.SqlClient;

namespace ImagemPath
{
    public partial class Form1 : Form
    {
        // string de conexão
        static string strCn = "Data Source=sql.fiap.com.br;Initial Catalog=3EMIA;User ID=RM12294;Password=230200";
        // Instanciando um objeto tendo como modelo a classe SqlConnection para conexão com o banco
        SqlConnection conexao = new SqlConnection(strCn);
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            // instrução SQL responsável por inserir o caminho da imagem no banco de dados
            string adicionar = "insert into tb_imagem_path_02(imgCODIGO,imgDESCRICAO,imgCAMINHO) values(@CODIGO, @DESCRICAO, @CAMINHO)";
            // instanciando um objeto tendo como modelo a classe SqlCommand para executar a instrução SQL
            SqlCommand cmd = new SqlCommand(adicionar, conexao);
            try
            {

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
