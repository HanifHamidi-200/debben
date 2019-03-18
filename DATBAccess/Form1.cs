using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DATBAccess
{
    public partial class Form1 : Form
    {
        private List<String> _colname = new List<String> { "Ajcolt", "Bemick", "Bomage", "Cornick", "Durant", "Fessilitude", "Golt", "Norraim", "Wellent", "Wesselpry" };
        private List<String> _rowname = new List<String> { "Cumnor", "Debben", "Ferrent", "Fossat", "Ijstack", "Juwise", "Lendon", "Qimash", "Seldry", "Sendry" };

        private List<int> _col1 = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private List<int> _col2 = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private List<int> _col3 = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private List<int> _col4 = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private List<int> _col5 = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private List<int> _col6 = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private List<int> _col7 = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private List<int> _col8 = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private List<int> _col9 = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private List<int> _col10 = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private int nNumber;
        private List<int> _questioncol=new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private List<int> _questionrow = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private List<int> _questionvalue = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        private void fCheck()
        {
            int nCol, nRow, nValue;
            String sValue, sCode = null;
            bool bFound = false;

            for (int i = 1; i <= 10; i++)
            {
                nCol = _questioncol[i - 1];
                nRow = _questionrow[i - 1];
                nValue = _questionvalue[i - 1];
                switch (i)
                {
                    case 1:
                        sValue = fCode(txtAnswer1.Text);
                        break;
                    case 2:
                        sValue = fCode(txtAnswer2.Text);
                        break;
                    case 3:
                        sValue = fCode(txtAnswer3.Text);
                        break;
                    case 4:
                        sValue = fCode(txtAnswer4.Text);
                        break;
                    case 5:
                        sValue = fCode(txtAnswer5.Text);
                        break;
                    case 6:
                        sValue = fCode(txtAnswer6.Text);
                        break;
                    case 7:
                        sValue = fCode(txtAnswer7.Text);
                        break;
                    case 8:
                        sValue = fCode(txtAnswer8.Text);
                        break;
                    case 9:
                        sValue = fCode(txtAnswer9.Text);
                        break;
                   default:
                        sValue = fCode(txtAnswer10.Text);
                        break;
                }
                sCode = sCode + sValue;
                if (nValue != Convert.ToInt32(sValue))
                {
                    bFound = true;
                }
            }

            if (bFound)
            {
                MessageBox.Show(sCode + " is not correct!", "Wrong");
            }
            else
            {
                fReset();
            }
        }

        private String fCode(String sText)
        {
            if (sText == "1")
            {
                return "1";
            }
            else if (sText == "0")
            {
                return "0";
            }
            else
            {
                return " ";
            }

        }
        private void fReset()
        {
            Random rnd1 = new Random();

            for(int i = 1; i <= 10; i++)
            {
                nNumber = rnd1.Next(1, 10);
                if (nNumber <= 5)
                {
                    _col1[i - 1] = 0;
                }
                else
                {
                    _col1[i - 1] = 1;
                }
                nNumber = rnd1.Next(1, 10);
                if (nNumber <= 5)
                {
                    _col2[i - 1] = 0;
                }
                else
                {
                    _col2[i - 1] = 1;
                }
                nNumber = rnd1.Next(1, 10);
                if (nNumber <= 5)
                {
                    _col3[i - 1] = 0;
                }
                else
                {
                    _col3[i - 1] = 1;
                }
                nNumber = rnd1.Next(1, 10);
                if (nNumber <= 5)
                {
                    _col4[i - 1] = 0;
                }
                else
                {
                    _col4[i - 1] = 1;
                }
                nNumber = rnd1.Next(1, 10);
                if (nNumber <= 5)
                {
                    _col5[i - 1] = 0;
                }
                else
                {
                    _col5[i - 1] = 1;
                }
                nNumber = rnd1.Next(1, 10);
                if (nNumber <= 5)
                {
                    _col6[i - 1] = 0;
                }
                else
                {
                    _col6[i - 1] = 1;
                }
                nNumber = rnd1.Next(1, 10);
                if (nNumber <= 5)
                {
                    _col7[i - 1] = 0;
                }
                else
                {
                    _col7[i - 1] = 1;
                }
                nNumber = rnd1.Next(1, 10);
                if (nNumber <= 5)
                {
                    _col8[i - 1] = 0;
                }
                else
                {
                    _col8[i - 1] = 1;
                }
                nNumber = rnd1.Next(1, 10);
                if (nNumber <= 5)
                {
                    _col9[i - 1] = 0;
                }
                else
                {
                    _col9[i - 1] = 1;
                }
                nNumber = rnd1.Next(1, 10);
                if (nNumber <= 5)
                {
                    _col10[i - 1] = 0;
                }
                else
                {
                    _col10[i - 1] = 1;
                }
            }

            for(int i = 1; i <= 10; i++)
            {
                _questioncol[i-1] = rnd1.Next(1, 11);
                _questionrow[i-1] = rnd1.Next(1, 11);
                _questionvalue[i - 1] = fValue(_questioncol[i - 1], _questionrow[i - 1]);
            }

            fUpdateDisplay();
        }

        private int fValue(int nCol,int nRow)
        {
            switch (nCol)
            {
                case 1:
                    return _col1[nRow - 1];
                case 2:
                    return _col2[nRow - 1];
                case 3:
                    return _col3[nRow - 1];
                case 4:
                    return _col4[nRow - 1];
                case 5:
                    return _col5[nRow - 1];
                case 6:
                    return _col6[nRow - 1];
                case 7:
                    return _col7[nRow - 1];
                case 8:
                    return _col8[nRow - 1];
                case 9:
                    return _col9[nRow - 1];
                default:
                    return _col10[nRow - 1];
            }
        }
        private void fUpdateDisplay()
        {
            int nCol, nRow;
            String sText;

            //1
            lbl11.Text = Convert.ToString(_col1[0]);
            lbl12.Text = Convert.ToString(_col1[1]);
            lbl13.Text = Convert.ToString(_col1[2]);
            lbl14.Text = Convert.ToString(_col1[3]);
            lbl15.Text = Convert.ToString(_col1[4]);
            lbl16.Text = Convert.ToString(_col1[5]);
            lbl17.Text = Convert.ToString(_col1[6]);
            lbl18.Text = Convert.ToString(_col1[7]);
            lbl19.Text = Convert.ToString(_col1[8]);
            lbl1a.Text = Convert.ToString(_col1[9]);

            //2
            lbl21.Text = Convert.ToString(_col2[0]);
            lbl22.Text = Convert.ToString(_col2[1]);
            lbl23.Text = Convert.ToString(_col2[2]);
            lbl24.Text = Convert.ToString(_col2[3]);
            lbl25.Text = Convert.ToString(_col2[4]);
            lbl26.Text = Convert.ToString(_col2[5]);
            lbl27.Text = Convert.ToString(_col2[6]);
            lbl28.Text = Convert.ToString(_col2[7]);
            lbl29.Text = Convert.ToString(_col2[8]);
            lbl2a.Text = Convert.ToString(_col2[9]);

            //3
            lbl31.Text = Convert.ToString(_col3[0]);
            lbl32.Text = Convert.ToString(_col3[1]);
            lbl33.Text = Convert.ToString(_col3[2]);
            lbl34.Text = Convert.ToString(_col3[3]);
            lbl35.Text = Convert.ToString(_col3[4]);
            lbl36.Text = Convert.ToString(_col3[5]);
            lbl37.Text = Convert.ToString(_col3[6]);
            lbl38.Text = Convert.ToString(_col3[7]);
            lbl39.Text = Convert.ToString(_col3[8]);
            lbl3a.Text = Convert.ToString(_col3[9]);

            //4
            lbl41.Text = Convert.ToString(_col4[0]);
            lbl42.Text = Convert.ToString(_col4[1]);
            lbl43.Text = Convert.ToString(_col4[2]);
            lbl44.Text = Convert.ToString(_col4[3]);
            lbl45.Text = Convert.ToString(_col4[4]);
            lbl46.Text = Convert.ToString(_col4[5]);
            lbl47.Text = Convert.ToString(_col4[6]);
            lbl48.Text = Convert.ToString(_col4[7]);
            lbl49.Text = Convert.ToString(_col4[8]);
            lbl4a.Text = Convert.ToString(_col4[9]);

            //5
            lbl51.Text = Convert.ToString(_col5[0]);
            lbl52.Text = Convert.ToString(_col5[1]);
            lbl53.Text = Convert.ToString(_col5[2]);
            lbl54.Text = Convert.ToString(_col5[3]);
            lbl55.Text = Convert.ToString(_col5[4]);
            lbl56.Text = Convert.ToString(_col5[5]);
            lbl57.Text = Convert.ToString(_col5[6]);
            lbl58.Text = Convert.ToString(_col5[7]);
            lbl59.Text = Convert.ToString(_col5[8]);
            lbl5a.Text = Convert.ToString(_col5[9]);

            //6
            lbl61.Text = Convert.ToString(_col6[0]);
            lbl62.Text = Convert.ToString(_col6[1]);
            lbl63.Text = Convert.ToString(_col6[2]);
            lbl64.Text = Convert.ToString(_col6[3]);
            lbl65.Text = Convert.ToString(_col6[4]);
            lbl66.Text = Convert.ToString(_col6[5]);
            lbl67.Text = Convert.ToString(_col6[6]);
            lbl68.Text = Convert.ToString(_col6[7]);
            lbl69.Text = Convert.ToString(_col6[8]);
            lbl6a.Text = Convert.ToString(_col6[9]);

            //7
            lbl71.Text = Convert.ToString(_col7[0]);
            lbl72.Text = Convert.ToString(_col7[1]);
            lbl73.Text = Convert.ToString(_col7[2]);
            lbl74.Text = Convert.ToString(_col7[3]);
            lbl75.Text = Convert.ToString(_col7[4]);
            lbl76.Text = Convert.ToString(_col7[5]);
            lbl77.Text = Convert.ToString(_col7[6]);
            lbl78.Text = Convert.ToString(_col7[7]);
            lbl79.Text = Convert.ToString(_col7[8]);
            lbl7a.Text = Convert.ToString(_col7[9]);

            //8
            lbl81.Text = Convert.ToString(_col8[0]);
            lbl82.Text = Convert.ToString(_col8[1]);
            lbl83.Text = Convert.ToString(_col8[2]);
            lbl84.Text = Convert.ToString(_col8[3]);
            lbl85.Text = Convert.ToString(_col8[4]);
            lbl86.Text = Convert.ToString(_col8[5]);
            lbl87.Text = Convert.ToString(_col8[6]);
            lbl88.Text = Convert.ToString(_col8[7]);
            lbl89.Text = Convert.ToString(_col8[8]);
            lbl8a.Text = Convert.ToString(_col8[9]);

            //9
            lbl91.Text = Convert.ToString(_col9[0]);
            lbl92.Text = Convert.ToString(_col9[1]);
            lbl93.Text = Convert.ToString(_col9[2]);
            lbl94.Text = Convert.ToString(_col9[3]);
            lbl95.Text = Convert.ToString(_col9[4]);
            lbl96.Text = Convert.ToString(_col9[5]);
            lbl97.Text = Convert.ToString(_col9[6]);
            lbl98.Text = Convert.ToString(_col9[7]);
            lbl99.Text = Convert.ToString(_col9[8]);
            lbl9a.Text = Convert.ToString(_col9[9]);

            //10
            lbla1.Text = Convert.ToString(_col10[0]);
            lbla2.Text = Convert.ToString(_col10[1]);
            lbla3.Text = Convert.ToString(_col10[2]);
            lbla4.Text = Convert.ToString(_col10[3]);
            lbla5.Text = Convert.ToString(_col10[4]);
            lbla6.Text = Convert.ToString(_col10[5]);
            lbla7.Text = Convert.ToString(_col10[6]);
            lbla8.Text = Convert.ToString(_col10[7]);
            lbla9.Text = Convert.ToString(_col10[8]);
            lblaa.Text = Convert.ToString(_col10[9]);

            for (int i = 1; i <= 10; i++)
            {
                nCol = _questioncol[i - 1];
                nRow = _questionrow[i - 1];
                sText = "(" + _colname[nCol - 1] + "," + _rowname[nRow - 1] + ")";
                switch (i)
                {
                    case 1:
                        lblQuestion1.Text = sText;
                        break;
                    case 2:
                        lblQuestion2.Text = sText;
                        break;
                    case 3:
                        lblQuestion3.Text = sText;
                        break;
                    case 4:
                        lblQuestion4.Text = sText;
                        break;
                    case 5:
                        lblQuestion5.Text = sText;
                        break;
                    case 6:
                        lblQuestion6.Text = sText;
                        break;
                    case 7:
                        lblQuestion7.Text = sText;
                        break;
                    case 8:
                        lblQuestion8.Text = sText;
                        break;
                    case 9:
                        lblQuestion9.Text = sText;
                        break;
                    case 10:
                        lblQuestion10.Text = sText;
                        break;

                }
            }
            txtAnswer1.Text = null;
            txtAnswer2.Text = null;
            txtAnswer3.Text = null;
            txtAnswer4.Text = null;
            txtAnswer5.Text = null;
            txtAnswer6.Text = null;
            txtAnswer7.Text = null;
            txtAnswer8.Text = null;
            txtAnswer9.Text = null;
            txtAnswer10.Text = null;

        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fReset();
        }

        private void BtnQNext_Click(object sender, EventArgs e)
        {
            fReset();
        }

        private void BtnComply_Click(object sender, EventArgs e)
        {
            fCheck();
        }
    }
}
