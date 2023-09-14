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
    public partial class PackageInDeliver : Form
    {
        public PackageInDeliver(PostmanActions actions)
        {
            InitializeComponent();
            actionsP = actions;
        }

        //Enter
        private void button1_Click(object sender, EventArgs e)
        {
            Postman_ postman = new();
            
            if (postman.PackageInDelivered(textBox3.Text))
                MessageBox.Show("Статус посылки изменен на 'Принято к доставке.'");
            else
                MessageBox.Show("Введен неверный номер посылки.");
        }

        //Back
        private void button2_Click(object sender, EventArgs e)
        {
            actionsP.Show();
            Close();
        }

        //Exit
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private PostmanActions actionsP;
    }
}