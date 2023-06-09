using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPEducaiton.UML.BuilderPattern.ArabaUretim;

namespace OOPEducaiton.UML.StructuralPatterns.FacadePattern.Example2
{
	class IskeletOlusturucu
	{
		public int x { get; set; }
		public int y { get; set; }
		public bool z { get; set; }
	}
	class MotorOlusturucu
	{
		public int x { get; set; }
		public int y { get; set; }
		public bool z { get; set; }
	}
	class ArabaOlusturucu
	{
		public IskeletOlusturucu Iskelet { get; set; }
		public MotorOlusturucu Motor { get; set; }
		public ArabaOlusturucu(IskeletOlusturucu Iskelet, MotorOlusturucu Motor)
		{
			this.Iskelet = Iskelet;
			this.Motor = Motor;
		}

		public Araba Olustur(Renkler renk)
		{
			return new Araba(Iskelet, Motor, renk);
		}
	}
	enum Renkler
	{
		Kırmızı,
		Mavi,
		Mor,
		Yeşil,
		Sarı
	}
	class Araba
	{
		public Araba(IskeletOlusturucu Iskelet, MotorOlusturucu Motor, Renkler Renk)
		{
			Console.WriteLine($"Iskelet x = {Iskelet.x}");
			Console.WriteLine($"Iskelet y = {Iskelet.y}");
			Console.WriteLine($"Iskelet z = {Iskelet.z}");
			Console.WriteLine($"Motor x = {Motor.x}");
			Console.WriteLine($"Motor y = {Motor.y}");
			Console.WriteLine($"Motor z = {Motor.z}");
			Console.WriteLine($"Renk = {Renk}");
		}
	}
	class FacadeUretici
	{
		IskeletOlusturucu iskelet;
		MotorOlusturucu motor;
		ArabaOlusturucu olustur;

		public FacadeUretici()
		{
			iskelet = new IskeletOlusturucu() { x = 3, y = 5, z = true };
			motor = new MotorOlusturucu() { x = 2, y = 4, z = false };
			olustur = new ArabaOlusturucu(iskelet, motor);
		}

		public void ArabaUret()
		{
			Araba uretilenAraba = olustur.Olustur(Renkler.Kırmızı);
		}
	}
	class FacadeExample2Runner
	{
        public FacadeExample2Runner()
        {
			FacadeUretici uretici = new FacadeUretici();
			uretici.ArabaUret();

			Console.Read();
		}
    }
}
