﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trabalho_Pesquisa
{
    public partial class CriarConta : Form
    {
        Thread nt;
        static public string pcUser = Environment.UserName;
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

            //A senha que o usuário digitou é convertida em um hash
            byte[] bytes = Encoding.UTF8.GetBytes(senha);
            byte[] hash = sha512.ComputeHash(bytes);
            string senhaCript = Convert.ToBase64String(hash);

            if (!File.Exists($"C:\\Users\\{pcUser}\\Documents\\Saves NewSearch\\{username}Conta.txt")) //Verificar que essa conta já não tá criada
            {
                //Ele cria um arquivo txt e salva a senha (criptografada)
                StreamWriter sw = new StreamWriter($"C:\\Users\\{pcUser}\\Documents\\Saves NewSearch\\{username}Conta.txt");
                sw.WriteLine(senhaCript);
                sw.Close();
                MessageBox.Show("Nova Conta Criada");
            } else
            {
                MessageBox.Show("Conta já existente");
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnjanelaSignUp_Click(object sender, EventArgs e)
        {
            this.Close();
            nt = new Thread(Login);
            nt.SetApartmentState(ApartmentState.STA);
            nt.Start();
        }
        private void Login()
        {
            Application.Run(new Login());
        }

        private void CriarConta_Load(object sender, EventArgs e)
        {

        }
    }
}
