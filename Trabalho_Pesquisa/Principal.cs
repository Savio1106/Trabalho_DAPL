using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Trabalho_Pesquisa
{
    public partial class Principal : Form
    {
        static public string username = Login.username;
        public Principal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.twitch.tv/search?term=" + txtPesquisa.Text);
            if (!File.Exists($"C:\\Users\\Alunos\\Documents\\Saves NewSearch\\{username}.txt"))
            {
                //Arquivo Conta
                StreamWriter sw = new StreamWriter($"C:\\Users\\Alunos\\Documents\\Saves NewSearch\\{username}.txt");
                sw.Close();
            } 

            using (StreamWriter writer1 = new StreamWriter($"C:\\Users\\Alunos\\Documents\\Saves NewSearch\\{username}.txt", append: true))
            {
                writer1.WriteLine();
                writer1.Write(txtPesquisa.Text);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            using (StreamReader sr = new StreamReader($"C:\\Users\\Alunos\\Documents\\Saves NewSearch\\{username}.txt"))
            {
                MessageBox.Show("Histórico de Pesquisa:\r\n" + sr.ReadToEnd());
            }
        }

        private void Principal_Load(object sender, EventArgs e)
        {

        }
    }
}
