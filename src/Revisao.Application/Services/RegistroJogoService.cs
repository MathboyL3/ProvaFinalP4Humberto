using AutoMapper;
using Revisao.Application.Interfaces;
using Revisao.Application.ViewModels;
using Revisao.Domain.Entities;
using Revisao.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revisao.Application.Services
{
	public class RegistroJogoService : IRegistroJogoService
	{
		private readonly IRegistroJogoRepository _registroJogoRepository;
		private readonly IMapper _mapper;

		public RegistroJogoService(IRegistroJogoRepository registroJogoRepository, IMapper mapper)
		{
			_registroJogoRepository = registroJogoRepository;
			_mapper = mapper;
		}

		public async Task<IEnumerable<RegistroJogoViewModel>> ObterTodosOsJogos()
		{
			return _mapper.Map<IEnumerable<RegistroJogoViewModel>>(await _registroJogoRepository.ObterTodosOsJogos());

		}

		public async Task RegistrarJogo(RegistroJogoViewModel registroJogoViewModel)
		{
			//Criar reggra de negocio aqui para um jogo valido.

			await _registroJogoRepository.RegistrarJogo(_mapper.Map<RegistroJogo>(registroJogoViewModel));
		}
	}
}
