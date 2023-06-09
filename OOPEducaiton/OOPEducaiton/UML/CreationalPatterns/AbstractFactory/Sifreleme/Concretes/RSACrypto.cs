using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPEducaiton.UML.CreationalPatterns.AbstractFactory.Sifreleme.Concretes
{
	public class RSACrypto : Cryptography
	{
		public override string Decrypt(string encryptedMessage)
		{
			throw new NotImplementedException();
		}

		public override string Encrypt(string message)
		{
			throw new NotImplementedException();
		}
	}
}