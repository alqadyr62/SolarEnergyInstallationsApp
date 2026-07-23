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
    public partial class addingNewCombinations : Form
    {
        public addingNewCombinations()
        {
            InitializeComponent();
        }

        string selectString = "";

        private void addingNewCombinations_Load(object sender, EventArgs e)
        {
            gunaLineTextBox1.Text = DateTime.Now.ToString("yyyy-MM-dd");

            comboBox1.Items.Clear();
            selectString = "select DISTINCT CName from combinations";
           
            sqliteHelper.select(selectString, comboBox1);


        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تريد الحفظ بالتأكيد ؟", "مدير التركيبات", MessageBoxButtons.YesNo) ==
               System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    DateTime d;
                    if (!DateTime.TryParseExact(gunaLineTextBox1.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out d))
                    {
                        MessageBox.Show("التاريخ يجب أن يكون من الشكل yyyy-MM-dd");
                        gunaLineTextBox1.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    }
                    else if (gunaLineTextBox1.Text == "" || comboBox1.Text == "" || gunaLineTextBox3.Text == "" || gunaLineTextBox4.Text == "")

                    {
                        MessageBox.Show("الحقول بالعلامة * مطلوبة");
                    }
                    else
                    {

                        string insertString = "insert into combinations (CID,CName,Cforwho,CTotal,CAddingDate,CAddingBy) values ((select coalesce(max(CID),0)+1 from combinations),'" + comboBox1.Text.Trim() + "','" + gunaLineTextBox3.Text.Trim() + "','" + gunaLineTextBox4.Text + "','" + gunaLineTextBox1.Text + "','" + Master.uName + "')";
                        sqliteHelper.insert(insertString, 1);

                        string InsString = "insert into inspection (inID,inText,inAddingDate,inAddingTime,inAddingBy) values " +
                                 "((select coalesce(max(inID),0)+1 from inspection),'" + " قام " + Master.uName + " " + "بإضافة تركيبة جديدة ','" + DateTime.Today.ToString("yyyy/MM/dd") + "','" + DateTime.Now.ToString("hh:mm tt") + "','النظام')";
                        sqliteHelper.insert(InsString, 0);

                    }

                    combinations.threadTrigger1 = 1;
                    combinations.threadTrigger2 = 1;

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void addingNewCombinations_FormClosing(object sender, FormClosingEventArgs e)
        {
            combinations.x1 = 0;
        }

        private void gunaGradientButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gunaLineTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
           if (e.KeyCode == Keys.Up)
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
                gunaLineTextBox4.Focus();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                gunaLineTextBox1.Focus();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Left)
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

        private void gunaLineTextBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
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

        private void gunaLineTextBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                gunaLineTextBox1.Focus();
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
    }
}
