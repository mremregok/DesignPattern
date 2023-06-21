using System;
using System.Collections.Generic;

namespace OOPEducaiton.UML.StructuralPatterns.ProxyPattern.Example2
{
	// Bu senaryoda, Proxy tasarım deseni stok bilgilerinin yönetimi
	// ve erişimi için kullanılır. Proxy sınıfı, stok bilgilerine erişimi
	// kontrol eder ve gerektiğinde gerçek stok hizmetine başvururken
	// önbellekteki bilgileri kullanır. Bu şekilde, stok bilgilerinin
	// doğru ve güncel olması sağlanırken, gereksiz erişimler ve ağ trafiği azaltılır.

	// Stok hizmeti arayüzü
	public interface IStockService
	{
		int GetStock(string productId);
	}

	// Gerçek stok hizmeti
	public class StockService : IStockService
	{
		public int GetStock(string productId)
		{
			// Gerçek stok bilgisini sağlayan işlemler
			Console.WriteLine($"Stok bilgisi alındı: Ürün ID: {productId}");
			// Gerçek stok bilgisini döndür
			return 50; // Örnek bir stok değeri
		}
	}

	// Stok Proxy sınıfı
	public class StockProxy : IStockService
	{
		private Dictionary<string, int> stockCache;
		private IStockService stockService;

		public StockProxy()
		{
			stockCache = new Dictionary<string, int>();
			stockService = new StockService();
		}

		public int GetStock(string productId)
		{
			if (stockCache.ContainsKey(productId))
			{
				Console.WriteLine($"Stok bilgisi önbellekten alındı: Ürün ID: {productId}");
				return stockCache[productId];
			}
			else
			{
				int stock = stockService.GetStock(productId);
				stockCache.Add(productId, stock);
				Console.WriteLine($"Stok bilgisi gerçek hizmetten alındı ve önbelleğe eklendi: Ürün ID: {productId}");
				return stock;
			}
		}
	}

	// İstemci kodu
	public class Client
	{
		private IStockService stockService;

		public Client()
		{
			stockService = new StockProxy();
		}

		public void CheckStock(string productId)
		{
			int stock = stockService.GetStock(productId);
			Console.WriteLine($"Ürün ID: {productId} için stok bilgisi: {stock}");
		}
	}

	public class ProxyExample2Runner
	{
        public ProxyExample2Runner()
        {
			Client client = new Client();

			// İlk stok sorgusu (gerçek hizmete erişilir)
			client.CheckStock("ABC123");

			// Aynı stok sorgusu (önbellekten alınır)
			client.CheckStock("ABC123");

			// Farklı bir stok sorgusu (gerçek hizmete erişilir)
			client.CheckStock("XYZ789");
		}
    }
}
