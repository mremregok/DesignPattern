using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.CreationalPatterns.AbstractFactory.Sifreleme.Concretes
{
	public class ABCCryptoKey : CryptoKey
	{
		public override string GenerateKey(int keySize)
		{
			throw new NotImplementedException();
		}
	}
}
