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
        private object locker;

        public ABitRetardedFileReader(string filename, string baseDir, ILogger logger, ThreadControl threadControl)
        {
            _filename = filename;
            _baseDir = baseDir;
            _logger = logger;
            _threadControl = threadControl;
            locker = new object();
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
                object locker = _threadControl.GetThreadControlCallback(_filename);
                lock(locker)
                {
                    Task task = Task.Run(() => Task.Delay(2000).Wait());

                    _logger.LogDebug($"Start readind {_filename}...");
                    using (StreamReader sr = new StreamReader($"{_baseDir}Resourses\\{_filename}"))
                    {
                        result = sr.ReadToEnd();
                        sr.Close();
                    }
                    _logger.LogDebug($"End readind {_filename}!");

                    task.Wait();
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
