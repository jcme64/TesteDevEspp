using ExameApi.Models;
using ExameApi.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExameApi.Repository
{
	public class ContasRepository : IContasRepository
    {
        DatabaseContext db;
        public ContasRepository(DatabaseContext _db)
        {
            db = _db;
        }

        public async Task<List<ContasViewModel>> GetAllByIdCliente(int Id)
        {
            if (db != null)
            {
                return await (from a in db.Conta
                              join b in db.Clientes on a.IdCliente equals b.IdCliente
                              where b.IdCliente == Id
                              select new ContasViewModel
                              {
                                  IdCliente = a.IdCliente,
                                  IdConta = a.IdConta,
                                  NumeroConta = a.NumeroConta,
                                  CpfCnpj = b.CpfCnpj,
                                  NomeCliente = b.NomeCliente,
                                  TpCliente = b.TpCliente
                              }).ToListAsync();
            }

            return null;
        }

        public async Task<ContasViewModel> Get(int Id)
        {
            if (db != null)
            {
                return await (from a in db.Conta
                              join b in db.Clientes on a.IdCliente equals b.IdCliente
                              where a.IdConta == Id
                              select new ContasViewModel
                              {
                                  IdCliente = a.IdCliente,
                                  IdConta = a.IdConta,
                                  NumeroConta = a.NumeroConta,
                                  CpfCnpj = b.CpfCnpj,
                                  NomeCliente = b.NomeCliente,
                                  TpCliente = b.TpCliente,
                              }).FirstOrDefaultAsync();
            }

            return null;
        }

        public async Task<int> Add(Conta model)
        {
            if (db != null)
            {
                await db.Conta.AddAsync(model);
                await db.SaveChangesAsync();

                return model.IdConta;
            }

            return 0;
        }

    }
}
