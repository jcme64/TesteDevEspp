using ExameApi.ViewModel;
using ExameApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExameApi.Repository
{
	public interface ILancamentosRepository
	{
		Task<List<LancamentosViewModel>> GetAllByIdConta(int Id);
		Task<int> Add(Lancamento model);
	}
}
