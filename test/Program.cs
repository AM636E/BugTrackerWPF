using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UI.Models;
using NLog;

namespace test
{
    class Program
    {
        public static Logger log;
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                log = LogManager.GetCurrentClassLogger();

                log.Trace("Version: {0}", Environment.Version.ToString());
                log.Trace("OS: {0}", Environment.OSVersion.ToString());
                log.Trace("Command: {0}", Environment.CommandLine.ToString());

                NLog.Targets.FileTarget tar = (NLog.Targets.FileTarget)LogManager.Configuration.FindTargetByName("run_log");
                tar.DeleteOldFileOnStartup = false;
                log.Trace("test message");

            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка работы с логом!\n" + e.Message);
            }

           
        }
    }
}
