namespace JobApplications.Web.Infrastructure.Resolvers
{
    using System;
    using System.Globalization;
    using System.Threading;
    using AutoMapper;

    public class DateTimeToLongDateStringResolver : ValueResolver<DateTime, string>
    {
        protected override string ResolveCore(DateTime source)
        {
            string longDateFormat = Thread.CurrentThread.CurrentCulture.DateTimeFormat.LongDatePattern;
            string result = source.ToString(longDateFormat, CultureInfo.InvariantCulture);
            return result;
        }
    }
}
