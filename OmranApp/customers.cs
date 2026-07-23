using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OmranApp
{
    public partial class customers : Form
    {
        public customers()
        {
            InitializeComponent();
        }


        public static int x1 = 0;
        public static int x2 = 0;


        string selectString = "";
        Thread th1 = null;
        Thread th2 = null;

        public static int threadTrigger1 = 0;
        public static int threadTrigger2 = 0;





        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void customers_Load(object sender, EventArgs e)
        {
            toolStripTextBox1.Text = DateTime.Now.ToString("yyyy-MM-dd");
            toolStripTextBox2.Text = DateTime.Now.ToString("yyyy-MM-dd");
            sqliteHelper.EnableStyle(dataGridView1);

            threadTrigger1 = 1;
            th1 = new Thread(start);
            th1.Start();
        }

        private void start()
        {
            while (true)
            {
                th2 = new Thread(refreash);
                th2.Start();
            }
        }

        private void refreash()
        {
            if (threadTrigger1 == 1)
            {
                threadTrigger1 = 0;
                toolStripComboBox1.Items.Clear();
                toolStripComboBox1.Items.Add("All");
                string selectString = "select DISTINCT CUName from customers";
                sqliteHelper.select(selectString,toolStripComboBox1);
                
            }

            if (threadTrigger2 == 1)
            {
                threadTrigger2 = 0;
                string selectString = "select CUID  as 'رقم الزبون',CUName as 'اسم الزبون',CUPhoneNumber as 'الهاتف',CUAddress as 'العنوان',CUType as 'نوع الزبون',CUTotal as 'المبلغ الكلي',CUAddingDate as 'تاريخ الاضافة',CUAddingBy as 'بواصطة' from customers where CUAddingBy='"+Master.uName+"'";
                sqliteHelper.select(selectString, dataGridView1);

            }
        }



        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            selectString = "select CuID as 'رقم',CUName as 'اسم الزبون',CUPhoneNumber as 'تلفون',CUAddress as 'العنوان',CUType as 'نوع الزبون',CUTotal as 'المبلغ الكلي',CUAddingDate as 'تاريخ الاضافة' , CUAddingBy as 'بواسطة' from  customers where CUAddingDate between '" + toolStripTextBox1.Text +"' AND '"+toolStripTextBox2.Text + "' AND CUAddingBy= '"+Master.uName+"'";
            sqliteHelper.select(selectString, dataGridView1);
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectString = "";
            if (toolStripComboBox1.Text == "All")
            {
                 selectString = "select CUID  as 'رقم الزبون',CUName as 'اسم الزبون',CUPhoneNumber as 'الهاتف',CUAddress as 'العنوان',CUType as 'نوع الزبون',CUTotal as 'المبلغ الكلي',CUAddingDate as 'تاريخ الاضافة',CUAddingBy as 'بواصطة' from customers where CUAddingBy ='"+Master.uName+"'";
                sqliteHelper.select(selectString, dataGridView1);
            }
            else
            {
                selectString = "select CUID  as 'رقم الزبون',CUName as 'اسم الزبون',CUPhoneNumber as 'الهاتف',CUAddress as 'العنوان',CUType as 'نوع الزبون',CUTotal as 'المبلغ الكلي',CUAddingDate as 'تاريخ الاضافة',CUAddingBy as 'بواصطة' from customers where CUName ='" + toolStripComboBox1.Text+ "' AND CUAddingBy ='"+Master.uName+"'";
                sqliteHelper.select(selectString, dataGridView1);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (x1 == 0)
            {
                x1 = 1;
                addingNewCustomer f1 = new addingNewCustomer();
                f1.Show();
            }
        }

        private void customers_FormClosing(object sender, FormClosingEventArgs e)
        {
            Master.x6 = 0;
            th1.Abort();
            th2.Abort();

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(x2 == 0)
            {
                customerCul f1 = new customerCul();
                f1.toolStripTextBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                f1.toolStripTextBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                f1.toolStripTextBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                f1.toolStripTextBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                f1.Show();
            }
        }
    }
}
