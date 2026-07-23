using DevExpress.XtraPrinting.BarCode.Native;
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
    public partial class combinationCul : Form
    {
        public combinationCul()
        {
            InitializeComponent();
        }

        public static int x1 = 0;
        Thread th1 = null;
        Thread th2 = null;
        public static int threadTrigger = 0;


        private void combinationCul_FormClosing(object sender, FormClosingEventArgs e)
        {
            combinations.x2 = 0;
            th1.Abort();
            th2.Abort();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (x1==0)
            {
                x1 = 1;
                outputForCom f1 = new outputForCom();
                f1.cid = toolStripTextBox1.Text;
                f1.Show();
            }
        }

        private void combinationCul_Load(object sender, EventArgs e)
        {
            sqliteHelper.EnableStyle(dataGridView1);
            threadTrigger = 1;
            th1 = new Thread(start);
          //  th1.IsBackground = true;
            th1.Start();
        }

        public void start() 
        {
            while (true) 
            {
                th2 = new Thread(refresh);
                th2.Start();
            }

        }

        private void refresh()
        {
            if (threadTrigger == 1)
            {
                threadTrigger = 0;
                string selectString = "select CCID as 'رقم التركيبة',CID as 'رقم العملية',IID as 'رقم المادة',CCIName as 'اسم المادة',CCIAmount as 'مبلغ',CCAddingDate as 'تاريخ الاضافة',CCAddingBy as 'بواسطة' from combinationsCul where CID = '"+toolStripTextBox1.Text+"'";
                sqliteHelper.select(selectString,dataGridView1);

                selectString = "select coalesce(sum(CCIAmount),0) from combinationsCul where CID ='" + toolStripTextBox1.Text + "'";
                toolStripTextBox5.Text =(double.Parse(toolStripTextBox4.Text) - double.Parse(sqliteHelper.selectWithReturn(selectString))).ToString();
            }
        }

    }
}
