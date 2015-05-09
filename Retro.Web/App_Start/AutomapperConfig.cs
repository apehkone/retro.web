using AutoMapper;
using Retro.Domain.Entities;
using Retro.Web.Models;

namespace Retro.Web
{
    public class AutomapperConfig
    {
        public static void Run() {
            Mapper.Initialize(x => x.AddProfile<DomainToViewModelMappingProfile>());
        }
    }


    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName { get { return "DomainToViewModelMappingProfile"; } }

        protected override void Configure() {
            Mapper.CreateMap<Retrospective, RetrospectiveModel>();
            Mapper.CreateMap<RetrospectiveItem, RetrospectiveItemModel>();
            Mapper.CreateMap<RetrospectiveItemCategory, RetrospectiveItemCategoryModel>();
        }
    }
}