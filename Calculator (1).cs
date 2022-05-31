using System;
using System.Data;
using System.Windows.Forms;

namespace Shoop
{
    public partial class Form1 : Form
    {
        private Shoop.Class.ProductDescribe product = new Shoop.Class.ProductDescribe();
        private BindingSource bindingSource = new BindingSource();
        private Shoop.Class.Maths Maths = new Shoop.Class.Maths();

        private int Amount;
        private float Cost;

        public Form1()
        {
            InitializeComponent();
            AutoSize = true;

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            product.NameProduct = textBox1.Text;
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
                try
                {
                    Amount = int.Parse(textBox2.Text);
                }
                catch (Exception)
                {

                    
                }
        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {
                try
                {
                    Cost = float.Parse(textBox3.Text);
                }
                catch (Exception)
                {
                    
                }
        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {
            product.DescribeProduct = textBox4.Text;
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.DataSource = bindingSource;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            textBox5.Text = String.Empty;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Delete String or check Tax
            if(Maths.Tax == 0)
            {
                MessageBox.Show("Enter Tax | (for example : 0.25 (25%) )");
               
            }
            if(Maths.Tax > 0.001){
                AdProduct();
                textBox1.Text = String.Empty;
                textBox2.Text = String.Empty;
                textBox3.Text = String.Empty;
                textBox4.Text = String.Empty;
            }
            

        }

        public void AdProduct()
        {
            //Add data to view
            dataGridView1.Rows.Add(product.NameProduct, Amount, Cost, product.DescribeProduct,DateTime.Now);
            try
            {
                mathematics();
                ShowTex();
                if (checkBox1.Checked)
                    MessageBox.Show("Total VAT/Tax: "+Maths.output);
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
                throw;
            }
        }

        void mathematics()
        {
            //calculations Tex
            try
            {
                OutputVAT.Text = String.Empty;
                    Maths.VAT = Cost * Maths.Tax;
                    Maths.total = Maths.VAT;
                Maths.output += Maths.total;

            }
            catch (Exception)
            {
                MessageBox.Show("Error #MT" + Maths.total);
                throw;
            }
        }

        private void textBox5_TextChanged_1(object sender, EventArgs e)
        {
            // add new Tax
            try
            {
                Maths.Tax = float.Parse(textBox5.Text);

            }
            catch (Exception)
            {
                MessageBox.Show("Error: tex set to 25% (0.25) ");
                Maths.Tax = 0.25;
                return;
            }
        }


        private void ShowTex()
        {
            //Show tax 
            OutputVAT.Text = Maths.VAT.ToString();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }

}