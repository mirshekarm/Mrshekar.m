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
using System.Globalization;

namespace ShutdownTimerForm
{
    public partial class Form1 : Form
    {
        //Value
        int HourInput;
        int MinuteInput;
        int SecondInput;
        string strUserDate = null;
        string strSystemDate = null;
        int YearInput;
        int MonthInput;
        int DayInput;
        Thread objThread2;
        DateTime userDate;
        Thread objThread3;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {






        }

        //Button Start Method
        private void button1_Click(object sender, EventArgs e)
        {
            //comment
            btnStart.Enabled = false;
            txtStatus.Text = "Running";

            //Input Value
            HourInput = Convert.ToInt32(txtHour.Text);
            MinuteInput = Convert.ToInt32(txtMinute.Text);
            SecondInput = Convert.ToInt32(txtSecond.Text);
            YearInput = Convert.ToInt32(txtYear.Text);
            MonthInput = Convert.ToInt32(txtMonth.Text);
            DayInput = Convert.ToInt32(txtDay.Text);



            //Analys Input Value and Convert to String
            userDate = new DateTime(YearInput, MonthInput, DayInput, HourInput, MinuteInput, SecondInput);
            strUserDate = userDate.ToUniversalTime().ToString("u");


            //start New Thread or Start Timer
            
            
            
            objThread2 = new Thread(Thread2);
            objThread2.Start();
            

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtMinute_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSecond_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }


        private void txtStatus_TextChanged(object sender, EventArgs e)
        {

        }

        //new Thread(Method)
        public void Thread2()
        {
            //Checking System Date and check systemDate == strUserDate
            while (true)
            {
                DateTime dateNow = DateTime.Now;
                string systemDate = dateNow.ToUniversalTime().ToString("u");


                if (systemDate == strUserDate)
                {
                    MessageBox.Show("shutdowning...");
                    Thread.Sleep(6000);
                    //shutdown System
                    System.Diagnostics.Process.Start("shutdown", "/s /t 0");
                    


                }

                Thread.Sleep(1000);
            }

        }
        
        

        //Timer 
        private void timer1_Tick(object sender, EventArgs e)
        {

            var strSystemDate = DateTime.Now.ToString("HH:mm:ss");
            txtTime.Text = strSystemDate;
        }



        //Button Stop Method
        private void btnStop_Click(object sender, EventArgs e)
        {
            //Stop Timer
            //if (btnStart.Enabled == true)
            //{
            //    MessageBox.Show("Pleas Start a Progress than Stop");
            //}
            //else if (btnStart.Enabled == false)
            //{
            //    timer1.Stop();
            //    btnStart.Enabled = true;
            //txtStatus.Text = "Stoped";
            //}

            //Stop Thread
            if (btnStart.Enabled == true)
            {
                MessageBox.Show("Pleas Start a Progress than Stop");

            }
            else if (btnStart.Enabled == false)
            {
                objThread2.Abort();
                btnStart.Enabled = true;
                txtStatus.Text = "Stoped";
            }


        }

        //CheckBox Method
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {


            if (checkBox1.Checked)
            {


                int Year = Convert.ToInt32(DateTime.Now.ToString("yyyy"));
                int Month = Convert.ToInt32(DateTime.Now.ToString("MM"));
                int Day = Convert.ToInt32(DateTime.Now.ToString("dd"));

                PersianCalendar pc = new PersianCalendar();
                DateTime convertShamsiToGhamari = new DateTime(Year, Month, Day, pc);

                txtYear.Text = convertShamsiToGhamari.Year.ToString();
                txtMonth.Text = convertShamsiToGhamari.Month.ToString();
                txtDay.Text = convertShamsiToGhamari.Day.ToString();
            }
            else
            {
                txtYear.Text = null;
                txtMonth.Text = null;
                txtDay.Text = null;
            }
        }

        private void txtTime_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
