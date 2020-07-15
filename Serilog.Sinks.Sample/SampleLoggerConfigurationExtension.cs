using Serilog.Configuration;
using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting;
using Serilog.Formatting.Display;
using Serilog.Sinks.Sample;
using System;
using System.Collections.Generic;
using System.Text;

namespace Serilog
{
    public static class SampleLoggerConfigurationExtension
    {
        const string DefaultOutputTemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}";

        public static LoggerConfiguration Sample(
            this LoggerSinkConfiguration loggerSinkConfiguration,
            string outputTemplate = DefaultOutputTemplate,
            IFormatProvider formatProvider = null)
        {
            if (loggerSinkConfiguration == null) throw new ArgumentNullException(nameof(loggerSinkConfiguration));
            if (outputTemplate == null) throw new ArgumentNullException(nameof(outputTemplate));

            var formatter = new MessageTemplateTextFormatter(outputTemplate, formatProvider);
            return Sample(loggerSinkConfiguration, formatter);
        }

        public static LoggerConfiguration Sample(
            this LoggerSinkConfiguration loggerSinkConfiguration,
            ITextFormatter formatter)
        {
            if (loggerSinkConfiguration == null) throw new ArgumentNullException(nameof(loggerSinkConfiguration));
            if (formatter == null) throw new ArgumentNullException(nameof(formatter));

            var sink = new SampleSink(formatter);

            return loggerSinkConfiguration.Sink(sink);
        }
    }
}
