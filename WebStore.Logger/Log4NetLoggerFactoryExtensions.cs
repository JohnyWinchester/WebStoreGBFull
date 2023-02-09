using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.Logger
{
    public static class Log4NetLoggerFactoryExtensions
    {
        private static string CheckFilePath(string filePath)
        {
            if (filePath is not { Length: > 0 })
                throw new ArgumentException("Не указан путь к файлу");

            if (Path.IsPathRooted(filePath))
                return filePath;

            var assembly = Assembly.GetEntryAssembly();
            var directory = Path.GetDirectoryName(assembly!.Location);

            return Path.Combine(directory!, filePath);
        }
        public static ILoggerFactory AddLog4Net(this ILoggerFactory Factory, string ConfigurationFile = "log4net.config")
        {
            Factory.AddProvider(new Log4NetLoggerProvider(CheckFilePath(ConfigurationFile)));

            return Factory;
        }
    }
}
