﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPEducaiton.UML.CreationalPatterns.AbstractFactory.Example2
{
	public class KurmaliOyuncakUretimBandi : UretimBandi
	{
		public override int UretimMiktari { get; set; }

		public override void Uret()
		{
			for(int i = 0; i < UretimMiktari; i++)
			{
				Oyuncak oyuncak = new KurmaliOyuncak()
				{
					SeriNo = i+1,
					UretimTarihi = DateTime.Now
				};
				Console.WriteLine($"{oyuncak.UretimTarihi} tarihinde {oyuncak.SeriNo} seri numaralı kurmalı oyuncak üretildi!");
			}
		}
	}
}