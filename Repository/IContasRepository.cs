using ExameApi.ViewModel;
using ExameApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExameApi.Repository
{
	public interface IContasRepository
	{
		Task<List<ContasViewModel>> GetAllByIdCliente(int Id);
		Task<ContasViewModel> Get(int Id);
		Task<int> Add(Conta model);
	}
}
