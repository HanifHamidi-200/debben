using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YULEYF
{
    public partial class Form1 : Form
    {
        private List<int> _col1 = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private List<int> _col2 = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private List<int> _col3 = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private List<int> _col4 = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private List<int> _col5 = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private List<int> _count = new List<int> { 0, 0, 0, 0, 0 };

        private void fReset()
        {
            Random rnd1 = new Random();

            for (int i = 1; i <= 20; i++)
            {
                _col1[i - 1] = rnd1.Next(1, 201);
                _col2[i - 1] = rnd1.Next(1, 201);
                _col3[i - 1] = rnd1.Next(1, 201);
                _col4[i - 1] = rnd1.Next(1, 201);
                _col5[i - 1] = rnd1.Next(1, 201);
            }
            for(int i = 1; i <= 5; i++)
            {
                _count[i - 1] = rnd1.Next(4, 21);
            }

            fUpdateDisplay();
        }

        private void fUpdateDisplay()
        {
            if (lst1.Items.Count > 0)
            {
                do
                {
                    lst1.Items.RemoveAt(0);
                } while (lst1.Items.Count > 0);
            }
            if (lst2.Items.Count > 0)
            {
                do
                {
                    lst2.Items.RemoveAt(0);
                } while (lst2.Items.Count > 0);
            }
            if (lst3.Items.Count > 0)
            {
                do
                {
                    lst3.Items.RemoveAt(0);
                } while (lst3.Items.Count > 0);
            }
            if (lst4.Items.Count > 0)
            {
                do
                {
                    lst4.Items.RemoveAt(0);
                } while (lst4.Items.Count > 0);
            }
            if (lst5.Items.Count > 0)
            {
                do
                {
                    lst5.Items.RemoveAt(0);
                } while (lst5.Items.Count > 0);
            }

            for(int i = 1; i <= _count[0]; i++)
            {
                lst1.Items.Add(_col1[i - 1]);
            }
            for (int i = 1; i <= _count[1]; i++)
            {
                lst2.Items.Add(_col2[i - 1]);
            }
            for (int i = 1; i <= _count[2]; i++)
            {
                lst3.Items.Add(_col3[i - 1]);
            }
            for (int i = 1; i <= _count[3]; i++)
            {
                lst4.Items.Add(_col4[i - 1]);
            }
            for (int i = 1; i <= _count[4]; i++)
            {
                lst5.Items.Add(_col5[i - 1]);
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Lst2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fReset();
        }

        private void BtnQNext_Click(object sender, EventArgs e)
        {
            fReset();
        }

        private void BtnOpen1_Click(object sender, EventArgs e)
        {
            fSub1 _dlg = new fSub1();
            _dlg.ShowDialog();
        }
        
        private void BtnOpen2_Click(object sender, EventArgs e)
        {
            fSub2 _dlg = new fSub2();
            _dlg.ShowDialog();

        }

        private void BtnOpen3_Click(object sender, EventArgs e)
        {
            fSub3 _dlg = new fSub3();
            _dlg.ShowDialog();

        }

        private void BtnOpen4_Click(object sender, EventArgs e)
        {
            fSub4 _dlg = new fSub4();
            _dlg.ShowDialog();

        }

        private void BtnOpen5_Click(object sender, EventArgs e)
        {
            fSub5 _dlg = new fSub5();
            _dlg.ShowDialog();

        }
    }
}
