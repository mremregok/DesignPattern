using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.BehavioralPatterns.State.Example2
{
    // State
    abstract class ATMState
    {
        public abstract void InsertCard(ATMMachine context);
        public abstract void EjectCard(ATMMachine context);
        public abstract void InsertPin(int pin, ATMMachine context);
        public abstract void RequestCash(int cashToWithdraw, ATMMachine context);
    }

    //Context
    class ATMMachine
    {
        ATMState state = new NoCard();
        public ATMState State { set => state = value; }
        /// <summary>
        /// CashInMachine : ATM'de ki peşin parayı ifade eder.
        /// </summary>
        public int CashInMachine { get; set; } = 2000;
        /// <summary>
        /// CorrectPinEntered : Pin'in girilip girilmediğini kontrol eder.
        /// </summary>
        public bool CorrectPinEntered { get; set; } = false;
        public void InsertCard()
            => state.InsertCard(this);
        public void EjectCard()
            => state.EjectCard(this);
        public void InsertPin(int pin)
            => state.InsertPin(pin, this);
        public void RequestCash(int cashToWithdraw)
            => state.RequestCash(cashToWithdraw, this);
    }

    //Concrete State
    /// <summary>
    /// Kartın takılı olmadığı durumu ifade eden sınıftır.
    /// </summary>
    class NoCard : ATMState
    {
        public override void EjectCard(ATMMachine context)
            => Console.WriteLine("Lütfen önce kartı takınız.");
        public override void InsertCard(ATMMachine context)
        {
            Console.WriteLine("Lütfen pin giriniz.");
            context.State = new HasCard();
        }
        public override void InsertPin(int pin, ATMMachine context)
            => Console.WriteLine("Lütfen önce kartı takınız.");
        public override void RequestCash(int cashToWithdraw, ATMMachine context)
            => Console.WriteLine("Lütfen önce kartı takınız.");
    }

    //Concrete State
    /// <summary>
    /// Kartın takılı olduğu sınıfı ifade eden sınıftır.
    /// </summary>
    class HasCard : ATMState
    {
        public override void EjectCard(ATMMachine context)
        {
            Console.WriteLine("Kart çıkarılmıştır.");
            context.State = new NoCard();
        }
        public override void InsertCard(ATMMachine context)
            => Console.WriteLine("Aynı anda birden fazla kart takamazsınız!");
        public override void InsertPin(int pin, ATMMachine context)
        {
            if (pin == 123)
            {
                Console.WriteLine("Pin doğrulandı!");
                context.CorrectPinEntered = true;
                context.State = new HasPin();
            }
            else
            {
                Console.WriteLine("Geçersiz pin girildi!");
                context.CorrectPinEntered = false;
                Console.WriteLine("Kart çıkarılmıştır.");
                context.State = new NoCard();
            }
        }
        public override void RequestCash(int cashToWithdraw, ATMMachine context)
            => Console.WriteLine("Lütfen önce pini giriniz.");
    }

    //Concrete State
    /// <summary>
    /// Pin'in olduğu durumu ifade eden sınıftır.
    /// </summary>
    class HasPin : ATMState
    {
        public override void EjectCard(ATMMachine context)
        {
            Console.WriteLine("Kart çıkarılmıştır.");
            context.State = new NoCard();
        }
        public override void InsertCard(ATMMachine context)
            => Console.WriteLine("Aynı anda birden fazla kart takamazsınız!");
        public override void InsertPin(int pin, ATMMachine context)
            => Console.WriteLine("Doğrulanmış bir pin zaten girilmiştir.");
        public override void RequestCash(int cashToWithdraw, ATMMachine context)
        {
            if (cashToWithdraw > context.CashInMachine)
            {
                Console.WriteLine("Çekmek istenen tutar adil bedeli aşmaktadır.");
                Console.WriteLine("Kart çıkarılmıştır.");
                context.State = new NoCard();
            }
            else
            {
                Console.WriteLine($"{cashToWithdraw} tutarında para çekilmiştir.");
                context.CashInMachine -= cashToWithdraw; //ATM'de ki para güncelleniyor.
                Console.WriteLine("Kart çıkarılmıştır.");
                context.State = new NoCard();
                Console.WriteLine($"ATM'de kalan para : {context.CashInMachine}");

                if (context.CashInMachine <= 0)
                    context.State = new NoCash();
            }
        }
    }

    //Concrete State
    /// <summary>
    /// ATM'de paranın 0'a eşit veya küçük olduğu durumları ifade eder.
    /// </summary>
    class NoCash : ATMState
    {
        public override void EjectCard(ATMMachine context)
         => Console.WriteLine("Para yok para :)");
        public override void InsertCard(ATMMachine context)
            => Console.WriteLine("Para yok para :)");
        public override void InsertPin(int pinEntered, ATMMachine context)
            => Console.WriteLine("Para yok para :)");
        public override void RequestCash(int cashToWithdraw, ATMMachine context)
            => Console.WriteLine("Para yok para :)");
    }

    public class StateExample2Runner
    {
        public static void Main()
        {
            ATMMachine atm = new ATMMachine();
            #region ATM'ye kart takıp geri çıkarma
            atm.InsertCard();
            atm.EjectCard();
            Console.WriteLine("*********");
            #endregion
            #region Doğrulanmış pin ile para çekme ve üzerine tekrar para çekme talebinde bulunma
            atm.InsertCard();
            atm.InsertPin(123);
            atm.RequestCash(1500);
            atm.RequestCash(100);
            Console.WriteLine("*********");
            //ATM'de kalan bakiye 500
            #endregion
            #region Para çekme
            atm.InsertCard();
            atm.InsertPin(123);
            atm.RequestCash(100);
            Console.WriteLine("*********");
            //ATM'de kalan bakiye 400
            #endregion
            #region Para çekme
            atm.InsertCard();
            atm.InsertPin(123);
            atm.RequestCash(300);
            Console.WriteLine("*********");
            //ATM'de kalan bakiye 100
            #endregion
            #region Para çekme
            atm.InsertCard();
            atm.InsertPin(123);
            atm.RequestCash(100);
            Console.WriteLine("*********");
            //ATM'de kalan bakiye 0
            #endregion
            #region Para olmayan ATM'den para çekme talebi
            atm.InsertCard();
            atm.InsertPin(123);
            atm.RequestCash(100);
            //Tüm işlemlerde para yok uyarısı!
            #endregion
        }
    }
}
