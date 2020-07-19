using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;

namespace BingIt
{
    class Program
    {
        public sealed class MyProcess
        {
            private void Launch(string browserName, string url, int waitAfterClick)
            {
                Process.Start(browserName + url);
                Thread.Sleep(waitAfterClick * 1000);
            }

            private static void TerminateMsEdge(string msEdgeProcessName)
            {
                foreach (Process Item in Process.GetProcessesByName(msEdgeProcessName))
                {
                    try
                    {
                        Item.Kill();
                        Item.WaitForExit(3000);
                    }
                    catch (Exception)
                    { }
                }
            }

            public void ClickAway(BingItConfig config)
            {
                TerminateMsEdge(config?.EdgeProcessName);
                foreach (var url in config?.Urls)
                    Launch(config?.EdgeName, url.Link, config.WaitAfterClick);
                TerminateMsEdge(config?.EdgeProcessName);
            }
        }

        static void Main()
        {
            new MyProcess().ClickAway(GetConfig());
        }

        private static BingItConfig GetConfig()
        {
            return (BingItConfig)new DataContractJsonSerializer(typeof(BingItConfig)).ReadObject(
                new MemoryStream(
                    Encoding.ASCII.GetBytes(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "Config.json"))));
        }
    }
}
