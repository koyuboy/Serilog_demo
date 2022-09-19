using Serilog.Context;
using Serilog.Core;
using Serilog.Events;

namespace Serilog_aspDotNetCore.CustomEnrichers
{
    public class UserNameEnricher: ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory pf)
        {
            var propertyName = "UserName";
            var propertyValue = "HUZEYFE";
            var newProperty = pf.CreateProperty(propertyName, propertyValue);
            logEvent.AddPropertyIfAbsent(newProperty);
        }
    }
}
