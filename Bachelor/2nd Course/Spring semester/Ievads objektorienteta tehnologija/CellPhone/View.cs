using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace CellPhone
{
    public partial class View : Form
    {
		private Model _model;

		private MouseEventHandler _mouseMoveEventHandler;
		private MouseEventHandler _mouseUpEventHandler;
		private MouseEventHandler _mouseDownEventHandler;

		private Point _mouseOffset;
		private bool _isMouseDown = false;

		public PhoneDisplay Display
		{
		    get { return display; }
		}

		public PhoneKeyboard Keyboard
		{
			get { return keyboard; }
		}

		private View()
		{
			InitializeComponent();

			#region Form region
			Point[] points = new Point[]
			{
				new Point(64, 0),
				new Point(119, 0),
				new Point(133, 1),
				new Point(143, 2),
				new Point(152, 3),
				new Point(159, 4),
				new Point(165, 5),
				new Point(170, 6),
				new Point(174, 7),
				new Point(176, 8),
				new Point(177, 9),
				new Point(178, 10),
				new Point(179, 11),
				new Point(180, 12),
				new Point(181, 14),
				new Point(182,18),
				new Point(182, 374),
				new Point(181, 377),
				new Point(180, 379),
				new Point(179, 381),
				new Point(178, 382),
				new Point(177, 384),
				new Point(176, 385),
				new Point(174, 386),
				new Point(173, 387),
				new Point(171, 388),
				new Point(169, 389),
				new Point(167, 390),
				new Point(164, 391),
				new Point(161, 392),
				new Point(157, 393),
				new Point(153, 394),
				new Point(146, 395),
				new Point(142, 396),
				new Point(43, 396),
				new Point(38, 395),
				new Point(32, 394),
				new Point(27, 393),
				new Point(23, 392),
				new Point(20, 391),
				new Point(17, 390),
				new Point(15, 389),
				new Point(13, 388),
				new Point(12, 387),
				new Point(10, 386),
				new Point(9, 385),
				new Point(8, 384),
				new Point(7, 383),
				new Point(6, 382),
				new Point(5, 380),
				new Point(4, 378),
				new Point(3, 375),
				new Point(2, 369),
				new Point(2, 18),
				new Point(3, 15),
				new Point(4, 12),
				new Point(5, 11),
				new Point(6, 10),
				new Point(7, 9),
				new Point(9, 8),
				new Point(10, 7),
				new Point(14, 6),
				new Point(20, 5),
				new Point(26, 4),
				new Point(31, 3),
				new Point(41, 2),
				new Point(50, 1)
			};
			GraphicsPath gp = new GraphicsPath();
			gp.AddLines(points);
			this.Region = new Region(gp);
			#endregion

			_mouseMoveEventHandler = new System.Windows.Forms.MouseEventHandler(control_MouseMove);
			_mouseUpEventHandler = new System.Windows.Forms.MouseEventHandler(control_MouseUp);
			_mouseDownEventHandler = new System.Windows.Forms.MouseEventHandler(control_MouseDown);

			SetControlDragOption(this);
		}

		public View(Model model) : this()
		{
			_model = model;
		}

		private void SetControlDragOption(Control control)
		{
			control.MouseMove += _mouseMoveEventHandler;
			control.MouseDown += _mouseDownEventHandler;
			control.MouseUp += _mouseUpEventHandler;

			foreach (Control c in control.Controls)
			{
				SetControlDragOption(c);
			}
		}

		private void control_MouseMove(object sender, MouseEventArgs e)
		{
			if (!_isMouseDown)
				return;

			Point mousePos = Control.MousePosition;
			mousePos.Offset(_mouseOffset.X, _mouseOffset.Y);
			Location = mousePos;
		}

		private void control_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
				_isMouseDown = false;
		}

		private void control_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Left)
				return;

			int xOffset = -e.X;
			int yOffset = -e.Y;

			if (sender != this && sender is Control)
			{
				Control ctrl = sender as Control;
				_mouseOffset = GetParentOffset(ctrl);
				xOffset -= _mouseOffset.X;
				yOffset -= _mouseOffset.Y;
			}

			_mouseOffset = new Point(xOffset, yOffset);
			_isMouseDown = true;
		}

		private Point GetParentOffset(Control c)
		{
			Point p;
			int x = c.Location.X;
			int y = c.Location.Y;
			if (c.Parent != this)
			{
				p = GetParentOffset(c.Parent);
				x += p.X;
				y += p.Y;
			}
			p = new Point(x, y);
			return p;
		}

		internal void ListContacts()
		{
			foreach (Contact ct in _model.Memory.Contacts)
			{
				display.AddMenuItem(ct.Name);
			}
			if (_model.Memory.Contacts.Count > 0)
				display.SelectedMenuIndex = 0;
		}

		internal void ListMessages()
		{
			string str;

			foreach (ShortMessage msg in _model.Memory.ShortMessages)
			{
				str = (msg.Text.Length > 12) ? msg.Text.Substring(0, 12) + "..." : msg.Text;
				display.AddMenuItem(str);
			}
			if (_model.Memory.ShortMessages.Count > 0)
				display.SelectedMenuIndex = 0;
		}

		private void View_Paint(object sender, PaintEventArgs e)
		{
			this.display.Refresh();
		}
	}
}