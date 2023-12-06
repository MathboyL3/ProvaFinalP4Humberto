using AutoMapper;
using Revisao.Data.Mongo.Collection;
using Revisao.Domain.Entities;

namespace Revisao.Data.AutoMapper
{
    public class CollectionToDomain : Profile
    {
        public CollectionToDomain() {
            CreateMap<RegistroJogoCollection, RegistroJogo>();
        }
    }
}
