using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.PowerPoint;
using Microsoft.Office.Core;
using LineEditor;
using System.Collections;
using System.Drawing.Drawing2D;

namespace CDRatio
{
    public partial class Form1 : Form
    {
        Microsoft.Office.Interop.PowerPoint.Application m_oApplication = new Microsoft.Office.Interop.PowerPoint.Application();
        Microsoft.Office.Interop.PowerPoint.Presentations m_oPresentations;
        Microsoft.Office.Interop.PowerPoint.Presentation m_oPresentation;
        int m_iNumberOfSlides = 0;
        int m_iCurrentSlide = 1;
        Bitmap bmpBackLeft = null;
        Bitmap bmpBackRight = null;
        private bool isSelected = false;
        private bool m_bHorizontalMode = false;
        private int _X, _Y;
        private ArrayList Lines = null;
        private string VERTICALSTR = "Vertical: ";
        private string HORIZONTALSTR = "Horizontal: ";
        private char SEPERATORPWRPNT = ';';

        private void InitiateMembers()
        {
             m_iNumberOfSlides = 0;
             m_iCurrentSlide = 1;
             bmpBackLeft = null;
             bmpBackRight = null;
             bool isSelected = false;
             bool m_bHorizontalMode = false;
             int _X, _Y;
             ArrayList Lines = null;
             pictureBox1.Image = null;
        }
        private struct Line
        {
            public MarkControl mark1;
            public MarkControl mark2;
            public int Width;
            public Color lineColor;
        }
        public Form1()
        {
            InitializeComponent();
            InitiateMembers();
            m_oPresentations = m_oApplication.Presentations;
            Lines = new ArrayList();

            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        int m_iTextIndex = 1;
        int m_iPictureIndex1 = 2;
        int m_iPictureIndex2 = 3;
        private bool RefreshValuesBasedOnSlide(int a_iSlide)
        {
            bool l_bRefreshedValues = false;
            int l_iTextIndex = 1;
            Slide l_oSlide = m_oPresentation.Slides[a_iSlide];
            for (int l_iShapeIndex = 1; l_iShapeIndex <= 3; l_iShapeIndex++)
            {
                if (l_oSlide.Shapes[l_iShapeIndex].HasTextFrame == MsoTriState.msoTrue)
                {
                    m_iTextIndex = l_iShapeIndex;
                    if (m_iTextIndex == 3)
                    {
                        m_iPictureIndex1 = 1;
                        m_iPictureIndex2 = 2;
                    }
                    else
                    {
                        m_iPictureIndex1 = 2;
                        m_iPictureIndex2 = 3;
                    }
                    break;
                }
            }
            if (l_oSlide.Shapes[m_iTextIndex].HasTextFrame == MsoTriState.msoTrue)
            {
                l_bRefreshedValues = true;
                string[] l_asTopTexts = l_oSlide.Shapes[m_iTextIndex].TextFrame.TextRange.Text.Split(new char[] { SEPERATORPWRPNT });
                if (l_asTopTexts.Length == 1)
                {
                    TitleTxt.Text = l_asTopTexts[0];
                    VerticalRatioLbl.Text = VERTICALSTR + "NA";
                    HorizontalRatioLbl.Text = HORIZONTALSTR + "NA";
                }
                else if (l_asTopTexts.Length == 2)
                {
                    TitleTxt.Text = l_asTopTexts[0];

                    string l_sSecondPiece = l_asTopTexts[1];
                    if (l_sSecondPiece.Contains(VERTICALSTR))
                    {
                        VerticalRatioLbl.Text = l_sSecondPiece;
                        HorizontalRatioLbl.Text = HORIZONTALSTR + "NA";
                    }
                    else
                    {
                        VerticalRatioLbl.Text = VERTICALSTR + ": NA";
                        HorizontalRatioLbl.Text = HORIZONTALSTR + "NA";
                    }
                }
                else if (l_asTopTexts.Length == 3)
                {
                    TitleTxt.Text = l_asTopTexts[0];

                    string l_sSecondPiece = l_asTopTexts[1];
                    if (l_sSecondPiece.Contains(VERTICALSTR))
                    {
                        VerticalRatioLbl.Text = l_sSecondPiece;
                    }
                    else
                    {
                        VerticalRatioLbl.Text = VERTICALSTR + "NA";
                    }

                    string l_sThirdPiece = l_asTopTexts[2];
                    if (l_sThirdPiece.Contains(HORIZONTALSTR))
                    {
                        HorizontalRatioLbl.Text = l_sThirdPiece;
                    }
                    else
                    {
                        HorizontalRatioLbl.Text = HORIZONTALSTR + "NA";
                    }
                }
            }
            return l_bRefreshedValues;
        }
        private bool ShowSlide(int a_iSlide)
        {
            bool l_bSlideShown = false;
            Slide l_oSlide = m_oPresentation.Slides[a_iSlide];
            if (RefreshValuesBasedOnSlide(a_iSlide))
            {
                if (SetPictureboxToShape(pictureBox1, ref bmpBackLeft, l_oSlide.Shapes[m_iPictureIndex1]))
                {
                    l_oOriginalImageBeforeScrollLeft = bmpBackLeft;
                    if (SetPictureboxToShape(pictureBox2, ref bmpBackRight, l_oSlide.Shapes[m_iPictureIndex2]))
                    {
                        l_oOriginalImageBeforeScrollRight = bmpBackRight;
                        l_bSlideShown = true;
                    }
                }
            }
            return l_bSlideShown;
        }

        private bool SetPictureboxToShape(PictureBox a_oPB, ref Bitmap a_oImg, Microsoft.Office.Interop.PowerPoint.Shape a_oShape)
        {
            bool l_bSuccess = false;
            a_oPB.Width = 431;
            a_oPB.Height = 333;
            if (a_oShape.Type == MsoShapeType.msoPicture)
            {
                a_oShape.Copy();
                bool l_bImgOK = Clipboard.ContainsImage();
                if (l_bImgOK)
                {
                    Image img = Clipboard.GetImage();
                    a_oImg = new Bitmap(img);
                    a_oPB.Image = img;
                    l_bSuccess = true;
                }
            }
            return l_bSuccess;
        }

        private bool m_bLinesAdded = false;
        private void ChooseBtn_Click(object sender, EventArgs e)
        {
            PrevBtn.Enabled = false;
            NextBtn.Enabled = false;
            DialogResult l_oResult = openFileDialog1.ShowDialog();
            if (l_oResult == DialogResult.OK)
            {
                m_oPresentation = m_oPresentations.Open(openFileDialog1.FileName, MsoTriState.msoFalse, MsoTriState.msoFalse, MsoTriState.msoFalse);
                m_iNumberOfSlides = m_oPresentation.Slides.Count;
                if (m_iNumberOfSlides > 0)
                {
                    m_iCurrentSlide = 1;
                    ShowSlide(m_iCurrentSlide);
                }
                if (m_iNumberOfSlides > 1)
                {
                    NextBtn.Enabled = true;
                }
                if (!m_bLinesAdded)
                {
                    m_oDiscLine = AddMarkingLines(pictureBox1, bmpBackLeft, Color.LightGreen, Color.LightGreen);
                    m_oCupLine = AddMarkingLines(pictureBox1, bmpBackLeft, Color.DarkBlue, Color.DarkBlue);            
                    m_bLinesAdded = true;
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_oPresentation != null)
                m_oPresentation.Close();
        }

        private void NextBtn_Click(object sender, EventArgs e)
        {
            m_iCurrentSlide++;
            ShowSlide(m_iCurrentSlide);
            if (m_iCurrentSlide >= m_iNumberOfSlides)
            {
                NextBtn.Enabled = false;
            }
            PrevBtn.Enabled = true;
        }

        private void PrevBtn_Click(object sender, EventArgs e)
        {
            m_iCurrentSlide--;
            ShowSlide(m_iCurrentSlide);
            if (m_iCurrentSlide <= 2)
            {
                PrevBtn.Enabled = false;
            }
            NextBtn.Enabled = true;
        }


        private int Distance2D(int x1, int y1, int x2, int y2)
        {
            int result = 0;
            
            double part1 = Math.Pow((x2 - x1), 2);

            double part2 = Math.Pow((y2 - y1), 2);

            double underRadical = part1 + part2;

            result = (int)Math.Sqrt(underRadical);
            
            return result;
        }

        private void CalculateBtn_Click(object sender, EventArgs e)
        {
            CalculateRatios();
        }

        private void CalculateRatios()
        {
            if ((m_oCupLine.mark1 != null) && (m_oCupLine.mark2 != null) && (m_oDiscLine.mark1 != null) && (m_oDiscLine.mark2 != null))
            {
                int l_iCupDistance = Distance2D(blue_xymark1[0], blue_xymark1[1], blue_xymark2[0], blue_xymark2[1]);
                int l_iDiscDistance = Distance2D(green_xymark1[0], green_xymark1[1], green_xymark2[0], green_xymark2[1]);
                RatioTxt.Text = String.Format("{0:0.00}", Convert.ToDouble(l_iCupDistance) / Convert.ToDouble(l_iDiscDistance));
                if (Math.Abs(green_xymark1[0] - green_xymark2[0]) > Math.Abs(green_xymark1[1] - green_xymark2[1]))
                {
                    m_bHorizontalMode = true;
                    ModeLbl.Text = "H";
                }
                else
                {
                    m_bHorizontalMode = false;
                    ModeLbl.Text = "V";
                }
            }
        }

        private void AddResultBtn_Click(object sender, EventArgs e)
        {
            Slide l_oSlide = m_oPresentation.Slides[m_iCurrentSlide];
            if (m_bHorizontalMode)
            {
                l_oSlide.Shapes[m_iTextIndex].TextFrame.TextRange.Text = TitleTxt.Text + ";" + VerticalRatioLbl.Text + ";" + "Horizontal: " + RatioTxt.Text.Substring(0, 4);
            }
            else
            {
                l_oSlide.Shapes[m_iTextIndex].TextFrame.TextRange.Text = TitleTxt.Text + ";" + "Vertical: " + RatioTxt.Text.Substring(0, 4) + ";" + HorizontalRatioLbl.Text;
            }
            m_oPresentation.Save();
            RefreshValuesBasedOnSlide(m_iCurrentSlide);
        }

        Line m_oCupLine;
        Line m_oDiscLine;
        public int m_iGreenLineWidth = 8;
        public int m_iBlueLineWidth = 4;
        private Line AddMarkingLines(PictureBox a_oPictureBox, Image a_oImg, Color a_oMarkColor, Color a_oLineColor)
        {
            Line line = new Line();
            try
            {
                //Adds blue marks that are the beginning/end of the line
                MarkControl mark1 = new MarkControl(a_oMarkColor);
                mark1.Location = new Point(a_oPictureBox.Width / 2, a_oPictureBox.Height / 2);
                a_oPictureBox.Controls.Add(mark1);

                MarkControl mark2 = new MarkControl(a_oMarkColor);
                mark2.Location = new Point(a_oPictureBox.Width / 2, a_oPictureBox.Height / 2);
                a_oPictureBox.Controls.Add(mark2);

                //Line Struct contains the information for a single line
                line.mark1 = mark1;
                line.mark2 = mark2;
                if (a_oMarkColor == Color.LightGreen)
                    line.Width = m_iGreenLineWidth;
                else
                    line.Width = m_iBlueLineWidth;
                line.lineColor = a_oLineColor;


                //Events for moving marks
                mark1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Mark_MouseUp);
                mark1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Mark_MouseDown);
                mark1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Mark_MouseMove);

                mark2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Mark_MouseUp);
                mark2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Mark_MouseDown);
                mark2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Mark_MouseMove);

                //Adds Line object to an arraylist
                Lines.Add(line);
                Redraw(a_oPictureBox, a_oImg);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return line;
        }

        int[] blue_xymark1;
        int[] blue_xymark2;
        int[] green_xymark1;
        int[] green_xymark2;
        //Simply draws a line
        private void DrawLine(Line line, PictureBox a_oPictureBox)
        {
            Graphics g = null;

            g = Graphics.FromImage(a_oPictureBox.Image);
            bool xymark1_ontop = true;
            bool xymark1_leftof = true;
            if (line.mark1.Center.X > line.mark2.Center.X)
                xymark1_leftof = false;
            if (line.mark1.Center.Y > line.mark2.Center.Y)
                xymark1_ontop = false;

            int l_xymark1_newpoint_x = line.mark1.Center.X;
            int l_xymark2_newpoint_x = line.mark2.Center.X;
            if (xymark1_leftof)
            {
                if (Math.Abs(line.mark1.Center.X - line.mark2.Center.X) > Math.Abs(line.mark1.Center.Y - line.mark2.Center.Y))
                {
                    l_xymark1_newpoint_x = line.mark1.Center.X + line.mark1.CenterToBorderDistance;
                    l_xymark2_newpoint_x = line.mark2.Center.X - line.mark2.CenterToBorderDistance;
                }
            }
            else
            {
                if (Math.Abs(line.mark1.Center.X - line.mark2.Center.X) > Math.Abs(line.mark1.Center.Y - line.mark2.Center.Y))
                {
                    l_xymark1_newpoint_x = line.mark1.Center.X - line.mark1.CenterToBorderDistance;
                    l_xymark2_newpoint_x = line.mark2.Center.X + line.mark2.CenterToBorderDistance;
                }
            }

            int l_xymark1_newpoint_y = line.mark1.Center.Y;
            int l_xymark2_newpoint_y = line.mark2.Center.Y;
            if (xymark1_ontop)
            {
                if (Math.Abs(line.mark1.Center.X - line.mark2.Center.X) < Math.Abs(line.mark1.Center.Y - line.mark2.Center.Y))
                {
                    l_xymark1_newpoint_y = line.mark1.Center.Y + line.mark1.CenterToBorderDistance;
                    l_xymark2_newpoint_y = line.mark2.Center.Y - line.mark2.CenterToBorderDistance;
                }
            }
            else
            {
                if (Math.Abs(line.mark1.Center.X - line.mark2.Center.X) < Math.Abs(line.mark1.Center.Y - line.mark2.Center.Y))
                {
                    l_xymark1_newpoint_y = line.mark1.Center.Y - line.mark1.CenterToBorderDistance;
                    l_xymark2_newpoint_y = line.mark2.Center.Y + line.mark2.CenterToBorderDistance;
                }
            }

            if (line.lineColor == Color.DarkBlue)
            {
                blue_xymark1 = xy_projection((Bitmap)a_oPictureBox.Image, l_xymark1_newpoint_x, l_xymark1_newpoint_y);
                blue_xymark2 = xy_projection((Bitmap)a_oPictureBox.Image, l_xymark2_newpoint_x, l_xymark2_newpoint_y);
                g.DrawLine(new Pen(line.lineColor, (float)line.Width), blue_xymark1[0], blue_xymark1[1], blue_xymark2[0], blue_xymark2[1]);
                g.Dispose();
            }
            else
            {
                green_xymark1 = xy_projection((Bitmap)a_oPictureBox.Image, l_xymark1_newpoint_x, l_xymark1_newpoint_y);
                green_xymark2 = xy_projection((Bitmap)a_oPictureBox.Image, l_xymark2_newpoint_x, l_xymark2_newpoint_y);
                g.DrawLine(new Pen(line.lineColor, (float)line.Width), green_xymark1[0], green_xymark1[1], green_xymark2[0], green_xymark2[1]);
                g.Dispose();
            }
        }

        //Redraws all the lines and a part of the background
        private void Redraw(Line line, Point p, PictureBox a_oPictureBox, Image a_oImg)
        {


            Graphics.FromImage(a_oPictureBox.Image).DrawImage(a_oImg, 0, 0, a_oPictureBox.Image.Width,
                a_oPictureBox.Image.Height);

            foreach (Line l in Lines)
            {
                DrawLine(l, a_oPictureBox);
            }

            Region r = getRegionByLine(line, p);
            a_oPictureBox.Invalidate(r);
            a_oPictureBox.Update();
        }


        //Redraws all the lines and the background too
        private void Redraw(PictureBox a_oPictureBox, Image a_oImg)
        {
            if (a_oImg != null)
                a_oPictureBox.Image = (Bitmap)a_oImg.Clone();
            else
            {
                a_oPictureBox.Image = new Bitmap(a_oPictureBox.Width, a_oPictureBox.Height);
                Graphics.FromImage(a_oPictureBox.Image).Clear(Color.Transparent);
            }

            foreach (Line l in Lines)
            {
                DrawLine(l, a_oPictureBox);
            }
            a_oPictureBox.Refresh();
            CalculateRatios();
        }

        private void Mark_MouseDown(object sender, MouseEventArgs e)
        {
            this.SuspendLayout();
            isSelected = true;
            _X = e.X;
            _Y = e.Y;
        }

        private void Mark_MouseMove(object sender, MouseEventArgs e)
        {
            if (isSelected)
            {
                MarkControl mc1 = (MarkControl)sender;
                Line l = getLineByMark(mc1);

                Point p = new Point(e.X - _X + mc1.Left, e.Y - _Y + mc1.Top);
                mc1.Location = p;
                Redraw(pictureBox1, bmpBackLeft);
            }
        }

        private void Mark_MouseUp(object sender, MouseEventArgs e)
        {
            isSelected = false;
            ResumeLayout();
            Redraw(pictureBox1, bmpBackLeft);
        }

        //Retrieves a mark having the other one
        private MarkControl getOtherMark(MarkControl m)
        {
            foreach (Line l in Lines)
            {
                if (l.mark1 == m)
                    return l.mark2;

                if (l.mark2 == m)
                    return l.mark1;
            }//Never happens :D
            throw new Exception("No relative mark found");
        }

        //Retrieves a Line object having a mark
        private Line getLineByMark(MarkControl m)
        {
            foreach (Line l in Lines)
            {
                if (l.mark1 == m || l.mark2 == m)
                    return l;
            }//Never happens :D
            throw new Exception("No line found");
        }


        //Returns the region to update
        private Region getRegionByLine(Line l, Point p)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddPolygon(new Point[] { l.mark1.Center, l.mark2.Center, p, l.mark1.Center });

            RectangleF rf = gp.GetBounds();
            gp.Dispose();

            rf.Inflate(100f, 100f);

            return new Region(rf);
        }

        AboutFrm m_oForm = null;
        private void AboutBtn_Click(object sender, EventArgs e)
        {
            m_oForm = new AboutFrm();
            m_oForm.ShowDialog();
            m_oForm.Close();
            m_oForm.Dispose();
        }

        int[] xy_projection(Bitmap myBitmap2, int x, int y)
        {
            int heightB = myBitmap2.Height;
            int heightP = pictureBox1.Height;
            int widthB = myBitmap2.Width;
            int widthP = pictureBox1.Width;
            double xRatio = (double)widthB / (double)widthP;
            double yRatio = (double)heightB / (double)heightP;
            int[] xy = new int[2];
            if (pictureBox1.SizeMode == PictureBoxSizeMode.StretchImage)
            {
                xy[0] = (int)(x * xRatio);
                xy[1] = (int)(y * yRatio);
            }
            else if (pictureBox1.SizeMode == PictureBoxSizeMode.CenterImage)
            {
                int borderHeight = (heightP - heightB) / 2;
                int borderWidth = (widthP - widthB) / 2;
                xy[0] = x - borderWidth;
                xy[1] = y - borderHeight;
            }
            else if (pictureBox1.SizeMode == PictureBoxSizeMode.Zoom)
            {
                double ratio = xRatio;
                bool x_filled = true;
                if (ratio < yRatio)
                {
                    ratio = yRatio;
                    x_filled = false;
                }
                if (x_filled)
                {
                    heightB = (int)(heightB / ratio);
                    int borderHeight = (heightP - heightB) / 2;
                    xy[0] = (int)(x * ratio);
                    xy[1] = (int)((y - borderHeight) * ratio);
                }
                else
                {
                    widthB = (int)(widthB / ratio);
                    int borderWidth = (widthP - widthB) / 2;
                    xy[0] = (int)((x - borderWidth) * ratio);
                    xy[1] = (int)(y * ratio);
                }
            }
            else
            {
                xy[0] = x;
                xy[1] = y;
            }
            return xy;
        }


        Image l_oOriginalImageBeforeScrollLeft = null;
        Image l_oOriginalImageBeforeScrollRight = null;
        private void zoomSlider_Scroll(object sender, EventArgs e)
        {
            //Before Scroll Get Left Side of right picture box and top side of left picture box
            int l_iTopSideOfLeftPictureBox = pictureBox1.Top;

            double l_dMagnifyingAmount = 1 + (double)((double)(zoomSlider.Value - 10) / 10);
            Bitmap l_oNewLeftBitmap = new Bitmap(l_oOriginalImageBeforeScrollLeft, Convert.ToInt32(l_oOriginalImageBeforeScrollLeft.Width * l_dMagnifyingAmount), Convert.ToInt32(l_oOriginalImageBeforeScrollLeft.Height * l_dMagnifyingAmount));
            bmpBackLeft = l_oNewLeftBitmap;
            pictureBox1.Image = l_oNewLeftBitmap;

            Bitmap l_oNewRightBitmap = new Bitmap(l_oOriginalImageBeforeScrollRight, Convert.ToInt32(l_oOriginalImageBeforeScrollRight.Width * l_dMagnifyingAmount), Convert.ToInt32(l_oOriginalImageBeforeScrollRight.Height * l_dMagnifyingAmount));
            bmpBackRight = l_oNewRightBitmap;
            pictureBox2.Image = l_oNewRightBitmap;

            pictureBox1.Location = new Point(panel1.Width - Convert.ToInt32(l_oOriginalImageBeforeScrollLeft.Width * l_dMagnifyingAmount), l_iTopSideOfLeftPictureBox);
        }

        private void UpBtn_Click(object sender, EventArgs e)
        {
            pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y - 10);
            pictureBox2.Location = new Point(pictureBox2.Location.X, pictureBox2.Location.Y - 10);
        }

        private void DownBtn_Click(object sender, EventArgs e)
        {
            pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y + 10);
            pictureBox2.Location = new Point(pictureBox2.Location.X, pictureBox2.Location.Y + 10);
        }

        private void LeftBtn_Click(object sender, EventArgs e)
        {
            pictureBox1.Location = new Point(pictureBox1.Location.X - 10, pictureBox1.Location.Y);
            pictureBox2.Location = new Point(pictureBox2.Location.X - 10, pictureBox2.Location.Y);
        }

        private void RightBtn_Click(object sender, EventArgs e)
        {
            pictureBox1.Location = new Point(pictureBox1.Location.X + 10, pictureBox1.Location.Y);
            pictureBox2.Location = new Point(pictureBox2.Location.X + 10, pictureBox2.Location.Y);
        }

        private void SGBtn_Click(object sender, EventArgs e)
        {
            m_oDiscLine.mark1.Show();
            m_oDiscLine.mark2.Show();
        }

        private void HGBtn_Click(object sender, EventArgs e)
        {
            m_oDiscLine.mark1.Hide();
            m_oDiscLine.mark2.Hide();
        }

        private void SRBtn_Click(object sender, EventArgs e)
        {
            m_oCupLine.mark1.Show();
            m_oCupLine.mark2.Show();
        }

        private void HRBtn_Click(object sender, EventArgs e)
        {
            m_oCupLine.mark1.Hide();
            m_oCupLine.mark2.Hide();
        }

        private void StoreValueBtn_Click(object sender, EventArgs e)
        {
            StoredValueLbl.Text = RatioTxt.Text;
        }

        private void CopyValueBtn_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(RatioTxt.Text);
        }

        private void StudyVersionBtn_Click(object sender, EventArgs e)
        {
            CopyValueBtn.Show();
            AddResultBtn.Hide();
            StoreValueBtn.Hide();
            StoredValueLbl.Hide();
            HorizontalRatioLbl.Hide();
            VerticalRatioLbl.Hide();
        }

        private void ClinicalVersionBtn_Click(object sender, EventArgs e)
        {
            CopyValueBtn.Hide();
            AddResultBtn.Show();
            StoreValueBtn.Show();
            StoredValueLbl.Show();
            HorizontalRatioLbl.Show();
            VerticalRatioLbl.Show();
        }
    }
}
