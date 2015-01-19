namespace JobApplications.Web.Infrastructure.Resolvers
{
    using System;
    using AutoMapper;

    /// <summary>
    /// AutoMapper resolver from DateTime? to ISO 8601 format string.
    /// </summary>
    public class DateTimeToIsoStringResolver : ValueResolver<DateTime?, string>
    {
        /// <summary>
        /// Convert DateTime to string in ISO 8601 format
        /// </summary>
        /// <param name="source">DateTime</param>
        /// <returns>String representation of DateTime or empty string, if <see cref="source"/> is null</returns>
        protected override string ResolveCore(DateTime? source)
        {
            if (source != null)
            {
                return source.Value.ToString("O");
            }

            return String.Empty;
        }
    }
}
