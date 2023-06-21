using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.StructuralPatterns.FacadePattern.Example3
{
	#region Alt Sistemler
	// Alt sistemler

	// Sipariş yönetimi alt sistemi
	public class OrderManagementSystem
	{
		public void CreateOrder(string productId, int quantity, string customerId)
		{
			// Sipariş oluşturma işlemleri
			Console.WriteLine($"Sipariş oluşturuldu: Ürün: {productId}, Adet: {quantity}, Müşteri: {customerId}");
		}
	}

	// Ödeme alt sistemi
	public class PaymentSystem
	{
		public void ProcessPayment(string customerId, decimal amount)
		{
			// Ödeme işlemleri
			Console.WriteLine($"Ödeme işlemi gerçekleştirildi: Müşteri: {customerId}, Tutar: {amount}TL");
		}
	}

	// Kargo takibi alt sistemi
	public class ShipmentTrackingSystem
	{
		public void TrackShipment(string orderId)
		{
			// Kargo takip işlemleri
			Console.WriteLine($"Kargo takibi yapılıyor: Sipariş: {orderId}");
		}
	}
	#endregion

	// Facade sınıfı
	public class OnlineShoppingFacade
	{
		private OrderManagementSystem orderSystem;
		private PaymentSystem paymentSystem;
		private ShipmentTrackingSystem shipmentSystem;

		public OnlineShoppingFacade()
		{
			orderSystem = new OrderManagementSystem();
			paymentSystem = new PaymentSystem();
			shipmentSystem = new ShipmentTrackingSystem();
		}

		public void PlaceOrder(string productId, int quantity, string customerId)
		{
			// Sipariş yönetimi alt sistemini kullanarak sipariş oluşturma
			orderSystem.CreateOrder(productId, quantity, customerId);

			// Ödeme alt sistemini kullanarak ödeme işlemini gerçekleştirme
			decimal totalPrice = CalculateTotalPrice(productId, quantity);
			paymentSystem.ProcessPayment(customerId, totalPrice);

			// Kargo takibi alt sistemini kullanarak kargo takibini başlatma
			string orderId = GenerateOrderId();
			shipmentSystem.TrackShipment(orderId);
		}

		private decimal CalculateTotalPrice(string productId, int quantity)
		{
			// Ürün fiyatı ve adet üzerinden toplam fiyatı hesaplama
			decimal productPrice = GetProductPrice(productId);
			return productPrice * quantity;
		}

		private decimal GetProductPrice(string productId)
		{
			// Ürün fiyatını veritabanından veya başka bir kaynaktan almak
			// Bu örnekte sabit bir değer döndürüyoruz
			return 10.99m;
		}

		private string GenerateOrderId()
		{
			// Sipariş numarasını oluşturma
			// Bu örnekte basitçe rastgele bir değer döndürüyoruz
			return Guid.NewGuid().ToString();
		}
	}

	public class FacadeExample3Runner
	{
        public FacadeExample3Runner()
        {
			// Online alışveriş sistemi kullanımı

			OnlineShoppingFacade shoppingFacade = new OnlineShoppingFacade();

			// Müşteri, alışveriş yapmak için sipariş verir
			shoppingFacade.PlaceOrder("ABC123", 2, "123456789");

			// Çıktı:
			// Sipariş oluşturuldu: Ürün: ABC123, Adet: 2, Müşteri: 123456789
			// Ödeme işlemi gerçekleştirildi: Müşteri: 123456789, Tutar: 21.98
			// Kargo takibi yapılıyor: Sipariş: <guid>

			Console.ReadKey();
		}
    }

}
