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
    public partial class CheckStatusPackage : Form
    {
        public CheckStatusPackage(OperatorActions actionsO)
        {
            InitializeComponent();
            this.actionsO = actionsO;
        }

        //Exit
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Back
        private void button2_Click(object sender, EventArgs e)
        {
            actionsO.Show();
            Close();
        }

        //Check status
        private void button1_Click(object sender, EventArgs e)
        {
            Operator_ oper = new();
            int status = oper.CheckPackageStatus(textBox3.Text);

            switch (status)
            {
                case 0:
                    MessageBox.Show("Ваша посылка принята в отделение.");
                    break;
                case 1:
                    MessageBox.Show("Ваша посылка в доставке.");
                    break;
                case 2:
                    MessageBox.Show("Ваша посылка доставлена.");
                    break;
                case 3:
                    MessageBox.Show("Ваша посылка выдана.");
                    break;
                default:
                    MessageBox.Show("Введен неверный номер посылки.");
                    break;
            }
        }

        private OperatorActions actionsO;
    }
}
