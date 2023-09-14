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

namespace Kursach_TP_Core.Forms.User
{
    public partial class UserActions : Form
    {
        public UserActions()
        {
            InitializeComponent();
        }

        //Проверить информацию о посылке
        private void button1_Click(object sender, EventArgs e)
        {
            CheckPackage chkPack = new CheckPackage(this);

            chkPack.Show();
            Hide();
        }

        //Проверить статус отделения
        private void button2_Click(object sender, EventArgs e)
        {
            CheckDepartment chkDep = new(this);

            chkDep.Show();
            Hide();
        }

        //Exit
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
