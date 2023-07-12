using System;

namespace OOPEducaiton.UML.BehavioralPatterns.Strategy.Example1
{
    // Strategy (Strateji) arabirimi
    interface IPaymentStrategy
    {
        void ProcessPayment(double amount);
    }

    // Concrete Strategy (Somut Strateji) sınıfı - Kredi Kartı
    class CreditCardPaymentStrategy : IPaymentStrategy
    {
        private string cardNumber;
        private string expirationDate;
        private string cvv;

        public CreditCardPaymentStrategy(string cardNumber, string expirationDate, string cvv)
        {
            this.cardNumber = cardNumber;
            this.expirationDate = expirationDate;
            this.cvv = cvv;
        }

        public void ProcessPayment(double amount)
        {
            // Kredi kartı ödeme işlemleriyle ilgili gerekli işlemler yapılır
            Console.WriteLine("Kredi kartıyla ödeme yapıldı: $" + amount);
            Console.WriteLine("Kredi kartı numarası: " + cardNumber);
            Console.WriteLine("Son kullanma tarihi: " + expirationDate);
            Console.WriteLine("CVV: " + cvv);
            Console.WriteLine("Kredi kartı ödeme işlemi tamamlandı.");
            Console.WriteLine();
        }
    }

    // Concrete Strategy (Somut Strateji) sınıfı - Banka Havalesi
    class BankTransferPaymentStrategy : IPaymentStrategy
    {
        private string accountNumber;
        private string bankCode;

        public BankTransferPaymentStrategy(string accountNumber, string bankCode)
        {
            this.accountNumber = accountNumber;
            this.bankCode = bankCode;
        }

        public void ProcessPayment(double amount)
        {
            // Banka havalesi ödeme işlemleriyle ilgili gerekli işlemler yapılır
            Console.WriteLine("Banka havalesiyle ödeme yapıldı: $" + amount);
            Console.WriteLine("Hesap numarası: " + accountNumber);
            Console.WriteLine("Banka kodu: " + bankCode);
            Console.WriteLine("Banka havalesi ödeme işlemi tamamlandı.");
            Console.WriteLine();
        }
    }

    // Context (Bağlam) sınıfı - Ödeme
    class PaymentContext
    {
        private IPaymentStrategy paymentStrategy;

        public PaymentContext(IPaymentStrategy paymentStrategy)
        {
            this.paymentStrategy = paymentStrategy;
        }

        public void SetPaymentStrategy(IPaymentStrategy paymentStrategy)
        {
            this.paymentStrategy = paymentStrategy;
        }

        public void MakePayment(double amount)
        {
            paymentStrategy.ProcessPayment(amount);
        }
    }

    // Kullanım
    public class StrategyExample1Runner
    {
        public static void Main()
        {
            // Kredi kartıyla ödeme yapma
            IPaymentStrategy creditCardStrategy = new CreditCardPaymentStrategy("1234567890123456", "12/24", "123");
            PaymentContext paymentContext = new PaymentContext(creditCardStrategy);
            paymentContext.MakePayment(100.50);

            // Banka havalesiyle ödeme yapma
            IPaymentStrategy bankTransferStrategy = new BankTransferPaymentStrategy("1234567890", "ABC");
            paymentContext.SetPaymentStrategy(bankTransferStrategy);
            paymentContext.MakePayment(200.75);

            Console.ReadLine();
        }
    }
}
