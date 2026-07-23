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
    public partial class output : Form
    {
        public output()
        {
            InitializeComponent();
        }

        string selectString = "";
        string Bid = "";
      //  string price = "";
      //  decimal total = 0;
        


        private void output_Load(object sender, EventArgs e)
        {
            gunaLineTextBox1.Text = DateTime.Now.ToString("yyyy-MM-dd");


            selectString = "select IName from Items";
            sqliteHelper.select(selectString,comboBox1);


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

           
            selectString = "select IID from Items where (IName ='" + comboBox1.Text + "') and (IAddingBy ='" + Master.uName + "')";
            Bid = sqliteHelper.selectWithReturn(selectString);

            selectString = "select IQuantity from Items where IID ='" + Bid + "' and IAddingBy ='" + Master.uName + "'";

            if (int.Parse(sqliteHelper.selectWithReturn(selectString)) > 0)
            {
                selectString = "select IPrice from Items where IName = '" + comboBox1.Text + "' and IAddingBy ='" + Master.uName + "'";

                gunaLineTextBox3.Text = sqliteHelper.selectWithReturn(selectString);

                
                selectString = "select IQuantity from Items where IName = '" + comboBox1.Text + "' and IAddingBy ='" + Master.uName + "'";
                gunaLineTextBox4.Text = sqliteHelper.selectWithReturn(selectString);

                selectString = "select IuName from Items where IName = '" + comboBox1.Text + "' and IAddingBy = '" + Master.uName + "'";
                gunaLineTextBox2.Text = sqliteHelper.selectWithReturn(selectString);

            }
            else
            {
                MessageBox.Show("لا يوجد رصيد لهذه المادة");
            }

        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            string selectString = "select iif(IQuantity -" + numericUpDown1.Value.ToString() + " < 0,'1','0') from Items where IID =" + Bid + " and IAddingBy ='" + Master.uName + "'";
            if (sqliteHelper.selectWithReturn(selectString) == "1")
            {
                MessageBox.Show("لا يوجد رصيد لهذه المادة");
            }
            else
            {
                if (MessageBox.Show("هل تريد الحفظ بالتأكيد ؟", "مدير الصندوق", MessageBoxButtons.YesNo) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {


                        DateTime dateObject;
                        if (DateTime.TryParse(gunaLineTextBox1.Text, out dateObject))
                        {
                            string updateString = "update Items set IQuantity = IQuantity - " + numericUpDown1.Value.ToString() + " where IID =" + Bid + " and IAddingBy ='" + Master.uName + "'";
                            sqliteHelper.upDate(updateString, 0);

                            string insertString = "insert into Box (BID,BType , IID , BItem ,BPrice,BQuantity,BTotal,BAddingDate,BAddingTime,BNote,BAddingBy) values ((select coalesce(max(BID),0)+1 from Box),'اخراج','"+ Bid + "','" + comboBox1.Text + "','" + gunaLineTextBox3.Text + "','" + numericUpDown1.Value.ToString().Trim() + "','" + gunaLineTextBox5.Text + "','" + gunaLineTextBox1.Text + "','" + DateTime.Now.ToString("hh:mm tt") + "','" + gunaLineTextBox6.Text.Trim() + "','" + Master.uName + "')";
                            sqliteHelper.insert(insertString, 1);

                          

                            string InsString = "insert into inspection (inID,inText,inAddingDate,inAddingTime,inAddingBy) values " +
                                 "((select coalesce(max(inID),0)+1 from inspection),'" + " قام " + Master.uName + " " + "بإخراج مادة من المستودع ','" + DateTime.Today.ToString("yyyy-MM-dd") + "','" + DateTime.Now.ToString("hh:mm tt") + "','النظام')";
                            sqliteHelper.insert(InsString, 0);
                            //   inputOutput.x3 = 1;
                            //    inputOutput.x5 = 1;
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

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            try
            {

            //    total = decimal.Parse(price) * decimal.Parse(numericUpDown1.Value.ToString());
                gunaLineTextBox5.Text = string.Format("{0:n}", decimal.Parse(gunaLineTextBox3.Text) * decimal.Parse(numericUpDown1.Value.ToString()));


            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void output_FormClosing(object sender, FormClosingEventArgs e)
        {
            inoutmanager.x2 = 0;
            combinationCul.x1 = 0;
        }

        private void gunaGradientButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
