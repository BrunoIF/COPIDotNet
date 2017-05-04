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
                // Usando o objeto OpenFileDialog para buscar a imagem que ficará armazenada
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // Abrir a conexão
                    conexao.Open();
                    // Carregar a imagem na picture box
                    imgImagem.Load(openFileDialog1.FileName);
                    // Zerar os parâmetros
                    cmd.Parameters.Clear();
                    // Usar os parâmetros para vincular os objetos aos campos da tabela
                    cmd.Parameters.AddWithValue("CODIGO", txtCodigo.Text);
                    cmd.Parameters.AddWithValue("DESCRICAO", txtDescricao.Text);
                    // Passando o parâmetro imagem (coração deste projeto) *cadastra apenas o caminho (path)*
                    cmd.Parameters.AddWithValue("CAMINHO", openFileDialog1.FileName);
                    // Executando a instrução SQL
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Imagem cadastrada com sucesso.");
                }
            }
            catch (Exception ex)
            {
                // Exibir o erro
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}
