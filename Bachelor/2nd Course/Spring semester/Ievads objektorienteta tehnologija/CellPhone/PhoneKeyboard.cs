using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace CellPhone
{
    public partial class PhoneKeyboard : UserControl
    {
        public PhoneKeyboard()
        {
            InitializeComponent();
        }

		public void SetBtnClickEventHandler(EventHandler eventHandler)
		{
			this.btn0.Click += eventHandler;
			this.btn1.Click += eventHandler;
			this.btn2.Click += eventHandler;
			this.btn3.Click += eventHandler;
			this.btn4.Click += eventHandler;
			this.btn5.Click += eventHandler;
			this.btn6.Click += eventHandler;
			this.btn7.Click += eventHandler;
			this.btn8.Click += eventHandler;
			this.btn9.Click += eventHandler;
			this.btnSharp.Click += eventHandler;
			this.btnStar.Click += eventHandler;
			this.btnSelectRight.Click += eventHandler;
			this.btnSelectLeft.Click += eventHandler;
			this.btnSelectCenter.Click += eventHandler;
			this.btnUp.Click += eventHandler;
			this.btnDown.Click += eventHandler;
			this.btnRight.Click += eventHandler;
			this.btnLeft.Click += eventHandler;
			this.btnBack.Click += eventHandler;
			this.btnDelete.Click += eventHandler;
		}
    }
}
