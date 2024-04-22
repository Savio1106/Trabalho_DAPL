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
        static public string pcUser = Environment.UserName;
        static public short selecao = 10;
        public Principal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!File.Exists($"C:\\Users\\{pcUser}\\Documents\\Saves NewSearch\\{username}.txt")) //Cria um arquivo para salvar o histórico do usuário (se ele não já existe)
            {
                StreamWriter sw = new StreamWriter($"C:\\Users\\{pcUser}\\Documents\\Saves NewSearch\\{username}.txt");
                sw.Close();
            }
            if (selecao != 10)
            {
                using (StreamWriter writer1 = new StreamWriter($"C:\\Users\\{pcUser}\\Documents\\Saves NewSearch\\{username}.txt", append: true))
                {   //Adiciona o que o usuário pesquisou no histórico dele
                    writer1.WriteLine();
                    writer1.Write(txtPesquisa.Text);
                }
            }
            switch (selecao) {
                case 0:
                    //Se o usuário selecionou "streamers", o nome do jogo é pesquisado no twitch
                    Process.Start("https://www.twitch.tv/search?term=" + txtPesquisa.Text);
                    break;
                case 1:
                    //Se ele selecionou "vídeos", o jogo é pesquisado no youtube
                    Process.Start("https://www.youtube.com/results?search_query=" + txtPesquisa.Text);
                    break;
                case 2:
                    //Se ele selecionou "steam", pesquisa o jogo no steam
                    Process.Start("https://store.steampowered.com/search/?term=" + txtPesquisa.Text);
                    break;
                default:
                    //Se ele não selecionou nada, é jogado um erro
                    MessageBox.Show("Por favor, selecione o que você quer pesquisar");
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //
            using (StreamReader sr = new StreamReader($"C:\\Users\\{pcUser}\\Documents\\Saves NewSearch\\{username}.txt"))
            {
                //O botão histórico faz com que o arquivo do histórico do usuário seja lido
                MessageBox.Show("Histórico de Pesquisa:\r\n" + sr.ReadToEnd());
            }
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            lblUsername.Text = username;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //Leitura da seleção streamers/vídeos/steam
            if (comboBox1.SelectedIndex == 0)
            {
                selecao = 0;
            } else if (comboBox1.SelectedIndex == 1)
            {
                selecao = 1;
            } else if (comboBox1.SelectedIndex == 2) 
            { 
                selecao = 2;
            } 
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblUsername_Click(object sender, EventArgs e)
        {
 
        }
    }
}
