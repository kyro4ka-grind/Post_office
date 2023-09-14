using Kursach_TP_Core.Forms.User;
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
    public partial class CheckDepartment : Form
    {
        public CheckDepartment(UserActions actions)
        {
            this.actions= actions;
            InitializeComponent();
        }

        //Выход
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Ввод номера отделения
        private void button1_Click(object sender, EventArgs e)
        {
            User_ user = new();
            int depNum;

            if (int.TryParse(textBox3.Text, out depNum))
            {
                int result = user.CheckDepartment(depNum);
                if (result == 0)
                    MessageBox.Show("Введен неверный индекс отделения.");
                else if (result == 1)
                    MessageBox.Show("Отделение открыто.");
                else
                    MessageBox.Show("Отделение закрыто.");
            }
            else
                MessageBox.Show("Введен неверный индекс отделения.");
        }

        //Назад к прошлой форме
        private void button2_Click(object sender, EventArgs e)
        {
            actions.Show();
            Close();
        }

        private UserActions actions;
    }
}
