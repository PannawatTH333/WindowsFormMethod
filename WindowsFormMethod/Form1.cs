using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormMethod
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("ยินดีต้อนรับทุกท่าน", "โปรแกรมคำนวณค่า MBI");
            clearForm();    
        }

        private void btnBMI_Click(object sender, EventArgs e)
        {
            //intput รับค่าจาก Textbox
            string name = txtName.Text;
            int age = Convert.ToInt32(txtAge.Text);
            // 1 double height = Convert.ToDouble(txtHeight.Text);
            // 1 double weight = Convert.ToDouble(txtWeight.Text);
            //2   double height = 0;
            //2     if (double.TryParse(txtHeight.Text,out height)==false)
            //2     {
            //2          MessageBox.Show("กรอกข้อมูลไม่ถูกต้ง", "เกิดข้อผิดพลาด");
            //2         return; //ค่าในif เป็นจริง ให้จบการทำงาน
            //2     }
            //2     double weight;
            //2     if (double.TryParse(txtWeight.Text,out weight)==false)
            //2     {
            //2         MessageBox.Show("กรอกข้อมูลไม่ถูกต้ง", "เกิดข้อผิดพลาด");
            //2         return; //ค่าในif เป็นจริง ให้จบการทำงาน
            //2     }

            double height = 0;
            double weight = 0;
            if (CheckDouble(txtWeight, txtHeight)) //เรียกใช้Methodแบบคืนค่าเป็น True/false
                height = Convert.ToInt32(txtHeight.Text);
                weight = Convert.ToInt32(txtWeight.Text);


            //Process คำนวณค่าBMI
            //double bmi = weight / Math.Pow(height / 100, 2);
            double bmi = BMI(height, weight);   //เรียกใช้ method BMI
            //Output แสดงค่า BMI
            lblResult.Text = bmi.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearForm();
        }

        private void clearForm()
        {
            txtAge.TextAlign = HorizontalAlignment.Right; //จัดชิดขวา
            txtHeight.TextAlign = HorizontalAlignment.Right;
            txtWeight.TextAlign = HorizontalAlignment.Right;
            txtName.Text = "";
            txtAge.Text = "0";
            txtHeight.Text = "0";
            txtWeight.Text = "0";
            txtName.Focus();
        }

        private void IntputDataValid(TextBox name, TextBox age)
        {
            if (name.Text.Length!=0)
            {
                name.ForeColor = Color.DarkGreen;
            }
            else
            {
                name.ForeColor = Color.Gray;
            }
            if (Convert.ToInt32(age.Text) >=0)
            {
                age.ForeColor = Color.DarkGreen;
            }
            else
            {
                age.ForeColor = Color.Gray;
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            IntputDataValid(txtName, txtAge);
        }

        private void txtAge_TextChanged(object sender, EventArgs e)
        {
            IntputDataValid(txtName, txtAge);
        }

        private double BMI(double h, double w) //Method BMI
        { double bmi = w/Math.Pow(h/100, 2);
            return bmi;
            //แบบสั้น
           // return w / Math.Pow(h / 100, 2);
            
        }

        private bool CheckDouble(TextBox txtW, TextBox txtH) //สำหรับตรวจสอบข้อมูล
        {
            double w = 0;
            double h = 0;
            if (double.TryParse(txtW.Text,out w)||(double.TryParse(txtH.Text,out h)))
            {
                 MessageBox.Show("กรอกข้อมูลไม่ถูกต้ง", "เกิดข้อผิดพลาด");
                return false;
            }
           
               
           
            return true;
        }
    }
}
