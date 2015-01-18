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
        }
    }
}
