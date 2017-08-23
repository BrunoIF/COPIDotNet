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

namespace prjAgendamento
{
    public partial class Form1 : Form
    {
        static string strCn = "Data Source=sql.fiap.com.br;Initial Catalog=3EMIA;User ID=RM12294;Password=230200";
        SqlConnection conexao = new SqlConnection(strCn);

        SqlDataReader DR;

        public Form1()
        {
            InitializeComponent();
        }
        // Agendar os horários no banco
        private void btnAgendar_Click(object sender, EventArgs e)
        {
            // criando a inserção do nome no agendamento de horários
            string agendar = "insert into tb_agendamento_02 values(@h1, @h2, @h3, @h4, @h5, @agendamento)";
            SqlCommand cmd = new SqlCommand(agendar, conexao);
            
            cmd.Parameters.AddWithValue("@h1",txtH1.Text);
            cmd.Parameters.AddWithValue("@h2", txtH2.Text);
            cmd.Parameters.AddWithValue("@h3", txtH3.Text);
            cmd.Parameters.AddWithValue("@h4", txtH4.Text);
            cmd.Parameters.AddWithValue("@h5", txtH5.Text);
            // atenção ao objeto datetimepicker
            cmd.Parameters.AddWithValue("@agendamento", dateTimePicker1.Text);

            try
            {
                conexao.Open();
                // Confirmar o agendamento
                int resultado;
                /* 
                   executando o insert no banco (cmd.ExecuteNonQuery()) 
                   e atribuindo o resultado a variável resultado

                   Se resultado = 1 - Sucesso
                   Se resultado = 0 - Falhou
                */
                resultado = cmd.ExecuteNonQuery();
                if (resultado == 1)
                {
                    MessageBox.Show("Hora agendada com sucesso");
                }
                else
                {
                    MessageBox.Show("ERRO...Não foi possível agendar este horário");
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // não esquecer de usar o DR para recuperar
            // string de pesquisa
            string pesquisa = "select * from tb_agendamento_02 where agendamento = @agendamento";
            SqlCommand cmd = new SqlCommand(pesquisa, conexao);
            cmd.Parameters.AddWithValue("@agendamento", dateTimePicker1.Text);
            

            // Atenção! Limpar os campos ates de executar o comando
            txtH1.Clear();
            txtH2.Clear();
            txtH3.Clear();
            txtH4.Clear();
            txtH5.Clear();

            try
            {
                conexao.Open();
                // recuperando os valores do banco
                DR = cmd.ExecuteReader();
                if (DR.Read())
                {
                    // Preencher os campos
                    txtH1.Text = DR.GetValue(1).ToString();
                    txtH2.Text = DR.GetValue(2).ToString();
                    txtH3.Text = DR.GetValue(3).ToString();
                    txtH4.Text = DR.GetValue(4).ToString();
                    txtH5.Text = DR.GetValue(5).ToString();
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
