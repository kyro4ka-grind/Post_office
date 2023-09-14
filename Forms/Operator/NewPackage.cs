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
    public partial class NewPackage : Form
    {
        public NewPackage(OperatorActions actionsO)
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

        //Enter
        private void button1_Click(object sender, EventArgs e)
        {
            Operator_ oper = new();
            int indexOut, indexIn, pasportNum;
            long phoneNum;

            if (int.TryParse(textBox3.Text, out indexOut) && int.TryParse(textBox6.Text, out indexIn) &&
                int.TryParse(textBox9.Text, out pasportNum) && long.TryParse(textBox10.Text, out phoneNum))
            {
                oper.NewPackage(textBox1.Text, textBox2.Text, indexOut, textBox4.Text, textBox5.Text, indexIn,
                textBox7.Text, textBox8.Text, pasportNum, phoneNum, textBox11.Text, textBox12.Text);
                MessageBox.Show("Отправление успешно создано.");
            }
            else
                MessageBox.Show("Введена неверная информация.");
        }
 
        private OperatorActions actionsO;
    }
}