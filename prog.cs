# ROBOT

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Taxi_Robocop
{
    public partial class Form1 : Form
    {
        Taxi_Robocop robot; //Объект класса Taxi_Robobcop
        int w, h; //Размер игровой области
        int wr, hr; //Размер робота

        /// <summary>
        /// Запуск
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            w = pictureBox1TaxiRobocop.Width;
            h = pictureBox1TaxiRobocop.Height;
            wr = pictureBox1TaxiRobocop.Width;
            hr = pictureBox1TaxiRobocop.Height;
            robot = new Taxi_Robocop(); //Создание объекта
            robot.X = 242;
            robot.Y = 121;
            pictureBox1TaxiRobocop.Left = robot.X;
            pictureBox1TaxiRobocop.Top = robot.Y;
        }

        private void button1Right_Click(object sender, EventArgs e)
        {

            while (robot.X < 368)
            {
                robot.Walking("Right");
                pictureBox1TaxiRobocop.Left = robot.X;
                pictureBox1TaxiRobocop.Top = robot.Y;
                Thread.Sleep(100);
            }
            if (radioButton2.Checked)
            {
                while (robot.X > 242)
                {
                    robot.Walking("Left");
                    pictureBox1TaxiRobocop.Left = robot.X;
                    pictureBox1TaxiRobocop.Top = robot.Y;
                    Thread.Sleep(100);
                }
            }

        } 

        private void button2Left_Click(object sender, EventArgs e)
        {
            while (robot.X > 0)
            {
                robot.Walking("Left");
                pictureBox1TaxiRobocop.Left = robot.X;
                pictureBox1TaxiRobocop.Top = robot.Y;
                Thread.Sleep(100);
            }
            if (radioButton2.Checked)
            {
                while (robot.X < 242)
                {
                    robot.Walking("Right");
                    pictureBox1TaxiRobocop.Left = robot.X;
                    pictureBox1TaxiRobocop.Top = robot.Y;
                    Thread.Sleep(100);
                }
            }
        }

        private void button3Up_Click(object sender, EventArgs e)
        {
            while (robot.Y > 0)
            {
                robot.Walking("Up");
                pictureBox1TaxiRobocop.Left = robot.X;
                pictureBox1TaxiRobocop.Top = robot.Y;
                Thread.Sleep(100);
            }

            if (radioButton2.Checked)
            {
                while (robot.Y < 121)
                {
                    robot.Walking("Down");
                    pictureBox1TaxiRobocop.Left = robot.X;
                    pictureBox1TaxiRobocop.Top = robot.Y;
                    Thread.Sleep(100);
                }
            }
        }

        private void button4Down_Click(object sender, EventArgs e)
        {
            while (robot.Y < 211)
            {
                robot.Walking("Down");
                pictureBox1TaxiRobocop.Left = robot.X;
                pictureBox1TaxiRobocop.Top = robot.Y;
                Thread.Sleep(100);
            }
            if (radioButton2.Checked)
            {
                while (robot.Y > 121)
                {
                    robot.Walking("Up");
                    pictureBox1TaxiRobocop.Left = robot.X;
                    pictureBox1TaxiRobocop.Top = robot.Y;
                    Thread.Sleep(100);
                }
            }
        }

        private void pictureBox1TaxiRobocop_Click(object sender, EventArgs e)
        {

        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5ChargeUp_Click(object sender, EventArgs e)
        {

        }

        private void button6ChargeDown_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

# CALCULATOR 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernCalcApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MaximumSize = new Size(350, 447);
        }

        string oper;
        int countNum = 0, countOper = 0;

        private void Operation_Click(object sender, EventArgs e)
        {
            if (countNum != 0 && countOper == 0 && (sender as Button).Text != "=")
            {
                x = Convert.ToDouble(OutputBox.Text);
                oper = (sender as Button).Text;
                OutputBox.Text = oper;
                countNum = 0;
                countOper++;
            }
            if (countOper > 0 && countNum != 0)
            {
                y = Convert.ToDouble(OutputBox.Text);
                if (y == 0) { MessageBox.Show("Делить на ноль Нельзя!!!"); return; }
                switch (oper)
                {
                    case "/": x = x / y; break;
                    case "*": x = x * y; break;
                    case "+": x = x + y; break;
                    case "-": x = x - y; break;
                    case "mod": x = x % y; break;
                    default: return;
                }

                oper = (sender as Button).Text;
                if (oper == "=") { OutputBox.Text = x.ToString(); countOper = 0; }
                else { OutputBox.Text = oper; countNum = 0; }
            }
        }

        string writedown;
        double x = 0, y = 0;
        bool otric = false, zap = true;

        private void btnPlusMinus_Click(object sender, EventArgs e)
        {
            if (countNum > 0)
            {
                OutputBox.Text = Convert.ToString(Convert.ToDouble(OutputBox.Text)*-1);
            }
        }

        private void MemoryBtn_Click(object sender, EventArgs e)
        {
            Button btnClick = (Button)sender;
            if (btnClick.Tag.ToString() == "read") MemBox.Text = OutputBox.Text;
            else if (btnClick.Tag.ToString() == "clear") MemBox.Text = "";
            else if (btnClick.Tag.ToString() == "send" && MemBox.Text.Length > 0) { OutputBox.Text = MemBox.Text; countNum++; }
            else if (btnClick.Tag.ToString() == "plus" && MemBox.Text.Length > 0) MemBox.Text = Convert.ToString(Convert.ToDouble(OutputBox.Text) + Convert.ToDouble(MemBox.Text));
            else if (btnClick.Tag.ToString() == "minus" && MemBox.Text.Length > 0) MemBox.Text = Convert.ToString(Convert.ToDouble(MemBox.Text) - Convert.ToDouble(OutputBox.Text));
        }

        private void checkModeEng_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkModeEng.Checked)
            {
                this.Size = new Size(570, 447);
                this.MaximumSize = new Size(570, 447);
                this.MinimumSize = new Size(570, 447);
            }
            else
            {
                this.Size = new Size(350, 447);
                this.MaximumSize = new Size(350, 447);
                this.MinimumSize = new Size(350, 447);
            }
        }

        private void Eng1Oper_Click(object sender, EventArgs e)
        {
            Button btnSend = (Button) sender;
            switch (btnSend.Text)
            {
                case "√":
                    if (Convert.ToDouble(this.OutputBox.Text) >= 0) this.OutputBox.Text = Convert.ToString(Math.Sqrt(Convert.ToDouble(this.OutputBox.Text)));
                    break;

                case "x^2":
                    this.OutputBox.Text = Convert.ToString(Math.Pow(Convert.ToDouble(this.OutputBox.Text), 2));
                    break;

                case "lg":
                    if (Convert.ToDouble(this.OutputBox.Text) > 0) this.OutputBox.Text = Convert.ToString(Math.Log10(Convert.ToDouble(this.OutputBox.Text)));
                    break;

                case "ln":
                    if (Convert.ToDouble(this.OutputBox.Text) > 0) this.OutputBox.Text = Convert.ToString(Math.Log(Convert.ToDouble(this.OutputBox.Text)));
                    break;

                case "cos":
                    if (Convert.ToDouble(this.OutputBox.Text) <= 1 && Convert.ToDouble(this.OutputBox.Text) >= -1) this.OutputBox.Text = Convert.ToString(Math.Cos(Convert.ToDouble(this.OutputBox.Text)));
                    break;
            }
           
        }

        private void btnInsertPi_Click(object sender, EventArgs e)
        {
            string info = (sender as Button).Text;

            if (info == "Pi") this.OutputBox.Text = Math.PI.ToString();
            else if (info == "e") this.OutputBox.Text = Math.E.ToString();
            countNum++;

        }

        private void btnDock_Click(object sender, EventArgs e)
        {
            zap = true;
            foreach (char i in OutputBox.Text)
            {
                if (i == ',') zap = false;
            }
            if (zap && countNum != 0)
            {
                OutputBox.Text = OutputBox.Text + ",";
                countNum += 1;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if ((sender as Button) == btnClearAll)
            {
                countNum = 0;
                countOper = 0;
                OutputBox.Text = "0";
                x = 0;
                y = 0;
            }
            else if((sender as Button) == btnClearCh && countNum != 0)
            {
                countNum--;
                OutputBox.Text = OutputBox.Text.Substring(0, OutputBox.Text.Length-1);
                if (countNum == 0) OutputBox.Text = "0";
            }
        }

        private void Operation_NumberInput(object sender, EventArgs e)
        {
            writedown = (sender as Button).Text;
            if (countNum == 0)
            {
                if (oper == "=") oper = ""; 
                OutputBox.Text = "";
                
            }
            OutputBox.Text += writedown;
            countNum++;
        }
    }
}

