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

            Mapper.CreateMap<Application, ApplicationEditViewModel>()
                .ForMember(a => a.ApplicationDate, opt => opt.ResolveUsing<DateTimeToIsoStringResolver>()
                    .FromMember(a => a.ApplicationDate))
                .ForMember(a => a.OfferDate, opt => opt.ResolveUsing<DateTimeToIsoStringResolver>()
                    .FromMember(a => a.OfferDate));

            Mapper.CreateMap<ApplicationEditViewModel, Application>()
                .ForMember(a => a.ApplicationDate, opt => opt.ResolveUsing<StringToDateResolver>()
                    .FromMember(a => a.ApplicationDate))
                .ForMember(a => a.OfferDate, opt => opt.ResolveUsing<StringToDateResolver>()
                    .FromMember(a => a.OfferDate))
                .ForMember(a => a.ApplicationId, opt => opt.UseDestinationValue());

            Mapper.CreateMap<Application, ApplicationDetailsViewModel>()
                .ForMember(a => a.ApplicationDate, opt => opt.ResolveUsing<DateTimeToLongDateStringResolver>()
                    .FromMember(a => a.ApplicationDate))
                .ForMember(a => a.OfferDate, opt => opt.ResolveUsing<DateTimeToLongDateStringResolver>()
                    .FromMember(a => a.OfferDate));
        }
    }
}
