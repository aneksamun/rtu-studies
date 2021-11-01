using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace CellPhone
{
	public delegate void CallEventHandler(object sender, CallEventArgs e);

    [Serializable]
	public class Controller
	{
		public event CallEventHandler CallReceive;

		public string _phoneNumber = "29123456";

		private View _view;
		public View View
		{
			get
			{
				return _view;
			}
		}
        private Model _model;
		public Model Model
		{
			get
			{
				return _model;
			}
		}

		private Controller _caller;
		private Controller _target;
		private Contact _newContact;
		private ShortMessage _newMessage;
		private DateTime _symbolEntered = DateTime.Now;
		private bool _isCapsOn;

		private char _lastSymbol
		{
			get { return (_view.Display.DisplayText.Length == 0) ? '\0' : _view.Display.DisplayText[_view.Display.DisplayText.Length - 1]; }
		}
		private bool _enoughTime
		{
			get { return DateTime.Now.Subtract(_symbolEntered).Seconds > 1; } 
		}


		private PhoneMode _mode;
		public PhoneMode Mode
		{
			get { return _mode; }
			set
			{
				_mode = value;
				PhoneDisplay display = _view.Display;

				switch (_mode)
				{
					case PhoneMode.Waiting:
					case PhoneMode.SendingCall:
					case PhoneMode.ReceivingCall:
					case PhoneMode.Speaking:
					case PhoneMode.Answering:
						display.ShowTitle(_mode);
						break;
					case PhoneMode.EnteringNumber:
						display.ShowTextBox("Phone number", "Call", "Back");
						break;
					case PhoneMode.MainMenu:
					case PhoneMode.ContactsMenu:
					case PhoneMode.MessagesMenu:
						display.ShowMenu(_mode);
						break;
					case PhoneMode.EnteringContactName:
						display.ShowTextBox("Enter name", "Ok", "Cancel");
						if (_newContact != null)
							display.ShowText(_newContact.Name);
						break;
					case PhoneMode.EnteringContactNumber:
						display.ShowTextBox("Enter number", "Save", "Cancel");
						if (_newContact != null)
							display.ShowText(_newContact.PhoneNumber);
						break;
					case PhoneMode.FindingContact:
						display.ShowMenu(_mode);
						_view.ListContacts();
						break;
					case PhoneMode.CreatingSMS:
					case PhoneMode.CreatingMMS:
					case PhoneMode.EditingMessage:
						display.ShowTextBox("Message:", "Send", "Save");
						if (_newMessage != null)
							display.ShowText(_newMessage.Text);
						break;
					case PhoneMode.ViewingMessages:
						display.ShowMenu(_mode);
						_view.ListMessages();
						break;
					case PhoneMode.EnteringTargetNumber:
						display.ShowTextBox("Enter number", "Send", "");
						break;
					case PhoneMode.SendingMessage:
						_view.Display.ShowTitle(_mode);
						break;
					default:
						break;
				}
			}
		}

        private Controller()
		{
			CallReceive += new CallEventHandler(Controller_CallReceive);
		}

		public Controller(Model model, View view)
			: this()
		{
			this._model = model;
			this._view = view;
			this._view.Keyboard.SetBtnClickEventHandler(new EventHandler(keyboardButton_Click));

			Mode = PhoneMode.Waiting;

			this._view.Show();
		}

		internal Controller(Model model, View view, Controller caller, string phoneNumber, string callerNumber)
			: this(model, view)
		{
			_caller = caller;
			_phoneNumber = phoneNumber;
			Controller_CallReceive(this, new CallEventArgs(callerNumber));
		}

		private void keyboardButton_Click(object sender, EventArgs e)
		{
			PictureBox button = sender as PictureBox;

			if (button == null)
				return;

			PhoneDisplay display = this._view.Display;
			PhoneKeyboard keyboard = this._view.Keyboard;
			Model m;

			switch (button.Name)
			{
				case "btnSelectLeft":
				case "btnSelectCenter":
					switch (Mode)
					{
						case PhoneMode.Waiting:
							Mode = PhoneMode.MainMenu;
							break;
						case PhoneMode.EnteringNumber:
							Mode = PhoneMode.SendingCall;
							display.DisplayTitle("Sending call to " + display.DisplayText);
							m = new Model();
							_target = new Controller(m, new View(m), this, display.DisplayText, _phoneNumber);
							break;
						case PhoneMode.SendingCall:
							_target.EndCall();
							Mode = PhoneMode.Waiting;
							break;
						case PhoneMode.ReceivingCall:
							if (_caller == null)
								break;
							_caller.StartCall(_phoneNumber);
							Mode = PhoneMode.Answering;
							display.DisplayTitle("Answering to " + _caller._phoneNumber);
							break;
						case PhoneMode.Speaking:
							_target.EndCall();
							Mode = PhoneMode.Waiting;
							break;
						case PhoneMode.Answering:
							EndCall();
							break;
						case PhoneMode.MainMenu:
							if (display.SelectedMenuIndex == 0)
								Mode = PhoneMode.ContactsMenu;
							else Mode = PhoneMode.MessagesMenu;
							break;
						case PhoneMode.ContactsMenu:
							if (display.SelectedMenuIndex == 0)
							{
								_newContact = new Contact();
								Mode = PhoneMode.EnteringContactName;
							}
							else Mode = PhoneMode.FindingContact;
							break;
						case PhoneMode.MessagesMenu:
							switch (display.SelectedMenuIndex)
							{
								case 0:
									_newMessage = new ShortMessage();
									Mode = PhoneMode.CreatingSMS;
									break;
								case 1:
									_newMessage = new MultimediaMessage();
									Mode = PhoneMode.CreatingSMS;
									break;
								case 2:
									Mode = PhoneMode.ViewingMessages;
									break;
								default:
									break;
							}
							break;
						case PhoneMode.EnteringContactName:
							_newContact.Name = display.DisplayText;
							Mode = PhoneMode.EnteringContactNumber;
							break;
						case PhoneMode.EnteringContactNumber:
							_newContact.PhoneNumber = display.DisplayText;
							_model.SaveContact(_newContact);
							Mode = PhoneMode.ContactsMenu;
							break;
						case PhoneMode.FindingContact:
							if (display.SelectedMenuString == null)
								return;
							_newContact = _model.GetContactByName(display.SelectedMenuString);
							Mode = PhoneMode.SendingCall;
							display.DisplayTitle("Sending call to " + _newContact.PhoneNumber);
							m = new Model();
							_target = new Controller(m, new View(m), this, _newContact.PhoneNumber, _phoneNumber);
							break;
						case PhoneMode.ViewingMessages:
							if (display.SelectedMenuString == null)
								return;
							_newMessage = _model.FindMessage(display.SelectedMenuString.Substring(0, ((display.SelectedMenuString.Length > 12) ? 12 : display.SelectedMenuString.Length)));
							Mode = PhoneMode.EnteringTargetNumber;
							break;
						case PhoneMode.EditingMessage:
							_newMessage = _model.FindMessage(display.DisplayText.Substring(0, ((display.DisplayText.Length > 12) ? 12 : display.DisplayText.Length)));
							Mode = PhoneMode.EnteringTargetNumber;
							break;
						case PhoneMode.CreatingSMS:
							_newMessage = new ShortMessage();
							Mode = PhoneMode.EnteringTargetNumber;
							break;
						case PhoneMode.CreatingMMS:
							_newMessage = new MultimediaMessage();
							Mode = PhoneMode.EnteringTargetNumber;
							break;
						case PhoneMode.EnteringTargetNumber:
							SendMessage(_newMessage);
							break;
						case PhoneMode.SendingMessage:
							Mode = PhoneMode.MessagesMenu;
							break;
						default:
							break;
					}
					break;
				case "btnSelectRight":
					switch (Mode)
					{
						case PhoneMode.Waiting:
							Application.Exit();
							break;
						case PhoneMode.ReceivingCall:
							EndCall();
							break;
						case PhoneMode.MainMenu:
						case PhoneMode.EnteringNumber:
							Mode = PhoneMode.Waiting;
							break;
						case PhoneMode.ContactsMenu:
						case PhoneMode.MessagesMenu:
							Mode = PhoneMode.MainMenu;
							break;
						case PhoneMode.EnteringContactName:
							Mode = PhoneMode.ContactsMenu;
							break;
						case PhoneMode.EnteringContactNumber:
							Mode = PhoneMode.ContactsMenu;
							break;
						case PhoneMode.FindingContact:
							if (display.SelectedMenuString == null)
								return;
							_newContact = _model.GetContactByName(display.SelectedMenuString);
							Mode = PhoneMode.EnteringContactName;
							break;
						case PhoneMode.ViewingMessages:
							if (display.SelectedMenuString == null)
								return;
							_newMessage = _model.FindMessage(display.SelectedMenuString.Substring(0, ((display.SelectedMenuString.Length > 12) ? 12 : display.SelectedMenuString.Length)));
							Mode = PhoneMode.EditingMessage;
							break;
						case PhoneMode.EditingMessage:
							_newMessage.Text = display.DisplayText;
							_model.SaveMessage(_newMessage);
							Mode = PhoneMode.MessagesMenu;
							break;
						case PhoneMode.CreatingSMS:
						case PhoneMode.CreatingMMS:
							_newMessage.Text = display.DisplayText;
							_model.AddMessage(_newMessage);
							Mode = PhoneMode.MessagesMenu;
							break;
						default:
							break;
					}
					break;
				case "btnBack":
					switch (Mode)
					{
						case PhoneMode.EnteringNumber:
						case PhoneMode.MainMenu:
							Mode = PhoneMode.Waiting;
							break;
						case PhoneMode.ContactsMenu:
						case PhoneMode.MessagesMenu:
							Mode = PhoneMode.MainMenu;
							break;
						case PhoneMode.EnteringContactName:
						case PhoneMode.EnteringContactNumber:
						case PhoneMode.FindingContact:
							Mode = PhoneMode.ContactsMenu;
							break;
						case PhoneMode.CreatingSMS:
						case PhoneMode.CreatingMMS:
						case PhoneMode.ViewingMessages:
						case PhoneMode.EnteringTargetNumber:
							Mode = PhoneMode.MessagesMenu;
							break;
						case PhoneMode.EditingMessage:
							Mode = PhoneMode.ViewingMessages;
							break;
						default:
							break;
					}
					break;
				case "btnDelete":
					switch (Mode)
					{
						case PhoneMode.EnteringNumber:
							display.RemoveChar();
							if (display.DisplayText.Length == 0)
								Mode = PhoneMode.Waiting;
							break;
						case PhoneMode.EnteringContactName:
						case PhoneMode.EnteringContactNumber:
						case PhoneMode.EnteringTargetNumber:
						case PhoneMode.EditingMessage:
						case PhoneMode.CreatingSMS:
						case PhoneMode.CreatingMMS:
							display.RemoveChar();
							break;
						case PhoneMode.FindingContact:
							if (display.SelectedMenuString == null) return;
							_model.DeleteContact(display.SelectedMenuString);
							Mode = Mode;
							break;
						case PhoneMode.ViewingMessages:
							if (display.SelectedMenuString == null) return;
							_model.DeleteMessage(display.SelectedMenuString.Substring(0, ((display.SelectedMenuString.Length > 10) ? 10 : display.SelectedMenuString.Length)));
							Mode = Mode;
							break;
						default:
							break;
					}
					break;
				case "btnLeft":
					break;
				case "btnRight":
					break;
				case "btnUp":
					display.ScrollUp();
					break;
				case "btnDown":
					display.ScrollDown();
					break;
				case "btn0":
					switch (Mode)
					{
						case PhoneMode.Waiting:
							Mode = PhoneMode.EnteringNumber;
							display.ShowText("0");
							break;
						case PhoneMode.EnteringNumber:
						case PhoneMode.EnteringTargetNumber:
						case PhoneMode.EnteringContactNumber:
							display.AddChar('0');
							break;
						case PhoneMode.EnteringContactName:
						case PhoneMode.EditingMessage:
						case PhoneMode.CreatingSMS:
						case PhoneMode.CreatingMMS:
							SelectSymbol('+', '0');
							break;
						default:
							break;
					}
					break;
				case "btn1":
					switch (Mode)
					{
						case PhoneMode.Waiting:
							Mode = PhoneMode.EnteringNumber;
							display.ShowText("1");
							break;
						case PhoneMode.EnteringNumber:
						case PhoneMode.EnteringContactNumber:
						case PhoneMode.EnteringTargetNumber:
							display.AddChar('1');
							break;
						case PhoneMode.EnteringContactName:
						case PhoneMode.EditingMessage:
						case PhoneMode.CreatingSMS:
						case PhoneMode.CreatingMMS:
							SelectSymbol('.', ',', '-', '?', '!', '1');
							break;
						default:
							break;
					}
					break;
				case "btn2":
					switch (Mode)
					{
						case PhoneMode.Waiting:
							Mode = PhoneMode.EnteringNumber;
							display.ShowText("2");
							break;
						case PhoneMode.EnteringNumber:
						case PhoneMode.EnteringContactNumber:
						case PhoneMode.EnteringTargetNumber:
							display.AddChar('2');
							break;
						case PhoneMode.EnteringContactName:
						case PhoneMode.EditingMessage:
						case PhoneMode.CreatingSMS:
						case PhoneMode.CreatingMMS:
							if (_isCapsOn)
								SelectSymbol('A', 'B', 'C', '2');
							else
								SelectSymbol('a', 'b', 'c', '2');
							break;
						default:
							break;
					}
					break;
				case "btn3":
					switch (Mode)
					{
						case PhoneMode.Waiting:
							Mode = PhoneMode.EnteringNumber;
							display.ShowText("3");
							break;
						case PhoneMode.EnteringNumber:
						case PhoneMode.EnteringContactNumber:
						case PhoneMode.EnteringTargetNumber:
							display.AddChar('3');
							break;
						case PhoneMode.EnteringContactName:
						case PhoneMode.EditingMessage:
						case PhoneMode.CreatingSMS:
						case PhoneMode.CreatingMMS:
							if (_isCapsOn)
								SelectSymbol('D', 'E', 'F', '3');
							else
								SelectSymbol('d', 'e', 'f', '3');
							break;
						default:
							break;
					}
					break;
				case "btn4":
					switch (Mode)
					{
						case PhoneMode.Waiting:
							Mode = PhoneMode.EnteringNumber;
							display.ShowText("4");
							break;
						case PhoneMode.EnteringNumber:
						case PhoneMode.EnteringContactNumber:
						case PhoneMode.EnteringTargetNumber:
							display.AddChar('4');
							break;
						case PhoneMode.EnteringContactName:
						case PhoneMode.EditingMessage:
						case PhoneMode.CreatingSMS:
						case PhoneMode.CreatingMMS:
							if (_isCapsOn)
								SelectSymbol('G', 'H', 'I', '4');
							else
								SelectSymbol('g', 'h', 'i', '4');
							break;
						default:
							break;
					}
					break;
				case "btn5":
					switch (Mode)
					{
						case PhoneMode.Waiting:
							Mode = PhoneMode.EnteringNumber;
							display.ShowText("5");
							break;
						case PhoneMode.EnteringNumber:
						case PhoneMode.EnteringContactNumber:
						case PhoneMode.EnteringTargetNumber:
							display.AddChar('5');
							break;
						case PhoneMode.EnteringContactName:
						case PhoneMode.EditingMessage:
						case PhoneMode.CreatingSMS:
						case PhoneMode.CreatingMMS:
							if (_isCapsOn)
								SelectSymbol('J', 'K', 'L', '5');
							else
								SelectSymbol('j', 'k', 'l', '5');
							break;
						default:
							break;
					}
					break;
				case "btn6":
					switch (Mode)
					{
						case PhoneMode.Waiting:
							Mode = PhoneMode.EnteringNumber;
							display.ShowText("6");
							break;
						case PhoneMode.EnteringNumber:
						case PhoneMode.EnteringContactNumber:
						case PhoneMode.EnteringTargetNumber:
							display.AddChar('6');
							break;
						case PhoneMode.EnteringContactName:
						case PhoneMode.EditingMessage:
						case PhoneMode.CreatingSMS:
						case PhoneMode.CreatingMMS:
							if (_isCapsOn)
								SelectSymbol('M', 'N', 'O', '6');
							else
								SelectSymbol('m', 'n', 'o', '6');
							break;
						default:
							break;
					}
					break;
				case "btn7":
					switch (Mode)
					{
						case PhoneMode.Waiting:
							Mode = PhoneMode.EnteringNumber;
							display.ShowText("7");
							break;
						case PhoneMode.EnteringNumber:
						case PhoneMode.EnteringContactNumber:
						case PhoneMode.EnteringTargetNumber:
							display.AddChar('7');
							break;
						case PhoneMode.EnteringContactName:
						case PhoneMode.EditingMessage:
						case PhoneMode.CreatingSMS:
						case PhoneMode.CreatingMMS:
							if (_isCapsOn)
								SelectSymbol('P', 'Q', 'R', 'S', '7');
							else
								SelectSymbol('p', 'q', 'r', 's', '7');
							break;
						default:
							break;
					}
					break;
				case "btn8":
					switch (Mode)
					{
						case PhoneMode.Waiting:
							Mode = PhoneMode.EnteringNumber;
							display.ShowText("8");
							break;
						case PhoneMode.EnteringNumber:
						case PhoneMode.EnteringContactNumber:
						case PhoneMode.EnteringTargetNumber:
							display.AddChar('8');
							break;
						case PhoneMode.EnteringContactName:
						case PhoneMode.EditingMessage:
						case PhoneMode.CreatingSMS:
						case PhoneMode.CreatingMMS:
							if (_isCapsOn)
								SelectSymbol('T', 'U', 'V', '8');
							else
								SelectSymbol('t', 'u', 'v', '8');
							break;
						default:
							break;
					}
					break;
				case "btn9":
					switch (Mode)
					{
						case PhoneMode.Waiting:
							Mode = PhoneMode.EnteringNumber;
							display.ShowText("9");
							break;
						case PhoneMode.EnteringNumber:
						case PhoneMode.EnteringContactNumber:
						case PhoneMode.EnteringTargetNumber:
							display.AddChar('9');
							break;
						case PhoneMode.EnteringContactName:
						case PhoneMode.EditingMessage:
						case PhoneMode.CreatingSMS:
						case PhoneMode.CreatingMMS:
							if (_isCapsOn)
								SelectSymbol('W', 'X', 'Y', 'Z', '9');
							else
								SelectSymbol('w', 'x', 'y', 'z', '9');
							break;
						default:
							break;
					}
					break;
				case "btnStar":
					switch (Mode)
					{
						case PhoneMode.Waiting:
							Mode = PhoneMode.EnteringNumber;
							display.ShowText("*");
							break;
						case PhoneMode.EnteringNumber:
						case PhoneMode.EnteringContactNumber:
						case PhoneMode.EnteringTargetNumber:
							display.AddChar('*');
							break;
						case PhoneMode.EnteringContactName:
						case PhoneMode.EditingMessage:
						case PhoneMode.CreatingSMS:
						case PhoneMode.CreatingMMS:
							_isCapsOn = !_isCapsOn;
							break;
						default:
							break;
					}
					break;
				case "btnSharp":
					switch (Mode)
					{
						case PhoneMode.Waiting:
							Mode = PhoneMode.EnteringNumber;
							display.ShowText("#");
							break;
						case PhoneMode.EnteringNumber:
						case PhoneMode.EnteringContactNumber:
						case PhoneMode.EnteringTargetNumber:
							display.AddChar('#');
							break;
						case PhoneMode.EnteringContactName:
						case PhoneMode.EditingMessage:
						case PhoneMode.CreatingSMS:
						case PhoneMode.CreatingMMS:
							SelectSymbol(' ', '#', '*');
							break;
						default:
							break;
					}
					break;
				default:
					break;
			}
			_symbolEntered = DateTime.Now;
		}

		private void SendMessage(ShortMessage _newMessage)
		{
			_model.DeleteMessage(_newMessage);
			Mode = PhoneMode.SendingMessage;
		}

		private void SelectSymbol(params char[] chars)
		{
			char nextChar = '\0';
			for (int i = 0; i < chars.Length; i++)
				if (chars[i] == _lastSymbol)
					nextChar = (i == chars.Length - 1) ? chars[0] : chars[i + 1];
			if (nextChar == '\0')
			{
				_view.Display.AddChar(chars[0]);
				return;
			}

			if (_enoughTime)
				_view.Display.AddChar(nextChar);
			else
				_view.Display.ReplaceChar(nextChar);
		}

		private void Controller_CallReceive(object sender, CallEventArgs e)
		{
			Mode = PhoneMode.ReceivingCall;
			_view.Display.DisplayTitle(e.Number + " is calling!");
		}

		private void StartCall(string num)
		{
			Mode = PhoneMode.Speaking;
			_view.Display.DisplayTitle("Speaking with " + num);
		}

		public void EndCall()
		{
			if (_caller != null)
				_caller.Mode = PhoneMode.Waiting;
			_view.Close();
		}
	}
}