# PASSWORD

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Password
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int tries = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            string pas = "0000";
            
            string pass = Convert.ToString(textBox1.Text);

            if (pas == pass)
            {
                MessageBox.Show("Верно. Добро пожаловать!");
                Form f2 = new Form2();
                f2.Owner = this;
                f2.Show();
            }
            else if (tries == 2)
            {
                MessageBox.Show("Попытки закончились","Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Enabled = false; //блокируем текстбокс
                return;
            }
            else if (tries < 2)
            {
                MessageBox.Show($"Неверно, попробуйте еще раз. Попытка {tries + 1} из 3.");
                tries++;
                textBox1.Text = "";
                textBox1.Focus();

                dR = label2.BackColor.R - label2.ForeColor.R; // Плавное появление текста
                dG = label2.BackColor.G - label2.ForeColor.G;
                dB = label2.BackColor.B - label2.ForeColor.B;
                sign = 1;
                Timer timer = new Timer();
                timer.Interval = 50;
                timer.Tick += timer1_Tick;
                timer.Start();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        int dR, dG, dB, sign;                   // Это тоже

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Math.Abs(label2.ForeColor.R - label2.BackColor.R) < Math.Abs(dR / 10))
            {
                sign *= -1;
                label2.Text = $"Попытка № {tries + 1}";
            }
            label2.ForeColor = Color.FromArgb(255, label2.ForeColor.R + sign * dR / 10, label2.ForeColor.G + sign * dG / 10, label2.ForeColor.B + sign * dB / 10);
            if (label2.BackColor.R == label2.ForeColor.R + dR)
            {
                ((Timer)sender).Stop();
            }
        }
    }
}

