using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursach_TP_Core.Forms.Operator
{
    public partial class PackageIssued : Form
    {
        public PackageIssued(OperatorActions actionsO)
        {
            InitializeComponent();
            this.actionsO = actionsO;
        }

        private OperatorActions actionsO;

        //Exit
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Enter
        private void button1_Click(object sender, EventArgs e)
        {
            Operator_ oper = new();

            if (oper.PackageIssued(textBox1.Text))
                MessageBox.Show("Статус посылки изменен на 'Выдано'");
            else
                MessageBox.Show("Введен неверный номер посылки.");
        }

        //Back
        private void button2_Click(object sender, EventArgs e)
        {
            actionsO.Show();
            Close();
        }
    }
}