using Kursach_TP_Core.Forms.Operator;
using Kursach_TP_Core.Forms.Postman;
using Kursach_TP_Core.Forms.User;
using Microsoft.VisualBasic.Logging;
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
    public partial class Login : Form
    {
        public Login(Start start)
        {
            this.start = start;
            InitializeComponent();
        }

        //Ввод информации при авторизации
        private void button1_Click(object sender, EventArgs e)
        {
            Share_ share = new();
            string login, password;
            int role;

            login = textBox1.Text;
            password = textBox2.Text;

            role = share.Login(login, password);
            //User = 0,Admin = 1,Operator = 2,Postman = 3
            if (role == 0)
            {
                MessageBox.Show("Авторизация прошла успешно.\nДобро пожаловать " + login);
                userActions = new();
                userActions.Show();
            }
            else if (role == 1)
            {
                MessageBox.Show("Авторизация прошла успешно.\nДобро пожаловать администратор " + login);
                
            }
            else if (role == 2)
            {
                MessageBox.Show("Авторизация прошла успешно.\nДобро пожаловать оператор " + login);
                operActions = new();
                operActions.Show();
            }
            else if (role == 3)
            {
                MessageBox.Show("Авторизация прошла успешно.\nДобро пожаловать почтальон " + login);
                postActions = new();
                postActions.Show();
            }
            else
            {
                MessageBox.Show("Попробуйте еще раз.");
                start.Show();
            }

            Close();
        }

        private Start start;
        private UserActions userActions;
        private OperatorActions operActions;
        private PostmanActions postActions;


        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
