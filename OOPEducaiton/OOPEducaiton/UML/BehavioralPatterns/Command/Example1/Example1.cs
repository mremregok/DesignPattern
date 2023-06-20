using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.BehavioralPatterns.Command.Example1
{
	// İlk olarak, Command arayüzünü veya soyut sınıfını
	// tanımlamamız gerekiyor. Bu arayüzde veya sınıfta,
	// komutu temsil edecek bir "Execute" metodu bulunmalıdır.
	public interface ICommand
	{
		void Execute();
	}

	// Ardından, Concrete Command sınıflarını oluşturabiliriz.
	// Her bir sınıf, belirli bir komutu gerçekleştirecek ve
	// gerekirse alıcı nesneleri kullanacak.
	public class TurnOnLightsCommand : ICommand
	{
		private LightController lightController;

		public TurnOnLightsCommand(LightController lightController)
		{
			this.lightController = lightController;
		}

		public void Execute()
		{
			lightController.TurnOnLights();
		}
	}

	public class SetTemperatureCommand : ICommand
	{
		private ThermostatController thermostatController;
		private int temperature;

		public SetTemperatureCommand(ThermostatController thermostatController, int temperature)
		{
			this.thermostatController = thermostatController;
			this.temperature = temperature;
		}

		public void Execute()
		{
			thermostatController.SetTemperature(temperature);
		}
	}

	// Diğer Concrete Command sınıfları (güvenlik kamerası kontrolü, perde kontrolü vb.) da burada tanımlanabilir.

	// Receiver sınıflarını oluşturmalıyız. Bu sınıflar,
	// gerçekleştirilecek işlemleri temsil eder. 
	public class LightController
	{
		public void TurnOnLights()
		{
			Console.WriteLine("Işıklar açıldı.");
		}

		// Diğer işlemler de burada tanımlanabilir.
	}

	public class ThermostatController
	{
		public void SetTemperature(int temperature)
		{
			Console.WriteLine("Termostat ayarı: " + temperature + "°C");
		}

		// Diğer işlemler de burada tanımlanabilir.
	}

	// Diğer Receiver sınıfları (güvenlik kamerası kontrolü, perde kontrolü vb.) da burada tanımlanabilir.

	// Son olarak, Invoker sınıfını oluşturmalıyız. Bu sınıf, komutu yürüten nesneyi temsil eder. 
	public class SmartHomeControl
	{
		private ICommand command;

		public void SetCommand(ICommand command)
		{
			this.command = command;
		}

		public void ExecuteCommand()
		{
			command.Execute();
		}
	}
	// Bu senaryoda, Command tasarım deseni kullanılarak ev otomasyonu
	// sistemindeki komutları temsil ettik. Kullanıcı, mobil uygulama
	// üzerinden komutları seçer ve bu komutlar Concrete Command sınıfları
	// aracılığıyla gerçekleştirilir. Böylece sistem esnek ve genişletilebilir
	// hale gelir, çünkü yeni komutlar eklemek veya mevcut komutları değiştirmek
	// kolay olur.
	public class CommandExample1Runner
	{
        public CommandExample1Runner()
        {
			// Örnek kullanım
			LightController lightController = new LightController();
			ThermostatController thermostatController = new ThermostatController();
			SmartHomeControl smartHomeControl = new SmartHomeControl();
			ICommand command = new TurnOnLightsCommand(lightController);
			smartHomeControl.SetCommand(command);
			smartHomeControl.ExecuteCommand();

			command = new SetTemperatureCommand(thermostatController, 25);
			smartHomeControl.SetCommand(command);
			smartHomeControl.ExecuteCommand();
		}
    }
}
