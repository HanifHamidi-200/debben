using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EagleHAPS
{
    public partial class Form1 : Form
    {
        private String msShuffle;
        private String msShuffle2;
        private String msHome;
        private String msMask;
        private int mnCol, mnRow;
        private List<int> _MatchKeyX_Col3 = new List<int> { -1, 0, 1, -1, 0, 1, -1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private List<int> _MatchKeyY_Col3 = new List<int> { -1, -1, -1, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private List<int> _MatchKeyX_Col45 = new List<int> { -2, -1, 0, 1, 2, -2, -2, -2, 2, 2, 2, -2, -1, 0, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0 };
        private List<int> _MatchKeyY_Col45 = new List<int> { -2, -2, -2, -2, -2, -1, 0, 1, -1, 0, 1, 2, 2, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0 };
        private List<int> _MatchKeyX_Col67 = new List<int> { -3, -2, -1, 0, 1, 2, 3, -3, -3, -3, -3, -3, 3, 3, 3, 3, 3, -3, -2, -1, 0, 1, 2, 3 };
        private List<int> _MatchKeyY_Col67 = new List<int> { -3, -3, -3, -3, -3, -3, -3, -2, -1, 0, 1, 2, -2, -1, 0, 1, 2, 3, 3, 3, 3, 3, 3, 3 };
        private int mnHomes;
        private bool mbRed = true;

        private int fCount()
        {
            int nPos, nType;
            int nCount = 0;

            for (int i = 1; i <= 8; i++)
            {
                for (int j = 1; j <= 8; j++)
                {
                    nPos = (i - 1) * 8 + j;
                    nType = fHoletype(msShuffle2, nPos);
                    if (nType == 6)
                    {
                        nCount++;
                    }
                }
            }

            return nCount;
        }
        private void fClick(int nCol,int nRow)
        {
            mnCol = nCol;
            mnRow = nRow;
            fResetMask();
            fUpdateDisplay();
        
        }

        private void fNewCoordinates(int nAddX,int nAddY,ref int nX,ref int nY)
        {
            nX = mnCol + nAddX;
            nY = mnRow + nAddY;

            if (nX > 8)
            {
                nX -= 8;
            }
            else if (nX < 1)
            {
                nX += 8;
            }
            if (nY > 8)
            {
                nY -= 8;
            }
            else if (nY < 1)
            {
                nY += 8;
            }
        }
        private void fResetMask()
        {
            Random rnd1 = new Random();
            int nPos;
            String sTwo = null;
            int nColour, nCount;
            int nAddX,nAddY,nX=0, nY=0;

             msMask = null;

            for (int i = 1; i <= 64; i++)
            {
                sTwo = "01";
                msMask = msMask + sTwo;
            }

            nColour = rnd1.Next(3, 6);
            nCount = 9;

            for (int i = 1; i <= nCount; i++)
            {
                nAddX = _MatchKeyX_Col3[i - 1];
                nAddY = _MatchKeyY_Col3[i - 1];
                fNewCoordinates(nAddX, nAddY, ref nX, ref nY);
                nPos = (nX - 1) * 8 + nY;
                sTwo = "0" + Convert.ToString(nColour);
                fPlace2(sTwo, nPos);
            }

            nColour = rnd1.Next(3, 6);
            nCount = 16;

            for (int i = 1; i <= nCount; i++)
            {
                nAddX = _MatchKeyX_Col45[i - 1];
                nAddY = _MatchKeyY_Col45[i - 1];
                fNewCoordinates(nAddX, nAddY, ref nX, ref nY);
                nPos = (nX - 1) * 8 + nY;
                sTwo = "0" + Convert.ToString(nColour);
                fPlace2(sTwo, nPos);
            }

            nColour = rnd1.Next(3, 6);
            nCount = 24;

            for (int i = 1; i <= nCount; i++)
            {
                nAddX = _MatchKeyX_Col67[i - 1];
                nAddY = _MatchKeyY_Col67[i - 1];
                fNewCoordinates(nAddX, nAddY, ref nX, ref nY);
                nPos = (nX - 1) * 8 + nY;
                sTwo = "0" + Convert.ToString(nColour);
                fPlace2(sTwo, nPos);
            }
        }
        private void fReset()
        {
            Random rnd1 = new Random();
            int nCount = rnd1.Next(4, 15);
            int nCol = 1, nRow = 0;
            int nPos;
            String sTwo = null;

            msShuffle = "01020304050607080910111213141516171819202122232425262728293021323334353637383940414243444546474849505152535455565758596061626364";
            msShuffle2 = null;
            msMask = null;
            msHome = null;

            for (int i = 1; i <= 64; i++)
            {
                sTwo = "01";
                msShuffle2 = msShuffle2 + sTwo;
                msHome = msHome + sTwo;
            }

            for (int i = 1; i <= nCount; i++)
            {
                fFree(ref nCol, ref nRow);
                nPos = (nCol - 1) * 8 + nRow;
                fPlace("02", nPos);
            }

            nCount = rnd1.Next(2, 9);
            mnHomes = nCount;
            for (int i = 1; i <= nCount; i++)
            {
                fFree2(ref nCol, ref nRow);
                nPos = (nCol - 1) * 8 + nRow;
                fPlace3("06", nPos);
            }

            fUpdateDisplay();

        }

        private void fUpdateDisplay()
        {
            PictureBox _pic = new PictureBox();
            int nType, nRotate = 1;

            //1
            nType = fHoletype2(msShuffle2, 1);
            fPeek(nType, nRotate, ref _pic);
            pic11.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 2);
            fPeek(nType, nRotate, ref _pic);
            pic12.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 3);
            fPeek(nType, nRotate, ref _pic);
            pic13.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 4);
            fPeek(nType, nRotate, ref _pic);
            pic14.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 5);
            fPeek(nType, nRotate, ref _pic);
            pic15.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 6);
            fPeek(nType, nRotate, ref _pic);
            pic16.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 7);
            fPeek(nType, nRotate, ref _pic);
            pic17.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 8);
            fPeek(nType, nRotate, ref _pic);
            pic18.Image = _pic.Image;

            //2
            nType = fHoletype2(msShuffle2, 9);
            fPeek(nType, nRotate, ref _pic);
            pic21.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 10);
            fPeek(nType, nRotate, ref _pic);
            pic22.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 11);
            fPeek(nType, nRotate, ref _pic);
            pic23.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 12);
            fPeek(nType, nRotate, ref _pic);
            pic24.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 13);
            fPeek(nType, nRotate, ref _pic);
            pic25.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 14);
            fPeek(nType, nRotate, ref _pic);
            pic26.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 15);
            fPeek(nType, nRotate, ref _pic);
            pic27.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 16);
            fPeek(nType, nRotate, ref _pic);
            pic28.Image = _pic.Image;

            //3
            nType = fHoletype2(msShuffle2, 17);
            fPeek(nType, nRotate, ref _pic);
            pic31.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 18);
            fPeek(nType, nRotate, ref _pic);
            pic32.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 19);
            fPeek(nType, nRotate, ref _pic);
            pic33.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 20);
            fPeek(nType, nRotate, ref _pic);
            pic34.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 21);
            fPeek(nType, nRotate, ref _pic);
            pic35.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 22);
            fPeek(nType, nRotate, ref _pic);
            pic36.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 23);
            fPeek(nType, nRotate, ref _pic);
            pic37.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 24);
            fPeek(nType, nRotate, ref _pic);
            pic38.Image = _pic.Image;

            //4
            nType = fHoletype2(msShuffle2, 25);
            fPeek(nType, nRotate, ref _pic);
            pic41.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 26);
            fPeek(nType, nRotate, ref _pic);
            pic42.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 27);
            fPeek(nType, nRotate, ref _pic);
            pic43.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 28);
            fPeek(nType, nRotate, ref _pic);
            pic44.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 29);
            fPeek(nType, nRotate, ref _pic);
            pic45.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 30);
            fPeek(nType, nRotate, ref _pic);
            pic46.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 31);
            fPeek(nType, nRotate, ref _pic);
            pic47.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 32);
            fPeek(nType, nRotate, ref _pic);
            pic48.Image = _pic.Image;

            //5
            nType = fHoletype2(msShuffle2, 33);
            fPeek(nType, nRotate, ref _pic);
            pic51.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 34);
            fPeek(nType, nRotate, ref _pic);
            pic52.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 35);
            fPeek(nType, nRotate, ref _pic);
            pic53.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 36);
            fPeek(nType, nRotate, ref _pic);
            pic54.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 37);
            fPeek(nType, nRotate, ref _pic);
            pic55.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 38);
            fPeek(nType, nRotate, ref _pic);
            pic56.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 39);
            fPeek(nType, nRotate, ref _pic);
            pic57.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 40);
            fPeek(nType, nRotate, ref _pic);
            pic58.Image = _pic.Image;

            //6
            nType = fHoletype2(msShuffle2, 41);
            fPeek(nType, nRotate, ref _pic);
            pic61.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 42);
            fPeek(nType, nRotate, ref _pic);
            pic62.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 43);
            fPeek(nType, nRotate, ref _pic);
            pic63.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 44);
            fPeek(nType, nRotate, ref _pic);
            pic64.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 45);
            fPeek(nType, nRotate, ref _pic);
            pic65.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 46);
            fPeek(nType, nRotate, ref _pic);
            pic66.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 47);
            fPeek(nType, nRotate, ref _pic);
            pic67.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 48);
            fPeek(nType, nRotate, ref _pic);
            pic68.Image = _pic.Image;

            //7
            nType = fHoletype2(msShuffle2, 49);
            fPeek(nType, nRotate, ref _pic);
            pic71.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 50);
            fPeek(nType, nRotate, ref _pic);
            pic72.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 51);
            fPeek(nType, nRotate, ref _pic);
            pic73.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 52);
            fPeek(nType, nRotate, ref _pic);
            pic74.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 53);
            fPeek(nType, nRotate, ref _pic);
            pic75.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 54);
            fPeek(nType, nRotate, ref _pic);
            pic76.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 55);
            fPeek(nType, nRotate, ref _pic);
            pic77.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 56);
            fPeek(nType, nRotate, ref _pic);
            pic78.Image = _pic.Image;

            //8
            nType = fHoletype2(msShuffle2, 57);
            fPeek(nType, nRotate, ref _pic);
            pic81.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 58);
            fPeek(nType, nRotate, ref _pic);
            pic82.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 59);
            fPeek(nType, nRotate, ref _pic);
            pic83.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 60);
            fPeek(nType, nRotate, ref _pic);
            pic84.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 61);
            fPeek(nType, nRotate, ref _pic);
            pic85.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 62);
            fPeek(nType, nRotate, ref _pic);
            pic86.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 63);
            fPeek(nType, nRotate, ref _pic);
            pic87.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 64);
            fPeek(nType, nRotate, ref _pic);
            pic88.Image = _pic.Image;

            fUpdateStatus();
        }

        private void fUpdateStatus()
        {
            int nCount = fCount();
            String sText = "DONE = " + Convert.ToString(nCount) + "/" + Convert.ToString(mnHomes);

            lblDone.Text = sText;
        }

        private void fIcon()
        {
            PictureBox _pic = new PictureBox();
            int nType = 4;
            int nRotate = 1;

            switch (mnCol)
            {
                case 1:
                    switch (mnRow)
                    {
                        case 1:
                            fPeek(nType, nRotate, ref _pic);
                            pic11.Image = _pic.Image;
                            break;
                        case 2:
                            fPeek(nType, nRotate, ref _pic);
                            pic12.Image = _pic.Image;
                            break;
                        case 3:
                            fPeek(nType, nRotate, ref _pic);
                            pic13.Image = _pic.Image;
                            break;
                        case 4:
                            fPeek(nType, nRotate, ref _pic);
                            pic14.Image = _pic.Image;
                            break;
                        case 5:
                            fPeek(nType, nRotate, ref _pic);
                            pic15.Image = _pic.Image;
                            break;
                        case 6:
                            fPeek(nType, nRotate, ref _pic);
                            pic16.Image = _pic.Image;
                            break;
                        case 7:
                            fPeek(nType, nRotate, ref _pic);
                            pic17.Image = _pic.Image;
                            break;
                        default:
                            fPeek(nType, nRotate, ref _pic);
                            pic18.Image = _pic.Image;
                            break;
                    }
                    break;
                case 2:
                    switch (mnRow)
                    {
                        case 1:
                            fPeek(nType, nRotate, ref _pic);
                            pic21.Image = _pic.Image;
                            break;
                        case 2:
                            fPeek(nType, nRotate, ref _pic);
                            pic22.Image = _pic.Image;
                            break;
                        case 3:
                            fPeek(nType, nRotate, ref _pic);
                            pic23.Image = _pic.Image;
                            break;
                        case 4:
                            fPeek(nType, nRotate, ref _pic);
                            pic24.Image = _pic.Image;
                            break;
                        case 5:
                            fPeek(nType, nRotate, ref _pic);
                            pic25.Image = _pic.Image;
                            break;
                        case 6:
                            fPeek(nType, nRotate, ref _pic);
                            pic26.Image = _pic.Image;
                            break;
                        case 7:
                            fPeek(nType, nRotate, ref _pic);
                            pic27.Image = _pic.Image;
                            break;
                        default:
                            fPeek(nType, nRotate, ref _pic);
                            pic28.Image = _pic.Image;
                            break;
                    }
                    break;
                case 3:
                    switch (mnRow)
                    {
                        case 1:
                            fPeek(nType, nRotate, ref _pic);
                            pic31.Image = _pic.Image;
                            break;
                        case 2:
                            fPeek(nType, nRotate, ref _pic);
                            pic32.Image = _pic.Image;
                            break;
                        case 3:
                            fPeek(nType, nRotate, ref _pic);
                            pic33.Image = _pic.Image;
                            break;
                        case 4:
                            fPeek(nType, nRotate, ref _pic);
                            pic34.Image = _pic.Image;
                            break;
                        case 5:
                            fPeek(nType, nRotate, ref _pic);
                            pic35.Image = _pic.Image;
                            break;
                        case 6:
                            fPeek(nType, nRotate, ref _pic);
                            pic36.Image = _pic.Image;
                            break;
                        case 7:
                            fPeek(nType, nRotate, ref _pic);
                            pic37.Image = _pic.Image;
                            break;
                        default:
                            fPeek(nType, nRotate, ref _pic);
                            pic38.Image = _pic.Image;
                            break;
                    }
                    break;
                case 4:
                    switch (mnRow)
                    {
                        case 1:
                            fPeek(nType, nRotate, ref _pic);
                            pic41.Image = _pic.Image;
                            break;
                        case 2:
                            fPeek(nType, nRotate, ref _pic);
                            pic42.Image = _pic.Image;
                            break;
                        case 3:
                            fPeek(nType, nRotate, ref _pic);
                            pic43.Image = _pic.Image;
                            break;
                        case 4:
                            fPeek(nType, nRotate, ref _pic);
                            pic44.Image = _pic.Image;
                            break;
                        case 5:
                            fPeek(nType, nRotate, ref _pic);
                            pic45.Image = _pic.Image;
                            break;
                        case 6:
                            fPeek(nType, nRotate, ref _pic);
                            pic46.Image = _pic.Image;
                            break;
                        case 7:
                            fPeek(nType, nRotate, ref _pic);
                            pic47.Image = _pic.Image;
                            break;
                        default:
                            fPeek(nType, nRotate, ref _pic);
                            pic48.Image = _pic.Image;
                            break;
                    }
                    break;
                case 5:
                    switch (mnRow)
                    {
                        case 1:
                            fPeek(nType, nRotate, ref _pic);
                            pic51.Image = _pic.Image;
                            break;
                        case 2:
                            fPeek(nType, nRotate, ref _pic);
                            pic52.Image = _pic.Image;
                            break;
                        case 3:
                            fPeek(nType, nRotate, ref _pic);
                            pic53.Image = _pic.Image;
                            break;
                        case 4:
                            fPeek(nType, nRotate, ref _pic);
                            pic54.Image = _pic.Image;
                            break;
                        case 5:
                            fPeek(nType, nRotate, ref _pic);
                            pic55.Image = _pic.Image;
                            break;
                        case 6:
                            fPeek(nType, nRotate, ref _pic);
                            pic56.Image = _pic.Image;
                            break;
                        case 7:
                            fPeek(nType, nRotate, ref _pic);
                            pic57.Image = _pic.Image;
                            break;
                        default:
                            fPeek(nType, nRotate, ref _pic);
                            pic58.Image = _pic.Image;
                            break;
                    }
                    break;
                case 6:
                    switch (mnRow)
                    {
                        case 1:
                            fPeek(nType, nRotate, ref _pic);
                            pic61.Image = _pic.Image;
                            break;
                        case 2:
                            fPeek(nType, nRotate, ref _pic);
                            pic62.Image = _pic.Image;
                            break;
                        case 3:
                            fPeek(nType, nRotate, ref _pic);
                            pic63.Image = _pic.Image;
                            break;
                        case 4:
                            fPeek(nType, nRotate, ref _pic);
                            pic64.Image = _pic.Image;
                            break;
                        case 5:
                            fPeek(nType, nRotate, ref _pic);
                            pic65.Image = _pic.Image;
                            break;
                        case 6:
                            fPeek(nType, nRotate, ref _pic);
                            pic66.Image = _pic.Image;
                            break;
                        case 7:
                            fPeek(nType, nRotate, ref _pic);
                            pic67.Image = _pic.Image;
                            break;
                        default:
                            fPeek(nType, nRotate, ref _pic);
                            pic68.Image = _pic.Image;
                            break;
                    }
                    break;
                case 7:
                    switch (mnRow)
                    {
                        case 1:
                            fPeek(nType, nRotate, ref _pic);
                            pic71.Image = _pic.Image;
                            break;
                        case 2:
                            fPeek(nType, nRotate, ref _pic);
                            pic72.Image = _pic.Image;
                            break;
                        case 3:
                            fPeek(nType, nRotate, ref _pic);
                            pic73.Image = _pic.Image;
                            break;
                        case 4:
                            fPeek(nType, nRotate, ref _pic);
                            pic74.Image = _pic.Image;
                            break;
                        case 5:
                            fPeek(nType, nRotate, ref _pic);
                            pic75.Image = _pic.Image;
                            break;
                        case 6:
                            fPeek(nType, nRotate, ref _pic);
                            pic76.Image = _pic.Image;
                            break;
                        case 7:
                            fPeek(nType, nRotate, ref _pic);
                            pic77.Image = _pic.Image;
                            break;
                        default:
                            fPeek(nType, nRotate, ref _pic);
                            pic78.Image = _pic.Image;
                            break;
                    }
                    break;
                default:
                    switch (mnRow)
                    {
                        case 1:
                            fPeek(nType, nRotate, ref _pic);
                            pic81.Image = _pic.Image;
                            break;
                        case 2:
                            fPeek(nType, nRotate, ref _pic);
                            pic82.Image = _pic.Image;
                            break;
                        case 3:
                            fPeek(nType, nRotate, ref _pic);
                            pic83.Image = _pic.Image;
                            break;
                        case 4:
                            fPeek(nType, nRotate, ref _pic);
                            pic84.Image = _pic.Image;
                            break;
                        case 5:
                            fPeek(nType, nRotate, ref _pic);
                            pic85.Image = _pic.Image;
                            break;
                        case 6:
                            fPeek(nType, nRotate, ref _pic);
                            pic86.Image = _pic.Image;
                            break;
                        case 7:
                            fPeek(nType, nRotate, ref _pic);
                            pic87.Image = _pic.Image;
                            break;
                        default:
                            fPeek(nType, nRotate, ref _pic);
                            pic88.Image = _pic.Image;
                            break;
                    }
                    break;
            }
        }


         private void fFree(ref int nCol, ref int nRow)
        {
            Random rnd1 = new Random();
            bool bFound = false;
            int nType = 0, nPos = 0;

            do
            {
                nCol = rnd1.Next(1, 9);
                nRow = rnd1.Next(1, 9);
                nPos = (nCol - 1) * 8 + nRow;
                nType = fHoletype(msShuffle2, nPos);
                if (nType == 1)
                {
                    bFound = true;
                }
            } while (bFound != true);

        }
        private void fFree2(ref int nCol, ref int nRow)
        {
            Random rnd1 = new Random();
            bool bFound = false;
            int nType = 0, nPos = 0;

            do
            {
                nCol = rnd1.Next(1, 9);
                nRow = rnd1.Next(1, 9);
                nPos = (nCol - 1) * 8 + nRow;
                nType = fHoletype(msShuffle2, nPos);
                if (nType == 1)
                {
                    nType = fHoletype(msHome, nPos);
                    if (nType != 6)
                    {
                        bFound = true;
                    }
                }
            } while (bFound != true);

        }
        private void fPlace(String sText, int nPos)
        {
            msShuffle2 = msShuffle2.Substring(0, nPos * 2 - 2) + sText + msShuffle2.Substring(nPos * 2, (64 - nPos) * 2);
        }
        private void fPlace2(String sText, int nPos)
        {
            msMask = msMask.Substring(0, nPos * 2 - 2) + sText + msMask.Substring(nPos * 2, (64 - nPos) * 2);
        }
        private void fPlace3(String sText, int nPos)
        {
            msHome = msHome.Substring(0, nPos * 2 - 2) + sText + msHome.Substring(nPos * 2, (64 - nPos) * 2);
        }
        private int fHoletype(String sShuffle, int nSquare)
        {
            int nType = 0;

            nType = Convert.ToInt32(sShuffle.Substring(nSquare * 2 - 2, 2));
            return nType;
        }
        private int fHoletype2(String sShuffle, int nSquare)
        {
            int nType1 ,nType2,nType3;

            if (msMask == null)
            {
                nType2 = Convert.ToInt32(sShuffle.Substring(nSquare * 2 - 2, 2));
                return nType2;
            }

            nType1 = Convert.ToInt32(msMask.Substring(nSquare * 2 - 2, 2));
            nType2 = Convert.ToInt32(sShuffle.Substring(nSquare * 2 - 2, 2));
            nType3 = Convert.ToInt32(msHome.Substring(nSquare * 2 - 2, 2));

            switch (nType2)
            {
                case 2:
                    break;
                case 6:
                    break;
                default:
                    nType2 = nType1;
                    if (mbRed)
                    {
                        if (nType2 == 3)
                        {
                            if (nType3 == 6)
                            {
                                nType2 = 6;
                                fPlace("06", nSquare);

                            }
                        }

                    }
                    else
                    {
                        if (nType2 != 3)
                        {
                            if (nType3 == 6)
                            {
                                if (nType2 == 1)
                                {

                                }
                                else
                                {
                                    nType2 = 6;
                                    fPlace("06", nSquare);

                                }

                            }
                        }

                    }
                    break;
            }

            return nType2;
        }

        private void fPeek(int nValue, int nRotate, ref PictureBox _pic2)
        {
            PictureBox picture1 = new PictureBox
            {
                Name = "pictureBox1",
                Image = Image.FromFile(@"F space.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture2 = new PictureBox
            {
                Name = "pictureBox2",
                Image = Image.FromFile(@"F meteorite.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture3 = new PictureBox
            {
                Name = "pictureBox3",
                Image = Image.FromFile(@"F radar1.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture4 = new PictureBox
            {
                Name = "pictureBox4",
                Image = Image.FromFile(@"F radar2.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture5 = new PictureBox
            {
                Name = "pictureBox5",
                Image = Image.FromFile(@"F radar3.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture6 = new PictureBox
            {
                Name = "pictureBox6",
                Image = Image.FromFile(@"F viablehomeworld.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture7 = new PictureBox
            {
                Name = "pictureBox7",
                Image = Image.FromFile(@"F NullGate.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            switch (nValue)
            {
                case 1:
                    _pic2 = picture1;
                    break;
                case 2:
                    _pic2 = picture2;
                    break;
                case 3:
                    _pic2 = picture3;
                    break;
                case 4:
                    _pic2 = picture4;
                    break;
                case 5:
                    _pic2 = picture5;
                    break;
                case 6:
                    _pic2 = picture6;
                    break;
                default:
                    _pic2 = picture7;
                    break;
            }
            for (int i = 1; i <= nRotate - 1; i++)
            {
                _pic2.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }

        }

        public Form1()
        {
            InitializeComponent();
        }

        private void BtnQNext_Click(object sender, EventArgs e)
        {
            fReset();
        }

        //1
        private void Pic11_Click(object sender, EventArgs e)
        {
            fClick(1, 1);
        }

        private void Pic12_Click(object sender, EventArgs e)
        {
            fClick(1, 2);
        }

        private void Pic13_Click(object sender, EventArgs e)
        {
            fClick(1, 3);
        }

        private void Pic14_Click(object sender, EventArgs e)
        {
            fClick(1, 4);
        }

        private void Pic15_Click(object sender, EventArgs e)
        {
            fClick(1, 5);
        }

        private void Pic16_Click(object sender, EventArgs e)
        {
            fClick(1, 6);
        }

        private void Pic17_Click(object sender, EventArgs e)
        {
            fClick(1, 7);
        }

        private void Pic18_Click(object sender, EventArgs e)
        {
            fClick(1, 8);
        }

        //2
         private void Pic21_Click(object sender, EventArgs e)
        {
            fClick(2, 1);
        }

        private void Pic22_Click(object sender, EventArgs e)
        {
            fClick(2, 2);
        }

        private void Pic23_Click(object sender, EventArgs e)
        {
            fClick(2, 3);
        }

        private void Pic24_Click(object sender, EventArgs e)
        {
            fClick(2, 4);
        }

        private void Pic25_Click(object sender, EventArgs e)
        {
            fClick(2, 5);
        }

        private void Pic26_Click(object sender, EventArgs e)
        {
            fClick(2, 6);
        }

        private void Pic27_Click(object sender, EventArgs e)
        {
            fClick(2, 7);
        }

        private void Pic28_Click(object sender, EventArgs e)
        {
            fClick(2, 8);
        }

        //3
         private void Pic31_Click(object sender, EventArgs e)
        {
            fClick(3, 1);
        }

        private void Pic32_Click(object sender, EventArgs e)
        {
            fClick(3, 2);
        }

        private void Pic33_Click(object sender, EventArgs e)
        {
            fClick(3, 3);
        }

        private void Pic34_Click(object sender, EventArgs e)
        {
            fClick(3, 4);
        }

        private void Pic35_Click(object sender, EventArgs e)
        {
            fClick(3, 5);
        }

        private void Pic36_Click(object sender, EventArgs e)
        {
            fClick(3, 6);
        }

        private void Pic37_Click(object sender, EventArgs e)
        {
            fClick(3, 7);
        }

        private void Pic38_Click(object sender, EventArgs e)
        {
            fClick(3, 8);
        }

        //4
         private void Pic41_Click(object sender, EventArgs e)
        {
            fClick(4, 1);
        }

        private void Pic42_Click(object sender, EventArgs e)
        {
            fClick(4, 2);
        }

        private void Pic43_Click(object sender, EventArgs e)
        {
            fClick(4, 3);
        }

        private void Pic44_Click(object sender, EventArgs e)
        {
            fClick(4, 4);
        }

        private void Pic45_Click(object sender, EventArgs e)
        {
            fClick(4, 5);
        }

        private void Pic46_Click(object sender, EventArgs e)
        {
            fClick(4, 6);
        }

        private void Pic47_Click(object sender, EventArgs e)
        {
            fClick(4, 7);
        }

        private void Pic48_Click(object sender, EventArgs e)
        {
            fClick(4, 8);
        }

        //5
         private void Pic51_Click(object sender, EventArgs e)
        {
            fClick(5, 1);
        }

        private void Pic52_Click(object sender, EventArgs e)
        {
            fClick(5, 2);
        }

        private void Pic53_Click(object sender, EventArgs e)
        {
            fClick(5, 3);
        }

        private void Pic54_Click(object sender, EventArgs e)
        {
            fClick(5, 4);
        }

        private void Pic55_Click(object sender, EventArgs e)
        {
            fClick(5, 5);
        }

        private void Pic56_Click(object sender, EventArgs e)
        {
            fClick(5, 6);
        }

        private void Pic57_Click(object sender, EventArgs e)
        {
            fClick(5, 7);
        }

        private void Pic58_Click(object sender, EventArgs e)
        {
            fClick(5, 8);
        }

        //6
         private void Pic61_Click(object sender, EventArgs e)
        {
            fClick(6, 1);
        }

        private void Pic62_Click(object sender, EventArgs e)
        {
            fClick(6, 2);
        }

        private void Pic63_Click(object sender, EventArgs e)
        {
            fClick(6, 3);
        }

        private void Pic64_Click(object sender, EventArgs e)
        {
            fClick(6, 4);
        }

        private void Pic65_Click(object sender, EventArgs e)
        {
            fClick(6, 5);
        }

        private void Pic66_Click(object sender, EventArgs e)
        {
            fClick(6, 6);
        }

        private void Pic67_Click(object sender, EventArgs e)
        {
            fClick(6, 7);
        }

        private void Pic68_Click(object sender, EventArgs e)
        {
            fClick(6, 8);
        }

        //7
         private void Pic71_Click(object sender, EventArgs e)
        {
            fClick(7, 1);
        }

        private void Pic72_Click(object sender, EventArgs e)
        {
            fClick(7, 2);
        }

        private void Pic73_Click(object sender, EventArgs e)
        {
            fClick(7, 3);
        }

        private void Pic74_Click(object sender, EventArgs e)
        {
            fClick(7, 4);
        }

        private void Pic75_Click(object sender, EventArgs e)
        {
            fClick(7, 5);
        }

        private void Pic76_Click(object sender, EventArgs e)
        {
            fClick(7, 6);
        }

        private void Pic77_Click(object sender, EventArgs e)
        {
            fClick(7, 7);
        }

        private void Pic78_Click(object sender, EventArgs e)
        {
            fClick(7, 8);
        }

        //8
         private void Pic81_Click(object sender, EventArgs e)
        {
            fClick(8, 1);
        }

        private void Pic82_Click(object sender, EventArgs e)
        {
            fClick(8, 2);
        }

        private void Pic83_Click(object sender, EventArgs e)
        {
            fClick(8, 3);
        }

        private void Pic84_Click(object sender, EventArgs e)
        {
            fClick(8, 4);
        }

        private void Pic85_Click(object sender, EventArgs e)
        {
            fClick(8, 5);
        }

        private void Pic86_Click(object sender, EventArgs e)
        {
            fClick(8, 6);
        }

        private void Pic87_Click(object sender, EventArgs e)
        {
            fClick(8, 7);
        }

        private void Pic88_Click(object sender, EventArgs e)
        {
            fClick(8, 8);
        }

        private void BtnComply_Click(object sender, EventArgs e)
        {
            int nCount = fCount();

            if (nCount == mnHomes)
            {
                fReset();
            }
        }

        private void BtnRed_Click(object sender, EventArgs e)
        {
            if (mbRed)
            {
                mbRed = false;
                btnRed.Text = "red = OFF";
            }
            else
            {
                mbRed = true;
                btnRed.Text = "red = ON";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fReset();
        }
    }
}
