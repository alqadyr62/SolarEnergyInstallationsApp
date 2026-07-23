using Guna.UI.WinForms;
using Guna.UI2.WinForms.Suite;
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
    public partial class addingNewCustomerAmount : Form
    {
        public addingNewCustomerAmount()
        {
            InitializeComponent();
        }
        public string cid = "";
        private void gunaLineTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaGradientButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addingNewCustomerAmount_FormClosing(object sender, FormClosingEventArgs e)
        {
            customerCul.x2 = 0;
        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تريد الحفظ بالتأكيد ؟", "مدير الزبائن", MessageBoxButtons.YesNo) ==
              System.Windows.Forms.DialogResult.Yes)
            {
                try
                {


                    DateTime dateObject;
                    if (DateTime.TryParse(gunaLineTextBox1.Text, out dateObject))
                    {


                        string insertString = "insert into customerCul (CUCID,CUID,CUCName,CUCPrice,CUCAddingDate,CUCAddingBy) values ((select coalesce(max(CUCID),0)+1 from customerCul),'" + cid + "','دفعة جديدة','" + gunaLineTextBox2.Text + "','" + gunaLineTextBox1.Text + "','" + Master.uName + "')";
                        sqliteHelper.insert(insertString, 1);

                        string InsString = "insert into inspection (inID,inText,inAddingDate,inAddingTime,inAddingBy) values " +
                                 "((select coalesce(max(inID),0)+1 from inspection),'" + " قام " + Master.uName + " " + "بإضافة دفعة جديدة لزبون','" + DateTime.Today.ToString("yyyy/MM/dd") + "','" + DateTime.Now.ToString("hh:mm tt") + "','النظام')";
                        sqliteHelper.insert(InsString, 0);
                        customerCul.threadTrigger = 1;
                        // inputOutput.x5 = 1;
                        this.Close();

                    }
                }
                catch
                {
                    MessageBox.Show("ادخل تاريخ صحيح");
                    gunaLineTextBox1.Text = DateTime.Today.ToString("yyyy-MM-dd");

                }
            }
        }

        private void addingNewCustomerAmount_Load(object sender, EventArgs e)
        {
            gunaLineTextBox1.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void gunaLineTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                gunaLineTextBox2.Focus();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                gunaLineTextBox2.Focus();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                gunaGradientButton1.Focus();
                e.Handled = true;
            }
        }

        private void gunaLineTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                gunaLineTextBox1.Focus();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                gunaLineTextBox1.Focus();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                gunaGradientButton1.Focus();
                e.Handled = true;
            }
        }
    }
}
