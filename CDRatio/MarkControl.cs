//Nothing to see here, it's only a red square :D Personalize it (circles,cross, etc)

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace LineEditor
{
	
	public class MarkControl : UserControl
	{
		private Container components = null;
        public const int CENTER_TO_BORDER = 6;
		public MarkControl(Color a_oBackColor)
		{		
			InitializeComponent();
            this.BackColor = a_oBackColor;	
		}

        public int CenterToBorderDistance
        {
            get { return CENTER_TO_BORDER; }
        }

		public Point Center
		{
            get { return new Point(Location.X + CENTER_TO_BORDER, Location.Y + CENTER_TO_BORDER); }
		}

		protected override void OnPaint(PaintEventArgs e)
		{
		//
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		
		private void InitializeComponent()
		{
			this.Name = "MarkControl";
            this.Size = new System.Drawing.Size((CENTER_TO_BORDER * 2) + 1, (CENTER_TO_BORDER * 2) + 1);

		}
		#endregion
	}
}
