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

namespace WindowsFormsApp4
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            {
                if (MessageBox.Show("Deseja realmente apagar?", "Exluir", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Excluirdados();
                }

            }
            private void Excluirdados()
            {
                SqlConnection conexao = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=K:\2 INFO\Informática\Lógica de Programação\Cinema da Najú\Cinema.mdf;Integrated Security=True;Connect Timeout=30");

                SqlCommand cmdExcluir = new SqlCommand();
                cmdExcluir.Connection = conexao;
                cmdExcluir.Parameters.AddWithValue("@cod_filme", textBox8.Text);
                cmdExcluir.CommandText = "delete from filme where cod_filme=@cod_filme";

                try
                {
                    conexao.Open();
                    cmdExcluir.ExecuteNonQuery();
                    MessageBox.Show("Dados excluídos!");
                    button2.Hide();
                    button3.Hide();
                    button1.Show();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    button2.Hide();
                    button3.Hide();
                    button1.Show();
                }
                finally
                {
                    conexao.Close();
                    textBox2.Text = maskedTextBox1.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = textBox8.Text = textBox9.Text = textBox1.Text = "";
                    textBox1.Focus();
                    button2.Hide();
                    button3.Hide();
                    button1.Show();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)

        { string criterio = textBox1.Text.ToString();
            string sqlcomando = "";

            SqlDataReader reg = null;
            if (criterio == "")
            {
                MessageBox.Show("Nenhum Registro incluido!!");
                return;
            }
            else
                sqlcomando = "select * from cinema where filme like'" + criterio + "%'";

            try
            {
                SqlConnection conexao = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=K:\2 INFO\Informática\Lógica de Programação\Cinema da Najú\Cinema.mdf;Integrated Security=True;Connect Timeout=30");

                SqlCommand comando = new SqlCommand();
                comando.Connection = conexao;
                comando.CommandText = sqlcomando;
                conexao.Open();
                reg = comando.ExecuteReader();
                button2.Show();
                button3.Show();

                if (reg.Read())
                {
                    textBox1.Text = reg["cod_filme"].ToString();
                    textBox2.Text = reg["filme"].ToString();
                    maskedTextBox1.Text = reg["dt_lancamento"].ToString();
                    textBox4.Text = reg["genero"].ToString();
                    textBox5.Text = reg["atores_principais"].ToString();
                    textBox6.Text = reg["duracao_minutos"].ToString();
                    textBox7.Text = reg["produtora"].ToString();
                    textBox8.Text = reg["sinopse"].ToString();
                    textBox9.Text = reg["valor_producao"].ToString();
                }
                else
                {
                    MessageBox.Show("Esse registro não existee!");
                    textBox1.Text = "";
                    textBox1.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Deu algum errooo!!" + ex);
                textBox1.Text = "";
                textBox1.Focus();
                button1.Show();
            }
        }
    }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conexao = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=K:\2 INFO\Informática\Lógica de Programação\Cinema da Najú\Cinema.mdf;Integrated Security=True;Connect Timeout=30");
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexao;

                comando.CommandText = "update fime set filme=@filme, dt_lancamento=@dt_lancamento, genero=@genero, atores_principais=@atores_principais, duracao_minutos=@duracao_minutos, produtora=@produtora, sinopse=@sinopse, valor_producao=@valor_producao where cod_filme=@cod_filme";

                comando.Parameters.AddWithValue("@cod_filme", int.Parse(textBox1.Text));
                comando.Parameters.AddWithValue("@filme", textBox2.Text);
                comando.Parameters.AddWithValue("@dt_lancamento", Convert.ToDateTime(maskedTextBox1.Text));
                comando.Parameters.AddWithValue("@genero", textBox4.Text);
                comando.Parameters.AddWithValue("@atores_principais", textBox5.Text);
                comando.Parameters.AddWithValue("@duracao_minutos", int.Parse(textBox6.Text));
                comando.Parameters.AddWithValue("@produtora", textBox7.Text);
                comando.Parameters.AddWithValue("@sinopse", textBox8.Text);
                comando.Parameters.AddWithValue("@valor_producao", decimal.Parse(textBox9.Text));

                conexao.Open();
                comando.ExecuteNonQuery();
                conexao.Close();

                MessageBox.Show("Registro ALTERADOO!");

                textBox2.Text = maskedTextBox1.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = textBox8.Text = textBox9.Text = textBox1.Text = "";
                textBox2.Focus();
                button2.Hide();
                button3.Hide();
                button1.Show();



            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao ALTERARRR!" + erro.Message);
                textBox2.Text = "";
                textBox2.Focus();

            }
        }
    }

