using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPEducaiton
{
	public abstract class Cryptography
	{
		public abstract string Encrypt(string message);
		public abstract string Decrypt(string encryptedMessage);
	}
}