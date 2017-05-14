using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mouse_drag
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Point loc = new Point();

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            
            loc.X = e.Location.X + panel1.Location.X;
            loc.Y = e.Location.Y + panel1.Location.Y;
            panel1.Location = loc;
        }

    }
}
