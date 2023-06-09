namespace OOPEducaiton.UML.StructuralPatterns.AdapterPattern.Example1
{

    //IError adında bir interface var ve bu interface kendinden türeyen classlar için bir grup oluşturacak.
    public interface IError
    {
        int ErrorNumber { get; set; }
        string Description { get; set; }
        void SendMail();
    }

    public class DbError : IError
    {
        private int _errorNumber;
        private string _description;

        public int ErrorNumber
        {
            get { return _errorNumber; }
            set { _errorNumber = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }


        public void SendMail()
        {
            Console.WriteLine("{0} {1} -> Db Hatasi gönderildi", ErrorNumber.ToString(), Description);
        }
    }

    public class ServiceError : IError
    {
        private int _errorNumber;
        private string _description;

        public int ErrorNumber
        {
            get { return _errorNumber; }
            set { _errorNumber = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public void SendMail()
        {
            Console.WriteLine("{0} {1} -> servis Hatasi gönderildi", ErrorNumber.ToString(), Description);
        }
    }

    public class Fax
    {
        public int FaxErrorCode { get; set; }
        public string ErrorDescription { get; set; }

        //Fax yolla
        void Send()
        {

        }

        //Fax al
        void Get()
        {

        }
    }

    public class FaxAdapter : IError
    {
        private Fax _fax;

        public FaxAdapter(Fax fax)
        {
            _fax = fax;
        }

        public int ErrorNumber
        {
            get { return _fax.FaxErrorCode; }
            set { _fax.FaxErrorCode = value; }
        }

        public string Description
        {
            get { return _fax.ErrorDescription; }
            set { _fax.ErrorDescription = value; }
        }

        public void SendMail()
        {
            Console.WriteLine("{0} {1} Fax hatasi alindi ", ErrorNumber.ToString(), Description);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Fax fax = new Fax { FaxErrorCode = 4000, ErrorDescription = "Cevap gelmiyor" };


            IError[] errors = {
                      new DbError{ErrorNumber=100,Description="Baglanti saglanamadi" },
                         new DbError{ErrorNumber=101,Description="sorgulama saglanamadi" },
                            new ServiceError{ErrorNumber=300,Description="yetki saglanamadi" },
                               new FaxAdapter(fax)
                            };

            foreach (IError error in errors)
                error.SendMail();

            Console.ReadKey();
        }
    }
}