# RECIEPT

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Receipt
{
    public partial class Form1Receipt : Form
    {
        public Form1Receipt()
        {
            InitializeComponent();
        }

        double pr, disc, aodisc, aodisc1, tot, numof, nds, ttcd, fp, chan;

        private void button4Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();

            StreamWriter receipt = new StreamWriter(@"C:\Users\roman\Downloads\Receipt.txt");
            receipt.WriteLine(textBox1Abouttheproducts.Text);
            receipt.Close();

            System.Diagnostics.Process receipt1 = new System.Diagnostics.Process();
            receipt1.StartInfo.FileName = "notepad.exe";
            receipt1.StartInfo.Arguments = @"C:\Users\roman\Downloads\Receipt.txt";
            receipt1.Start();
        }

        private void textBox7Tothecashdesk_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox7Tothecashdesk.Text == "0")
            {
                textBox7Tothecashdesk.Text = "";
            }
        }

        private void textBox3Discount_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox3Discount.Text == "0")
            {
                textBox3Discount.Text = "";
            }
        }

        private void textBox2Price_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox2Price.Text == "0")
            {
                textBox2Price.Text = "";
            }
        }

        private void textBox2Price_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8 && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void button1Add_Click(object sender, EventArgs e)
        {
            pr = Convert.ToDouble(textBox2Price.Text);
            disc = Convert.ToDouble(textBox3Discount.Text);
            numof = Convert.ToDouble(numericUpDown1Numberof.Value);

            if (numof > 1)
            {
                pr = numof * pr;
                aodisc1 = (pr * disc) / 100;
                aodisc = aodisc1 / numof;
                textBox4Amountofdiscount.Text = aodisc.ToString();
                tot = pr - aodisc;
                textBox5Total.Text = tot.ToString();

                nds = Math.Round((Convert.ToDouble(textBox5Total.Text) * 20) / 120, 2);
            }
            else
            {
                aodisc = (pr * disc) / 100;
                textBox4Amountofdiscount.Text = aodisc.ToString();
                tot = pr - aodisc;
                textBox5Total.Text = tot.ToString();

                nds = Math.Round((Convert.ToDouble(textBox5Total.Text) * 20) / 120, 2);
            }

            fp += tot;
            textBox6Forpayment.Text = fp.ToString();
            textBox1Abouttheproducts.Text += numericUpDown1Numberof.Value + " " + comboBox1Productname.Text + " (discount: " + disc + " %)" + Environment.NewLine +
                                             "NDS: 20 % (" + nds + ")" + Environment.NewLine +
                                             "Amount of discount (for one product): " + aodisc + Environment.NewLine;
        }

        private void button3NewBuy_Click(object sender, EventArgs e)
        {
            textBox8AbouttheproductsCover.Visible = true;
            textBox1Abouttheproducts.Text = "";
            comboBox1Productname.SelectedIndex = -1;
            textBox2Price.Text = "0";
            numericUpDown1Numberof.Value = 0;
            textBox3Discount.Text = "0";
            textBox4Amountofdiscount.Text = "0";
            textBox5Total.Text = "0";
            textBox6Forpayment.Text = "0";
            textBox7Tothecashdesk.Text = "0";
        }

        private void button2Buy_Click(object sender, EventArgs e)
        {
            ttcd = Convert.ToDouble(textBox7Tothecashdesk.Text);
            chan = ttcd - fp;

            textBox8AbouttheproductsCover.Visible = false;

            textBox1Abouttheproducts.Text += Environment.NewLine + "FOR PAYMENT: " + fp + Environment.NewLine +
                                             "To the cash desk: " + ttcd + Environment.NewLine +
                                             "Change: " + chan + Environment.NewLine;
        }
    }
}

