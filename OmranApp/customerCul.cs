using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OmranApp
{
    public partial class customerCul : Form
    {
        public customerCul()
        {
            InitializeComponent();
        }

        public static int x1 = 0;
        public static int x2 = 0;

        Thread th1 = null;
        Thread th2 = null;
        public static int threadTrigger = 0;

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (x1 == 0) 
            {
                inputForCustomer f1 = new inputForCustomer();
                f1.cid = toolStripTextBox1.Text;
                f1.Show();
                
            }
        }

        private void customerCul_FormClosing(object sender, FormClosingEventArgs e)
        {
            customers.x2 = 0;
            th1.Abort();
            th2.Abort();
        }

        private void customerCul_Load(object sender, EventArgs e)
        {
            if (toolStripTextBox2.Text == "مورد")
            {
                toolStripButton1.Enabled = true;
            }
            else
            {
                toolStripButton1.Enabled=false;
            }

            if (toolStripTextBox2.Text =="زبون عادي")
            {
                toolStripButton3.Enabled = true;

            }
            else
            {
                toolStripButton3.Enabled = false;

            }
            sqliteHelper.EnableStyle(dataGridView1);
            threadTrigger = 1;

            th1 = new Thread(start);
            th1.Start();
        }

        private void start()
        {
            while (true)
            {
                th2 = new Thread(refreah);
                th2.Start();
            }
        }

        private void refreah()
        {
            if (threadTrigger == 1)
            {
                threadTrigger = 0;
                string selectString = "select CUCID as 'رقم العملية',CUID as 'رقم الزبون',CUCName as 'اسم الزبون',CUCPrice as 'المبلغ',CUCAddingDate as 'تاريخ الاضافة',CUCAddingBy as 'بواسطة' from customerCul where CUID ='" + toolStripTextBox1.Text+"'";

                sqliteHelper.select(selectString, dataGridView1);

                selectString = "select coalesce(sum(CUCPrice),0) from customerCul where CUID ='" + toolStripTextBox1.Text + "'";
                toolStripTextBox5.Text = (double.Parse(toolStripTextBox4.Text) - double.Parse(sqliteHelper.selectWithReturn(selectString))).ToString();
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (x2 == 0)
            {
                x2 = 1;
                addingNewCustomerAmount f1 = new addingNewCustomerAmount();
                f1.cid = toolStripTextBox1.Text;
                f1.Show();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
