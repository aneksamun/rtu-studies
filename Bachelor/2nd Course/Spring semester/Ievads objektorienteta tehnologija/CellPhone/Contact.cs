using System;
using System.Collections.Generic;
using System.Text;

namespace CellPhone
{
	[Serializable]
	public class Contact
	{
		private string _name;
		public string Name
		{
			get
			{
				return _name;
			}
			set { _name = value; }
		}
		private string _phoneNumber;

		public string PhoneNumber
		{
			get
			{
				return _phoneNumber;
			}
			set { _phoneNumber = value; }
		}

		public Contact() { }
	}
}
