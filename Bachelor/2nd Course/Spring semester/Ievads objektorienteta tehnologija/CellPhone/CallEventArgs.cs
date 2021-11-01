using System;
using System.Collections.Generic;
using System.Text;

namespace CellPhone
{
	public class CallEventArgs : EventArgs
	{
		private string _number;
		public string Number
		{
			get { return _number; }
		}

		private CallEventArgs() { }

		public CallEventArgs(string number)
			: this()
		{
			_number = number;
		}
	}
}
