using System;
using System.Collections.Generic;
using System.Text;

namespace CellPhone
{
	[Serializable]
	public class MultimediaMessage : ShortMessage
	{
		protected object _data;	
		public object Data
		{
			get
			{
				return _data;
			}
			set { _data = value; }
		}

		public  MultimediaMessage() { }
	}
}
