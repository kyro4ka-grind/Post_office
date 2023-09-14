using Kursach_TP_Core.Forms.Share;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursach_TP_Core.Forms
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }

        //Авторизация
        private void button1_Click(object sender, EventArgs e)
        {
            Login login = new(this);
            login.Show();
            Hide();
        }

        //Регистрация
        private void button2_Click(object sender, EventArgs e)
        {
            Registration reg = new(this);
            reg.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
