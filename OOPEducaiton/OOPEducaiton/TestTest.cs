using OOPEducaiton;

namespace OOPEducaiton
{
    struct TestStr { }
        public sealed class SingletonLazy
        {
            static int instanceCounter = 0;
            private static readonly Lazy<SingletonLazy> singleInstance 
            = new Lazy<SingletonLazy>(() => new SingletonLazy()); //private static Singleton singleInstance = null;  
            private SingletonLazy()
            {
                instanceCounter++;
               List<SingletonLazy> list = new List<SingletonLazy>();
               SingletonLazy sing = list[5];

            sing.LogMessage("");
            }
            public static SingletonLazy SingleInstance
            {
                get
                {
                    return singleInstance.Value;
                }
            }
            public void LogMessage(string message)
            {
            }
        }
    
    public class MessageCore
    {
        private static MessageCore _instance;
        
        private static MessageCore Instance 
            = _instance ?? (_instance = new MessageCore());

        private MessageCore() { }

        public static void SendMessage(string message) 
            => Instance.sendMessage(message);
        
        protected  void sendMessage(string message)
        {
            Console.WriteLine($"{message} gönderildi.");
        }
    }
}

class program
{
    void main()
    {
        MessageCore.SendMessage("mesaj");
    }
}
