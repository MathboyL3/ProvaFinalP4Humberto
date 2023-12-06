using AutoMapper;
using Revisao.Application.ViewModels;
using Revisao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revisao.Application.AutoMapper
{
	public class ApplicationToDomain : Profile
	{
		public ApplicationToDomain()
		{

			CreateMap<RegistroJogoViewModel, RegistroJogo>()
			   .ConstructUsing(r => new RegistroJogo(r.primeiroNumero, r.segundoNumero, r.terceiroNumero, r.quartoNumero, r.quintoNumero, r.sextoNumero));

		}
	}
}
