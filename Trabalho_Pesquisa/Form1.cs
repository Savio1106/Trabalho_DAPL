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
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Trabalho_Pesquisa
{
    public partial class Login : Form
    {
        Thread nt;
        static public string username;
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            username = txtUsername.Text;
            string senha = txtSenha.Text;

            SHA512 sha512 = SHA512.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(senha);
            byte[] hash = sha512.ComputeHash(bytes);
            string senhaCript = Convert.ToBase64String(hash);

            string senhaArmazenada = LerSenhaCriptografada($"C:\\Users\\Alunos\\Documents\\Saves NewSearch\\{username}Conta.txt");

            if (File.Exists($"C:\\Users\\Alunos\\Documents\\Saves NewSearch\\{username}Conta.txt"))
            {
                    if (string.Equals(senhaCript, senhaArmazenada))
                    {
                        MessageBox.Show($"Bem vindo, {username}");
                        this.Close();
                        nt = new Thread(Principal);
                        nt.SetApartmentState(ApartmentState.STA);
                        nt.Start();
                }
            } 
            
            MessageBox.Show("Nome de usuário ou senha incorretos");
            

            }
            private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnjanelaCriarConta_Click(object sender, EventArgs e)
        {
            this.Close();
            nt = new Thread(CriarConta);
            nt.SetApartmentState(ApartmentState.STA);
            nt.Start();
        }

        private void CriarConta()
        {
            Application.Run(new CriarConta());
        }
        private void Principal()
        {
            Application.Run(new Principal());
        }
        static string LerSenhaCriptografada(string nomeArquivo)
        {
            try
            {
                // Ler a senha criptografada do arquivo
                using (StreamReader sr = new StreamReader(nomeArquivo))
                {
                    return sr.ReadLine();
                }
            }
            catch (Exception ex)
            {
              //  MessageBox.Show("Nome de usuário ou senha incorretos");
                return null;
            }
        }
    }
}
