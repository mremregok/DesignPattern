using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.Singleton
{
    internal class WebGlobals
    {
        private static WebGlobals _instance;
        private static WebGlobals Instance= _instance?? (_instance= new WebGlobals())!;
        private WebGlobals() { }

        private string getWebRootPath() { return ""; }
        private string getAppPath() { return AppDomain.CurrentDomain.BaseDirectory; }   
        private string getAppName() { return typeof(WebGlobals).Assembly.GetName().Name; }

        public static string GetWebRootPath=> Instance.getWebRootPath();
        public static string GetAppPath=> Instance.getAppPath();    
        public static string GetAppName=> Instance.getAppName();

    }
}


public class SampleSingleton
{
    private static SampleSingleton _instance;
    public static SampleSingleton Instance = _instance ?? (_instance = new SampleSingleton());
    private SampleSingleton() { }
}