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

namespace Kursach_TP_Core.Forms.Operator
{
    public partial class OperatorActions : Form
    {
        public OperatorActions()
        {
            InitializeComponent();
        }

        //Exit
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Проверить информацию о посылке
        private void button1_Click(object sender, EventArgs e)
        {
            CheckPackage chkPack = new CheckPackage(this);

            chkPack.Show();
            Hide();
        }

        //Проверить статус посылки
        private void button2_Click(object sender, EventArgs e)
        {
            CheckStatusPackage chkStat = new CheckStatusPackage(this);

            chkStat.Show();
            Hide();
        }

        //Создать новое отправление
        private void button4_Click(object sender, EventArgs e)
        {
            NewPackage newPack = new NewPackage(this);
            newPack.Show();
            Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PackageIssued issuedPack = new PackageIssued(this);
            issuedPack.Show();
            Hide();
        }
    }
}