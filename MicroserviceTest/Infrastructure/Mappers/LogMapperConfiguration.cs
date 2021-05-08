using Entities;
using MicroserviceTest.Infrastructure.Mappers.Base;
using MicroserviceTest.ViewModels.LogViewModels;
using Calabonga.UnitOfWork;

namespace MicroserviceTest.Infrastructure.Mappers
{
    /// <summary>
    /// Mapper Configuration for entity Log
    /// </summary>
    public class LogMapperConfiguration: MapperConfigurationBase
    {
        /// <inheritdoc />
        public LogMapperConfiguration()
        {
            CreateMap<LogCreateViewModel, Log>()
                .ForMember(x=>x.Id, o=>o.Ignore());

            CreateMap<Log, LogViewModel>();

            CreateMap<IPagedList<Log>, IPagedList<LogViewModel>>()
                .ConvertUsing<PagedListConverter<Log, LogViewModel>>();
        }
    }
}
