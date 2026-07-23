using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OmranApp
{
    public partial class addingNewItem : Form
    {
        public addingNewItem()
        {
            InitializeComponent();
        }

        string selectString = "";

        private void gunaLineTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                gunaLineTextBox2.Focus();
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

        private void gunaLineTextBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                gunaLineTextBox2.Focus();
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

        private void gunaGradientButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addingNewItem_Load(object sender, EventArgs e)
        {
            gunaLineTextBox1.Text = DateTime.Now.ToString("yyyy-MM-dd");

            selectString = "select UnName from units";
            sqliteHelper.select(selectString, comboBox1);


        }

        private void addingNewItem_FormClosing(object sender, FormClosingEventArgs e)
        {
            Storehouse.x1 = 0;
        }

        private void gunaComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تريد الحفظ بالتأكيد ؟", "مدير المستودع", MessageBoxButtons.YesNo) ==
              System.Windows.Forms.DialogResult.Yes)
            {

                try
                {
                    double price = double.Parse(gunaLineTextBox3.Text);
                    DateTime d;
                    if (!DateTime.TryParseExact(gunaLineTextBox1.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out d))
                    {
                        MessageBox.Show("التاريخ يجب أن يكون من الشكل yyyy-MM-dd");
                        gunaLineTextBox1.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    }
                    else if (gunaLineTextBox1.Text == "" || gunaLineTextBox2.Text == "" || gunaLineTextBox3.Text == "")

                    {
                        MessageBox.Show("الحقول بالعلامة * مطلوبة");
                    }
                    else
                    {
                        string insertString = "insert into Items (IID,IName,IUName,IQuantity,IPrice,ITotal,INote,IAddingDate,IAddingBy) values ((select coalesce(max(IID),0)+1 from Items),'"
                             + gunaLineTextBox2.Text.Trim() + "','" + comboBox1.Text.Trim() + "',0,'" + gunaLineTextBox3.Text + "',0,'" + gunaLineTextBox4.Text + "','" + gunaLineTextBox1.Text + "','"+Master.uName+"')";
                        sqliteHelper.insert(insertString, 1);

                        string InsString = "insert into inspection (inID,inText,inAddingDate,inAddingTime,inAddingBy) values " +
                                 "((select coalesce(max(inID),0)+1 from inspection),'" + " قام " + Master.uName + " " + "بإضافة مادة جديدة ','" + DateTime.Today.ToString("yyyy/MM/dd") + "','" + DateTime.Now.ToString("hh:mm tt") + "','النظام')";
                        sqliteHelper.insert(InsString, 0);


                    }

                    Storehouse.threadTrigger1 = 1;
                    Storehouse.threadTrigger2 = 1;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            gunaLineTextBox3.Focus();
        }
    }
}
