namespace JobApplications.Web.Infrastructure.Resolvers
{
    using System;
    using System.Globalization;
    using System.Threading;
    using AutoMapper;

    /// <summary>
    /// AutoMapper resolver from DateTime? to string in long date format.
    /// </summary>
    public class DateTimeToLongDateStringResolver : ValueResolver<DateTime?, string>
    {
        /// <summary>
        /// Convert DateTime? to string in long date format
        /// </summary>
        /// <param name="source">DateTime? to convert</param>
        /// <returns>String representation of <see cref="source"/> or null, if <see cref="source"/> is null</returns>
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
