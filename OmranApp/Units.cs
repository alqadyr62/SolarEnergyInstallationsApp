using Guna.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OmranApp
{
    public partial class Units : Form
    {
        public Units()
        {
            InitializeComponent();
        }

        string selectString = "";
        public static int x1 = 0;

        Thread th1 = null;
        Thread th2 = null;

        public static int threadTrigger1 = 0;
        public static int threadTrigger2 = 0;

        string unitId = "";

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Units_FormClosing(object sender, FormClosingEventArgs e)
        {
            Master.x3 = 0;
            th1.Abort();
            th2.Abort();

        }

        private void Units_Load(object sender, EventArgs e)
        {
            toolStripTextBox1.Text = DateTime.Now.ToString("yyyy-MM-dd");
            toolStripTextBox2.Text = DateTime.Now.ToString("yyyy-MM-dd");

            sqliteHelper.EnableStyle2(dataGridView1);

        
            threadTrigger1 = 1;

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
                toolStripComboBox1.Items.Clear();
                toolStripComboBox1.Items.Add("All");
                selectString = "select UnName from units";
                sqliteHelper.select(selectString, toolStripComboBox1);
                Thread.Sleep(200);
            }

            if (threadTrigger2 == 1)
            {
                threadTrigger2 = 0;
                selectString = "select UnID as 'التسلسل',UnName as 'اسم الوحدة',UnNote as 'ملاحظة',UnAddingDate as 'تاريخ الاضافة' from units";
                sqliteHelper.select(selectString, dataGridView1);
                Thread.Sleep(200);

            }

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (x1 == 0)
            {
                x1 = 1;
                addingNewUnit f1 = new addingNewUnit();
                f1.Show();
            }
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripComboBox1.Text == "All")
            {
                selectString = "select UnID as 'التسلسل',UnName as 'اسم الوحدة',UnNote as 'ملاحظة',UnAddingDate as 'تاريخ الاضافة' from units ";
                sqliteHelper.select(selectString, dataGridView1);
            }
            else
            {
                selectString = "select UnID as 'التسلسل',UnName as 'اسم الوحدة',UnNote as 'ملاحظة',UnAddingDate as 'تاريخ الاضافة' from units where UnName ='" + toolStripComboBox1.Text + "'";
                sqliteHelper.select(selectString, dataGridView1);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            DateTime d1;
            DateTime d2;

            if (!DateTime.TryParseExact(toolStripTextBox1.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out d1)&& !DateTime.TryParseExact(toolStripTextBox1.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out d2))
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
                selectString = "select UnID as 'التسلسل',UnName as 'اسم الوحدة',UnNote as 'ملاحظة',UnAddingDate as 'تاريخ الاضافة' from units where UnAddingDate between '" + toolStripComboBox1.Text + "' and '"+toolStripTextBox2.Text+"'";
                sqliteHelper.select(selectString, dataGridView1);

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (MessageBox.Show("هل تريد  الحفظ بالتأكيد ؟", "مدير الوحدات", MessageBoxButtons.YesNo) ==
                  System.Windows.Forms.DialogResult.Yes)
                {
                    string updateString = "update Units set UnName = '" + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + "' where UnID =" + unitId ;
                    sqliteHelper.upDate(updateString, 1);
                    string InsString = "insert into inspection (inID,inText,inAddingDate,inAddingTime,inAddingBy) values ((select coalesce(max(inID),0)+1 from inspection),'" + " قام " + Master.uName + " " + "بتعديل بيانات  وحدة ','" + DateTime.Today.ToString("yyyy-MM-dd") + "','" + DateTime.Now.ToString("hh:mm tt") + "','النظام')";
                    sqliteHelper.insert(InsString, 0);

                    Units.threadTrigger1 = 1;
                }
            }
            catch
            {

            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                unitId = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (MessageBox.Show("هل تريد  حذف هذه الوحدة بالتأكيد ؟", "مدير الوحدات", MessageBoxButtons.YesNo) ==
                 System.Windows.Forms.DialogResult.Yes)
                {
                    string deleteString = "";
                    string resetString = "";

                    deleteString = "delete from Units where UnID ='" + unitId + "'";
                    sqliteHelper.delete(deleteString, 1);

                    resetString = "DBCC CHECKIDENT ('Units', reseed, (select max(UnID) from Units))";
                    sqliteHelper.resetPK(resetString, 0);
                    string InsString = "insert into inspection (inID,inText,inAddingDate,inAddingTime,inAddingBy) values " +
                          "((select coalesce(max(inID),0)+1 from inspection),'" + " قام " + Master.uName + " " + "بحذف وحدة ','" + DateTime.Today.ToString("yyyy/MM/dd") + "','" + DateTime.Now.ToString("hh:mm tt") + "','النظام')";
                    sqliteHelper.insert(InsString, 0);
                    Units.threadTrigger1 = 1;
                    Units.threadTrigger2 = 1;
                }
            }
            catch
            {

            }
        }

        private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                toolStripButton3.PerformClick();

            }
        }

        private void toolStripTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                toolStripButton3.PerformClick();

            }
        }
    }
}

