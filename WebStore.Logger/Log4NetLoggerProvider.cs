using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace WebStore.Logger
{
    public class Log4NetLoggerProvider : ILoggerProvider
    {
        private readonly string _ConfigurationFile;
        private readonly ConcurrentDictionary<string,Log4NetLogger> _Loggers = new ();

        public Log4NetLoggerProvider(string ConfigurationFile)
        {
            _ConfigurationFile = ConfigurationFile;
        }
        public ILogger CreateLogger(string Category) =>
            _Loggers.GetOrAdd(Category, category =>
            {
                var xml = new XmlDocument();
                xml.Load(_ConfigurationFile);
                return new Log4NetLogger(category, xml["log4net"]);
            });

        public void Dispose() => _Loggers.Clear();
    }
}
