using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Revisao.Application.Interfaces;
using Revisao.Application.ViewModels;

namespace Revisao.API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class JogoMegaSenaController : ControllerBase
	{

		private readonly IRegistroJogoService _registroJogoService;
		private readonly IMapper _mapper;

		public JogoMegaSenaController(IRegistroJogoService registroJogoService, IMapper mapper)
		{
			_registroJogoService = registroJogoService;
			_mapper = mapper;
		}

		[HttpGet(Name = "ObterTodosOsJogos")]
		public async Task<IActionResult> ObterTodosOsJogos()
		{
			return Ok(await _registroJogoService.ObterTodosOsJogos());
		}


		[HttpPost(Name = "RegistrarNovoJogo")]
		public async Task<IActionResult> RegistrarNovoJogo(RegistroJogoViewModel registroJogoViewModel)
		{
			await _registroJogoService.RegistrarJogo(registroJogoViewModel);
            return Ok("Registrado com sucesso!");
		}
	}
}
