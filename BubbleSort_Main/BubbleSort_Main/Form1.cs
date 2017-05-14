using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

/*
    Program na ověření časové závislosti řadícího algorytmu bubblesort
    vytvořil: Tomáš Orlovský
    --------------------------------------------------------------------------------------------
    poznámky k programu:

    Tento program je modulární, aby bylo možné jednoduše implementovat jiné řadící algorytmy a měnit hodnoty pro řazení.

    Test s defaultními (i s vlastními) hodnotami ukázal, že teoretická hodnota, vypočítaná z testu dvou prvků, nekoresponduje s naměřenými výsledky.
    Vysvětluji si to jedině tak, že seřazení dvou prvků nemá dostatečnou prioritu, tudíž výsledný čas je (odhad z mého pozorování) asi 20x vyšší, než když si třízení více prvků vyžádá více prostředků.
    
    Z toho důvodu mnou vytvořený graf ukazuje téměř lineární charakteristiku, protože má stejné měřítko.

    Testoval jsem i ručně nastavit prioritu ve správci úloh s nulovým účinkem.

    To znamená že tento výpočet ovlivňuje něco jiného, ovšem nezjistil jsem co.
*/

namespace BubbleSort_Main
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        public int[] param = new int[6];
        public byte start = 0;
        public double[] sum;
        public double[] refer;
        public double scale = 1;

        public void bubbleSort(int tests, int sNum, int step, int repeat, int min, int max)
        {
            sum = new double[tests];
            refer = new double[tests];

       
        mainForm.ActiveForm.Focus();
            int num = sNum;
            if (tests <= 20 && tests >= 5
                && sNum + tests * step <= 100000000) 
            {
                log.Items.Clear();
                log.Items.Add("Zahajuji testování");
                log.Items.Add("Vytvářím generátor náhodných čísel");
                Random rnd = new Random();
                for(int t = 0; t < tests; t++)
                {
                    log.Items.Add("Zahajuji testování pro " + num + " prvků");
                    int[] N = new int[num];
                    for (int r = 1; r <= repeat; r++)
                    {
                        log.Items.Add("Generuji nová čísla");
                        for(int n=0; n < num; n++)
                        {
                            N[n] = rnd.Next(min, max + 1);
                        }
                        log.Items.Add("Zahajuji test č." + r + " pro " + num + " počet prvků");
                        sum[t] += bubbleSortTest(N);
                    }
                    sum[t] = sum[t] / repeat;
                    num += step;
                }
            }
            int[] T = {1,0};
            double refert;
            do
            {
                refert = bubbleSortTest(T) / 2;
            } while (refert == 0);
            
            for (int i = 0; i < tests; i++)
            {
                refer[i] = ((sNum + (step * i))* (sNum + (step * i)) * refert) / 2;
                log.Items.Add("Výsledek pro "+ (sNum+step* i)+" počet prvků: "+ sum[i]+"s ... teoretický čas: "+refer[i]);

            }
            if (sum[sum.Length - 1] > refer[refer.Length - 1]) scale = sum[sum.Length - 1];
            else scale = refer[refer.Length - 1];
            panel1.Refresh();
        }

        private double bubbleSortTest(int[] num)
        {
            Stopwatch time = new Stopwatch();
            int n;
            n = num.Length;
            int c;
            int p = 0;
            time.Start();
            for (int y = 0; y < n - 1; y++)
            {
                p++;
                for (int i = 0; i < n - p; i++)
                {
                    if (num[i] > num[i + 1])
                    {
                        c = num[i];
                        num[i] = num[i + 1];
                        num[i + 1] = c;
                    }
                }

            }
            time.Stop();
            log.Items.Add("Test dokončen (" + time.Elapsed.TotalSeconds + ")");
            return (time.Elapsed.TotalSeconds);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics kp = e.Graphics;
            
            
                

            for (int i = 1; i < param[0]; i++)
            {
                kp.DrawLine(Pens.Green, (panel1.Width / param[0] * (i - 1)), panel1.Height - (float)(panel1.Height / scale * sum[i - 1]), (panel1.Width / param[0] * (i)), panel1.Height - (float)(panel1.Height / scale * sum[i]));
                kp.DrawLine(Pens.Blue, (panel1.Width / param[0] * (i - 1)), panel1.Height - (float)(panel1.Height / scale * refer[i - 1]), (panel1.Width / param[0] * (i)), panel1.Height - (float)(panel1.Height / scale * refer[i]));
            }

        }

        private void newTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newForm = new newTestForm(this);
            newForm.ShowDialog();

            while (start == 0)
            {
                System.Threading.Thread.Sleep(100);
            }
            switch (start)
            {
                case 1:
                    start = 0;
                    bubbleSort(param[0], param[1], param[2], param[3], param[4], param[5]);
                    break;
                case 2:
                    start = 0;
                    break;
            }
        }

        private void mainForm_SizeChanged(object sender, EventArgs e)
        {
            log.Height = panel1.Size.Height - 87;
            panel1.Width = mainForm.ActiveForm.Size.Width - 396;
            panel1.Refresh();
        }
    }
}
