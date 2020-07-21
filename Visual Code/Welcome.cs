using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

namespace Visual_Code
{
    public partial class Welcome : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );
        public Welcome()
        {
            //Thread.Sleep(2000);
            //this.Hide();
            //Nqueen frm = new Nqueen();
            //frm.Show();
            InitializeComponent();
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 60, 60));
        }

        private void gunaCirclePictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void pictureBox2_Click(object sender, EventArgs e)
        //{
       

        //}

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Nqueen frm = new Nqueen();
            frm.Show();
        }

        //private void gunaCirclePictureBox3_Click(object sender, EventArgs e)
        //{
        //    this.Hide();
        //    Nqueen frm = new Nqueen();
        //    frm.Show();
        //}
    }
}
