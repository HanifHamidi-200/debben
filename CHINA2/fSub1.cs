using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CHINA2
{
    public partial class fSub1 : Form
    {
        private void fShow(int nMode)
        {
            pic1.Visible = false;
            pic2.Visible = false;
            pic3.Visible = false;

            switch (nMode)
            {
                case 1:
                    pic1.Visible = true;
                    break;
                case 2:
                    pic2.Visible = true;
                    break;
                default:
                    pic3.Visible = true;
                    break;
            }
        }
        public fSub1()
        {
            InitializeComponent();
            pic2.Left = pic1.Left;
            pic2.Top = pic1.Top;
            pic3.Left = pic1.Left;
            pic3.Top = pic1.Top;

        }

        private void FSub1_Load(object sender, EventArgs e)
        {
            fShow(1);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            fShow(1);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            fShow(2);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            fShow(3);
        }
    }
}
