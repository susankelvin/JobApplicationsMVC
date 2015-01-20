namespace JobApplications.Web.Infrastructure.Resolvers
{
    using System;
    using System.Globalization;
    using AutoMapper;

    /// <summary>
    /// AutoMapper resolver from ISO 8601 format date string to DateTime
    /// </summary>
    public class StringToDateResolver : ValueResolver<string, DateTime?>
    {
        /// <summary>
        /// Convert ISO 8601 date string to DateTime
        /// </summary>
        /// <param name="source">ISO 8601 date string</param>
        /// <returns>DateTime or null, if failed to parse</returns>
        protected override DateTime? ResolveCore(string source)
        {
            DateTime result;

            return DateTime.TryParse(source, CultureInfo.InvariantCulture, DateTimeStyles.None, out result) ? result as DateTime? : null;
        }
    }
}
