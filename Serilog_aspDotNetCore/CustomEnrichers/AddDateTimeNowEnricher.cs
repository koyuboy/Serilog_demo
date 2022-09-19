using Serilog.Context;
using Serilog.Core;
using Serilog.Events;

namespace Serilog_aspDotNetCore.CustomEnrichers
{
    public class AddDateTimeNowEnricher: ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory pf)
        {
            var propertyName = "DateTimeNow";
            var propertyValue = DateTime.Now;
            var newProperty = pf.CreateProperty(propertyName, propertyValue);
            logEvent.AddPropertyIfAbsent(newProperty);
        }
    }
}
