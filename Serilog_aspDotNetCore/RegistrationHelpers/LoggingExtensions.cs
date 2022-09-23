using Serilog;
using Serilog.Configuration;
using Serilog_aspDotNetCore.CustomEnrichers;

namespace Serilog_aspDotNetCore.RegistrationHelpers
{
    public static class LoggingExtensions
    {
        public static LoggerConfiguration WithAddDateTimeNow(
            this LoggerEnrichmentConfiguration enrich)
        {
            if (enrich == null)
                throw new ArgumentNullException(nameof(enrich));

            return enrich.With<AddDateTimeNowEnricher>().Enrich.With<UserNameEnricher>();

        }

        //public static LoggerConfiguration WithUserName(
        //    this LoggerEnrichmentConfiguration enrich)
        //{
        //    if (enrich == null)
        //        throw new ArgumentNullException(nameof(enrich));

        //    return enrich.With<UserNameEnricher>();

        //}
    }
}
