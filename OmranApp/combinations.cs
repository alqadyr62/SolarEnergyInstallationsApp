using DevExpress.Data.Mask;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OmranApp
{
    public partial class combinations : Form
    {
        public combinations()
        {
            InitializeComponent();
        }

        string selectString = "";
        Thread th1 = null;
        Thread th2 = null;

        public static int threadTrigger1= 0;
        public static int threadTrigger2 = 0;

        public static int x1 = 0;
        public static int x2 = 0;
        public static int x3 = 0;


        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void combinations_Load(object sender, EventArgs e)
        {
            toolStripTextBox1.Text = DateTime.Now.ToString("yyyy-MM-dd");
            toolStripTextBox2.Text = DateTime.Now.ToString("yyyy-MM-dd");

            sqliteHelper.EnableStyle(dataGridView1);

            
            threadTrigger2 = 1;

            th1 = new Thread(start);
            th1.Start();
        }

        private void start()
        {
            while (true)
            {
                th2 = new Thread(refresh);
                th2.Start();
            }
        }

        private void refresh()
        {

            if (threadTrigger1 == 1)
            {
                threadTrigger1 = 0;
                selectString = "select CID as 'التسلسل',CName as 'مسؤول التركيب',Cforwho as 'الى',CTotal as 'الاجمالي',CAddingDate as 'تاريخ الاضافة',CAddingBy as 'بواسطة' from combinations where CAddingDate between '" + toolStripTextBox1.Text + "' and '" + toolStripTextBox2.Text + "'";
                sqliteHelper.select(selectString, dataGridView1);

            } else if (threadTrigger2 == 1) 
            {
                threadTrigger2 = 0;
                toolStripComboBox1.Items.Clear();
                selectString = "select DISTINCT CName from combinations";
                toolStripComboBox1.Items.Add("All");
                sqliteHelper.select(selectString, toolStripComboBox1);

            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            DateTime d1;
            DateTime d2;

            if (!DateTime.TryParseExact(toolStripTextBox1.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out d1) && !DateTime.TryParseExact(toolStripTextBox1.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out d2))
            {
                MessageBox.Show("التاريخ يجب أن يكون من الشكل yyyy-MM-dd");
                toolStripTextBox1.Text = DateTime.Now.ToString("yyyy-MM-dd");
                toolStripTextBox2.Text = DateTime.Now.ToString("yyyy-MM-dd");

            }
            else if (DateTime.Parse(toolStripTextBox1.Text) > DateTime.Parse(toolStripTextBox2.Text))
            {
                MessageBox.Show("The From Date is must be bigger than the To Date");

            }
            else
            {
                selectString = "select CID as 'التسلسل',CName as 'مسؤول التركيب',Cforwho as 'الى',CTotal as 'الاجمالي',CAddingDate as 'تاريخ الاضافة',CAddingBy as 'بواسطة' from combinations where CAddingDate between '" + toolStripTextBox1.Text + "' and '" + toolStripTextBox2.Text + "'";
                sqliteHelper.select(selectString, dataGridView1);
            }
        }

        private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                toolStripButton1.PerformClick();

            }
        }

        private void toolStripTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                toolStripButton1.PerformClick();

            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (x1 == 0)
            {
                x1 = 1;
                addingNewCombinations f1 = new addingNewCombinations();
                f1.Show();
            }
        }

       
        private void combinations_FormClosing(object sender, FormClosingEventArgs e)
        {
            Master.x5 = 0;
            th1.Abort();
            th2.Abort();

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (x3 == 0)
            {
                x3 = 1;
                addingNewInstallaionOfficer f1 = new addingNewInstallaionOfficer();
                f1.Show();
            }
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(toolStripComboBox1.Text == "All")
            {
                selectString = "select CID as 'التسلسل',CName as 'مسؤول التركيب',Cforwho as 'الى',CTotal as 'الاجمالي',CAddingDate as 'تاريخ الاضافة',CAddingBy as 'بواسطة' from combinations ";
                sqliteHelper.select(selectString, dataGridView1);

            }
            else
            {
                selectString = "select CID as 'التسلسل',CName as 'مسؤول التركيب',Cforwho as 'الى',CTotal as 'الاجمالي',CAddingDate as 'تاريخ الاضافة',CAddingBy as 'بواسطة' from combinations where CName ='" + toolStripComboBox1.Text + "'";
                sqliteHelper.select(selectString, dataGridView1);

            }
        }

        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (x2 == 0)
                {
                    x2 = 0;
                    combinationCul f1 = new combinationCul();
                    f1.toolStripTextBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    f1.toolStripTextBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    f1.toolStripTextBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    f1.toolStripTextBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    f1.Show();

                }
            } catch { } 
        }
    }
}
