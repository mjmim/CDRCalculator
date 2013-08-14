namespace CDRatio
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ChooseBtn = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.NextBtn = new System.Windows.Forms.Button();
            this.PrevBtn = new System.Windows.Forms.Button();
            this.CalculateBtn = new System.Windows.Forms.Button();
            this.RatioTxt = new System.Windows.Forms.TextBox();
            this.AddResultBtn = new System.Windows.Forms.Button();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.CopyValueBtn = new System.Windows.Forms.Button();
            this.HRBtn = new System.Windows.Forms.Button();
            this.SRBtn = new System.Windows.Forms.Button();
            this.SGBtn = new System.Windows.Forms.Button();
            this.HGBtn = new System.Windows.Forms.Button();
            this.ModeLbl = new System.Windows.Forms.Label();
            this.DownBtn = new System.Windows.Forms.Button();
            this.RightBtn = new System.Windows.Forms.Button();
            this.LeftBtn = new System.Windows.Forms.Button();
            this.UpBtn = new System.Windows.Forms.Button();
            this.zoomSlider = new System.Windows.Forms.TrackBar();
            this.StoredValueLbl = new System.Windows.Forms.Label();
            this.StoreValueBtn = new System.Windows.Forms.Button();
            this.VerticalRatioLbl = new System.Windows.Forms.Label();
            this.HorizontalRatioLbl = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.TitleTxt = new System.Windows.Forms.TextBox();
            this.BottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoomSlider)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // ChooseBtn
            // 
            this.ChooseBtn.Location = new System.Drawing.Point(368, 6);
            this.ChooseBtn.Name = "ChooseBtn";
            this.ChooseBtn.Size = new System.Drawing.Size(176, 35);
            this.ChooseBtn.TabIndex = 1;
            this.ChooseBtn.Text = "Choose PowerPoint";
            this.ChooseBtn.UseVisualStyleBackColor = true;
            this.ChooseBtn.Click += new System.EventHandler(this.ChooseBtn_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // NextBtn
            // 
            this.NextBtn.Enabled = false;
            this.NextBtn.Location = new System.Drawing.Point(813, 69);
            this.NextBtn.Name = "NextBtn";
            this.NextBtn.Size = new System.Drawing.Size(75, 23);
            this.NextBtn.TabIndex = 6;
            this.NextBtn.Text = "Next";
            this.NextBtn.UseVisualStyleBackColor = true;
            this.NextBtn.Click += new System.EventHandler(this.NextBtn_Click);
            // 
            // PrevBtn
            // 
            this.PrevBtn.Enabled = false;
            this.PrevBtn.Location = new System.Drawing.Point(27, 68);
            this.PrevBtn.Name = "PrevBtn";
            this.PrevBtn.Size = new System.Drawing.Size(75, 23);
            this.PrevBtn.TabIndex = 7;
            this.PrevBtn.Text = "Previous";
            this.PrevBtn.UseVisualStyleBackColor = true;
            this.PrevBtn.Click += new System.EventHandler(this.PrevBtn_Click);
            // 
            // CalculateBtn
            // 
            this.CalculateBtn.Location = new System.Drawing.Point(292, 3);
            this.CalculateBtn.Name = "CalculateBtn";
            this.CalculateBtn.Size = new System.Drawing.Size(75, 23);
            this.CalculateBtn.TabIndex = 16;
            this.CalculateBtn.Text = "Calc Ratio";
            this.CalculateBtn.UseVisualStyleBackColor = true;
            this.CalculateBtn.Visible = false;
            this.CalculateBtn.Click += new System.EventHandler(this.CalculateBtn_Click);
            // 
            // RatioTxt
            // 
            this.RatioTxt.Location = new System.Drawing.Point(373, 5);
            this.RatioTxt.Name = "RatioTxt";
            this.RatioTxt.Size = new System.Drawing.Size(117, 20);
            this.RatioTxt.TabIndex = 17;
            // 
            // AddResultBtn
            // 
            this.AddResultBtn.Location = new System.Drawing.Point(512, 4);
            this.AddResultBtn.Name = "AddResultBtn";
            this.AddResultBtn.Size = new System.Drawing.Size(75, 23);
            this.AddResultBtn.TabIndex = 23;
            this.AddResultBtn.Text = "Add Result";
            this.AddResultBtn.UseVisualStyleBackColor = true;
            this.AddResultBtn.Visible = false;
            this.AddResultBtn.Click += new System.EventHandler(this.AddResultBtn_Click);
            // 
            // BottomPanel
            // 
            this.BottomPanel.Controls.Add(this.CopyValueBtn);
            this.BottomPanel.Controls.Add(this.HRBtn);
            this.BottomPanel.Controls.Add(this.SRBtn);
            this.BottomPanel.Controls.Add(this.SGBtn);
            this.BottomPanel.Controls.Add(this.HGBtn);
            this.BottomPanel.Controls.Add(this.ModeLbl);
            this.BottomPanel.Controls.Add(this.DownBtn);
            this.BottomPanel.Controls.Add(this.RightBtn);
            this.BottomPanel.Controls.Add(this.LeftBtn);
            this.BottomPanel.Controls.Add(this.UpBtn);
            this.BottomPanel.Controls.Add(this.zoomSlider);
            this.BottomPanel.Controls.Add(this.RatioTxt);
            this.BottomPanel.Controls.Add(this.AddResultBtn);
            this.BottomPanel.Controls.Add(this.StoredValueLbl);
            this.BottomPanel.Controls.Add(this.StoreValueBtn);
            this.BottomPanel.Controls.Add(this.CalculateBtn);
            this.BottomPanel.Location = new System.Drawing.Point(27, 436);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(861, 119);
            this.BottomPanel.TabIndex = 28;
            // 
            // CopyValueBtn
            // 
            this.CopyValueBtn.Location = new System.Drawing.Point(512, 4);
            this.CopyValueBtn.Name = "CopyValueBtn";
            this.CopyValueBtn.Size = new System.Drawing.Size(75, 23);
            this.CopyValueBtn.TabIndex = 37;
            this.CopyValueBtn.Text = "Copy Value";
            this.CopyValueBtn.UseVisualStyleBackColor = true;
            this.CopyValueBtn.Click += new System.EventHandler(this.CopyValueBtn_Click);
            // 
            // HRBtn
            // 
            this.HRBtn.Location = new System.Drawing.Point(192, 4);
            this.HRBtn.Name = "HRBtn";
            this.HRBtn.Size = new System.Drawing.Size(42, 23);
            this.HRBtn.TabIndex = 34;
            this.HRBtn.Text = "HBB";
            this.HRBtn.UseVisualStyleBackColor = true;
            this.HRBtn.Click += new System.EventHandler(this.HRBtn_Click);
            // 
            // SRBtn
            // 
            this.SRBtn.Location = new System.Drawing.Point(144, 4);
            this.SRBtn.Name = "SRBtn";
            this.SRBtn.Size = new System.Drawing.Size(42, 23);
            this.SRBtn.TabIndex = 33;
            this.SRBtn.Text = "SBB";
            this.SRBtn.UseVisualStyleBackColor = true;
            this.SRBtn.Click += new System.EventHandler(this.SRBtn_Click);
            // 
            // SGBtn
            // 
            this.SGBtn.Location = new System.Drawing.Point(22, 3);
            this.SGBtn.Name = "SGBtn";
            this.SGBtn.Size = new System.Drawing.Size(42, 23);
            this.SGBtn.TabIndex = 32;
            this.SGBtn.Text = "SGB";
            this.SGBtn.UseVisualStyleBackColor = true;
            this.SGBtn.Click += new System.EventHandler(this.SGBtn_Click);
            // 
            // HGBtn
            // 
            this.HGBtn.Location = new System.Drawing.Point(70, 4);
            this.HGBtn.Name = "HGBtn";
            this.HGBtn.Size = new System.Drawing.Size(42, 23);
            this.HGBtn.TabIndex = 31;
            this.HGBtn.Text = "HGB";
            this.HGBtn.UseVisualStyleBackColor = true;
            this.HGBtn.Click += new System.EventHandler(this.HGBtn_Click);
            // 
            // ModeLbl
            // 
            this.ModeLbl.AutoSize = true;
            this.ModeLbl.Location = new System.Drawing.Point(493, 8);
            this.ModeLbl.Name = "ModeLbl";
            this.ModeLbl.Size = new System.Drawing.Size(14, 13);
            this.ModeLbl.TabIndex = 30;
            this.ModeLbl.Text = "V";
            // 
            // DownBtn
            // 
            this.DownBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DownBtn.BackgroundImage")));
            this.DownBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DownBtn.Location = new System.Drawing.Point(415, 83);
            this.DownBtn.Name = "DownBtn";
            this.DownBtn.Size = new System.Drawing.Size(30, 30);
            this.DownBtn.TabIndex = 29;
            this.DownBtn.UseVisualStyleBackColor = true;
            this.DownBtn.Click += new System.EventHandler(this.DownBtn_Click);
            // 
            // RightBtn
            // 
            this.RightBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("RightBtn.BackgroundImage")));
            this.RightBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RightBtn.Location = new System.Drawing.Point(444, 55);
            this.RightBtn.Name = "RightBtn";
            this.RightBtn.Size = new System.Drawing.Size(30, 30);
            this.RightBtn.TabIndex = 28;
            this.RightBtn.UseVisualStyleBackColor = true;
            this.RightBtn.Click += new System.EventHandler(this.RightBtn_Click);
            // 
            // LeftBtn
            // 
            this.LeftBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LeftBtn.BackgroundImage")));
            this.LeftBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LeftBtn.Location = new System.Drawing.Point(386, 55);
            this.LeftBtn.Name = "LeftBtn";
            this.LeftBtn.Size = new System.Drawing.Size(30, 30);
            this.LeftBtn.TabIndex = 27;
            this.LeftBtn.UseVisualStyleBackColor = true;
            this.LeftBtn.Click += new System.EventHandler(this.LeftBtn_Click);
            // 
            // UpBtn
            // 
            this.UpBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("UpBtn.BackgroundImage")));
            this.UpBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.UpBtn.Location = new System.Drawing.Point(415, 29);
            this.UpBtn.Name = "UpBtn";
            this.UpBtn.Size = new System.Drawing.Size(30, 30);
            this.UpBtn.TabIndex = 26;
            this.UpBtn.UseVisualStyleBackColor = true;
            this.UpBtn.Click += new System.EventHandler(this.UpBtn_Click);
            // 
            // zoomSlider
            // 
            this.zoomSlider.LargeChange = 1;
            this.zoomSlider.Location = new System.Drawing.Point(17, 37);
            this.zoomSlider.Maximum = 20;
            this.zoomSlider.Name = "zoomSlider";
            this.zoomSlider.Size = new System.Drawing.Size(335, 45);
            this.zoomSlider.TabIndex = 25;
            this.zoomSlider.Value = 10;
            this.zoomSlider.Scroll += new System.EventHandler(this.zoomSlider_Scroll);
            // 
            // StoredValueLbl
            // 
            this.StoredValueLbl.AutoSize = true;
            this.StoredValueLbl.Location = new System.Drawing.Point(117, 94);
            this.StoredValueLbl.Name = "StoredValueLbl";
            this.StoredValueLbl.Size = new System.Drawing.Size(68, 13);
            this.StoredValueLbl.TabIndex = 36;
            this.StoredValueLbl.Text = "Stored Value";
            this.StoredValueLbl.Visible = false;
            // 
            // StoreValueBtn
            // 
            this.StoreValueBtn.Location = new System.Drawing.Point(22, 89);
            this.StoreValueBtn.Name = "StoreValueBtn";
            this.StoreValueBtn.Size = new System.Drawing.Size(75, 23);
            this.StoreValueBtn.TabIndex = 35;
            this.StoreValueBtn.Text = "Store Value";
            this.StoreValueBtn.UseVisualStyleBackColor = true;
            this.StoreValueBtn.Visible = false;
            this.StoreValueBtn.Click += new System.EventHandler(this.StoreValueBtn_Click);
            // 
            // VerticalRatioLbl
            // 
            this.VerticalRatioLbl.AutoSize = true;
            this.VerticalRatioLbl.Location = new System.Drawing.Point(221, 77);
            this.VerticalRatioLbl.Name = "VerticalRatioLbl";
            this.VerticalRatioLbl.Size = new System.Drawing.Size(73, 13);
            this.VerticalRatioLbl.TabIndex = 30;
            this.VerticalRatioLbl.Text = "Vertical Ratio:";
            this.VerticalRatioLbl.Visible = false;
            // 
            // HorizontalRatioLbl
            // 
            this.HorizontalRatioLbl.AutoSize = true;
            this.HorizontalRatioLbl.Location = new System.Drawing.Point(585, 77);
            this.HorizontalRatioLbl.Name = "HorizontalRatioLbl";
            this.HorizontalRatioLbl.Size = new System.Drawing.Size(85, 13);
            this.HorizontalRatioLbl.TabIndex = 31;
            this.HorizontalRatioLbl.Text = "Horizontal Ratio:";
            this.HorizontalRatioLbl.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(27, 97);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(431, 333);
            this.panel1.TabIndex = 32;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(431, 333);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Location = new System.Drawing.Point(458, 97);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(431, 333);
            this.panel2.TabIndex = 33;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(431, 333);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // TitleTxt
            // 
            this.TitleTxt.Location = new System.Drawing.Point(306, 47);
            this.TitleTxt.Name = "TitleTxt";
            this.TitleTxt.ReadOnly = true;
            this.TitleTxt.Size = new System.Drawing.Size(309, 20);
            this.TitleTxt.TabIndex = 2;
            this.TitleTxt.Text = "Slideshow Name";
            this.TitleTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(922, 578);
            this.Controls.Add(this.TitleTxt);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.HorizontalRatioLbl);
            this.Controls.Add(this.VerticalRatioLbl);
            this.Controls.Add(this.BottomPanel);
            this.Controls.Add(this.PrevBtn);
            this.Controls.Add(this.NextBtn);
            this.Controls.Add(this.ChooseBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "CDRCalculator - 14.08.2013";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.BottomPanel.ResumeLayout(false);
            this.BottomPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoomSlider)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ChooseBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button NextBtn;
        private System.Windows.Forms.Button PrevBtn;
        private System.Windows.Forms.Button CalculateBtn;
        private System.Windows.Forms.TextBox RatioTxt;
        private System.Windows.Forms.Button AddResultBtn;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.Label VerticalRatioLbl;
        private System.Windows.Forms.Label HorizontalRatioLbl;
        private System.Windows.Forms.TrackBar zoomSlider;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button UpBtn;
        private System.Windows.Forms.Button DownBtn;
        private System.Windows.Forms.Button RightBtn;
        private System.Windows.Forms.Button LeftBtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label ModeLbl;
        private System.Windows.Forms.Button HRBtn;
        private System.Windows.Forms.Button SRBtn;
        private System.Windows.Forms.Button SGBtn;
        private System.Windows.Forms.Button HGBtn;
        private System.Windows.Forms.Button CopyValueBtn;
        private System.Windows.Forms.TextBox TitleTxt;
        private System.Windows.Forms.Label StoredValueLbl;
        private System.Windows.Forms.Button StoreValueBtn;
    }
}

