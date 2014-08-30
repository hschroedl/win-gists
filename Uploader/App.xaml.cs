﻿using System;
using System.IO;
using System.Threading;
using System.Windows;
using Hardcodet.Wpf.TaskbarNotification;
using WinGistsConfiguration.Configuration;

namespace Uploader
{
    public partial class App : Application
    {
        private TaskbarIcon taskbarIcon;

        protected override void OnStartup(StartupEventArgs e){
            var icon = new UploaderIcon();

            String[] args = e.Args;
            if (IsValidInput(args)){
                String filepath = args[0];
                var executionConfiguration = new ExecutionConfiguration{
                    Filepath = filepath,
                    Configuration = ConfigurationManager.LoadConfigurationFromFile()
                };
                var executor = new Executor(executionConfiguration);
                executor.Execute();
            }
            icon.ShowStandardBaloon();
            Thread.Sleep(3000);
            Current.Shutdown();
        }


        private static Boolean IsValidInput(String[] args){
            if (args.Length != 1){
                Console.WriteLine(@"Error: Invalid number of arguments. Expected filepath.");
                return false;
            }
            if (!File.Exists(args[0])){
                Console.WriteLine("Error: File " + args + " does not exist.");
                return false;
            }
            return true;
        }

    }
}