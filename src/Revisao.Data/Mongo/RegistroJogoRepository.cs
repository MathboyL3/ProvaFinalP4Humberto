using AutoMapper;
using Revisao.Data.Interfaces;
using Revisao.Data.Mongo.Collection;
using Revisao.Domain.Entities;
using Revisao.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revisao.Data.Mongo
{
    public class RegistroJogoRepository : IRegistroJogoRepository
    {
        private readonly IMongoRepository<RegistroJogoCollection> _registroJogoRepository;
        private readonly IMapper _mapper;
        public RegistroJogoRepository(IMongoRepository<RegistroJogoCollection> registroJogoRepository, IMapper mapper) {
            _registroJogoRepository = registroJogoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RegistroJogo>> ObterTodosOsJogos()
        {
            var jogosCollection = _registroJogoRepository.FilterBy(x => true);
            return _mapper.Map<IEnumerable<RegistroJogo>>(jogosCollection);
        }

        public async Task RegistrarJogo(RegistroJogo registroJogo)
        {
            var mapped = _mapper.Map<RegistroJogoCollection>(registroJogo);
            await _registroJogoRepository.InsertOneAsync(mapped);
        }
    }
}
