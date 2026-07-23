using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OmranApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public bool key1 = false;     //DESKTOP-FUGQNF4 DESKTOP-N4JQ6C6 DESKTOP-MD8VGAU
        public static bool key2 = false;

        public static int x1 = 0;

        public int x2 = 0;


        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = DateTime.Now.ToString("yyyy-MM-dd");
            gunaLineTextBox1.Enabled = false;
            gunaLineTextBox1.UseSystemPasswordChar = true;


            try
            {
                string users = "select Trim(Uname) from users";
                sqliteHelper.select(users, this.gunaComboBox1);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gunaGradientButton2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تريد الخروج بالتأكيد ؟", "صفحة تسجيل الدخول", MessageBoxButtons.YesNo) ==
               System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            string selelctString = "select Uname , Upassword from users where Uname = '" + gunaComboBox1.Text + "'" + "AND Upassword ='" + gunaLineTextBox1.Text + "'";

            if (sqliteHelper.isFound(selelctString))
            {

                string InsString = "insert into inspection (inID,inText,inAddingDate,inAddingTime,inAddingBy) values " +
                        "((select coalesce(max(inID),0)+1 from inspection),'" + " قام " + gunaComboBox1.Text + " " + "بتسجيل الدخول للبرنامج ','" + DateTime.Today.ToString("yyyy/MM/dd") + "','" + DateTime.Now.ToString("hh:mm tt") + "','النظام')";
                sqliteHelper.insert(InsString, 0);
                this.key1 = false;
                this.Hide();
                if (x2 == 0)
                {
                    x2 = 1;
                    Master f1 = new Master();
                    f1.toolStripStatusLabel5.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    f1.toolStripStatusLabel2.Text = gunaComboBox1.Text;
                    f1.key2 = true;
                    f1.Show();
                }

            }
        }

        private void gunaComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            gunaLineTextBox1.Enabled = true;
            gunaLineTextBox1.Focus();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                gunaLineTextBox1.UseSystemPasswordChar = true;
            }
            else
            {
                gunaLineTextBox1.UseSystemPasswordChar = false;

            }
        }

        private void gunaLineTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                gunaGradientButton1.PerformClick();


            }
        }
    }
}