# PC

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCmanager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int price = 0;

        private void buttonOff_Click(object sender, EventArgs e)
        {
            price = 0;
            labelInfo.Text = "Итого: ";
            foreach (var i in Controls.OfType<GroupBox>())
            {
                foreach (var j in i.Controls.OfType<RadioButton>())
                {
                    j.Checked = false;
                }
                foreach (var j in i.Controls.OfType<CheckBox>())
                {
                    j.Checked = false;
                }
                pictureCpu.Image = new Bitmap(Properties.Resources.none);
                pictureVideo.Image = new Bitmap(Properties.Resources.none);
                pictureMome.Image = new Bitmap(Properties.Resources.none);
            }
            
        }

        private void buttonInfo_Click(object sender, EventArgs e)
        {
            price = 0;
            if (amdRd.Checked) price += 5000;
            else price += 10000;
            if (videocardRd3.Checked) price += 12300;
            else if (videocardRd2.Checked) price += 2500;
            if (mathRd1.Checked) price += 2000;
            else price += 1500;
            if (blockRd1.Checked) price += 500;
            else if (blockRd2.Checked) price += 1000;
            else if (blockRd3.Checked) price += 1500;
            else if (blockRd4.Checked) price += 2000;
            if (cpuRd1.Checked) price += 3000;
            else if (cpuRd2.Checked) price += 6000;
            else if (cpuRd3.Checked) price += 12000;
            else if (cpuRd4.Checked) price += 24000;
            if (bluetooth.Checked) price += 500;
            if (cdCard.Checked) price += 1000;
            if (audioCard.Checked) price += 1500;
            if (osRd1.Checked) price += 6000;
            else if (osRd2.Checked) price += 3000;
            if (antiVrd1.Checked) price += 4000;
            else if (antiVrd2.Checked) price += 2500;
            else if (antiVrd3.Checked) price += 3000;
            if (photoshop.Checked) price += 25000;
            if (aeff.Checked) price += 30000;
            if (c4D.Checked) price += 50000;
            if (msOffice.Checked) price += 7500;

            labelInfo.Text = $"Итого: {price.ToString()} руб."; 
        }
        





        private void CheckedChanged(object sender, EventArgs e)
        {
            if (amdRd.Checked) pictureCpu.Image = new Bitmap(Properties.Resources.amd);
            else pictureCpu.Image = new Bitmap(Properties.Resources.intel);
            if (videocardRd3.Checked) pictureVideo.Image = new Bitmap(Properties.Resources.nvidea);
            else if (videocardRd2.Checked) pictureVideo.Image = new Bitmap(Properties.Resources.amdVideo);
            else pictureVideo.Image = new Bitmap(Properties.Resources.none);
            if (mathRd1.Checked) pictureMome.Image = new Bitmap(Properties.Resources.gigabyte);
            else pictureMome.Image = new Bitmap(Properties.Resources.assRock);
        }
    }
}
