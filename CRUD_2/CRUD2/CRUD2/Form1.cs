using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Importar o SQL Client
using System.Data.SqlClient;

namespace CRUD2
{
    /*SQL CLIENT
     *      > Sql Connection
     *      > Sql Command
     *      > Sql Data Reader
     */
    public partial class Form1 : Form
    {
        // Classe principal (construção do form)
        // Criar uma variável para armazenar a string de conexão
        // Mudar para a barra (\) para 2 barras (\\)
        static string strCn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\DBCRUD2.mdf;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
