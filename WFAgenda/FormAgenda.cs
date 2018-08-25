using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

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


        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (txtNome.Text != "" && txtEndereco.Text != "" && txtCelular.Text != "" && txtTelefone.Text != "" && txtEmail.Text != "")
            {

                try
                {

                    cmd = new SqlCommand("DELETE Contatos WHERE id=@id", con);

                    con.Open();
                    cmd.Parameters.AddWithValue("@id", ID);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Os dados foram Removidos!");
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
                MessageBox.Show("Selecione  um registro para Deletar!");
            }
        }

        private void FormAgenda_Load(object sender, EventArgs e)
        {

        }

        //private void dgvAgenda_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        ID = Convert.ToInt32(dgvAgenda.Rows[e.RowIndex].Cells[0].Value.ToString());
        //        txtNome.Text = dgvAgenda.Rows[e.RowIndex].Cells[1].Value.ToString();
        //        txtEndereco.Text = dgvAgenda.Rows[e.RowIndex].Cells[2].Value.ToString();
        //        txtCelular.Text = dgvAgenda.Rows[e.RowIndex].Cells[3].Value.ToString();
        //        txtTelefone.Text = dgvAgenda.Rows[e.RowIndex].Cells[4].Value.ToString();
        //        txtEmail.Text = dgvAgenda.Rows[e.RowIndex].Cells[5].Value.ToString();
        //    }
        //    catch
        //    {

        //    }
        //}
    }
}
