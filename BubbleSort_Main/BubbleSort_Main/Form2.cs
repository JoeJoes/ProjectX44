using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BubbleSort_Main
{
    public partial class newTestForm : Form
    {
        private readonly mainForm _mainForm;

        public newTestForm(mainForm form)
        {
            InitializeComponent();
            this._mainForm = form;
            this._mainForm.start = 2;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int set_tests = 0;
            int set_sNum = 0;
            int set_step = 0;
            int set_repeat = 0;
            int set_min = 0;
            int set_max = 0;

            try
            {
                set_tests = Convert.ToInt32(textBox1.Text);
                set_sNum = Convert.ToInt32(textBox2.Text);
                set_step = Convert.ToInt32(textBox3.Text);
                set_repeat = Convert.ToInt32(textBox4.Text);
                set_min = Convert.ToInt32(textBox5.Text);
                set_max = Convert.ToInt32(textBox6.Text);
            }
            catch
            {
                MessageBox.Show("CHYBA: Neplatný formát dat");
                return;
            }

            if (set_tests < 5 || set_tests > 20 ||
                set_sNum < 0 ||
                set_step < 0 ||
                set_repeat < 5 || set_repeat > 20 ||
                set_min > set_max) 
            {
                MessageBox.Show("CHYBA: Neplatná/é hodnoty");
            }
            else
            {
                this._mainForm.param[0] = set_tests;
                this._mainForm.param[1] = set_sNum;
                this._mainForm.param[2] = set_step;
                this._mainForm.param[3] = set_repeat;
                this._mainForm.param[4] = set_min;
                this._mainForm.param[5] = set_max;
                this._mainForm.start = 1;

                //this.Hide();
                
                //this._mainForm.bubbleSort(set_tests, set_sNum, set_step, set_repeat, set_min, set_max);
                this.Close();
            }
           
        }
    }
}
