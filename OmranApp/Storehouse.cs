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
    public partial class Storehouse : Form
    {
        public Storehouse()
        {
            InitializeComponent();
        }

        string selectString = "";

        Thread th1 = null;
        Thread th2 = null;

        public static int x1 = 0 ;
        

        public static int threadTrigger1 = 0;
        public static int threadTrigger2 = 0;

        string id = "";


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Storehouse_Load(object sender, EventArgs e)
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
                selectString = "select IName from Items";
                sqliteHelper.select(selectString,toolStripComboBox1);
                Thread.Sleep(200);


            }
            if (threadTrigger2 == 1)
            {
                threadTrigger2 = 0;
                selectString = "select IID as 'التسلسل', IName as 'اسم المادة',IUName as 'وحدة المادة', IQuantity as 'العدد', IPrice as 'السعر', IQuantity*IPrice as 'السعر الكلي', INote as 'الملاحظات',IAddingBy as 'بواسطة',IAddingDate as 'تاريخ الاضافة' from Items";
                sqliteHelper.select(selectString, dataGridView1);
                Thread.Sleep(200);

            }
        }

        private void Storehouse_FormClosing(object sender, FormClosingEventArgs e)
        {
            Master.x2 = 0;
            th1.Abort();
            th2.Abort();

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
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
                MessageBox.Show("تاريخ بداية البحث يجب ان يكون أكبر من تاريخ نهاية البحث");

            }
            else
            {
                selectString = "select IID as 'التسلسل', IName as 'اسم المادة',IUName as 'وحدة المادة', IQuantity as 'العدد', IPrice as 'السعر', IQuantity*IPrice as 'السعر الكلي', INote as 'الملاحظات',IAddingBy as 'بواسطة',IAddingDate as 'تاريخ الاضافة' from Items  where IAddingDate between '" + toolStripTextBox1.Text+"' and '"+toolStripTextBox2.Text +"'";
                sqliteHelper.select(selectString, dataGridView1);

            }
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripComboBox1.Text == "All")
            {
                selectString = "select IID as 'التسلسل', IName as 'اسم المادة',IUName as 'وحدة المادة', IQuantity as 'العدد', IPrice as 'السعر', IQuantity*IPrice as 'السعر الكلي', INote as 'الملاحظات',IAddingBy as 'بواسطة',IAddingDate as 'تاريخ الاضافة' from Items";
                sqliteHelper.select(selectString, dataGridView1);

            }
            else
            {
                selectString = "select IID as 'التسلسل', IName as 'اسم المادة',IUName as 'وحدة المادة', IQuantity as 'العدد', IPrice as 'السعر', IQuantity*IPrice as 'السعر الكلي', INote as 'الملاحظات',IAddingBy as 'بواسطة',IAddingDate as 'تاريخ الاضافة' from Items where IName='" + toolStripComboBox1.Text+"'";
                sqliteHelper.select(selectString, dataGridView1);

            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (x1 == 0)
            {
                x1 = 1;
                addingNewItem f1 = new addingNewItem();
                f1.Show();
            }
        }

      

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                string quantity = "select IQuantity from Items where IID ='" + id + "'";
                if (int.Parse(sqliteHelper.selectWithReturn(quantity)) == 0)
                {
                    if (MessageBox.Show("هل تريد  حذف هذه الوحدة بالتأكيد ؟", "مدير الوحدات", MessageBoxButtons.YesNo) ==
                   System.Windows.Forms.DialogResult.Yes)
                    {
                        string deleteString = "";
                        string resetString = "";

                        deleteString = "delete from Items where IID ='" + id + "'";
                        sqliteHelper.delete(deleteString, 1);

                        resetString = "DBCC CHECKIDENT ('Items', reseed, (select max(IID) from Items))";
                        sqliteHelper.resetPK(resetString, 0);

                        string InsString = "insert into inspection (inID,inText,inAddingDate,inAddingTime,inAddingBy) values " +
                          "((select coalesce(max(inID),0)+1 from inspection),'" + "قام  " + Master.uName + " " + "بحذف مادة من المستودع  ','" + DateTime.Today.ToString("yyyy/MM/dd") + "','" + DateTime.Now.ToString("hh:mm tt") + "','النظام')";
                        sqliteHelper.insert(InsString, 0);
                        threadTrigger1 = 1;
                        threadTrigger2 = 1;
                    }


                }
                else
                {
                    MessageBox.Show("المادة لا يمكن حذفها ... يوجد رصيد لها في المستودع");
                }
            }
            catch
            {

            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (MessageBox.Show("هل تريد  الحفظ بالتأكيد ؟", "مدير  المستودع", MessageBoxButtons.YesNo) ==
                  System.Windows.Forms.DialogResult.Yes)
                {
                    string updateString = "update Items set IPrice = " + Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString()) + ",IName ='" + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + "' where IID =" + id;

                    sqliteHelper.upDate(updateString, 1);
                    string InsString = "insert into inspection (inID,inText,inAddingDate,inAddingTime,inAddingBy) values " +
                              "((select coalesce(max(inID),0)+1 from inspection),'" + " قام " + Master.uName + " " + "بتعديل بيانات مادة في المستودع ','" + DateTime.Today.ToString("yyyy-MM-dd") + "','" + DateTime.Now.ToString("hh:mm tt") + "','النظام')";
                    sqliteHelper.insert(InsString, 0);
                    threadTrigger1 = 1;
                    threadTrigger2 = 1;

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
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
