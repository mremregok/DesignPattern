using System;

namespace OOPEducaiton.UML.BehavioralPatterns.State.Example1
{
    // State (Durum) arabirimi
    interface IOrderState
    {
        void ProcessOrder(Order order);
    }

    // Concrete State (Somut Durum) sınıfı - Hazırlanıyor
    class OrderPreparingState : IOrderState
    {
        public void ProcessOrder(Order order)
        {
            Console.WriteLine("Sipariş hazırlanıyor.");
            order.SetState(new OrderShippingState());
        }
    }

    // Concrete State (Somut Durum) sınıfı - Gönderimde
    class OrderShippingState : IOrderState
    {
        public void ProcessOrder(Order order)
        {
            Console.WriteLine("Sipariş gönderimde. Takip numarası oluşturuluyor.");
            order.SetState(new OrderDeliveredState());
        }
    }

    // Concrete State (Somut Durum) sınıfı - Teslim Edildi
    class OrderDeliveredState : IOrderState
    {
        public void ProcessOrder(Order order)
        {
            Console.WriteLine("Sipariş teslim edildi. Durum değiştirilemez.");
        }
    }

    // Context (Bağlam) sınıfı - Sipariş
    class Order
    {
        private IOrderState currentState;

        public Order()
        {
            currentState = new OrderPreparingState();
        }

        public void SetState(IOrderState state)
        {
            currentState = state;
        }

        public void ProcessOrder()
        {
            currentState.ProcessOrder(this);
        }
    }

    public class StateExample1Runner
    {
        public static void Main()
        {
            Order order = new Order();

            // Yeni bir sipariş oluşturuldu
            order.ProcessOrder();

            // Sipariş gönderimde
            order.ProcessOrder();

            // Sipariş teslim edildi
            order.ProcessOrder();

            // Durum değiştirilemez
            order.ProcessOrder();

            Console.ReadLine();
        }
    }
}
