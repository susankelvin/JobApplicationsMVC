using System;
using System.Globalization;
using System.Threading;

namespace JobApplications.Web.Infrastructure
{
    using AutoMapper;
    using Database.Models;
    using Models.Applications;
    using Resolvers;

    public static class AutoMapperConfiguration
    {
        public static void Execute()
        {
            Mapper.CreateMap<ApplicationNewViewModel, Application>()
                .ForMember(a => a.OfferDate, opt => opt.ResolveUsing<StringToDateResolver>()
                    .FromMember(a => a.OfferDate));

            Mapper.CreateMap<Application, ApplicationTableViewModel>()
                .ForMember(a => a.ApplicationDate, opt => opt.ResolveUsing<DateTimeToLongDateStringResolver>()
                    .FromMember(a => a.ApplicationDate));
        }
    }
}
