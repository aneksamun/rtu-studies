using System;
using System.Collections.Generic;
using System.Text;

namespace CellPhone
{
	[Serializable]
	public class ShortMessage
	{
		public ShortMessage() { }

		protected string _text;
		public string Text
		{
			get
			{
				return _text;
			}
			set { _text = value; }
		}
	}
}
