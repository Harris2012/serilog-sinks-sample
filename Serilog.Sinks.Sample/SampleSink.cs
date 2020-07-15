using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting;
using System;

namespace Serilog.Sinks.Sample
{
    public class SampleSink : ILogEventSink
    {
        private ITextFormatter textFormatter;

        public SampleSink(ITextFormatter formatter)
        {
            this.textFormatter = formatter;
        }

        public void Emit(LogEvent logEvent)
        {
            //将输出流设置为控制台
            var output = Console.Out;

            textFormatter.Format(logEvent, output);
        }
    }
}
