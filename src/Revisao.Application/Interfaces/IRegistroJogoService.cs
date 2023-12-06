using Revisao.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revisao.Application.Interfaces
{
	public interface IRegistroJogoService
	{
		public Task RegistrarJogo(RegistroJogoViewModel registroJogoViewModel);

		public Task<IEnumerable<RegistroJogoViewModel>> ObterTodosOsJogos();
	}
}
