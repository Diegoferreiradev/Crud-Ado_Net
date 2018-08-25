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

        SqlConnection con = new SqlConnection("Data Source=AddServidor; Initial Catalog=db_Contatos; Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adapt;
        int ID = 2;

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
                adapt = new SqlDataAdapter("SELECT * FROM Contatos", con);
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
                    cmd = new SqlCommand("INSERT INTO Contatos(nome,endereco,celular,telefone,email)" +
                    "VALUES (@nome, @endereco, @celular, @telefone, @email)", con);

                    con.Open();

                    cmd.Parameters.AddWithValue("@nome", txtNome.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@endereco", txtEndereco.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@celular", txtCelular.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@telefone", txtTelefone.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text.ToLower());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cadastro realizado com Sucesso!");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);

                }
                finally
                {
                    con.Close();
                    ListarTodos();
                    LimparDados();
                    
                }
            }

            else
            {
                MessageBox.Show("Informe todos os dados requeridos!");
            }

        }


        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text != "" && txtEndereco.Text != "" && txtCelular.Text != "" && txtTelefone.Text != "" && txtEmail.Text != "")
            {
                try
                {
                    cmd = new SqlCommand("UPDATE Contatos SET nome=@nome, endereco=@endereco, celular=@celular, telefone=@telefone, email=@email WHERE id=@id" , con);
                    con.Open();

                    cmd.Parameters.AddWithValue("@id", ID);
                    cmd.Parameters.AddWithValue("@nome", txtNome.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@endereco", txtEndereco.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@celular", txtCelular.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@telefone", txtTelefone.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text.ToLower());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Os dados foram atualizados com Sucesso!");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }
                finally
                {
                    con.Close();
                    ListarTodos();
                    LimparDados();
                }
            }
            else
            {
                MessageBox.Show("Informe todos os dados Requeridos!");
            }
        }


        private void LimparDados()
        {
            txtNome.Text = "";
            txtEndereco.Text = "";
            txtCelular.Text = "";
            txtTelefone.Text = "";
            txtEmail.Text = "";
        }

        private void FormAgenda_Load(object sender, EventArgs e)
        {

        }


    }
}
