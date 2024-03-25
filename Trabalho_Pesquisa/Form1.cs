using System;
using System.IO;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trabalho_Pesquisa
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            SHA512 sha512 = SHA512.Create();

            string username = txtUsername.Text;

            string senha = txtSenha.Text;

            //Variável Senha criptografada
            byte[] bytes = Encoding.UTF8.GetBytes(senha);
            byte[] hash = sha512.ComputeHash(bytes);
            string senhaCript = Convert.ToBase64String(hash);

            MessageBox.Show($"Username {username} \r\nSenha criptografada {senhaCript}");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
