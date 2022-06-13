using System;
using Microsoft.AspNetCore.Hosting;

namespace Patron_test.Components
{
    public class ABitRetardedFileReader
    {
        private readonly string _filename;
        private readonly string _baseDir;
        private readonly ILogger _logger;
        private readonly ThreadControl _threadControl;

        public ABitRetardedFileReader(string filename, string baseDir, ILogger logger, ThreadControl threadControl)
        {
            _filename = filename;
            _baseDir = baseDir;
            _logger = logger;
            _threadControl = threadControl;
        }

        public static string StartAndCallback(string filename, string baseDir, ILogger logger, ThreadControl threadControl)
        {
            var fr = new ABitRetardedFileReader(filename, baseDir, logger, threadControl);
            return fr.GetValue();
        }

        private string GetValue()
        {
            string result = "";
            try
            {
                ThreadControlCallback tcc = _threadControl.GetThreadControlCallback(_filename);
                
                lock (tcc.Locker)
                {
                    if (!tcc.HasReaded)
                    {
                        Task task = Task.Delay(2000);
                        task.Start();

                        _logger.LogDebug($"Start readind {_filename}...");
                        using (StreamReader sr = new StreamReader($"{_baseDir}Resourses\\{_filename}"))
                        {
                            sr.ReadToEnd();
                            result = tcc.Value;
                        }
                        _logger.LogDebug($"End readind {_filename}!");

                        tcc.HasReaded = true;
                        task.Wait();
                    }
                    else
                    {
                        result = tcc.Value;
                    }
                }
               
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            return result;
        }
    }
}
