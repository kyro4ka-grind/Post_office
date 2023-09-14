using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursach_TP_Core.Forms.Share
{
    public partial class Registration : Form
    {
        public Registration(Start start)
        {
            InitializeComponent();
            this.start = start;
        }

        private Start start;

        //Ввод информации при регистрации
        private void button1_Click(object sender, EventArgs e)
        {
            string login, email, password;
            Share_ share = new();

            email = textBox1.Text;
            login = textBox2.Text;
            password = textBox3.Text;

            //Проверка
            if (share.Registration(email, login, password))
            {
                MessageBox.Show("Регистрация прошла успешно.");
                start.Show();
            }
            else
            {
                MessageBox.Show("Попробуйте еще раз.");
                start.Show();
            }

            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
