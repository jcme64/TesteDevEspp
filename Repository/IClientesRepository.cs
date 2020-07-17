using ExameApi.ViewModel;
using ExameApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExameApi.Repository
{
	public interface IClientesRepository
	{
		Task<List<ClientesViewModel>> GetAll();
		Task<ClientesViewModel> Get(int Id);
		Task<int> Add(Clientes model);
		Task<int> Delete(int Id);
		Task Update(Clientes model);
	}
}
