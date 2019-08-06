using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Service
{
    class LoggerService : ServiceBase
    {
        private string filename;
        private CancellationTokenSource _cts;

        public LoggerService(string filename)
        {
            this.filename = filename;
        }

        protected override void OnStart(string[] args)
        {
            
            _cts = new CancellationTokenSource();
            WriteLog("service started");
            Task.Factory.StartNew(() => InitService(), _cts.Token);
        }

        protected override void OnStop()
        {
            _cts.Cancel();
            WriteLog("service stopped");
        }

        private void WriteLog(string e)
        {
            File.AppendAllText(filename, $"{e} - {DateTime.Now}{Environment.NewLine}");
        }

        private async void InitService()
        {
            while (true)
            {
                await Process();
                _cts.Token.ThrowIfCancellationRequested();
                Thread.Sleep(2000);
            }
        }

        private async Task Process()
        {
            var tasks = Task.Factory.StartNew(() =>
                {
                    _cts.Token.ThrowIfCancellationRequested();
                    WriteLog("  => processing");
                });
            _cts.Token.ThrowIfCancellationRequested();
            await Task.WhenAll(tasks);
        }
    }
}
