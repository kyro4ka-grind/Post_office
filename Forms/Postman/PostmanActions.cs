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

namespace Kursach_TP_Core.Forms.Postman
{
    public partial class PostmanActions : Form
    {
        public PostmanActions()
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

        //Изменить статус посылки на принято к доставке
        private void button2_Click(object sender, EventArgs e)
        {
            PackageInDeliver pckgInDeliver = new(this);
            pckgInDeliver.Show();
            Hide();
        }

        //Изменить статус посылки на доставлено
        private void button4_Click(object sender, EventArgs e)
        {
            PackageDelivered pckgDelivered = new(this);
            pckgDelivered.Show();
            Hide();
        }

        //Exit
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
