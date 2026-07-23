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
    public partial class input : Form
    {
        public input()
        {
            InitializeComponent();
        }

        string selectString = "";
        private decimal total = 0;
        private string Bid = "";
        private string price = "";
      //  string users = "";

        private void input_Load(object sender, EventArgs e)
        {
            gunaLineTextBox1.Text = DateTime.Now.ToString("yyyy-MM-dd");

            selectString = "select IName from Items";
            sqliteHelper.select(selectString, comboBox1);

        }

        private void input_FormClosing(object sender, FormClosingEventArgs e)
        {
            inoutmanager.x1 = 0;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           



            selectString = "select IPrice from Items where IName = '" + comboBox1.Text + "' and IAddingBy ='" + Master.uName + "'";
            //sqliteHelper.select(selectString, gunaLineTextBox3);
            gunaLineTextBox3.Text = sqliteHelper.selectWithReturn(selectString);

            price = sqliteHelper.selectWithReturn(selectString);
            selectString = "select IID from Items where IName ='" + comboBox1.Text + "' and IAddingBy ='" + Master.uName + "'";
            Bid = sqliteHelper.selectWithReturn(selectString);

            selectString = "select IQuantity from Items where IName = '" + comboBox1.Text + "'and IAddingBy ='" + Master.uName + "'";
            gunaLineTextBox4.Text = sqliteHelper.selectWithReturn(selectString);

            selectString = "select IUName from Items where IName = '" + comboBox1.Text + "'and IAddingBy = '" + Master.uName + "'";
            gunaLineTextBox2.Text = sqliteHelper.selectWithReturn(selectString);

        }

        private void gunaGradientButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                total = decimal.Parse(price) * decimal.Parse(numericUpDown1.Value.ToString());

                gunaLineTextBox5.Text = string.Format("{0:n}", total);
            }
            catch
            {
                MessageBox.Show("السعر لا يجب ان يكون فارغ");
            }
        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تريد الحفظ بالتأكيد ؟", "مدير الصندوق", MessageBoxButtons.YesNo) ==
              System.Windows.Forms.DialogResult.Yes)
            {
                try
                {


                    DateTime dateObject;
                    if (DateTime.TryParse(gunaLineTextBox1.Text, out dateObject))
                    {
                        string updateString = "update Items set IQuantity = IQuantity + " + numericUpDown1.Value.ToString() + " where IID =" + Bid + " and IAddingBy ='" + Master.uName + "'";
                        sqliteHelper.upDate(updateString, 0);


                        string insertString = "insert into Box (BID,BType , IID , BItem ,BPrice,BQuantity,BTotal,BAddingDate,BAddingTime,BNote,BAddingBy) values ((select coalesce(max(BID),0)+1 from Box),'ادخال',"
                                     + Bid + ",'" + comboBox1.Text + "','" + price + "','" + numericUpDown1.Value.ToString().Trim() + "','" + total + "','" + gunaLineTextBox1.Text + "','" + DateTime.Now.ToString("hh:mm tt") + "','" + gunaLineTextBox6.Text.Trim() + "','" + Master.uName + "')";
                        sqliteHelper.insert(insertString, 1);
                        string InsString = "insert into inspection (inID,inText,inAddingDate,inAddingTime,inAddingBy) values " +
                                 "((select coalesce(max(inID),0)+1 from inspection),'" + " قام " + Master.uName + " " + "يإدخال مادة الى المستودع ','" + DateTime.Today.ToString("yyyy/MM/dd") + "','" + DateTime.Now.ToString("hh:mm tt") + "','النظام')";
                        sqliteHelper.insert(InsString, 0);
                        //   inputOutput.x3 = 1;
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
    }
}

