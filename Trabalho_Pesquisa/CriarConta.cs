using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trabalho_Pesquisa
{
    public partial class CriarConta : Form
    {
        public CriarConta()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void avancar_Click(object sender, EventArgs e)
        {
            
        }

        private void avancar_Click_1(object sender, EventArgs e)
        {
            SHA512 sha512 = SHA512.Create();

            string username = txtUsername.Text;

            string senha = txtSenha.Text;

            //Variável Senha criptografada
            byte[] bytes = Encoding.UTF8.GetBytes(senha);
            byte[] hash = sha512.ComputeHash(bytes);
            string senhaCript = Convert.ToBase64String(hash);

            //Arquivo Conta
            StreamWriter sw = new StreamWriter($"C:\\Users\\Alunos\\Documents\\Saves NewSearch\\{username}Conta.txt");
            sw.WriteLine(senhaCript);
            sw.Close();
            MessageBox.Show("Nova Conta Criada");
        }
    }
}
