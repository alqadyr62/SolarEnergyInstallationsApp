using DevExpress.Utils;
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
    public partial class Master : Form
    {
        public Master()
        {
            InitializeComponent();
        }

        public bool key2 = false;
        public static int x1 = 0;
        public static int x2 = 0;
        public static int x3 = 0;
        public static int x4 = 0;
        public static int x5 = 0;
        public static int x6 = 0;
        public static int x7 = 0;


        public static string uName = "";

     //   Thread th1 = null;
        // Thread th2 = null;

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void Master_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (key2 == true)
            {
                this.key2 = false;
                Form1.key2 = false;
               // th1.Abort();
                System.Diagnostics.Process.GetCurrentProcess().Kill();
                Application.Exit();
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            if(x2 == 0)
            {
                x2 = 1;
                Storehouse f1 = new Storehouse();
                f1.Dock = DockStyle.Fill;
                f1.MdiParent = this;
                xtraTabbedMdiManager1.Pages[xtraTabbedMdiManager1.Pages.Count - 1].Text = "مستودع المواد";
                xtraTabbedMdiManager1.Pages[xtraTabbedMdiManager1.Pages.Count - 1].ShowCloseButton = DefaultBoolean.False;

                f1.Show();
                //f3.username = uName;

                xtraTabbedMdiManager1.Pages[xtraTabbedMdiManager1.Pages.Count - 1].Appearance.Header.Font = new Font("Times New Roman", 14, FontStyle.Bold);
                xtraTabbedMdiManager1.Pages[xtraTabbedMdiManager1.Pages.Count - 1].Appearance.HeaderActive.Font = new Font("Times New Roman", 14, FontStyle.Bold);

            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (x3 == 0)
            {
                x3 = 1;
                Units f1 = new Units();
                f1.Dock = DockStyle.Fill;
                f1.MdiParent = this;
                xtraTabbedMdiManager1.Pages[xtraTabbedMdiManager1.Pages.Count - 1].Text = "الوحدات";
                xtraTabbedMdiManager1.Pages[xtraTabbedMdiManager1.Pages.Count - 1].ShowCloseButton = DefaultBoolean.False;

                f1.Show();
                //f3.username = uName;

                xtraTabbedMdiManager1.Pages[xtraTabbedMdiManager1.Pages.Count - 1].Appearance.Header.Font = new Font("Times New Roman", 14, FontStyle.Bold);
                xtraTabbedMdiManager1.Pages[xtraTabbedMdiManager1.Pages.Count - 1].Appearance.HeaderActive.Font = new Font("Times New Roman", 14, FontStyle.Bold);

            }
        }

        private void Master_Load(object sender, EventArgs e)
        {
            uName = this.toolStripStatusLabel2.Text;
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            if (x4 == 0)
            {
                x4 = 1;
                inoutmanager f1 = new inoutmanager();
                f1.Dock = DockStyle.Fill;
                f1.MdiParent = this;
                xtraTabbedMdiManager1.Pages[xtraTabbedMdiManager1.Pages.Count - 1].Text = "الصندوق";
                xtraTabbedMdiManager1.Pages[xtraTabbedMdiManager1.Pages.Count - 1].ShowCloseButton = DefaultBoolean.False;

                f1.Show();
                //f3.username = uName;

                xtraTabbedMdiManager1.Pages[xtraTabbedMdiManager1.Pages.Count - 1].Appearance.Header.Font = new Font("Times New Roman", 14, FontStyle.Bold);
                xtraTabbedMdiManager1.Pages[xtraTabbedMdiManager1.Pages.Count - 1].Appearance.HeaderActive.Font = new Font("Times New Roman", 14, FontStyle.Bold);

            }
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            if (x5 == 0) 
            {
                
                x5 = 1;
                combinations f1 = new combinations();
                f1.Dock = DockStyle.Fill;
                f1.MdiParent = this;
                xtraTabbedMdiManager1.Pages[xtraTabbedMdiManager1.Pages.Count - 1].Text = "التركيبات";
                xtraTabbedMdiManager1.Pages[xtraTabbedMdiManager1.Pages.Count - 1].ShowCloseButton = DefaultBoolean.False;

                f1.Show();
                //f3.username = uName;

                xtraTabbedMdiManager1.Pages[xtraTabbedMdiManager1.Pages.Count - 1].Appearance.Header.Font = new Font("Times New Roman", 14, FontStyle.Bold);
                xtraTabbedMdiManager1.Pages[xtraTabbedMdiManager1.Pages.Count - 1].Appearance.HeaderActive.Font = new Font("Times New Roman", 14, FontStyle.Bold);

            }
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            if(x6 == 0)
            {
                x6 = 1;
                customers f1 = new customers();
                f1.Dock = DockStyle.Fill;
                f1.MdiParent = this;
                xtraTabbedMdiManager1.Pages[xtraTabbedMdiManager1.Pages.Count - 1].Text = "الزبائن";
                xtraTabbedMdiManager1.Pages[xtraTabbedMdiManager1.Pages.Count - 1].ShowCloseButton = DefaultBoolean.False;

                f1.Show();
                
                xtraTabbedMdiManager1.Pages[xtraTabbedMdiManager1.Pages.Count - 1].Appearance.Header.Font = new Font("Times New Roman", 14, FontStyle.Bold);
                xtraTabbedMdiManager1.Pages[xtraTabbedMdiManager1.Pages.Count - 1].Appearance.HeaderActive.Font = new Font("Times New Roman", 14, FontStyle.Bold);

            }
        }
    }
}
