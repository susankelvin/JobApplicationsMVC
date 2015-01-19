namespace JobApplications.Web.Infrastructure.Resolvers
{
    using System;
    using System.Globalization;
    using System.Threading;
    using AutoMapper;

    public class DateTimeToLongDateStringResolver : ValueResolver<DateTime?, string>
    {
        protected override string ResolveCore(DateTime? source)
        {
            if (source != null)
            {
                string longDateFormat = Thread.CurrentThread.CurrentCulture.DateTimeFormat.LongDatePattern;
                string result = ((DateTime)source).ToString(longDateFormat, CultureInfo.InvariantCulture);
                return result;
            }

            return String.Empty;
        }
    }
}
