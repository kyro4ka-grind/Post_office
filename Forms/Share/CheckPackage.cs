using Kursach_TP_Core.Forms.Operator;
using Kursach_TP_Core.Forms.Postman;
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
    public partial class CheckPackage : Form
    {
        public CheckPackage(UserActions actions)
        {
            InitializeComponent();
            this.actionsU = actions;
        }

        public CheckPackage(OperatorActions actions)
        {
            InitializeComponent();
            this.actionsO = actions;
        }

        public CheckPackage(PostmanActions actions)
        {
            InitializeComponent();
            this.actionsP = actions;
        }

        //Ввод номера посылки
        private void button1_Click(object sender, EventArgs e)
        {
            Share_ share = new();
            string packNum = textBox3.Text;
            string result = share.CheckPackage(packNum);

            if (result == "")
                MessageBox.Show("Введен неверный номер посылки.");
            else
                MessageBox.Show(result);
        }

        //Go back form
        private void button2_Click(object sender, EventArgs e)
        {
            if (actionsU != null)
                actionsU.Show();
            else if (actionsO != null)
                actionsO.Show();
            else
                actionsP.Show();
            Close();
        }

        //Exit
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private UserActions actionsU;
        private OperatorActions actionsO;
        private PostmanActions actionsP;
    }
}
