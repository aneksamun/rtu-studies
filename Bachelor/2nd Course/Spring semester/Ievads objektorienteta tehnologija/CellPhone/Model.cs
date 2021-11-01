using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace CellPhone
{
	public class Model
	{
		private const string _dataFileName = "memory.dat";

		private PhoneMemory _memory;
		public PhoneMemory Memory
		{
			get { return _memory; }
		}

		public Model()
		{
			try
			{
				LoadData();
			}
			catch
			{
				_memory = new PhoneMemory();
				_memory.Contacts = new List<Contact>();
				_memory.ShortMessages = new List<ShortMessage>();
				_memory.MltimediaMessages = new List<MultimediaMessage>();
				SaveData();
			}
		}

		private void LoadData()
		{
			Stream fStream = File.OpenRead(_dataFileName);
			BinaryFormatter binFormat = new BinaryFormatter();
			_memory = (PhoneMemory)binFormat.Deserialize(fStream);
			fStream.Close();
		}

		private void SaveData()
		{
			BinaryFormatter binFormat = new BinaryFormatter();
			Stream fStream = new FileStream(_dataFileName, FileMode.Create, FileAccess.Write, FileShare.None);
			binFormat.Serialize(fStream, _memory);
			fStream.Close();
		}
		
		internal void AddContact(Contact newContact)
		{
			_memory.Contacts.Add(newContact);
			SaveData();
		}

		internal void DeleteContact(string name)
		{
			foreach (Contact ct in _memory.Contacts)
				if (ct.Name == name)
				{
					_memory.Contacts.Remove(ct);
					SaveData();
					return;
				}
		}

		internal Contact GetContactByName(string name)
		{
			foreach (Contact ct in _memory.Contacts)
				if (ct.Name == name)
					return ct;
			return null;
		}

		internal void SaveContact(Contact newContact)
		{
			foreach (Contact ct in _memory.Contacts)
				if (ct == newContact)
				{
					SaveData();
					return;
				}

			AddContact(newContact);			
		}

		internal void DeleteMessage(ShortMessage _newMessage)
		{
			foreach (ShortMessage msg in _memory.ShortMessages)
				if (msg == _newMessage)
				{
					_memory.ShortMessages.Remove(msg);
					SaveData();
					return;
				}
		}

		internal void DeleteMessage(string startsWith)
		{
			foreach (ShortMessage msg in _memory.ShortMessages)
				if (msg.Text.StartsWith(startsWith))
				{
					_memory.ShortMessages.Remove(msg);
					SaveData();
					return;
				}
		}

		internal ShortMessage FindMessage(string startsWith)
		{
			foreach (ShortMessage msg in _memory.ShortMessages)
				if (msg.Text.StartsWith(startsWith))
					return msg;
			return null;
		}

		internal void AddMessage(ShortMessage newMessage)
		{
			_memory.ShortMessages.Add(newMessage);
			SaveData();
		}

		internal void SaveMessage(ShortMessage newMessage)
		{
			foreach (ShortMessage msg in _memory.ShortMessages)
				if (msg == newMessage)
				{
					SaveData();
					return;
				}

			AddMessage(newMessage);
		}
	}
}
