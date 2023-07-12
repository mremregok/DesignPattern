using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPEducaiton.UML.StructuralPatterns.CompositePattern.Example2;

namespace OOPEducaiton.UML.BehavioralPatterns.Mediator.Example2
{
    /// <summary>
    /// Mediator Arayüzü
    /// </summary>
    public interface IAnakart
    {
        void Degistir(Birim birim);
    }

    /// <summary>
    /// Colleague Arayüzü
    /// </summary>
    public abstract class Birim
    {
        protected IAnakart _anakart;
        public Birim(IAnakart anakart)
        {
            _anakart = anakart;
        }
    }

    /// <summary>
    /// Concrete Colleague
    /// </summary>
    public class CDDriver : Birim
    {
        public CDDriver(IAnakart anakart) : base(anakart)
        {
        }
        string _cdData;
        public string CDData => _cdData;
        public void CDOku()
        {
            _cdData = "görüntü1,görüntü2,görüntü3*ses1,ses2,ses3";
            _anakart.Degistir(this);
        }
    }

    /// <summary>
    /// Concrete Colleague
    /// </summary>
    public class CPU : Birim
    {
        public CPU(IAnakart anakart) : base(anakart)
        {
        }
        string _videoData, _sesData;
        public string VideoData => _videoData;
        public string SesData => _sesData;
        public void DataIsle(string cdData)
        {
            string[] array = cdData.Split("*");
            _videoData = array[0]; //görüntü değerleri video data olarak alınıyor.
            _sesData = array[1]; //ses değerleri ses data olarak alınıyor.
            _anakart.Degistir(this);
        }
    }

    /// <summary>
    /// Concrete Colleague
    /// </summary>
    public class EkranKarti : Birim
    {
        public EkranKarti(IAnakart anakart) : base(anakart)
        {
        }
        public void GorselVer(string videoData)
        {
            string[] datas = videoData.Split(",");
            foreach (string data in datas)
                Console.WriteLine($"Gelen görüntü : {data}");
        }
    }

    /// <summary>
    /// Concrete Colleague
    /// </summary>
    public class SesKarti : Birim
    {
        public SesKarti(IAnakart anakart) : base(anakart)
        {
        }
        public void SesVer(string sesData)
        {
            string[] datas = sesData.Split(",");
            foreach (string data in datas)
                Console.WriteLine($"Gelen ses : {data}");
        }
    }

    /// <summary>
    /// Concrete Mediator
    /// </summary>
    public class Anakart : IAnakart
    {
        CDDriver _cdDriver;
        CPU _cpu;
        EkranKarti _ekranKarti;
        SesKarti _sesKarti;

        public CDDriver CDDriver { set => _cdDriver = value; }
        public CPU CPU { set => _cpu = value; }
        public EkranKarti EkranKarti { set => _ekranKarti = value; }
        public SesKarti SesKarti { set => _sesKarti = value; }

        public void Degistir(Birim birim)
        {
            if (birim is CDDriver)
            {
                string cdData = _cdDriver.CDData;
                _cpu.DataIsle(cdData);
            }
            else if (birim is CPU)
            {
                string videoData = _cpu.VideoData, sesData = _cpu.SesData;
                _ekranKarti.GorselVer(videoData);
                _sesKarti.SesVer(sesData);
            }
        }
    }

    public class MediatorExample2Runner
    {
        public static void Main()
        {
            Anakart anakart = new Anakart();

            //Colleague'ler oluşturuluyor...
            CDDriver cdDriver = new CDDriver(anakart);
            CPU cpu = new CPU(anakart);
            EkranKarti ekranKarti = new EkranKarti(anakart);
            SesKarti sesKarti = new SesKarti(anakart);

            //Mediator'a colleague'ler bildiriliyor.
            anakart.CDDriver = cdDriver;
            anakart.CPU = cpu;
            anakart.EkranKarti = ekranKarti;
            anakart.SesKarti = sesKarti;

            cdDriver.CDOku();
        }
    }
}
