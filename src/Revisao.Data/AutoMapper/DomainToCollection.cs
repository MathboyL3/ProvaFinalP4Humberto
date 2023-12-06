using AutoMapper;
using Revisao.Data.Mongo.Collection;
using Revisao.Domain.Entities;

namespace Revisao.Data.AutoMapper
{
    public class DomainToCollection : Profile
    {
        public DomainToCollection()
        {
            CreateMap<RegistroJogo, RegistroJogoCollection>();
        }
    }
}
