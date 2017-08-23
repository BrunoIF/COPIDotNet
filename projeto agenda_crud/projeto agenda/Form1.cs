using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// ativando bibliotecas para trabalhar com sql
using System.Data.SqlClient;

namespace projeto_agenda
{
    public partial class Form1 : Form
    {
        //string de conexão ATENÇÂO !!! substituir \ por \\
        static string strCn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\DBAgenda.mdf;Integrated Security=True";
        //criando um objeto de nome conexao tendo como modelo a classe SqlConnection para conexão ao banco de dados
        SqlConnection conexao = new SqlConnection(strCn);

        public Form1()
        {
            InitializeComponent();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            //instrução sql responsável por pesquisar o banco de dados (CRUD - Read)
            string pesquisa = "select * from tbcontatos where Id = @Id";

            //criando um objeto de nome cmd tendo como modelo a classe SqlCommandd para executar a instrução sql
            SqlCommand cmd = new SqlCommand(pesquisa, conexao);
            // uso de parâmetro
            cmd.Parameters.AddWithValue("@Id", txtId.Text);
            // Atravé da classe SqlDataReader que faz parte do SqlCliente, criamos uma variável chamada DR que será usada na leitura dos dados (instrução select)
            SqlDataReader DR;
            //tratamento de exceções: try - catch - finally (em caso de erro capturamos o tipo do erro)
            try
            {
                // Abrindo a conexão com o banco
                conexao.Open();
                // Executando a instrução e armazenando o resultado no reader DR
                DR = cmd.ExecuteReader();
                // Se houver um registro correspondente ao Id
                if (DR.Read())
                {
                    // Exibe as informações nas caixas de texto (textBox) correspondentes (0) corresponde ao Id, (1) ao Nome e assim sucessivamente
                    txtId.Text = DR.GetValue(0).ToString();
                    txtNome.Text = DR.GetValue(1).ToString();
                    txtFone.Text = DR.GetValue(2).ToString();
                    txtEmail.Text = DR.GetValue(3).ToString();
                }
                // Senão, exibimos uma mensagem avisando e também limpamos os campos para uma nova pesquisa
                else
                {
                    MessageBox.Show("Registro não encontrado");
                    txtNome.Clear();
                    txtFone.Clear();
                    txtEmail.Clear();
                    txtId.Focus();
                } // Encerrando o uso do reader DR
                DR.Close();
                // Encerrando o uso do cmd
                cmd.Dispose();
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

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            //instrução sql responsável por adicionar dados ao banco (CRUD - Create)
            string adiciona = "insert into tbcontatos values (@Id, @Nome, @Fone, @Email)";

            //criando um objeto de nome cmd tendo como modelo a classe SqlCommand para executar a instrução sql
            SqlCommand cmd = new SqlCommand(adiciona, conexao);
            cmd.Parameters.AddWithValue("@Id", txtId.Text);
            cmd.Parameters.AddWithValue("@Nome", txtNome.Text);
            cmd.Parameters.AddWithValue("@Fone", txtFone.Text);
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);

            //tratamento de exceções: try - catch - finally (em caso de erro capturamos o tipo do erro)
            try
            {
                // Abrindo a conexão com o banco
                conexao.Open();
                // Criando uma variável para adicionar e armazenar o resultado
                int resultado;
                resultado = cmd.ExecuteNonQuery();
                // Verificando se o registro foi adicionado
                // Caso o valor da variável resultado seja 1
                // significa que o comando funcionou, neste caso limpar os campos e exibir uma mensagem
                if (resultado == 1)
                {
                    MessageBox.Show("Registro adicionado com sucesso");
                    txtId.Clear();
                    txtNome.Clear();
                    txtFone.Clear();
                    txtEmail.Clear();
                    txtId.Focus();
                }
                // Encerrando o uso do cmd
                cmd.Dispose();
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

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            //instrução sql responsável por alterar um registro do banco (CRUD - Update)
            string altera = "update tbcontatos set Nome= '" + txtNome.Text +
               "', Fone= '" + txtFone.Text +
               "', Email= '" + txtEmail.Text +
               "' where Id= " + txtId.Text;

            //criando um objeto de nome cmd tendo como modelo a classe SqlCommand para executar a instrução sql
            SqlCommand cmd = new SqlCommand(altera, conexao);
            //tratamento de exceções: try - catch - finally (em caso de erro capturamos o tipo do erro)
            try
            {
                // Abrindo a conexão com o banco
                conexao.Open();
                // Criando uma variável para alterar e armazenar o resultado
                int resultado;
                resultado = cmd.ExecuteNonQuery();
                // Verificando se o registro foi alterado
                // Caso o valor da variável resultado seja 1
                // significa que o comando funcionou, neste caso limpar os campos e exibir uma mensagem
                if (resultado == 1)
                {
                    txtId.Clear();
                    txtNome.Clear();
                    txtFone.Clear();
                    txtEmail.Clear();
                    txtId.Focus();
                    MessageBox.Show("Registro alterado com sucesso");
                }
                // Encerrando o uso do cmd
                cmd.Dispose();
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

        private void btnRemover_Click(object sender, EventArgs e)
        {
            //instrução sql responsável por remover um registro do banco (CRUD - Delete)
            string remove = "delete from tbcontatos where Id= " + txtId.Text;

            //criando um objeto de nome cmd tendo como modelo a classe SqlCommand para executar a instrução sql
            SqlCommand cmd = new SqlCommand(remove, conexao);
            //tratamento de exceções: try - catch - finally (em caso de erro capturamos o tipo do erro)
            try
            {
                // Abrindo a conexão com o banco
                conexao.Open();
                // Criando uma variável para adicionar e armazenar o resultado
                int resultado;
                if (MessageBox.Show("Tem certeza que deseja remover este registro ?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    resultado = cmd.ExecuteNonQuery();
                    // Verificando se o registro foi apagado
                    // Caso o valor da variável resultado seja 1
                    // significa que o comando funcionou, neste caso limpar os campos e exibir uma mensagem
                    if (resultado == 1)
                    {
                        txtId.Clear();
                        txtNome.Clear();
                        txtFone.Clear();
                        txtEmail.Clear();
                        txtId.Focus();
                        MessageBox.Show("Registro removido com sucesso");
                    }
                    // Encerrando o uso do cmd
                    cmd.Dispose();
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

// Material de apoio: professorjosedeassis.com.br