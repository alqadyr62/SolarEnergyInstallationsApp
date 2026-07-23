using Guna.UI.WinForms;
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
    public partial class addingNewInstallaionOfficer : Form
    {
        public addingNewInstallaionOfficer()
        {
            InitializeComponent();
        }

        private void addingNewInstallaionOfficer_Load(object sender, EventArgs e)
        {
            gunaLineTextBox1.Text = DateTime.Now.ToString("yyyy-MM-dd");

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
                    else if (gunaLineTextBox1.Text == "" || gunaLineTextBox2.Text == "")

                    {
                        MessageBox.Show("الحقول بالعلامة * مطلوبة");
                    }
                    else
                    {
                        string insertString = "insert into installationOfficer (IOID,IOName,IOAddingDate,IOAddingBy) values ((select coalesce(max(IOID),0)+1 from installationOfficer),'" + gunaLineTextBox2.Text.Trim() + "','" + gunaLineTextBox3.Text.Trim() + "','" + gunaLineTextBox1.Text + "','" + Master.uName + "')";
                        sqliteHelper.insert(insertString, 1);

                        string InsString = "insert into inspection (inID,inText,inAddingDate,inAddingTime,inAddingBy) values " +
                                 "((select coalesce(max(inID),0)+1 from inspection),'" + " قام " + Master.uName + " " + "بإضافة مسؤول تركيبات جديدة ','" + DateTime.Today.ToString("yyyy/MM/dd") + "','" + DateTime.Now.ToString("hh:mm tt") + "','النظام')";
                        sqliteHelper.insert(InsString, 0);


                    }

                   // Units.threadTrigger1 = 1;
                   // Units.threadTrigger2 = 1;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

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
                gunaLineTextBox3.Focus();
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
                gunaLineTextBox2.Focus();
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
                gunaLineTextBox1.Focus();
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
    }
}
