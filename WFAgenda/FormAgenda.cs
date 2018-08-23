using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace WFAgenda
{
    public partial class FormAgenda : Form
    {

        SqlConnection con = new SqlConnection("Data Source=ADDServidor; Initial Catalog=db_Contatos; Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adapt;
        int ID = 0;

        public FormAgenda()
        {
            InitializeComponent();
            ListarTodos();
        }

        private void ListarTodos()
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("select * from Contatos", con);
                adapt.Fill(dt);
                dgvAgenda.DataSource = dt;

            }
            catch
            {
                throw;

            }
            finally
            {
                con.Close();
            }
        }


        private void FormAgenda_Load(object sender, EventArgs e)
        {

        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            txtNome.Text = "";
            txtEndereco.Text = "";
            txtCelular.Text = "";
            txtTelefone.Text = "";
            txtEmail.Text = "";
            txtNome.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text != "" && txtEndereco.Text != "" && txtCelular.Text != "" && txtTelefone.Text != "" && txtEmail.Text != "")
            {
                try
                {
                    cmd = new SqlCommand("insert into Contatos(nome,endereco,celular,telefone,email)" +
                    "values ('@nome','@endereco','@celular','@telefone','@email')", con);

                    con.Open();

                    cmd.Parameters.AddWithValue("@nome", txtNome.Text.ToUpper());
                    cmd.Parameters.AddWithValue("");

                }
            }

        }
    }
}
