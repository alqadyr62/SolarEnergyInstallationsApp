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
    public partial class addingNewCustomer : Form
    {
        public addingNewCustomer()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void addingNewCustomer_Load(object sender, EventArgs e)
        {
            gunaLineTextBox1.Text = DateTime.Now.ToString("yyyy-MM-dd");
            comboBox1.Items.Add("زبون عادي");
            comboBox1.Items.Add("مورد");


        }

        private void addingNewCustomer_FormClosing(object sender, FormClosingEventArgs e)
        {
            customers.x1 = 0;
        }



        private void gunaGradientButton2_Click(object sender, EventArgs e)
        {
            this.Close();
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

                        string insertString = "insert into customers (CUID,CUName , CUPhoneNumber , CUAddress ,CUType,CUAddingDate,CUAddingBy,CUNote,CUTotal) values ((select coalesce(max(CUID),0)+1 from customers),'" + gunaLineTextBox2.Text + "','"
                        + gunaLineTextBox3.Text + "','" + gunaLineTextBox4.Text + "','" + comboBox1.Text + "','" + gunaLineTextBox1.Text +  "','" + Master.uName + "','"+gunaLineTextBox5.Text+"','"+ gunaLineTextBox6.Text + "')";
                        sqliteHelper.insert(insertString, 1);
                        string InsString = "insert into inspection (inID,inText,inAddingDate,inAddingTime,inAddingBy) values " +
                                 "((select coalesce(max(inID),0)+1 from inspection),'" + " قام " + Master.uName + " " + "يإدخال مادة الى المستودع ','" + DateTime.Today.ToString("yyyy/MM/dd") + "','" + DateTime.Now.ToString("hh:mm tt") + "','النظام')";
                        sqliteHelper.insert(InsString, 0);
                        customers.threadTrigger1 = 1;
                        customers.threadTrigger2 = 1;

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

        private void gunaLineTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                gunaLineTextBox2.Focus();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                gunaLineTextBox5.Focus();
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
                gunaLineTextBox3.Focus();
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

        private void gunaLineTextBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                gunaLineTextBox4.Focus();
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

        private void gunaLineTextBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                gunaLineTextBox6.Focus();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                gunaLineTextBox3.Focus();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                gunaGradientButton1.Focus();
                e.Handled = true;
            }
        }

        private void gunaLineTextBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                gunaLineTextBox5.Focus();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                gunaLineTextBox4.Focus();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                gunaGradientButton1.Focus();
                e.Handled = true;
            }
        }

        private void gunaLineTextBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                gunaLineTextBox1.Focus();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                gunaLineTextBox6.Focus();
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
