using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Security.RightsManagement;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OmranApp
{
    public partial class inoutmanager : Form
    {
        public inoutmanager()
        {
            InitializeComponent();
        }

        Thread th1 = null;
        Thread th2 = null;

        public int threadtrigger1 = 0;
        public int threadtrigger2 = 0;
        public int threadtrigger3 = 0;

        public static int x1 = 0;
        public static int x2 = 0;



      //  string selectString = "";

        private void inoutmanager_Load(object sender, EventArgs e)
        {
            toolStripTextBox1.Text = DateTime.Now.ToString("yyyy-MM-dd");
            toolStripTextBox2.Text = DateTime.Now.ToString("yyyy-MM-dd");

            toolStripComboBox2.Items.Add("الكل");
            toolStripComboBox2.Items.Add("ادخال");
            toolStripComboBox2.Items.Add("اخراج");

            sqliteHelper.EnableStyle(dataGridView1);


            threadtrigger1 = 1;
            threadtrigger2 = 1;

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
            try
            {
                if (threadtrigger1 == 1)
                {
                    //               Thread.Sleep(5000);

                    threadtrigger1 = 0;
                    string selectString = "";
                    if (toolStripComboBox1.Text == "الكل" && toolStripComboBox2.Text == "الكل")
                    {

                        selectString = "select coalesce(sum(BTotal),0)  from Box where " +
                                             "(BAddingDate between '" + toolStripTextBox1.Text + "' and '" + toolStripTextBox2.Text + "'"+") and (BType ='ادخال' and (BAddingBy = '" + Master.uName + "')";
                        toolStripTextBox4.Text = string.Format("{0:n}", decimal.Parse(sqliteHelper.selectWithReturn(selectString)));

                        selectString = "select coalesce(sum(BTotal),0)  from Box where " +
                            "(BAddingDate between '" + toolStripTextBox1.Text + "' and '" + toolStripTextBox2.Text + "') " +
                            "and (BType ='اخراج') and (BAddingBy = '" + Master.uName + "')";
                        toolStripTextBox5.Text = string.Format("{0:n}", decimal.Parse(sqliteHelper.selectWithReturn(selectString)));


                    }
                    else if (toolStripComboBox1.Text == "الكل" && toolStripComboBox2.Text == "ادخال")
                    {
                        selectString = "select coalesce(sum(BTotal),0)  from Box where " +
                                           "(BAddingDate between '" + toolStripTextBox1.Text + "' and '" + toolStripTextBox2.Text + "'" + ") and (BType ='ادخال') and (BAddingBy = '" + Master.uName + "')";
                        toolStripTextBox4.Text = string.Format("{0:n}", decimal.Parse(sqliteHelper.selectWithReturn(selectString)));
                        toolStripTextBox5.Text = "0";
                    }
                    else if (toolStripComboBox1.Text == "الكل" && toolStripComboBox2.Text == "اخراج")
                    {
                        selectString = "select coalesce(sum(BTotal),0)  from Box where " +
                                                  "(BAddingDate between '" + toolStripTextBox1.Text + "' and '" + toolStripTextBox2.Text + "' " + ") and (BType ='اخراج') and (BAddingBy = '" + Master.uName + "')";
                        toolStripTextBox4.Text = string.Format("{0:n}", decimal.Parse(sqliteHelper.selectWithReturn(selectString)));
                        toolStripTextBox5.Text = "0";
                    }
                    else if (toolStripComboBox1.Text != "الكل" && toolStripComboBox2.Text == "ادخال")
                    {

                        selectString = "select coalesce(sum(BTotal),0)  from Box where " +
                                               "((BAddingDate between '" + toolStripTextBox1.Text + "' and '" + toolStripTextBox2.Text + "') " + ") and (BItem ='" + toolStripComboBox1.Text + "') and (BType ='ادخال') and (BAddingBy = '" + Master.uName + "')";
                        toolStripTextBox4.Text = string.Format("{0:n}", decimal.Parse(sqliteHelper.selectWithReturn(selectString)));
                        toolStripTextBox5.Text = "00";

                    }
                    else if (toolStripComboBox1.Text != "الكل" && toolStripComboBox2.Text == "اخراج")
                    {

                        toolStripTextBox4.Text = "00";
                        selectString = "select coalesce(sum(BTotal),0)  from Box where " +
                         "(BAddingDate between '" + toolStripTextBox1.Text + "' and '" + toolStripTextBox2.Text + "') " +
                         "and (BItem ='" + toolStripComboBox1.Text + "') and (BType ='اخراج') and (BAddingBy = '" + Master.uName + "')";
                        toolStripTextBox5.Text = string.Format("{0:n}", decimal.Parse(sqliteHelper.selectWithReturn(selectString)));

                    }
                    else if (toolStripComboBox2.Text == "الكل" && toolStripComboBox1.Text != "الكل")
                    {
                        selectString = "select coalesce(sum(BTotal),0)  from Box where " +
                                               "(BAddingDate between '" + toolStripTextBox1.Text + "' and '" + toolStripTextBox2.Text + "') " + " and (BItem ='" + toolStripComboBox1.Text + "')  and (BType ='ادخال') and (BAddingBy = '" + Master.uName + "')";
                        toolStripTextBox4.Text = string.Format("{0:n}", decimal.Parse(sqliteHelper.selectWithReturn(selectString)));

                        selectString = "select coalesce(sum(BTotal),0)  from Box where " +
                          "(BAddingDate between '" + toolStripTextBox1.Text + "' and '" + toolStripTextBox2.Text + "') " +
                          " and (BItem ='" + toolStripComboBox1.Text + "') and (BType ='اخراج') and (BAddingBy = '" + Master.uName + "')";
                        toolStripTextBox5.Text = string.Format("{0:n}", decimal.Parse(sqliteHelper.selectWithReturn(selectString)));

                    }

                    if (threadtrigger2 == 1)
                    {
                        threadtrigger2 = 0;
                        toolStripComboBox1.Items.Clear();
                        toolStripComboBox1.Items.Add("الكل");
                        selectString = "select IName from Items where IAddingBy ='" + Master.uName + "'";
                        sqliteHelper.select(selectString, toolStripComboBox1);

                    }

                }
            }
            catch
            {

            }


             
        }
            
        

        private void toolStripComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime d;
            if (!DateTime.TryParseExact(toolStripTextBox1.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out d) || !DateTime.TryParseExact(toolStripTextBox2.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out d))
            {
                MessageBox.Show("yyyy-mm-dd الشكل المسموح به هو");
            }
            else if (DateTime.Parse(toolStripTextBox1.Text) > DateTime.Parse(toolStripTextBox2.Text))
            {
                MessageBox.Show("تاريخ بداية البحث اكبر من تاريخ نهاية البحث");

            }
            else
            {

                if (toolStripComboBox1.Text == "الكل" && toolStripComboBox2.Text == "الكل")
                {


                    string selectString = "select BID as 'رقم العملية' ,trim(BType) as 'نوع العملية',IID as 'رقم المادة',trim(BItem) as 'اسم المادة',printf('%,d',BPrice) as 'السعر للوحدة',BQuantity as 'العدد',printf('%,d',BTotal) as 'السعر الكلي',trim(BAddingDate) as 'تاريخ الإضافة',BAddingTime as 'وقت الاضافة',BAddingBy as 'بواسطة',trim(BNote) as 'الملاحظات' from Box  where (BAddingDate between '" + toolStripTextBox1.Text + "' and '" + toolStripTextBox2.Text + "')  and (BAddingBy ='" + Master.uName + "')";
                    sqliteHelper.select(selectString, this.dataGridView1);
                    threadtrigger1 = 1;

                }
                else if (toolStripComboBox2.Text == "الكل" && toolStripComboBox1.Text != "الكل")
                {

                    string selectString = "select BID as 'رقم العملية' ,trim(BType) as 'نوع العملية',IID as 'رقم المنتج',trim(BItem) as 'اسم المادة',printf('%,d',BPrice) as 'السعر للوحدة',BQuantity as 'العدد',printf('%,d',BTotal) as 'السعر الكلي',trim(BAddingDate) as 'تاريخ الإضافة',BAddingTime as 'وقت الاضافة' ,BAddingBy as 'بواسطة',trim(BNote) as 'الملاحظات'   from Box  where (BAddingDate between '" + toolStripTextBox1.Text + "' and '" + toolStripTextBox2.Text + "')  and (BItem ='" + toolStripComboBox1.Text + "') and (BAddingBy ='" + Master.uName + "')";
                    sqliteHelper.select(selectString, this.dataGridView1);
                    threadtrigger1 = 1;


                }
                else if (toolStripComboBox1.Text == "الكل" && toolStripComboBox2.Text != "الكل")
                {

                    string selectString = "select BID as 'رقم العملية' ,trim(BType) as 'نوع العملية',IID as 'رقم المنتج',trim(BItem) as 'اسم المادة',printf('%,d',BPrice) as 'السعر للوحدة',BQuantity as 'العدد',printf('%,d',BTotal) as 'السعر الكلي',trim(BAddingDate) as 'تاريخ الإضافة',BAddingTime as 'وقت الاضافة' ,BAddingBy as 'بواسطة',trim(BNote) as 'الملاحظات'   from Box  where (BAddingDate between '" + toolStripTextBox1.Text + "' and '" + toolStripTextBox2.Text + "') and (BType ='" + toolStripComboBox2.Text + "')  and (BAddingBy ='" + Master.uName + "')";
                    sqliteHelper.select(selectString, this.dataGridView1);
                    threadtrigger1 = 1;
                }
                else if (toolStripComboBox1.Text != "الكل" && toolStripComboBox2.Text != "الكل")
                {

                    string selectString = "select BID as 'رقم العملية' ,trim(BType) as 'نوع العملية',IID as 'رقم المنتج',trim(BItem) as 'اسم المادة',printf('%,d',BPrice) as 'السعر للوحدة',BQuantity as 'العدد',printf('%,d',BTotal) as 'السعر الكلي',trim(BAddingDate) as 'تاريخ الإضافة',BAddingTime as 'وقت الاضافة',BAddingBy as 'بواسطة',trim(BNote) as 'الملاحظات' from Box  where (BAddingDate between '" + toolStripTextBox1.Text + "' and '" + toolStripTextBox2.Text + "') and (BType ='" + toolStripComboBox2.Text + "') and (BItem ='" + toolStripComboBox1.Text + "') and (BAddingBy ='" + Master.uName + "')";
                    sqliteHelper.select(selectString, this.dataGridView1);
                    threadtrigger1 = 1;

                }

            }
        }

        private void ادخالToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (x1 == 0)
            {
                x1 = 1;
                input f1 = new input();
                f1.Show();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void inoutmanager_FormClosing(object sender, FormClosingEventArgs e)
        {
            Master.x4 = 0;
            th1.Abort();
            th2.Abort();
        }

        private void اخراجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (x2 == 0)
            {
                x2 = 1;
                output f1 = new output();
                f1.Show();
            }
        }
    }
}
