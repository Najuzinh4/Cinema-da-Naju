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
    public partial class Form1 : Form
    {
        

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\BancoDados.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                SqlConnection conexao = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=K:\2 INFO\Informática\Lógica de Programação\Cinema da Najú\Cinema.mdf;Integrated Security=True;Connect Timeout=30");
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = "INSERT INTO filme (filme,dt_lancamento,genero,atores_principais,duracao_minutos,produtora,sinopse,valor_producao) values (@filme,@dt_lancamento,@genero,@atores_principais,@duracao_minutos,@produtora,@sinopse,@valor_producao)";
            comando.Parameters.AddWithValue("@filme", textBox2.Text);
            comando.Parameters.AddWithValue("@dt_lancamento", Convert.ToDateTime(maskedTextBox1.Text));
            comando.Parameters.AddWithValue("@genero", textBox4.Text);
            comando.Parameters.AddWithValue("@atores_principais", textBox5.Text);
            comando.Parameters.AddWithValue("@duracao_minutos", textBox6.Text);
            comando.Parameters.AddWithValue("@produtora", textBox7.Text);
            comando.Parameters.AddWithValue("@sinopse", textBox8.Text);
            comando.Parameters.AddWithValue("@valor_producao", textBox9.Text);
            conexao.Open();
            comando.ExecuteNonQuery();
            conexao.Close();
            MessageBox.Show("Registro Inserido com Sucesso!");
            textBox2.Text = maskedTextBox1.Text = textBox4.Text = textBox5.Text = textBox6.Text
                = textBox7.Text = textBox8.Text = textBox9.Text = "";
        }
            catch (SqlException erro)
            {
                MessageBox.Show("Erro ao inserir! -> " + erro.Message);
            }
}

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
