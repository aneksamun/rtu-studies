using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace CellPhone
{
    public partial class PhoneDisplay : UserControl
    {
		public string DisplayText
		{
			get { return tbEntryBox.Text; }
		}

		public int SelectedMenuIndex
		{
			get { return listMenu.SelectedIndex; }
			set	{ listMenu.SelectedIndex = (value > listMenu.Items.Count) ? 0 : value; }
		}

		public string SelectedMenuString
		{
			get { return (listMenu.SelectedItem == null) ? null : listMenu.SelectedItem.ToString(); }
		}

		private Timer _timer = new Timer();

        internal PhoneDisplay()
        {
            InitializeComponent();

			this._timer.Interval = 2000;
			this._timer.Tick += new EventHandler(_timer_Tick);
		}

		private void _timer_Tick(object sender, EventArgs e)
		{
			DisplayTitle(DateTime.Today.ToShortDateString() + "\n" + DateTime.Now.ToShortTimeString());
		}

		internal void DisplayTitle(string text)
		{
			lbTitle.Text = text;
		}

		internal void ShowTitle(PhoneMode mode)
		{
			_timer.Stop();

			switch (mode)
			{
				case PhoneMode.Waiting:
					tbEntryBox.Visible = false;
					listMenu.Visible = false;

					lbSelectLeft.Text = "Menu";
					lbSelectLeft.Visible = true;

					lbSelectRight.Text = "Exit";
					lbSelectRight.Visible = true;

					_timer.Start();
					DisplayTitle(DateTime.Today.ToShortDateString() + "\n" + DateTime.Now.ToShortTimeString());
					lbTitle.Visible = true;
					break;
				case PhoneMode.SendingCall:
					tbEntryBox.Visible = false;
					listMenu.Visible = false;
					lbSelectRight.Visible = false;

					lbSelectLeft.Text = "Cancel";
					lbSelectLeft.Visible = true;

					lbTitle.Visible = true;
					break;
				case PhoneMode.ReceivingCall:
					tbEntryBox.Visible = false;
					listMenu.Visible = false;

					lbSelectRight.Text = "Cancel";
					lbSelectRight.Visible = true;

					lbSelectLeft.Text = "Answer";
					lbSelectLeft.Visible = true;

					lbTitle.Visible = true;
					break;
				case PhoneMode.Speaking:
				case PhoneMode.Answering:
					tbEntryBox.Visible = false;
					listMenu.Visible = false;
					lbSelectRight.Visible = false;

					lbSelectLeft.Text = "End call";
					lbSelectLeft.Visible = true;

					lbTitle.Visible = true;
					break;
				case PhoneMode.SendingMessage:
					tbEntryBox.Visible = false;
					listMenu.Visible = false;
					lbSelectRight.Visible = false;

					lbSelectLeft.Text = "Ok";
					lbSelectLeft.Visible = true;

					lbTitle.Text = "Message sent!";
					lbTitle.Visible = true;
					break;
			}
		}

		internal void ShowTextBox(string title, string left, string right)
		{
			_timer.Stop();
			listMenu.Visible = false;
			tbEntryBox.Text = "";
			tbEntryBox.Visible = true;
			lbTitle.Text = title;
			lbTitle.Visible = true;
			lbSelectLeft.Text = left;
			lbSelectLeft.Visible = true;
			lbSelectRight.Text = right;
			lbSelectRight.Visible = true;
		}

		internal void ShowText(string str)
		{
			tbEntryBox.Text = str;
		}

		internal void AddChar(char c)
		{
			tbEntryBox.Text += c;
		}

		internal void RemoveChar()
		{
			if (tbEntryBox.Text.Length == 0)
				return;
			tbEntryBox.Text = tbEntryBox.Text.Substring(0, tbEntryBox.Text.Length - 1);
		}

		internal void ReplaceChar(char c)
		{
			RemoveChar();
			AddChar(c);
		}

		internal void ShowMenu(PhoneMode pm)
		{
			tbEntryBox.Visible = false;

			lbSelectRight.Text = "Back";
			lbSelectRight.Visible = true;

			lbSelectLeft.Text = "Select";
			lbSelectLeft.Visible = true;

			_timer.Stop();
			lbTitle.Visible = true;

			switch (pm)
			{
				case PhoneMode.MainMenu:
					DisplayTitle("Main menu");
					listMenu.Items.Clear();
					listMenu.Items.Add("Contacts");
					listMenu.Items.Add("Messages");
					listMenu.SelectedIndex = 0;
					listMenu.Visible = true;
					break;
				case PhoneMode.ContactsMenu:
					DisplayTitle("Contacts");
					listMenu.Items.Clear();
					listMenu.Items.Add("New");
					listMenu.Items.Add("Find");
					listMenu.SelectedIndex = 0;
					listMenu.Visible = true;
					break;
				case PhoneMode.MessagesMenu:
					DisplayTitle("Messages");
					listMenu.Items.Clear();
					listMenu.Items.Add("New SMS");
					listMenu.Items.Add("New MMS");
					listMenu.Items.Add("Saved messages");
					listMenu.SelectedIndex = 0;
					listMenu.Visible = true;
					break;
				case PhoneMode.FindingContact:
					lbSelectLeft.Text = "Call";
					lbSelectRight.Text = "Edit";
					DisplayTitle("Contacts:");
					listMenu.Items.Clear();
					listMenu.SelectedIndex = -1;
					listMenu.Visible = true;
					break;
				case PhoneMode.ViewingMessages:
					lbSelectLeft.Text = "Send";
					lbSelectRight.Text = "Edit";
					DisplayTitle("Messages:");
					listMenu.Items.Clear();
					listMenu.SelectedIndex = -1;
					listMenu.Visible = true;
					break;
			}
		}

		internal void ScrollDown()
		{
			if (listMenu.Items.Count == 0)
				return;
			listMenu.SelectedIndex = (listMenu.SelectedIndex == listMenu.Items.Count - 1) ? 0 : listMenu.SelectedIndex + 1;
		}

		internal void ScrollUp()
		{
			if (listMenu.Items.Count == 0)
				return;
			listMenu.SelectedIndex = (listMenu.SelectedIndex == 0) ? listMenu.Items.Count - 1 : listMenu.SelectedIndex - 1;
		}

		internal void AddMenuItem(string p)
		{
			listMenu.Items.Add(p);
		}


	}
}
