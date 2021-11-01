using System;
using System.Collections.Generic;
using System.Text;

namespace CellPhone
{
	[Serializable]
	public class PhoneMemory
	{
		private List<Contact> _contacts;
		public List<Contact> Contacts
		{
			get { return _contacts; }
			set { _contacts = value; }
		}

		private List<ShortMessage> _shortMessages;
		public List<ShortMessage> ShortMessages
		{
			get { return _shortMessages; }
			set { _shortMessages = value; }
		}

		private List<MultimediaMessage> _multimediaMessages;
		public List<MultimediaMessage> MltimediaMessages
		{
			get { return _multimediaMessages; }
			set { _multimediaMessages = value; }
		}

		public PhoneMemory() { }
	}
}
